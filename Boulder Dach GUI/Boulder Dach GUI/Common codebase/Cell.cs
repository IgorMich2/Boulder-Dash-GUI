using System;
using System.Windows.Forms;
namespace Boulder_Dach_GUI
{
    abstract class Cell
    {
        public virtual char Value { get; set; }
        public virtual bool CanEnter()
        {
            return false;
        }
        public virtual void OnEnter() { }
        public virtual string path()
        {
            return "x";
        }

        public virtual void Teleportation(int y, int x)
        {
        }
    }
}
