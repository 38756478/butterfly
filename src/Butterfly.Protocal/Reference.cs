﻿namespace Butterfly.Protocol
{
    public class SpanReference
    {
        public string Reference { get; set; }

        public string SpanId { get; set; }

        public string ParentId { get; set; }
    }
}