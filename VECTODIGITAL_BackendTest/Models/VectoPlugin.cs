using VECTODIGITAL_BackendTest.Interface;

namespace VECTODIGITAL_BackendTest.Models
{
    public abstract class VectoPlugin : IImageEffect
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public int ImageID { get; set; }
        public string EffectName { get; set; }
        public string EffectValue { get; set; }

        public abstract void Apply(VectoImage image);
        public abstract void Desecrate(VectoImage image);
    }
}