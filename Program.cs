namespace HMS_SLS_Y4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        //[STAThread]
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Login loginForm = new Login())
            {
                loginForm.ShowDialog();

                if (loginForm.IsLoginSuccessful)
                {
                    Application.Run(new Main());
                }
            }
        }

    }
}