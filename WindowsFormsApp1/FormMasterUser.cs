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
                foreach(string[] d in data.data)
                {
                    dgvUser.Rows.Add(d);
                }
            }
            
        }
    }
}
