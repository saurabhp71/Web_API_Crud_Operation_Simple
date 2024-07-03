using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Web_API_Crud_Operation_Simple.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public List<User> UsersList { get; set; }
        public List<SelectListItem> SelectList { get; set; }
        public SelectList CountryList { get; set; }
    }
}