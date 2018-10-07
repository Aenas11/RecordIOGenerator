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

        [TestMethod]
        public void ImageAnnotationLableSerialization()
        {
            string result = "11.0000\t0.2480\t0.0027\t0.9220\t0.8080\t";

            var imageLabel = new ImageAnnotationLabel();
            imageLabel.ClassIndex = 11;
            imageLabel.XMin = 0.248F;
            imageLabel.YMin = 0.0027F;
            imageLabel.XMax = 0.9220F;
            imageLabel.YMax = 0.8080F;

            var ImageAnnotationLabelSerialized = imageLabel.ToString();

            Assert.AreEqual(result,ImageAnnotationLabelSerialized);

        }

        [TestMethod]
        public void ImageAnnotationListSerialization()
        {
            string result = "44\t2\t5\t11.0000\t0.2480\t0.0027\t0.9220\t0.8080\t2010_000152.jpg";

            var imageLabel = new ImageAnnotationLabel();
            imageLabel.ClassIndex = 11;
            imageLabel.XMin = 0.248F;
            imageLabel.YMin = 0.0027F;
            imageLabel.XMax = 0.9220F;
            imageLabel.YMax = 0.8080F;

            var imageAnnotation = new ImageAnnotaion("2010_000152.jpg");
            imageAnnotation.ImageIndex = 44;

            imageAnnotation.ImageLabels = new System.Collections.Generic.List<ImageAnnotationLabel>();
            imageAnnotation.ImageLabels.Add(imageLabel);

            string ImageAnnotationSerialized = imageAnnotation.ToString();

            Assert.AreEqual(result, ImageAnnotationSerialized);

        }

    }
}
