using System;
using System.Collections.Generic;
using System.Text;

namespace WPFEscapeRoom
{
    class Door
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; } = true;
        public Item Key { get; set; }

    }
}
