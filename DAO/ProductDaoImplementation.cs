using WebApplicationDemo.Models;
using Npgsql;
using System.Data;
using NpgsqlTypes;

namespace WebApplicationDemo.DAO
{
    public class ProductDaoImplementation : IProductDao
    {
        NpgsqlConnection _connection;
        public ProductDaoImplementation(NpgsqlConnection connection) 
        {
            _connection = connection;
        }

        public async Task<int> InsertProduct(Product p)
        {
            //Create a connection object using connection string
            //Open connection
            //Create Command Object, Pass The connection
            //Specify The Command Type
            //Create the Query Call the Command Objects Execute Method. If you have parameter add parameter.
            //Close The reader if you have open reader
            //Close The Connection

            int rowsInserted = 0;

            string message;

            string insertQuery = @$"insert into amey.products(product_name,price,category,star_rating,description,product_code,imageurl) values('{p.ProductName}',{p.Price},'{p.Category}',{p.StarRating},'{p.Description}','{p.ProductCode}','{p.ImageUrl}')";

            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery,_connection);
                    insertCommand.CommandType = CommandType.Text;
                    rowsInserted = await insertCommand.ExecuteNonQueryAsync();
                }
            }
            catch (NpgsqlException e) 
            {
                message = e.Message;
                Console.WriteLine("------Exception-----:"+message); 
            }
            return rowsInserted;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product p = null; ;
            string query = @"select * from amey.products where product_id=@product_id";
            string errMessage = string.Empty;

            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@product_id", id);
                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    
                        while (reader.Read())
                        {
                            p = new Product();
                            p.ProductId = (int)reader.GetInt32(0);
                            p.ProductName =reader.GetString(1);
                            p.Price =(decimal)reader["price"];
                            p.Category = reader["category"].ToString();
                            p.StarRating = (decimal)reader["star_rating"];
                            p.Description = reader["description"].ToString();
                            p.ProductCode = reader["product_code"].ToString();
                            p.ImageUrl = reader["imageurl"].ToString();
                    }
                    
                    reader?.Close();
                }
                return p;
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }
            return p;
        }

        

        public async Task<List<Product>> GetProducts()
        {
            List<Product> plist = new List<Product>();
            string query = @"select * from amey.products";
            string errMessage = string.Empty;
            Product p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Product();
                        p.ProductId = reader.GetInt32(0);
                        p.ProductName = reader.GetString(1);
                        p.Price = reader.GetDecimal(2);
                        p.Category = reader.GetString(3);
                        p.StarRating = reader.GetDecimal(4);
                        p.Description = reader.GetString(5);
                        p.ProductCode = reader.GetString(6);
                        p.ImageUrl = reader.GetString(7);
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }

        public async Task<int> UpdatePriceById(int id, decimal newPrice)
        {
            int rowsAffected = 0;
            string query = @$"update amey.products set price=@new_price where product_id=@pid;";

            using (_connection)
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;

                NpgsqlParameter priceParameter = new()
                {
                    ParameterName = "@new_price",
                    Value = newPrice,
                    NpgsqlDbType = NpgsqlDbType.Numeric,
                    Direction = ParameterDirection.Input,   
                };

                NpgsqlParameter idParameter = new()
                {
                    ParameterName = "@pid",
                    Value = id,
                    NpgsqlDbType = NpgsqlDbType.Integer,
                    Direction = ParameterDirection.Input,
                };

                command.Parameters.Add(priceParameter);
                command.Parameters.Add(idParameter);

                rowsAffected = await command.ExecuteNonQueryAsync();
            }

            return rowsAffected;
        }


        public async Task<int> DeleteById(int id)
        {
            string query = @"delete from amey.products where product_id=@product_id";
            string errMessage = string.Empty;
            int isDeleted = 0;

            try
            {
               // Product p = await this.GetProductById(id);
                //if (p != null)
                //{
                    using (_connection)
                    {
                        await _connection.OpenAsync();
                        NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                        command.CommandType = CommandType.Text;
                        //command.Parameters.AddWithValue("@product_id", id);
                        command.Parameters.Add("@product_id",NpgsqlDbType.Integer).Value=id;
                        isDeleted = await command.ExecuteNonQueryAsync();
                    }
                //}
                //else
                //{
                //    isDeleted = 0;
                //}
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }
            return isDeleted;
        }

        public async Task<int> GetTotalProductsCount()
        {
            int count = 0;
            string query = @"select count(product_id) from amey.products";
            string errMessage = string.Empty;
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;
                    var result = await command.ExecuteScalarAsync();
                    count = Convert.ToInt32(result);
                }
            }
            catch (NpgsqlException e) 
            { 
            }
            return count;
        }

        public async Task<List<Product>> GetProductsByPriceRange(decimal min,decimal max)
        {
            List<Product> plist = new List<Product>();
            string query = @"select * from amey.products where price>=@min and price <=@max;";
            string errMessage = string.Empty;
            Product p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@min", min);
                command.Parameters.AddWithValue("@max", max);
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Product();
                        p.ProductId = reader.GetInt32(0);
                        p.ProductName = reader.GetString(1);
                        p.Price = reader.GetDecimal(2);
                        p.Category = reader.GetString(3);
                        p.StarRating = reader.GetDecimal(4);
                        p.Description = reader.GetString(5);
                        p.ProductCode = reader.GetString(6);
                        p.ImageUrl = reader.GetString(7);
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }

        public async Task<List<Product>> SortProductsByPrice()
        {
            List<Product> plist = new List<Product>();
            string query = @"select * from amey.products order by price desc;";
            string errMessage = string.Empty;
            Product p = null;

            try
            {
                await _connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        p = new Product();
                        p.ProductId = reader.GetInt32(0);
                        p.ProductName = reader.GetString(1);
                        p.Price = reader.GetDecimal(2);
                        p.Category = reader.GetString(3);
                        p.StarRating = reader.GetDecimal(4);
                        p.Description = reader.GetString(5);
                        p.ProductCode = reader.GetString(6);
                        p.ImageUrl = reader.GetString(7);
                        plist.Add(p);
                    }
                }
                reader.Close();
            }
            catch (NpgsqlException e)
            {
                errMessage = e.Message;
                Console.WriteLine("------Exception-----:" + errMessage);
            }

            return plist;
        }

    }
}
