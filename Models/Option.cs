using System;
using System.Collections.Generic;

#nullable disable

namespace RoflanBobus
{
    public partial class Option
    {
        public Option()
        {
            OptionsTours = new HashSet<OptionsTour>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }

        public virtual ICollection<OptionsTour> OptionsTours { get; set; }
    }
}
