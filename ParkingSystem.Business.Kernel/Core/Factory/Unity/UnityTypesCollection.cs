using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ParkingSystem.Business.Kernel.Core.Factory.Unity
{
    /// <summary>
    /// The collection class that will store the list of each element/item that
    ///        is returned back from the configuration manager.
    /// </summary>
    [ConfigurationCollection(typeof(UnityTypeElement), AddItemName = "Type")]
    public class UnityTypesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new UnityTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UnityTypeElement)(element)).TypeName;
        }
        public UnityTypeElement this[int idx]
        {
            get
            {
                return (UnityTypeElement)BaseGet(idx);
            }
        }
    }
}
