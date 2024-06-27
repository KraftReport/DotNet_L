using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleC_sharp
{
    internal class PoketMonsterRepository
    {
        private readonly DababaseConnection _dbConn;
        public PoketMonsterRepository(DababaseConnection dababaseConnection)
        {
            this._dbConn = dababaseConnection;
        }

        public void CreatePocketMonster(PocketMonster pocketMonster)
        {
            using (SqlConnection connection = _dbConn.getOpenConnection())
            {
                var query = "insert into PocketMonster (Name,Type) values (@Name,@Type)";
                var sqlCmd = new SqlCommand(query, connection);
                sqlCmd.Parameters.AddWithValue("@Name", pocketMonster.Name);
                sqlCmd.Parameters.AddWithValue("@Type", pocketMonster.Type);
                var rows = sqlCmd.ExecuteNonQuery();
                Console.WriteLine($"{rows} row(s) inserted.");
            }
        }

        public List<PocketMonster> GetPocketMonsterList()
        {
            var list = new List<PocketMonster>();
            using (SqlConnection connection = _dbConn.getOpenConnection())
            {
                var query = "select * from PocketMonster";
                var cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new PocketMonster
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Type = (string)reader["Type"],
                    });
                }


            }
            return list;
        }


        public void UpdatePocketMonster(PocketMonster pocketMonster)
        {
            using (SqlConnection sqlConnection = _dbConn.getOpenConnection())
            {
                string query = "UPDATE PocketMonster SET Name = @NewName, Type = @NewType WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@NewName", pocketMonster.Name);
                command.Parameters.AddWithValue("@NewType", pocketMonster.Type);
                command.Parameters.AddWithValue("@Id", pocketMonster.Id);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) updated.");
            }
        }

        public void DeletePocketMonster(int pocketMonsterId)
        {
            using(var conn =  _dbConn.getOpenConnection())
            {
                var query = "delete from PocketMonster where Id = @Id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id",pocketMonsterId);
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rows} deleted");
            }
        }

    }
}
