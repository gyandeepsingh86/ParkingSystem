using ParkingSystem.Business.Interface.Core.Integration.Managers;
using ParkingSystem.Business.Kernel.Core.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Unity;
using Unity.Extension;

namespace ParkingSystem.Business.Kernel.Core.Factory.Unity
{
    class UnityContainerFactory
    {
        private static volatile IUnityContainer _instance;
        private static readonly object SyncRoot = new Object();

        /// <summary>
        /// Prevents a default instance of the <see cref="UnityContainerFactory"/> class from being created.
        /// </summary>
        private UnityContainerFactory() { }

        /// <summary>
        /// Gets the Unity Container instance.
        /// </summary>
        public static IUnityContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new UnityContainer();
                            var unityContainerExtensions = GetAllUnityContainerExtensions();
                            foreach (var extension in unityContainerExtensions)
                                _instance.AddExtension(extension);
                            AddManualTypeRegistrations(_instance);
                        }
                    }
                }

                return _instance;
            }
        }

        private static IList<UnityContainerExtension> GetAllUnityContainerExtensions()
        {
            List<UnityContainerExtension> objects = new List<UnityContainerExtension>();
            var allAssesmlies = AssemblyHelper.GetAllAssemblies();
            foreach (var assembly in allAssesmlies)
            {
                foreach (Type type in assembly.GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(UnityContainerExtension))))
                {
                    objects.Add((UnityContainerExtension)Activator.CreateInstance(type, null));
                }
            }
            return objects;
        }


        private static void AddManualTypeRegistrations(IUnityContainer container)
        {
            var section = ConfigurationManager.GetSection("UnityTypes") as UnityTypesConfigSection;
            if (section != null)
            {
                foreach (UnityTypeElement typeElement in section.Types)
                {
                    try
                    {
                        RegisterTypesWithContainer(_instance, typeElement.TypeName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the elements to container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="configFileName">Name of the config file.</param>
        private static void RegisterTypesWithContainer(IUnityContainer container, string typeName)
        {
            if (!string.IsNullOrWhiteSpace(typeName))
            {
                var type = Type.GetType(typeName);
                if (type != null)
                {
                    var instance = Activator.CreateInstance(type) as IRegisterWithUnityManager;
                    if (instance != null)
                        instance.RegisterTypes(container);
                }
            }
        }
    }
}
