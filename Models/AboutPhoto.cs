using System;
using System.Collections.Generic;

#nullable disable

namespace SmolenskTravelApi
{
    public partial class AboutPhoto
    {
        public int Id { get; set; }
        public int? IdTour { get; set; }
        public byte[] Photo { get; set; }

        public virtual Tour IdTourNavigation { get; set; }
    }
}
