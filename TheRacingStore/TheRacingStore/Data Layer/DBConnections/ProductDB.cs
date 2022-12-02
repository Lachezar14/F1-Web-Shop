using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Threading.Tasks;
using Models;

namespace Data_Layer.DBConnections
{
    public class ProductDB : IProductDB
    {
        private string conn = "server=studmysql01.fhict.local;database=dbi477927;uid=dbi477927;pwd=root";

        public Product GetProduct(int id)
        {
            string query = $"SELECT p.Id,p.Description,p.Stock,p.Price,p.Type,c.Size FROM products p INNER JOIN clothes c ON p.Id=c.Product_Id WHERE Id = @id AND Type='Clothing';";
            string query2 = $"SELECT p.Id,p.Description,p.Stock,p.Price,p.Type,s.Length,s.Height FROM products p INNER JOIN posters s ON p.Id = s.Product_Id WHERE Id = @id AND Type = 'Poster'";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            MySqlCommand command2 = new MySqlCommand(query2, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();
                if (myReader.Read())
                {
                    Product clothing = new Clothing(
                        myReader.GetInt32("Id"),
                        myReader.GetString("Description"),
                        myReader.GetInt32("Stock"),
                        myReader.GetDecimal("Price"),
                        myReader.GetString("Type"),
                        myReader.GetString("Size")
                    );
                    return clothing;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
            try
            {
                myConn.Open();
                command2.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command2.ExecuteReader();
                if (myReader.Read())
                {
                    Product poster = new Poster(
                        myReader.GetInt32("Id"),
                        myReader.GetString("Description"),
                        myReader.GetInt32("Stock"),
                        myReader.GetDecimal("Price"),
                        myReader.GetString("Type"),
                        myReader.GetInt32("Length"),
                        myReader.GetInt32("Height")
                    );
                    return poster;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<Product> GetAllProducts()
        {
            string query = "SELECT p.Id,p.Description,p.Stock,p.Price,p.Type,c.Size FROM `products` p INNER JOIN clothes c ON p.Id=c.Product_Id ;";
            string query2 = "SELECT p.Id,p.Description,p.Stock,p.Price,p.Type,o.Length,o.Height FROM `products` p INNER JOIN posters o ON p.Id=o.Product_Id ;";
            List<Product> products = new List<Product>();

            try
            {
                using (MySqlDataReader myReader = MySqlHelper.ExecuteReader(conn, query))
                {
                    while (myReader.Read())
                    {
                        Product clothing = new Clothing(
                            myReader.GetInt32("Id"),
                            myReader.GetString("Description"),
                            myReader.GetInt32("Stock"),
                            myReader.GetDecimal("Price"),
                            myReader.GetString("Type"),
                            myReader.GetString("Size")
                        );
                        products.Add(clothing);
                    }
                }
                using (MySqlDataReader myReader = MySqlHelper.ExecuteReader(conn, query2))
                {
                    while (myReader.Read())
                    {
                        Product poster = new Poster(
                            myReader.GetInt32("Id"),
                            myReader.GetString("Description"),
                            myReader.GetInt32("Stock"),
                            myReader.GetDecimal("Price"),
                            myReader.GetString("Type"),
                            myReader.GetInt32("Length"),
                            myReader.GetInt32("Height")
                        );
                        products.Add(poster);
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertClothing(Product product)
        {
            Clothing clothing = (Clothing)product;
            string query = "INSERT INTO products(Description,Stock,Price,Type) VALUES (@Description,@Stock,@Price,@Type); INSERT INTO clothes(Product_Id,Size) VALUES ((SELECT MAX(Id) FROM products),@Size);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Description", clothing.Description);
                command.Parameters.AddWithValue("@Stock", clothing.Stock);
                command.Parameters.AddWithValue("@Price", clothing.Price);
                command.Parameters.AddWithValue("@Type", clothing.Type);
                command.Parameters.AddWithValue("@Size", clothing.Size);
                MySqlDataReader myReader = command.ExecuteReader();
                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }
        public void InsertPoster(Product product)
        {
            Poster poster = (Poster)product;
            string query = "INSERT INTO products(Description,Stock,Price,Type) VALUES (@Description,@Stock,@Price,@Type); INSERT INTO posters(Product_Id,Length,Height) VALUES ((SELECT MAX(Id) FROM products),@Length,@Height);"; 
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Description", poster.Description);
                command.Parameters.AddWithValue("@Stock", poster.Stock);
                command.Parameters.AddWithValue("@Price", poster.Price);
                command.Parameters.AddWithValue("@Type", poster.Type);
                command.Parameters.AddWithValue("@Length", poster.Length);
                command.Parameters.AddWithValue("@Height", poster.Height);
                MySqlDataReader myReader = command.ExecuteReader();
                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }
        public void ProductBought(int id)
        {
            string query = $"UPDATE products SET Stock = @Stock WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            Product product = GetProduct(id);
            int stock = product.Stock - 1;
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Stock", stock);
                MySqlDataReader myReader = command.ExecuteReader();
                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product.Type == "Clothing")
            {
                Clothing clothing = (Clothing)product;
                string query = $"UPDATE products SET Description = @Description,Stock = @Stock,Price = @Price WHERE Id = @Id; UPDATE clothes SET Size = @Size WHERE Product_Id = @Id;";
                MySqlConnection myConn = new MySqlConnection(conn);
                MySqlCommand command = new MySqlCommand(query, myConn);
                try
                {
                    myConn.Open();
                    command.Parameters.AddWithValue("@Id", clothing.Id);
                    command.Parameters.AddWithValue("@Description", clothing.Description);
                    command.Parameters.AddWithValue("@Stock", clothing.Stock);
                    command.Parameters.AddWithValue("@Price", clothing.Price);
                    command.Parameters.AddWithValue("@Size", clothing.Size);
                    MySqlDataReader myReader = command.ExecuteReader();
                    if (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    myConn.Close();
                }
            }
            else if (product.Type == "Poster")
            {
                Poster poster = (Poster)product;
                string query = $"UPDATE products SET Description = @Description,Stock = @Stock,Price = @Price WHERE Id = @Id; UPDATE posters SET Length = @Length,Height = @Height WHERE Product_Id = @Id;";
                MySqlConnection myConn = new MySqlConnection(conn);
                MySqlCommand command = new MySqlCommand(query, myConn);
                try
                {
                    myConn.Open();
                    command.Parameters.AddWithValue("@Id", poster.Id);
                    command.Parameters.AddWithValue("@Description", poster.Description);
                    command.Parameters.AddWithValue("@Stock", poster.Stock);
                    command.Parameters.AddWithValue("@Price", poster.Price);
                    command.Parameters.AddWithValue("@Length", poster.Length);
                    command.Parameters.AddWithValue("@Height", poster.Height);
                    MySqlDataReader myReader = command.ExecuteReader();
                    if (myReader.Read())
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    myConn.Close();
                }
            }
        }
        
        public void DropProduct(int id)
        {
            string query = "DELETE FROM products WHERE Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}
