﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Genre
    {
        public Genre()
        {
            Games = new List<Game>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Game> Games { get; set; }
    }
}
