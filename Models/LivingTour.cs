using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SmolenskTravelApi
{
    public partial class LivingTour
    {
        public LivingTour()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
