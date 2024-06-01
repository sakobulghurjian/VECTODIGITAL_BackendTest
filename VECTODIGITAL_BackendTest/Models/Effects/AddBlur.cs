namespace VECTODIGITAL_BackendTest.Models.Effects
{
    public class AddBlur : VectoPlugin
    {
        public override void Apply(VectoImage image)
        {
            var Blurpixelsize = this.EffectValue;

            // Apply Value
        }

        public override void Desecrate(VectoImage image)
        {
            var Blurpixelsize = this.EffectValue;
            // Remove Blur
        }
    }
}