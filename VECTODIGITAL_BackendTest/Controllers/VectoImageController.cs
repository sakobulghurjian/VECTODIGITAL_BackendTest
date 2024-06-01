using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VECTODIGITAL_BackendTest.Configurations;
using VECTODIGITAL_BackendTest.Models;

namespace VECTODIGITAL_BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VectoImageController : ControllerBase
    {
        private readonly Configuration _confiugration;

        public VectoImageController()
        {
            _confiugration = new Configuration();
        }

        [HttpGet(Name = "GetImages")]
        public IEnumerable<VectoImage> Get()
        {
            return _confiugration.Images;
        }

        [HttpPost(Name = "ChangeImageEffects")]
        public void EditImageEffects(List<EditImagesVM> editImages)
        {
            foreach (EditImagesVM EditImage in editImages)
            {
                VectoImage imagefromDB = _confiugration.Images.Where(r => r.ID == EditImage.Image.ID).FirstOrDefault();
                if (imagefromDB == null)
                    continue;

                imagefromDB.Redius = EditImage.Image.Redius;
                imagefromDB.Size = EditImage.Image.Size;

                foreach (VectoPlugin plugin in EditImage.Plugins)
                {
                    VectoPlugin dbplugin = _confiugration.plugins.Where(r => r.ID == plugin.ID).FirstOrDefault();
                    if (dbplugin == null)
                    {
                        plugin.Active = true;
                        _confiugration.plugins.Add(plugin);
                    }

                    if (plugin.Active == true)
                    {
                        plugin.Apply(imagefromDB);
                    }
                }
            }
        }

        [HttpPost]
        public ActionResult<VectoPlugin> PostPlugin(VectoPlugin plugin)
        {
            VectoPlugin dbplugin = _confiugration.plugins.Where(r => r.ID == plugin.ID).FirstOrDefault();
            if (dbplugin == null)
            {
                plugin.Active = true;
                _confiugration.plugins.Add(plugin);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlugin(int id)
        {
            VectoPlugin plugin = _confiugration.plugins.Where(r => r.ID == id).FirstOrDefault();
            if (plugin == null)
            {
                return NotFound();
            }

            plugin.Active = false;

            var images = _confiugration.Images.Where(r => r.ID == plugin.ImageID);

            foreach (var image in images)
            {
                plugin.Desecrate(image);
            }

            return NoContent();
        }

    }
}