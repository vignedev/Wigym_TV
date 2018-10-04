using System.Collections.Generic;

namespace TV.Models
{
    public class DisplayData
    {
        public List<Section> Sections { get; set; }
        public string FooterText { get; set; }
        public bool ShowNameDay { get; set; }
    }
}