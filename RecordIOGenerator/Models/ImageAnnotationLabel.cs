using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordIOGenerator.Models
{
    /// <summary>
    /// The classes should be labeled with successive numbers and start with 0. 
    /// The bounding box coordinates are ratios of its top-left (xmin, ymin) and bottom-right (xmax, ymax) corner indices to the overall image size. 
    /// Note that the top-left corner of the entire image is the origin (0, 0).
    /// </summary>
    public class ImageAnnotationLabel
    {
        /// <summary>
        /// Image class index. Starts with 0.
        /// </summary>
        public int ClassIndex { get; set; }
        public float XMin { get; set; }
        public float YMin { get; set; }
        public float XMax { get; set; }
        public float YMax { get; set; }

    }
}
