using FunctionalTestinngCore.Settings;
using FunctionalTestinngCore.Utils;
using FunctionalTestinngCore.Utils.Images;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.IO;

namespace FunctionalTestinngCore.Selenium
{
    public class Browser
    {
        private IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void NavigateTo(string url)
        {
            this._driver.Navigate().GoToUrl(url);
        }

        public void SetResolution(Size resolution)
        {
            if (this._driver.Manage().Window.Size != resolution)
                this._driver.Manage().Window.Size = resolution;
        }

        public void SaveScreen(string path)
        {
            OSUtils.CreatePath(path);
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);
        }

        public void ElementMatch(IWebElement element, string path, int timeout = 30, double tolerance = 1)
        {
            if (Wait.Until(() => this.ElementMatch(element, path, tolerance), timeout))
            {
                Console.WriteLine("Element match " + path);
            }
            else
            {
                Assert.Fail("Element does not match " + path);
            }
        }

        public void ScreenMatch(string path, int timeout = 30, double tolerance = 1)
        {
            if (Wait.Until(() => this.ScreenMatch(path, tolerance), timeout))
            {
                Console.WriteLine("Actual screen match " + path);
            }
            else
            {
                Assert.Fail("Page does not match " + path);
            }
        }

        private bool ElementMatch(IWebElement element, string expectedImagePath, double tolerance = 1)
        {
            var actualImage = this.GetScreenShot(element);
            return this.ImageMatch(actualImage, expectedImagePath, tolerance);
        }

        private bool ScreenMatch(string expectedImagePath, double tolerance = 1)
        {
            var actualImage = this.GetScreenShot();
            return this.ImageMatch(actualImage, expectedImagePath, tolerance);
        }

        private Bitmap GetScreenShot(IWebElement element = null)
        {
            Screenshot sc = ((ITakesScreenshot)this._driver).GetScreenshot();
            var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
            if (element == null)
            {
                return img;
            }
            else
            {
                return img.Clone(new Rectangle(element.Location, element.Size), img.PixelFormat);
            }
        }

        private bool ImageMatch(Bitmap actualImage, string expectedImagePath, double tolerance = 1)
        {
            // Get expected image
            if (File.Exists(expectedImagePath))
            {
                var expectedImage = new Bitmap(expectedImagePath);

                // Compare images
                var result = Images.Compare(actualImage, expectedImage);

                // Dispose images
                actualImage.Dispose();
                expectedImage.Dispose();

                // Return result
                if (result.Diff < tolerance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // Save actual image as expected if expected iamge do not exists (and return false).
                OSUtils.CreatePath(expectedImagePath);
                actualImage.Save(expectedImagePath);
                actualImage.Dispose();
                return false;
            }
        }
    }
}
