﻿using System;

namespace Butterfly.DataContract.Tracing
{
    public class TraceHistogram
    {
        public DateTimeOffset Time { get; set; }

        public int Count { get; set; }
    }
}