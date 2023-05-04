﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalPrototype.Models
{
    public class SiteStructureViewModel
    {
        public int Id { get; set; }
        [DisplayName("Structure Name")]
        public string Name { get; set; }
        [DisplayName("Author")]
        public string by { get; set; }
        [DisplayName("Number of Acts")]
        public int Acts { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
