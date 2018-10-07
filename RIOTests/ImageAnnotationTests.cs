using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordIOGenerator.Models;
using System;
using System.Drawing;
using System.IO;

namespace RecordIOGeneratorTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ImageAnnotationTests
    {

        const string dog1ImagePath = @"..\..\Images\2010_000152.jpg";

        [TestMethod]
        public void ImageAnnotationHasAllMandatoryPropertiesDefaults()
        {
            ImageAnnotaion testIA;
            using (Stream stream = File.OpenRead(dog1ImagePath))
            {
                using (Image sourceImage = Image.FromStream(stream, false, false))
                {
                    //Console.WriteLine(sourceImage.Width);
                    //Console.WriteLine(sourceImage.Height);
                    testIA = new ImageAnnotaion(dog1ImagePath);                    
                }
            }            
            Assert.IsFalse(String.IsNullOrEmpty(testIA.Path));
            Assert.AreEqual(2,testIA.HeaderSize);
            Assert.AreEqual(5, testIA.LabelWidth);

        }

        [TestMethod]
        public void ImageAnnotationLabelWidhtCanbeChanged()
        {
            var testIA = new ImageAnnotaion(dog1ImagePath,headerSize:2, labelWidth: 4);
            Assert.AreEqual(4, testIA.LabelWidth);
        }

        [TestMethod]
        public void ImageAnnotationHeaderSizeCanbeChanged()
        {
            var testIA = new ImageAnnotaion(dog1ImagePath, headerSize: 3);
            Assert.AreEqual(3, testIA.HeaderSize);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"ImmageAnnotationBox allows incorect bounding box")]
        public void ImageAnnotationLabelBoundingBoxAcceptsOnlyAllowedRange()
        {
            var imageLabel = new ImageAnnotationLabel();
            imageLabel.XMax = 4;
            imageLabel.YMax = 4;
            imageLabel.XMin = 4;
            imageLabel.YMin = 4;
        }
    }
}
