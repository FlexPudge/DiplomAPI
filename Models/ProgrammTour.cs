using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace SmolenskTravelApi
{
    public partial class ProgrammTour
    {
        public ProgrammTour()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
        public string Day8 { get; set; }
        public string Day9 { get; set; }
        public string Day10 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
