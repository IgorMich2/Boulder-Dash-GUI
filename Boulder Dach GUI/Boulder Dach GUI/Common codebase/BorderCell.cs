using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulder_Dach_GUI
{
    class BorderCell : Cell
    {
        public override bool CanEnter()
        {
            return false;
        }

        public override string Path()
        {
            return "wall.jpg";
        }
        public BorderCell(char value)
        {
            this.Value = value;
        }
    }
}
