using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

class Program // Консольное приложение для работы с БД на сервере MsSQL Managment Studio
{
    public static string connectionString = "Server=DESKTOP-BEC2GJ7\\SQLEXPRESS;Database=BDPS;Trusted_Connection=True;"; 
    public string FIO;
    
    public void insda()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
                Console.WriteLine("Введите имя клиента");
                FIO = Console.ReadLine().ToString();

                string SQLCout = "select COUNT(ID) from dbo.POW";
                SqlCommand SQLCOUNTc = new SqlCommand(SQLCout, connection);
                int count = (int)SQLCOUNTc.ExecuteScalar();

                string SqlQueryInsert = $"INSERT INTO POW(ID,FIO) VALUES ({count + 2},'{FIO}')";
                SqlCommand insertSqlCommand = new SqlCommand(SqlQueryInsert, connection);
                insertSqlCommand.ExecuteNonQuery();

                string sqlQuery = $"SELECT * FROM POW WHERE ID={count + 2}";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var column1 = reader["ID"];
                            var column2 = reader["FIO"];

                            Console.WriteLine($"Была добавлена в БД запись с id: {column1}, Текстом: {column2}");
                        }
                    }
                }
            }
        }
    }
class mn
{
    static void Main() // Если static, то не могу принимать
    {
        int check;
        Program pm = new Program();
        while (true)
            {
        Console.WriteLine("Добавить записи в БД? - 1 \nОбновить запись? - 2 \nУдалить запись? - 3");
        check = Convert.ToInt32(Console.ReadLine());

        switch (check)
        {
            case 1:
                pm.insda();
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
    }
}