using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ParkingSystem.Business.Kernel.Core.Factory.Unity
{
    class UnityTypesConfigSection : ConfigurationSection
    {
        /// <summary>
        /// The value of the property here "Folders" needs to match that of the config file section
        /// </summary>
        [ConfigurationProperty("Types")]
        public UnityTypesCollection Types
        {
            get { return ((UnityTypesCollection)(base["Types"])); }
        }
    }
}
