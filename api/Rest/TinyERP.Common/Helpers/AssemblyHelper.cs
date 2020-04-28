using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using TinyERP.Common.Enums;
using TinyERP.Common.Task;

namespace TinyERP.Common.Helpers
{
    public class AssemblyHelper
    {
        public static void Execute<IInterface>(ITaskArgument arg = null, bool runInOrder = true) where IInterface : ITask
        {
            IList<Type> types = AssemblyHelper.GetTypes<IInterface>();
            if (types.Count() == 0) { return; }
            if (runInOrder == true)
            {
                IList<IInterface> instances = new List<IInterface>();
                foreach (var type in types)
                {
                    instances.Add(AssemblyHelper.CreateInstance<IInterface>(type));
                }
                instances = instances.OrderByDescending(item => item.Priority).ToList();
                foreach (IInterface instance in instances)
                {
                    instance.Execute(arg);
                }
                return;
            }
            foreach (Type type in types)
            {
                ITask instance = AssemblyHelper.CreateInstance<ITask>(type);
                instance.Execute(arg);
            }
        }

        internal static IList<Type> GetInterfaces(object arg)
        {
            return arg.GetType().GetInterfaces().Where(item => item.FullName.StartsWith("TinyERP.")).ToList();
        }

        public static IType CreateInstance<IType>(Type type)
        {
            object result = Activator.CreateInstance(type, new object[] { });
            return (IType)result;
        }
        public static Type GetType<IType>()
        {
            return GetTypes<IType>().FirstOrDefault();
        }

        private static IList<Type> GetTypes<IInterface>()
        {
            IList<Type> result = new List<Type>();
            IList<string> dlls = AssemblyHelper.GetApplicationDlls();
            foreach (string dll in dlls)
            {
                IList<Type> types = Assembly.Load(dll).GetTypes()
                    .Where(item => typeof(IInterface).IsAssignableFrom(item) && !item.IsAbstract && item.IsClass)
                    .ToList();
                result = result.Concat(types).ToList();
            }
            return result;
        }
        private static IList<string> GetApplicationDlls()
        {
            IList<string> dlls = new List<string>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase).Replace("file:\\", string.Empty);
            dlls = Directory.GetFiles(path, "*.dll").Where(item => IsCustomeClass(item)).Select(file => Path.GetFileNameWithoutExtension(file)).ToList();
            return dlls;
        }
        private static bool IsCustomeClass(string itemName)
        {
            Regex regex = new Regex(ApplicationConts.RegexConts);
            Match match = regex.Match(Path.GetFileName(itemName));
            return match.Success;
        }
    }
}
