﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Butterfly.Flow;
using Butterfly.DataContract.Tracing;
using Butterfly.Server.Models;
using Butterfly.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Butterfly.Server.Controllers
{
    [Route("api/[controller]")]
    public class SpanController : Controller
    {
        private readonly ISpanProducer _spanProducer;
        private readonly ISpanQuery _spanQuery;
        private readonly IMapper _mapper;

        public SpanController(ISpanProducer spanProducer, ISpanQuery spanQuery, IMapper mapper)
        {
            _spanProducer = spanProducer;
            _spanQuery = spanQuery;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<SpanResponse[]> Get()
        {
            return _mapper.Map<IEnumerable<SpanResponse>>(await _spanQuery.GetSpans()).ToArray();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Span[] spans)
        {
            _spanProducer.PostAsync(spans, CancellationToken.None);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}