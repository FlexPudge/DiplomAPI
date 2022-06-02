using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace RoflanBobus
{
    public partial class Tour
    {
        public Tour()
        {
            Favorites = new HashSet<Favorite>();
            Vouchers = new HashSet<Voucher>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string TypeTour { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Duration { get; set; }
        public int? Complexity { get; set; }
        public int? MinimumAge { get; set; }
        public DateTime? Date { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
        public int? IdtourInfo { get; set; }
        public int? IdprogrammTour { get; set; }
        public int? IdlivingTour { get; set; }
        public virtual LivingTour IdlivingTourNavigation { get; set; }
        public virtual ProgrammTour IdprogrammTourNavigation { get; set; }
        public virtual InfoTour IdtourInfoNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
