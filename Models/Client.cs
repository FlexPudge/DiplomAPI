using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace RoflanBobus
{
    public partial class Client
    {
        public Client()
        {
            Favorites = new HashSet<Favorite>();
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        [JsonIgnore]
        public virtual ICollection<Favorite> Favorites { get; set; }
        [JsonIgnore]
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
