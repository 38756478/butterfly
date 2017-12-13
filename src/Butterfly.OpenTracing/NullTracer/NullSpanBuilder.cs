﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.OpenTracing.NullTracer
{
    public class NullSpanBuilder : ISpanBuilder
    {
        public static readonly ISpanBuilder Instance = new NullSpanBuilder();

        public SpanReferenceCollection References { get; } = new SpanReferenceCollection();

        public string OperationName { get; }

        public DateTimeOffset? StartTimestamp { get; }

        public Baggage Baggage { get; } = new Baggage();

        public bool? Sampled { get; }
    }
}