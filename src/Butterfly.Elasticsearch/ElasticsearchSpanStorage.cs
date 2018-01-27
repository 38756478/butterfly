﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Butterfly.Common;
using Butterfly.DataContract.Tracing;
using Butterfly.Storage;
using Nest;

namespace Butterfly.Elasticsearch
{
    public class ElasticsearchSpanStorage : ISpanStorage
    {
        private readonly ElasticClient _elasticClient;
        private readonly IIndexManager _indexManager;

        public ElasticsearchSpanStorage(IElasticClientFactory elasticClientFactory, IIndexManager indexManager)
        {
            _elasticClient = elasticClientFactory?.Create() ?? throw new ArgumentNullException(nameof(elasticClientFactory));
            _indexManager = indexManager ?? throw new ArgumentNullException(nameof(indexManager));
        }

        public Task StoreAsync(IEnumerable<Span> spans, CancellationToken cancellationToken)
        {
            if (spans == null)
            {
                return TaskUtils.FailCompletedTask;
            }

            return BulkStore(spans, cancellationToken);
        }

        private Task BulkStore(IEnumerable<Span> spans, CancellationToken cancellationToken)
        {
            var bulkRequest = new BulkRequest {Operations = new List<IBulkOperation>()};

            foreach (var span in spans)
            {
                var operation = new BulkIndexOperation<Span>(span) {Index = _indexManager.CreateTracingIndex(DateTimeOffset.UtcNow)};
                bulkRequest.Operations.Add(operation);
            }

            return _elasticClient.BulkAsync(bulkRequest, cancellationToken);
        }
    }
}