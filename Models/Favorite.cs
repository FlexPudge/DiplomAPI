using System;
using System.Collections.Generic;

#nullable disable

namespace SmolenskTravelApi
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int? Idclient { get; set; }
        public int? Idtours { get; set; }

        public virtual Client IdclientNavigation { get; set; }
        public virtual Tour IdtoursNavigation { get; set; }
    }
}
