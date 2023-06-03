﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Image { get; set; }

        public string NameSurname { get; set; }

        public string Gender { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
