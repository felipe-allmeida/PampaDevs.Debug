using PampaDevs.Debug.Logger.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace PampaDevs.Debug.Logger
{
    sealed class LoggerData
    {
        public bool IsActive { get; set; }
        public ELoggerType LoggerType { get; set; }
        public ILoggerBuilder Builder { get; set; }
    }
}
