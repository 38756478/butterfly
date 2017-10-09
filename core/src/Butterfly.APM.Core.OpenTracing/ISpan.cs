﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Butterfly.APM.Core.OpenTracing
{
    public interface ISpan : IDisposable
    {
        ISpanContext SpanContext { get; }

        Baggage Baggage { get; }

        TagCollection Tags { get; }

        void Finish();
    }
}