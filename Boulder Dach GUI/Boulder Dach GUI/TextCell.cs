using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class TextCell : Cell
    {
        public override string path()
        {
            return (Convert.ToString(Value)+".png");
        }
        public TextCell(char value)
        {
            this.Value = value;
        }
    }
}
