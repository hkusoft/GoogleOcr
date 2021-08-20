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
    public class UtilityTests
    {
        [TestMethod()]
        public void IsFileTypeTest()
        {            
            var output = Utility.IsFileType(null, ".pdf");
            Assert.IsFalse(output);

            output = Utility.IsFileType("abc.any", "");
            Assert.IsFalse(output);

            output = Utility.IsFileType("abc", ".pdf");
            Assert.IsFalse(output);
                        
            output = Utility.IsFileType("abc.pdf", ".pdf");
            Assert.IsTrue(output);

            output = Utility.IsFileType("abc.tif", ".pdf");
            Assert.IsFalse(output);

            output = Utility.IsFileType("abc.tif", ".tif");
            Assert.IsTrue(output);           

        }
    }
}