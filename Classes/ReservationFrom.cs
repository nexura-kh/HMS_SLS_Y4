using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Classes
{
    public partial class ReservationFrom : Component
    {
        public class Resevation
        {

        }

        public ReservationFrom()
        {
            InitializeComponent();
        }

        public ReservationFrom(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
