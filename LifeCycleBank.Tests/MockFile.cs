﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LifeCycleBank.Tests
{
    class MockFile
    {
        public string[] GetMockFile()
        {
            string[] file = new string[] {
            "3",
            "1005; 559268 - 7528; Berglunds snabbköp; Berguvsvägen  8; Luleå; ; S - 958 22; Sweden; 0921 - 12 34 65",
            "1024; 556392 - 8406; Folk och fä HB; Åkergatan 24; Bräcke; ; S - 844 67; Sweden; 0695 - 34 67 21",
            "1032; 551553 - 1910; Great Lakes Food Market; 2732 Baker Blvd.; Eugene; OR; 97403; USA; (503) 555 - 7555",
            "5",
            "13019; 1005; 1488.80",
            "13020; 1005; 613.20",
            "13093; 1024; 695.62",
            "13128; 1032; 392.20",
            "13130; 1032; 4807.00"};

            return file;
        }
    }
}
