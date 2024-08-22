using System.Data.SQLite;

namespace simple_calculator;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    public const string myConnectionString = "Data Source=database.db";
    
    [STAThread]
    static void Main()
    {
        InitializeDatabase();
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new CalForm());

    }

    /// <summary>
    /// 检查数据库文件是否存在，不存在则初始化
    /// </summary>
    private static void InitializeDatabase()
    {
        string fileName = "database.db";

        // 检查数据库文件是否存在
        if (!File.Exists(fileName))
        {
            // 初始化数据库文件
            File.Create(fileName).Dispose();
            using SQLiteConnection conn = new(myConnectionString);
            conn.Open();
            SQLiteCommand cmd = new();
            string iniStr = "CREATE TABLE history (id INTEGER PRIMARY KEY AUTOINCREMENT, results TEXT(50));";
            cmd = new SQLiteCommand(iniStr, conn);
            try { cmd.ExecuteNonQuery(); }

            catch (SQLiteException)
            {
                MessageBox.Show("无法初始化数据库！");
            }
        }
    }
}