﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetRates.DAL.Models
{
    public class Platform 
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public string token_address { get; set; }

        public int Json_Ref_Id { get; set; }
    }
}
