using System;
using System.Collections.Generic;

#nullable disable

namespace RoflanBobus
{
    public partial class OptionsTour
    {
        public int Id { get; set; }
        public int? Idtour { get; set; }
        public int? Idoptions { get; set; }

        public virtual Option IdoptionsNavigation { get; set; }
    }
}
