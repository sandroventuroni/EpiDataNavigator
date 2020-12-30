using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiDataNavigator
{
    public class GridLoaderRecord
    {
        public int columnOrder { get; set; }
        public string columnName { get; set; }
        public string dataType { get; set; }
        public int gridCol { get; set; }
        public Boolean isLink { get; set; }
        public Boolean isHidden { get; set; }
        public Boolean isMerge { get; set; }

    }
}
