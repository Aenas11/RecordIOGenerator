using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordIOGenerator.Models
{
    public class ImageAnnotationsList
    {
        private IList<ImageAnnotaion> annotations;

        public IList<ImageAnnotaion> Annotations
        {
            get { return annotations; }
            set { annotations = value; }
        }

    }
}
