﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_DragonFlyDoji : Recognizer
    {
        /// <summary>
        /// A constructor for Recognize_DragonFlyDoji
        /// </summary>
        public Recognizer_DragonFlyDoji() : base("DragonFlyDoji", 1) 
        {

        }

        /// <summary>
        /// A method that recognizes smartcandlestick patterns 
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Retrieving SmartCandlestick object at the specified index
            SmartCandlestick SCS = LSCS[index];
            bool r = (SCS.bodyrange <= (SCS.range * 0.05m)) && SCS.uppertail <= ((8 / 100m) * SCS.range);
            // Check if the pattern already exists in the dictionary
            if (!SCS.candlestickpattern.ContainsKey(patternName))
            {
                // Add patternName and boolean value to dictionary
                SCS.candlestickpattern.Add(patternName, r);
            }
            return r;
        }

    }
}
