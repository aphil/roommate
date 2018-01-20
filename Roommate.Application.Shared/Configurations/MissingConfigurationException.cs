using System;
using System.Collections.Generic;
using System.Text;

namespace Roommate.Application.Shared.Configurations
{
    public class MissingConfigurationException : Exception
    {
        public MissingConfigurationException(string configurationName)
            : base($"Missing configuration named {configurationName}")
        {

        }
    }
}
