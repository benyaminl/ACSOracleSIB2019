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
    using Models;
    using Library;
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //String[] data = UserModel.get();
            //MessageBox.Show("Halo!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Pakai Data ValueName Tuple
            (bool status, string msg) hasil = Database.connect(txtUser.Text, txtPassword.Text);
            // Jika gagal maka 
            if (hasil.status == false)
            {
                MessageBox.Show(hasil.msg);
            }

            var form = new FormMasterUser();
            form.ShowDialog();
        }
    }
}
