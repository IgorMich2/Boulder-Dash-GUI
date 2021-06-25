using System;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Sand : Cell
    {
        public override char Value { get => '*'; }
        public override string Path()
        {
            return "sand.jpg";
        }
        public override bool CanEnter()
        {
            return true;
        }
    }
}
