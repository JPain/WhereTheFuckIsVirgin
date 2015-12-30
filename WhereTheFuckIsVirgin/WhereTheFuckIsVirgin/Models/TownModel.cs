using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhereTheFuckIsVirgin.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Postcodes { get; set; }
    }
}