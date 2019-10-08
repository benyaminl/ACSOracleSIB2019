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
            //Dictionary<string, Object> parameter = new Dictionary<string, Object> { };
            //parameter["usss"] = "%POS%";
            var data = Database.executeQuery("SELECT username, roles FROM userpos ");
            if (data.status == false)
            {
                MessageBox.Show(data.msg);
            } else
            {
                this.refreshData(data.data);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                MessageBox.Show("Klik! - " + dgvUser.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string query = "SELECT username, roles  FROM userpos WHERE username like :username";
            Dictionary<string, Object> parameter = new Dictionary<string, Object> { };
            parameter["username"] = "%"+textBox1.Text+"%";

            var data = Database.executeQuery(query, parameter);
            if (data.status == false)
            {
                MessageBox.Show(data.msg);
            }
            else
            {
                this.refreshData(data.data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTambahUser form = new FormTambahUser();
            form.ShowDialog();

            var data = Database.executeQuery("SELECT username, roles FROM userpos ");
            if (data.status == false)
            {
                MessageBox.Show(data.msg);
            }
            else
            {
                this.refreshData(data.data);
            }
        }

        private void refreshData(List<object[]> data = null)
        {
            dgvUser.Rows.Clear();
            if(data == null)
            {
                data = new List<object[]> { };
            }
            // Add to show on DGV
            foreach (Object[] d in data)
            {
                Object[] dd = new Object[d.Length + 1];
                d.CopyTo(dd, 0);
                dd[d.Length] = "Detail";
                dgvUser.Rows.Add(dd);
            }
        }
    }
}
