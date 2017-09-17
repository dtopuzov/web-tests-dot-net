using System.Drawing;

namespace FunctionalTestinngCore.Utils.Images
{
    class ImageComparisonResult
    {
        public double Diff { get; set; }
        public Bitmap DiffImage { get; set; }

        public ImageComparisonResult(double diff, Bitmap diffImage)
        {
            this.Diff = diff;
            this.DiffImage = diffImage;
        }
    }
}
