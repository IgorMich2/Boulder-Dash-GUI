﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dach_GUI
{
    class RareDiamond : Diamond
    {
        public override char Value { get => '$'; }
        public override bool CanEnter()
        {
            return true;
        }
        public override void OnEnter()
        {
            GameField.AddScores(500);
        }

        public override string path()
        {
            return "rarediamond.jpg";
        }


    }
}
