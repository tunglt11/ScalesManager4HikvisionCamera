using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScalesManager.Component
{
    public partial class ProtectedDataGridView : DevComponents.DotNetBar.Controls.DataGridViewX
    {
        private static object _locker = new object();
        protected override void OnPaint(PaintEventArgs e)
        {
            lock (_locker)
            {
                try
                {
                    base.OnPaint(e);
                }
                catch (Exception ex)
                {
                    //Console.Write(ex.StackTrace);
                }

            }
        }
    }
}
