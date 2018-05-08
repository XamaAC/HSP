using System;
using System.Collections.Generic;

namespace HSP.Models
{
    public partial class DExpansionSets
    {
        public DExpansionSets()
        {
            DExpansions = new HashSet<DExpansions>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<DExpansions> DExpansions { get; set; }
    }
}
