﻿using System;

namespace Butterfly.APM.OpenTracing
{
    internal class SpanContext : ISpanContext
    {
        private readonly Baggage _baggage;

        public string TraceId { get; }

        public string SpanId { get; }

        public bool Sampled { get; }

        public Baggage Baggage { get; }

        public SpanContext(string traceId, string spanId, bool sampled, Baggage baggage)
        {
            TraceId = traceId;
            SpanId = spanId;
            Sampled = sampled;
            Baggage = baggage ?? throw new ArgumentNullException(nameof(baggage));
        }
    }
}