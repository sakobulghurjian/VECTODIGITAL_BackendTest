using VECTODIGITAL_BackendTest.Models;

namespace VECTODIGITAL_BackendTest.Configurations
{
    public class Configuration
    {
        public List<VectoPlugin> plugins;
        public List<VectoImage> Images;

        public Configuration()
        {
            plugins = GetPlugins();
            Images = GetImages();
        }
        private static List<VectoPlugin> GetPlugins()
        {
            return new List<VectoPlugin>();
        }

        private static List<VectoImage> GetImages()
        {
            return new List<VectoImage>();
        }
    }
}