﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranklinBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot Franklin = new Bot();
            Franklin.Connect(true);
            Console.ReadLine();
            Franklin.Disconnect();
        }
    }
}
