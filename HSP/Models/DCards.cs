using System;
using System.Collections.Generic;

namespace HSP.Models
{
    public partial class DCards
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? IdHeroClass { get; set; }
        public int IdExpansion { get; set; }
        public int IdCardType { get; set; }
        public int IdCardClass { get; set; }
        public string ImgPath { get; set; }
        public string ImgGoldenPath { get; set; }
        public string ImgDeckPath { get; set; }

        public DExpansions IdExpansionNavigation { get; set; }
        public DHeroClasses IdHeroClassNavigation { get; set; }
    }
}
