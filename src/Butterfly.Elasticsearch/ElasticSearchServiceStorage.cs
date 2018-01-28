﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Butterfly.Common;
using Butterfly.DataContract.Tracing;
using Butterfly.Storage;
using Microsoft.Extensions.Caching.Memory;
using Nest;

namespace Butterfly.Elasticsearch
{
    internal class ElasticSearchServiceStorage : IServiceStorage
    {
        private readonly ElasticClient _elasticClient;
        private readonly IIndexManager _indexManager;
        private readonly IMemoryCache _memoryCache;

        public ElasticSearchServiceStorage(IElasticClientFactory elasticClientFactory, IIndexManager indexManager, IMemoryCache memoryCache)
        {
            _elasticClient = elasticClientFactory?.Create() ?? throw new ArgumentNullException(nameof(elasticClientFactory));
            _indexManager = indexManager ?? throw new ArgumentNullException(nameof(indexManager));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task StoreServiceAsync(IEnumerable<Service> services, CancellationToken cancellationToken)
        {
            if (services == null)
            {
                return;
            }

            foreach (var service in services)
            {
                await StorySingleServiceAsync(service, cancellationToken);
            }
        }

        private async Task StorySingleServiceAsync(Service service, CancellationToken cancellationToken)
        {
            var cacheKey = $"service-{service.Name}";
            if (_memoryCache.TryGetValue(cacheKey, out _))
            {
                return;
            }
            var index = _indexManager.CreateServiceIndex();
            var searchResponse = await _elasticClient.SearchAsync<Service>(s => s.Index(index).Query(q => q.Term(t => t.Field(f => f.Name).Value(service.Name))).Size(1));
            if (searchResponse.Documents.Count == 0)
            {
                await _elasticClient.IndexAsync(service, descriptor => descriptor.Index(index));
            }
            _memoryCache.Set(cacheKey, true, TimeSpan.FromMinutes(15));
        }
    }
}