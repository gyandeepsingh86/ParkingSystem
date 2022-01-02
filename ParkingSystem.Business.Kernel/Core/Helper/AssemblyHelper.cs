using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ParkingSystem.Business.Kernel.Core.Helper
{
    class AssemblyHelper
    {
        public static IEnumerable<Assembly> GetAllAssemblies()
        {
            var callingAssembly = Assembly.GetCallingAssembly();
            return GetAllAssemblies(callingAssembly);
        }

        public static IEnumerable<Assembly> GetAllAssemblies(Assembly callingAssembly)
        {
            var assemblyNames = callingAssembly.GetReferencedAssemblies().ToList();

            var assemblies = assemblyNames.Where(a => a.FullName.StartsWith("Brain2.ANAB")).Select(Assembly.Load).Where(
                a => !a.Location.EndsWith("Tests.dll", StringComparison.OrdinalIgnoreCase)).ToList();

            var allAssemblies = new HashSet<Assembly>();
            foreach (var assembly in assemblies)
            {
                if (!allAssemblies.Any(x => x.Equals(assembly)))
                    allAssemblies.Add(assembly);
            }

            var currDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Brain2.ANAB")).Where(
                a => !a.Location.EndsWith("Tests.dll", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var assembly in currDomainAssemblies)
            {
                if (!allAssemblies.Any(x => x.Equals(assembly)))
                    allAssemblies.Add(assembly);
            }

            //try
            //{
            //    var currDomainAssemblies2 = BuildManager.DefaultBuildManager.GetProjectInstanceForBuild();
            //    if (currDomainAssemblies2 != null)
            //    {
            //        foreach (var assemblyObj in currDomainAssemblies2)
            //        {
            //            var assembly = assemblyObj as Assembly;
            //            if (assembly != null)
            //                if (assembly.FullName.StartsWith("Brain2.ANAB") && !assembly.Location.EndsWith("Tests.dll", StringComparison.OrdinalIgnoreCase))
            //                {
            //                    if (!allAssemblies.Any(x => x.Equals(assembly)))
            //                        allAssemblies.Add(assembly);
            //                }
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (Directory.Exists(path) && path.IndexOf("asp.net", StringComparison.OrdinalIgnoreCase) < 0)
                foreach (string dll in Directory.GetFiles(path, "Brain2.ANAB*.dll"))
                {
                    if (dll.IndexOf("Tests.dll", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        var assembly = Assembly.LoadFile(dll);
                        if (!allAssemblies.Any(x => x.Equals(assembly)))
                            allAssemblies.Add(assembly);
                    }
                }

            return allAssemblies;
        }
    }
}
