namespace HMS_SLS_Y4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public bool IsLoginSuccessful { get; private set; } = false;

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "admin" && password == "12345")
            {
                IsLoginSuccessful = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
