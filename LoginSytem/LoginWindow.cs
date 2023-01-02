using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSytem
{
    public partial class LoginWindow : Form
    {
        private List<KeyValuePair<string, string>> Users;
        MainWindow loggedWindow;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Users = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Gabriel", "123"),
                new KeyValuePair<string, string>("Admin", "admin")
            };
            this.loggedWindow= new MainWindow();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (loginInput.Text == "" || passInput.Text == "")
                errorLabel.Text = "Error on login or password";

            bool logged = false;

            foreach (KeyValuePair<string,string> user in this.Users)
            {
                if (user.Key == loginInput.Text && user.Value == passInput.Text)
                {
                    logged= true;
                }
            }

            if (logged)
            {
                this.Hide();
                loggedWindow.ShowDialog();
                loggedWindow.StartPosition = FormStartPosition.CenterParent;
            }
            else
            {
                errorLabel.ForeColor = Color.Red;
                errorLabel.Text = "Error on login or password";
            }

        }

    
        private void cancelButton_Click(object sender, EventArgs e)
        {
            loginInput.Text = "";
            passInput.Text = "";
            this.Close();
        }
    }
}
