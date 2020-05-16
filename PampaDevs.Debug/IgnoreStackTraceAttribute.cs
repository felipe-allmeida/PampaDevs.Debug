using System;
using System.Collections.Generic;
using System.Text;

namespace PampaDevs.Debug
{
    [AttributeUsage(AttributeTargets.Method)]
    sealed class IgnoreStackTrace : Attribute
    {

    }
}
