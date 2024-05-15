﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_Peak : Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer_Peak class, calling base constructor with parameters "Peak" and 3
        /// </summary>
        public Recognizer_Peak() : base("Peak", 3) 
        {

        }

        /// <summary>
        /// Override Recognize method from the base class and Recognizes the pattern
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>A bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Checking if the index is within the range of the list LSCS
            if (index > 0 && index < LSCS.Count - 1)
            {
                // Retrieving SmartCandlestick object at the specified index
                SmartCandlestick SCS = LSCS[index];
                // Retrieving SmartCandlestick object at the next index
                SmartCandlestick SCSNext = LSCS[index + 1];
                // Retrieving SmartCandlestick object at the previous index
                SmartCandlestick SCSPrev = LSCS[index - 1];
                bool r = SCS.high > SCSPrev.high && SCS.high > SCSNext.high;
                // Check if the pattern already exists in the dictionary
                if (!SCS.candlestickpattern.ContainsKey(patternName))
                {
                    // Add patternName and boolean value to dictionary
                    SCS.candlestickpattern.Add(patternName, r);
                }
                return r;
            }
            else
            {
                return false;
            }
        }

    }
}
