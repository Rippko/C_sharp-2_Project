using Dapper;
using Microsoft.Data.Sqlite;

namespace Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //database connection
            string connection_string = "Data Source=mydb.db;";
            using SqliteConnection connection = new SqliteConnection(connection_string);
            connection.Open();

            //dva zpusoby commandu
            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = File.ReadAllText("database-create.sql");
            //command.ExecuteNonQuery();

            //SqliteCommand command2 = new SqliteCommand();
            //command2.Connection = connection;

            //using SqliteCommand insert_cmd = connection.CreateCommand();
            //insert_cmd.CommandText = "INSERT INTO Customer (Name, Address) VALUES (@Name, @Address)";
            //insert_cmd.Parameters.AddWithValue("@Name", "Katka");
            //insert_cmd.Parameters.AddWithValue("@Address", DBNull.Value);
            //// nechci číst výsledek dotazu
            ////insert_cmd.ExecuteNonQuery();

            //using SqliteCommand count_cmd = connection.CreateCommand();
            //count_cmd.CommandText = "SELECT COUNT(*) FROM Customer";
            //long count = (long)count_cmd.ExecuteScalar();
            //Console.WriteLine(count);

            //using SqliteCommand select_all = connection.CreateCommand();
            //select_all.CommandText = "SELECT Id, Name, Address FROM Customer";

            //using SqliteDataReader reader = select_all.ExecuteReader();
            //while(reader.Read())
            //{
            //    int id = reader.GetInt32(reader.GetOrdinal("Id"));
            //    string name = reader.GetString(reader.GetOrdinal("Name"));
            //    string? address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"));

            //    Console.WriteLine($"ID: {id} | {name} | {address}");
            //}

            //using SqliteTransaction transaction = connection.BeginTransaction();

            //for (int i = 0; i < 5; i++)
            //{
            //    using SqliteCommand cmd = connection.CreateCommand();
            //    cmd.Transaction = transaction;
            //    cmd.CommandText = @"INSERT INTO [Order] (CustomerId, Product, Price) VALUES (1, @CustomerId, @Product, @Price)";
            //    cmd.Parameters.AddWithValue("CustomerId", 1);
            //    cmd.Parameters.AddWithValue("Product", "Auto" + i);
            //    cmd.Parameters.AddWithValue("Price", i * 10000);
            //    //cmd.ExecuteNonQuery();
            //}
            ////transaction.Commit();

            //using SqliteCommand saved_method = connection.CreateCommand();
            //saved_method.CommandType = System.Data.CommandType.StoredProcedure;
            //saved_method.CommandText = "NázevProcedury()";
            //saved_method.ExecuteNonQuery();

            //connection.Execute("INSERT INTO Customer (Name, Address) VALUES (@Name, @Address)", new { Name = "Tonda", Address = "Znojmo"});

            long count = connection.ExecuteScalar<long>("SELECT COUNT(*) FROM Customer");

            Console.WriteLine(count);


            IEnumerable<Customer> customers = connection.Query<Customer>("SELECT * FROM Customer");

            foreach (Customer c in customers)
            {
                Console.WriteLine(c.Id + " " + c.Name + " " + c.Address);
            }

            //connection.Insert();
            //connection.Update();
            //connection.Delete();
            //connection.Get();
            //connection.GetList();

            //důležité zapnout toto nastavení ihned na začátku
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.SQLite);

            int ? id = connection.Insert(new Customer()
            {
                Name = "Zuzana",
                Address = "Beroun"
            });


            Customer customer = connection.Get<Customer>(1);
            customer.Name = customer.Name.ToUpper();
            connection.Update(customer);

            connection.Delete(customer);

            using SqliteTransaction tr2 = connection.BeginTransaction();
            try
            {
                
                int? id_c = connection.Insert<Customer>(new Customer
                {
                    Name = "Roman",
                    Address = "Olomouc"
                }, tr2);

                for (int i = 0; i < 3; i++)
                {
                    connection.Execute(@"INSER INTO [Order] (CustomerId, Product, Price) VALUES (@CustomerId, @Product, @Price)",
                                                       new { CustomerId = id_c.Value, Product = "Lod" + i, Price = i * 50000 }, tr2);
                }
                tr2.Commit();
            }
            catch (Exception ex)
            {
                tr2.Rollback();
            }
            
        }
    }
}
