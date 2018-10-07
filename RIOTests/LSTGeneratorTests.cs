using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecordIOGenerator.Models;
using System;
using System.Drawing;
using System.IO;
using RecordIOGenerator;
using System.Linq;
using System.Collections.Generic;

namespace RecordIOGeneratorTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class LSTGenerator
    {
        const string folderWithImagesPath = @"..\..\Images\";

        [TestMethod]        
        public void LSTGeneratorShould()
        {
            var annotationsList = new ImageAnnotationsList();
            annotationsList.Annotations = new List<ImageAnnotaion>();


            string[] sourceFiles = Directory.GetFiles(folderWithImagesPath, "*", SearchOption.AllDirectories);
            foreach (string file in sourceFiles)
            {
                using (Stream stream = File.OpenRead(file))
                {
                    using (Image sourceImage = Image.FromStream(stream, false, false))
                    {
                        ImageAnnotaion imageAnnotation = new ImageAnnotaion(file);
                        imageAnnotation.ImageLabels = new List<ImageAnnotationLabel>();
                        ImageAnnotationLabel item = new ImageAnnotationLabel();

                        imageAnnotation.ImageLabels.Add(item);
                        annotationsList.Annotations.Add(imageAnnotation);
                    }
                }
            }

            Assert.IsTrue(annotationsList.Annotations.ToList().Any());
            
        }
    }
}
