﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }

    }
}
