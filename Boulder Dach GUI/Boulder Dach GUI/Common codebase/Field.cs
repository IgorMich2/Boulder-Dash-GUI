using System.Collections.Generic;
using System.Media;
using System;
using System.Windows.Forms;

namespace Boulder_Dach_GUI
{
    class Field
    {
        public static List<List<Cell>> frame = new List<List<Cell>>();

        public static List<(int, int)> PortalCoordinates = new List<(int, int)>();

        static public SoundPlayer player = new SoundPlayer();
    }
}
