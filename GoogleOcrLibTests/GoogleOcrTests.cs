using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleOcrLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOcrLib.Tests
{
    [TestClass()]
    public class GoogleOcrTests
    {
        [TestMethod()]
        public void LoadPDFTest()
        {
            var text = GoogleOcr.Load("Samples/PDF/Abc.pdf");
            Assert.IsNotNull(text);
            Assert.IsTrue(text.Contains("Abc"));
            Assert.IsTrue(text.Contains("This is a text"));
        }

        [TestMethod()]
        public void LoadTifTest()
        {
            var text = GoogleOcr.Load("Samples/TIFF/Abc.tif");
            Assert.IsNotNull(text);
            Assert.IsTrue(text.Contains("Abc"));
            Assert.IsTrue(text.Contains("This is a text"));
        }

        [TestMethod()]
        public void LoadGifTest()
        {
            var text = GoogleOcr.Load("Samples/Gif/TestClass.gif");
            Assert.IsNotNull(text);
            Assert.IsTrue(text.Contains("TestClass"));
            Assert.IsTrue(text.Contains("GoogleOcrTests"));
        }
    }
}