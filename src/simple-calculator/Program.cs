using System.Data.SQLite;

namespace simple_calculator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private const string myConnectionString = "Data Source=database.db";
        [STAThread]
        static void Main()
        {
            InitializeDatabase();
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new CalForm());

        }

        private static void InitializeDatabase()
        {
            string fileName = "database.db";

            // ������ݿ��ļ��Ƿ����
            if (!File.Exists(fileName))
            {
                // ��ʼ�����ݿ��ļ�
                File.Create(fileName).Dispose();
                using SQLiteConnection conn = new(myConnectionString);
                conn.Open();
                SQLiteCommand cmd = new();
                string iniStr = "CREATE TABLE history (results TEXT(50))";
                cmd = new SQLiteCommand(iniStr, conn);
                try { cmd.ExecuteNonQuery(); }

                catch (SQLiteException)
                {
                    MessageBox.Show("�޷���ʼ�����ݿ⣡");
                }
            }
        }
    }
}