using System;
using System.Collections.Generic;
using System.Text;

namespace WPFEscapeRoom
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsLocked { get; set; } = false;
        public Item Key { get; set; }
        public Item HiddenItem { get; set; }
        public bool IsPortable { get; set; }
        public Item(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        // Constructor met 3 parameters
        public Item(string name, string desc, bool isPort) : this(name, desc)
        {
            IsPortable = isPort;
            //Name = name;
            //Description = desc;

        }
        // overerving met ToString
        public override string ToString()
        {
            return Name;
        }
    }
}
