using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    using Library;
    public partial class FormMasterUser : Form
    {
        public FormMasterUser()
        {
            InitializeComponent();
        }

        private void FormMasterUser_Load(object sender, EventArgs e)
        {
            Dictionary<string, Object> parameter = new Dictionary<string, Object> { };
            parameter["usss"] = "%POS%";
            var data = Database.executeQuery("SELECT user, user_id FROM DBA_USERS WHERE username like :usss",
                parameter);
            if (data.status == false)
            {
                MessageBox.Show(data.msg);
            } else
            {
                foreach(Object[] d in data.data)
                {
                    Object[] dd = new Object[d.Length + 1];
                    d.CopyTo(dd, 0);
                    dd[d.Length] = "Detail";
                    dgvUser.Rows.Add(dd);
                }
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                MessageBox.Show("Klik! - " + dgvUser.Rows[e.RowIndex].Cells[0].Value);
            }
        }
    }
}
