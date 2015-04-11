using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace thatsmyareacode.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string AreaCode { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Zinger FavoriteZinger { get; set; }
        public List<Zinger> ZingerList { get; set; }
    }
}