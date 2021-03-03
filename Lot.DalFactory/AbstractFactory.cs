
using Lot.IDAL;
using System.Reflection;

namespace Lot.DalFactory
{
    public class AbstractFactory
    {
        //配置文件设置
        public static string AssemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];

        public static IUserDal GetCurrentUserDal()
        {
            string fullclassname = AssemblyName + ".UserDal";
            return (IUserDal)CreateInstace(fullclassname);
        }
        private static object CreateInstace(string classname)
        {
            var assembly = Assembly.Load(AssemblyName);//这里加载的是程序集名称 如DAL
            return assembly.CreateInstance(classname);//这里需要填写 命名空间.类名
        }
    }
}