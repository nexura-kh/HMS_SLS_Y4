using HMS_SLS_Y4.Seeders;

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

            SeedRoom seedRoom = new SeedRoom();
            SeedFood seedFood = new SeedFood();
            SeedReservation seedReservation = new SeedReservation();
            SeedOrder seedOrder = new SeedOrder();

            seedRoom.SeedRoomTypes();
            seedRoom.SeedRooms();

            seedReservation.SeedUsers();
            seedReservation.SeedCustomers();
            seedReservation.SeedReservations();

            seedFood.SeedFoods();
            seedOrder.SeedOrders();

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