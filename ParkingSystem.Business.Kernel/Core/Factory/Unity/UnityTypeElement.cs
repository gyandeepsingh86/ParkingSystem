using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ParkingSystem.Business.Kernel.Core.Factory.Unity
{
    /// <summary>
    /// The class that holds onto each element returned by the configuration manager.
    /// </summary>
    public class UnityTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("typeName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string TypeName
        {
            get
            {
                return ((string)(base["typeName"]));
            }
            set
            {
                base["typeName"] = value;
            }
        }

    }
}
