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
            IsLoginSuccessful = true;
          
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
