using System;
using System.Collections.Generic;

namespace HSP.Models
{
    public partial class DExpansions
    {
        public DExpansions()
        {
            DCards = new HashSet<DCards>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int IdExpansionSet { get; set; }

        public DExpansionSets IdExpansionSetNavigation { get; set; }
        public ICollection<DCards> DCards { get; set; }
    }
}
