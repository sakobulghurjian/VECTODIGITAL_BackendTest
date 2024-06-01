using VECTODIGITAL_BackendTest.Models;

namespace VECTODIGITAL_BackendTest.Interface
{
    public interface IImageEffect
    {
        void Apply(VectoImage image);
        void Desecrate(VectoImage image);
    }
}