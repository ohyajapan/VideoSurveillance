using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoSurveillance
{
    public struct Motion
    {
        public float Level { get; }
        public DateTime DateTime { get; }

        public Motion(float level, DateTime dateTime)
        {
            Level = level;
            DateTime = dateTime;
        }
    }
}
