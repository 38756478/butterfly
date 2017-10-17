﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Butterfly.APM.Core.Server
{
    public interface IServerHost
    {
        Task Run(CancellationToken cancellationToken);
    }
}
