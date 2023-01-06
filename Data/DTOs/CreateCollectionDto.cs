﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enums;

namespace Data.DTOs
{
    public class CreateCollectionDto
    {
        public EntityType Type { get; set; }
        public string Name { get; set; }
    }
}
