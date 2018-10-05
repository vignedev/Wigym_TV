﻿using System.Collections.Generic;

namespace TV.Models
{
    public class Section
    {
        public Section()
        {
            DisplayObjects = new List<IDisplayObject>();
        }

        public Position Position { get; set; }
        public List<IDisplayObject> DisplayObjects { get; set; }
        public int Interval { get; set; }
        public bool ShouldSwitchImages => DisplayObjects.Count > 1;
    }
}