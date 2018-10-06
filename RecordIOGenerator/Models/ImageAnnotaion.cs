using RecordIOGenerator.Models;
using System.Collections.Generic;

namespace RecordIOGenerator.Models
{
    public class ImageAnnotaion
    {
        /// <summary>
        /// Unique image index
        /// </summary>
        public int ImageIndex { get; set; }
        /// <summary>
        /// Header size of the current row
        /// </summary>
        public int HeaderSize { get { return 2; } }
        public int LabelWidth { get { return 5; } }
        /// <summary>
        /// List of labels
        /// </summary>
        public IList<ImageAnnotationLabel> ImageLabels { get; set; }

        /// <summary>
        /// Relative path of the image file
        /// </summary>
        public string Path { get; set; }
    }
}