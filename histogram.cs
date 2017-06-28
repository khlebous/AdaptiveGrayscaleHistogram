using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace histogram
{
    public partial class histogram : Form
    {
        Form1 _parent;
        public histogram(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            trackBarBottom.Value = parent.bottomValue;
            trackBarTop.Value = parent.topValue;
        }

        private void trackBarBottom_ValueChanged(object sender, EventArgs e)
        {
            _parent.bottomValue = trackBarBottom.Value;
            _parent.tsmi.PerformClick();
            Console.WriteLine($"bottom value changed {trackBarBottom.Value}");
        }
        
        private void trackBarTop_ValueChanged(object sender, EventArgs e)
        {
            _parent.topValue = trackBarTop.Value;
            _parent.tsmi.PerformClick();
            Console.WriteLine($"top value changed {trackBarTop.Value}");
        }
    }
}
