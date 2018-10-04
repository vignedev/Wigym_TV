using System.Collections.Generic;

namespace TV.Models
{
    public class Section
    {
        public Position Position { get; set; }
        public List<Image> Images { get; set; }
        public int Interval { get; set; }
        public bool ShouldSwitchImages => Images.Count > 1;
    }
}