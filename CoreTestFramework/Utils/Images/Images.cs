using System;
using System.Drawing;

namespace FunctionalTestinngCore.Utils.Images
{
    class Images
    {
        public static ImageComparisonResult Compare(Bitmap actualImage, Bitmap expectedImage, int rgbSimilarityTolerance = 10)
        {
            int width = Math.Min(actualImage.Width, expectedImage.Width);
            int height = Math.Min(actualImage.Height, expectedImage.Height);

            int diferentPixels = 0;
            int similarPixels = 0;
            int totalPixels = width * height;

            Bitmap diffImage = new Bitmap(width, height);
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    Color actualPixel = actualImage.GetPixel(i, j);
                    Color expectedPixel = expectedImage.GetPixel(i, j);

                    if (actualPixel != expectedPixel)
                    {
                        if ((Math.Abs(actualPixel.A - expectedPixel.A) < rgbSimilarityTolerance)
                            && (Math.Abs(actualPixel.B - expectedPixel.B) < rgbSimilarityTolerance)
                            && (Math.Abs(actualPixel.G - expectedPixel.G) < rgbSimilarityTolerance)
                            && (Math.Abs(actualPixel.R - expectedPixel.R) < rgbSimilarityTolerance))
                        {
                            similarPixels++;
                            diffImage.SetPixel(i, j, Color.Orange);
                        }
                        else
                        {
                            diferentPixels++;
                            diffImage.SetPixel(i, j, Color.Red);
                        }
                    }
                    else
                    {
                        diffImage.SetPixel(i, j, actualPixel);
                    }
                }
            }

            double diff = ((double)diferentPixels / (double)totalPixels) * 100;
            double similar = ((double)similarPixels / (double)totalPixels) * 100;

            var result = new ImageComparisonResult(diff, diffImage);

            actualImage.Dispose();
            expectedImage.Dispose();
            diffImage.Dispose();

            return result;
        }
    }
}
