using System;
using System.Collections.Generic;
using System.Text;

namespace DevexpresDashboard.Models
{
    public class IndexInfo
    {
        public string TableName { get; set; }
        public string IndexName { get; set; }
        public int IndexID { get; set; }
        public string IndexType { get; set; }
        public float Fragmantation { get; set; }
        public float UsedSpace { get; set; }
    }
}
