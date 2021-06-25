using System;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    class Diamond : Cell
    {
        public override char Value { get => '@'; }
        public override bool CanEnter()
        {
            return true;
        }
        public override void OnEnter()
        {
            GameField.AddScores(100);
        }

        public override string Path()
        {
            return "diamond.jpg";
        }
    }
}
