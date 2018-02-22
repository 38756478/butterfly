﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Butterfly.DataContract.Tracing;
using Butterfly.Consumer;
using Butterfly.Server.ViewModels;
using Butterfly.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Butterfly.Server.Controllers
{
    [Route("api/[controller]")]
    public class SpanDetailController : Controller
    {

        private readonly ISpanQuery _spanQuery;
        private readonly IMapper _mapper;

        public SpanDetailController(ISpanProducer spanProducer, ISpanQuery spanQuery, IMapper mapper)
        {
            _spanQuery = spanQuery;
            _mapper = mapper;
        }

        [HttpGet("{spanId}")]
        public async Task<SpanDetailViewModel> Get([FromRoute] string spanId)
        {
            var span = _mapper.Map<SpanDetailViewModel>(await _spanQuery.GetSpan(spanId));
            span.Logs = span.Logs.OrderBy(x => x.Timestamp).ToList();
            return span;
        }
    }
}