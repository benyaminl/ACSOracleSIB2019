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
    public partial class FormTambahUser : Form
    {
        public FormTambahUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO userpos VALUES (:username,:nama, " +
                ":passwordnya, :roles)";
            Dictionary<string, object> data = new Dictionary<string, object> { };
            data.Add("username", txtUser.Text);
            data.Add("passwordnya", txtPass.Text);
            data.Add("nama", txtNama.Text);
            data.Add("roles", 1);
            (bool status, string msg) result = Database.executeNonQuery(query, data);

            if (result.status)
            {
                MessageBox.Show("Data masuk berhasil","Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else
            {
                MessageBox.Show(result.msg);
            }
        }
    }
}
