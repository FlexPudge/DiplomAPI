using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace RoflanBobus
{
    public partial class InfoTour
    {
        public InfoTour()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string GeneralInformation { get; set; }
        public string HotInformation { get; set; }
        public string AdditionalInformation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
