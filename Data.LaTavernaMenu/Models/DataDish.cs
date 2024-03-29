﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.LaTavernaMenu.Models
{
    public class DataDish
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public bool IsNew { get; set; }

        public bool IsAPorzione { get; set; } // indica se è all'etto o a porzione

        public Guid SectionId { get; set; }

        public DataSection Section { get; set; }

    }
}
