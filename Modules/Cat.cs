﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagochi.Interfaces;

namespace Tamagochi.Modules
{
    class Cat : ICat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Health { get; set; }
        public int Mood { get; set; }
        public int Satiety { get; set; }
        public int Level { get; set; }
    }
}
