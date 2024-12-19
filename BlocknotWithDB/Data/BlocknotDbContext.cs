using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Transactions;

namespace BlocknotWithDB.Data
{
    internal class BlocknotDbContext
    {
        private const string ConnectionString = "Data Source=lectures-db-dev.database.windows.net;Initial Catalog=BlocknotDB;Persist Security Info=True;User ID=ad;Password=Ararat73;Encrypt=True;Trust Server Certificate=True";

        public Blocknot Blocknot { get; set; }

        public BlocknotDbContext(Blocknot blocknot)
        {
            Blocknot = blocknot;
        }

        public async Task SaveChangesAsync()
        {
            using (TransactionScope scope = new TransactionScope)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);

                await connection.OpenAsync();

                //SqlTransaction? transaction = (await connection.BeginTransactionAsync()) as SqlTransaction;

                string insertCommand = "INSERT INTO Records (Name, Surname, Phone) " +
                    "VALUES (@Name, @Surname, @Phone)";

                try
                {
                    using SqlCommand command = new SqlCommand(insertCommand, connection);

                    //command.Transaction = transaction;

                    foreach (Record record in Blocknot)
                    {
                        command.Parameters.AddWithValue("@Name", record.Name);
                        command.Parameters.AddWithValue("@Surname", record.Surname);
                        command.Parameters.AddWithValue("@Phone", record.Phone);

                        await command.ExecuteNonQueryAsync();
                    }
                    scope.Complete();
                }
                catch (DbException)
                {
                    //await transaction!.RollbackAsync();
                    throw;
                }
            }
            //await transaction!.CommitAsync();
        }

        public async Task LoadAsync()
        {
            string sqlCommand = "SELECT Id, Name, Surname, Phone FROM Records";

            using SqlConnection connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand(sqlCommand, connection);

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int id = (int)reader["Id"];

                string name = reader["Name"].ToString()!;
                string? surname = reader["Surname"]?.ToString();
                string? phone = reader["Phone"]?.ToString();

                Record record = new Record
                {
                    Id = id,
                    Name = name,
                    Surname = surname,
                    Phone = phone
                };

                Blocknot.Add(record);
            }
        }
    }
}