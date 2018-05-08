using System;
using System.Collections.Generic;

namespace HSP.Models
{
    public partial class DHeroClasses
    {
        public DHeroClasses()
        {
            DCards = new HashSet<DCards>();
            DHeroClassSkins = new HashSet<DHeroClassSkins>();
        }

        public int Id { get; set; }
        public string ClassName { get; set; }
        public int? IdHeroClassDefaultSkin { get; set; }

        public DHeroClassSkins IdHeroClassDefaultSkinNavigation { get; set; }
        public ICollection<DCards> DCards { get; set; }
        public ICollection<DHeroClassSkins> DHeroClassSkins { get; set; }
    }
}
