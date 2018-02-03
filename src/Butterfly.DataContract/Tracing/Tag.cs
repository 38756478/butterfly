﻿using MessagePack;

namespace Butterfly.DataContract.Tracing
{
    [MessagePackObject]
    public class Tag
    {
        [Key(0)]
        public string Key { get; set; }

        [Key(1)]
        public string Value { get; set; }
    }
}