using System;

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


        private float xMin;
        /// <summary>
        /// Range: 0.0 - 1.0
        /// </summary>
        public float XMin
        {
            get { return xMin; }
            set {

                if(0<=value && value <=1.0)
                {
                    xMin = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("XMin","Ration should be more than 0 and less then 1");
                }
            }
        }

        private float yMin;
        /// <summary>
        /// Range: 0.0 - 1.0
        /// </summary>
        public float YMin
        {
            get { return yMin; }
            set
            {

                if (0 <= value && value <= 1.0)
                {
                    yMin = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("YMin", "Ration should be more than 0 and less then 1");
                }
            }
        }

        private float xMax;
        /// <summary>
        /// Range: 0.0 - 1.0
        /// </summary>
        public float XMax
        {
            get { return xMax; }
            set
            {

                if (0 <= value && value <= 1.0)
                {
                    xMax = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("XMax", "Ration should be more than 0 and less then 1");
                }
            }
        }

        private float yMax;
        /// <summary>
        /// Range: 0.0 - 1.0
        /// </summary>
        public float YMax
        {
            get { return yMax; }
            set
            {

                if (0 <= value && value <= 1.0)
                {
                    yMax = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("YMax", "Ration should be more than 0 and less then 1");
                }
            }
        }

    }
}
