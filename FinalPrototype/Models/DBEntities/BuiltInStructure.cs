﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalPrototype.Models.DBEntities
{
    public class BuiltInStructure
    {
        public class SiteStructure
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string Name { get; set; }

            public string by { get; set; }

            public int Acts { get; set; }
            public string Description { get; set; }
        }
    }
}
