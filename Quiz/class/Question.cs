﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{

    internal class Question
    {
        public string question { get; set; }
        public Dictionary<string, bool> choices {get;set;}
    }
}
