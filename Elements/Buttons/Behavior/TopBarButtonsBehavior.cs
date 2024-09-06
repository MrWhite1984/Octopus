using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus.Elements.Buttons.Behavior
{
    class TopBarButtonsBehavior
    {
        public static void OnMouseEnterBehavior(Panel panel, Label label)
        {
            panel.BackColor = Color.LightGray;
            label.ForeColor = Color.Black;
        }
        public static void OnMouseLeaveBehavior(Panel panel, Label label)
        {
            panel.BackColor= Color.DimGray;
            label.ForeColor= Color.White;
        }
    }
}
