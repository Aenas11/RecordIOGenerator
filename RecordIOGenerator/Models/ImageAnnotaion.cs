using System.Collections.Generic;
using System.Text;

namespace RecordIOGenerator.Models
{
    public class ImageAnnotaion
    {

        private string imagePath;
        /// <summary>
        /// Relative path of the image file
        /// </summary>
        public string Path
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
        /// <summary>
        /// Unique image index
        /// </summary>
        public int ImageIndex { get; set; }

        private int headerSize;
        /// <summary>
        /// Header size of the current row
        /// </summary>
        public int HeaderSize
        {
            get { return headerSize; }
            set { headerSize = value; }
        }


        private int labelWidht;
        /// <summary>
        /// Default value 5. 
        /// 5 means each object within an image will have 5 numbers to describe its label information,
        /// including class index, and bounding box coordinates
        /// </summary>
        public int LabelWidth
        {
            get { return labelWidht; }
            set { labelWidht = value; }
        }

        /// <summary>
        /// List of labels
        /// </summary>
        public IList<ImageAnnotationLabel> ImageLabels { get; set; }


        public ImageAnnotaion(string path, int headerSize = 2, int labelWidth = 5)
        {

            this.imagePath = path;
            this.headerSize = headerSize;
            this.labelWidht = labelWidth;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(this.ImageIndex);
            stringBuilder.Append("\t");
            stringBuilder.Append(this.HeaderSize);
            stringBuilder.Append("\t");
            stringBuilder.Append(this.LabelWidth);
            stringBuilder.Append("\t");

            foreach (var label in this.ImageLabels)
            {
                stringBuilder.Append(label);
            }

            stringBuilder.Append(this.Path);

            return stringBuilder.ToString();
        }
    }
}