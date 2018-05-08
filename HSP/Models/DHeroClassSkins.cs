using System;
using System.Collections.Generic;

namespace HSP.Models
{
    public partial class DHeroClassSkins
    {
        public DHeroClassSkins()
        {
            DHeroClasses = new HashSet<DHeroClasses>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int IdHeroClass { get; set; }
        public string ImgPath { get; set; }

        public DHeroClasses IdHeroClassNavigation { get; set; }
        public ICollection<DHeroClasses> DHeroClasses { get; set; }
    }
}
