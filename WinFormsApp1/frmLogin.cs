using FStoreAppLibrary.Data_Layer.Repository;
using FStoreAppLibrary.Models;
using System.Text.Json;

namespace WinFormsApp1
{

    public partial class frmLogin
    {
        IMemberRepository memberRepository = new MemberRepository();
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {


            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string jsonString = File.ReadAllText("appsettings.json");
            Member admin = JsonSerializer.Deserialize<Member>(jsonString)!;

            if (email == String.Empty || email == "")
            {
                MessageBox.Show("Please input username!");
            }
            else if (password == "")
            {
                MessageBox.Show("Please input Password");
            }
            else
            {
                var member= ((MemberRepository)memberRepository).GetMembers()
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefault();
                if (member is not null)
                {
                    this.Hide();
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }
        }
            

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnExit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CancelButton = this.btnExit;
            this.AcceptButton = this.btnLogin;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
