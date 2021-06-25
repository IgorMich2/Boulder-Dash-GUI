using System;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Empty : Cell
    {
        public override char Value { get => ' '; }

        public override bool CanEnter()
        {
            return true;
        }

        public override string Path()
        {
            return "empty.jpg";
        }
    }
}
