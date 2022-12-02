using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using Models;

namespace Data_Layer.DBConnections
{
    public class OrderDB : IOrderDB
    {
        private string conn = "server=studmysql01.fhict.local;database=dbi477927;uid=dbi477927;pwd=root";
        
        public Order GetOrder(int userId,int productId)
        {
            UserDB userDB = new UserDB();
            ProductDB productDB = new ProductDB();

            User user = userDB.GetUser(userId);
            Product product = productDB.GetProduct(productId); 
            
            string query = $"SELECT * FROM orders WHERE Product_Id = @product_Id AND Buyer_Id = @buyer_Id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@product_Id", productId);
                command.Parameters.AddWithValue("user_id", userId);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                    Order order = new(myReader.GetInt32("Id"), product, user, myReader.GetInt32("Shipped"));
                    return order;
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
      
        public List<Order> GetAllOrders()
        {
            string query = "SELECT * FROM orders INNER JOIN products ON orders.Product_Id=products.Id INNER JOIN users ON orders.Buyer_Id=users.Id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            
            ProductDB productDB = new ProductDB();
            Product product = new Product();

            UserDB userDB = new UserDB();
            User user = new User();
            List<Order> orders = new List<Order>();

            try
            {
                myConn.Open();
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    int productId = myReader.GetInt32("Product_Id");
                    int userId = myReader.GetInt32("Buyer_Id");
                    
                    product = productDB.GetProduct(productId);
                    user = userDB.GetUser(userId);
                    
                    Order order = new(myReader.GetInt32("Id"), product, user, myReader.GetInt32("Shipped"));
                    orders.Add(order);
                }
                return orders;
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
       
        public void InsertOrder(Order order)
        {
            if (order.User.Id == 0)
            {
                string query = "INSERT INTO orders(Product_Id,Buyer_Id,Address,City,Postcode,Revenue,Shipped) VALUES (@Product_Id,(SELECT MAX(Id) FROM users),@Address,@City,@Postcode,@Revenue,@Shipped);";
                MySqlConnection myConn = new MySqlConnection(conn);
                MySqlCommand command = new MySqlCommand(query, myConn);
                try
                {
                    myConn.Open();
                    command.Parameters.AddWithValue("@Product_Id", order.Product.Id);
                    //command.Parameters.AddWithValue("@Buyer_Id", id); //purvo suzdai usera, posle napraj kueri za novo suzdadenoto id na usera i go pusni tuka
                    command.Parameters.AddWithValue("@Address", order.User.Address);
                    command.Parameters.AddWithValue("@City", order.User.City);
                    command.Parameters.AddWithValue("@Postcode", order.User.Postcode);
                    command.Parameters.AddWithValue("@Revenue", order.Product.Price);
                    command.Parameters.AddWithValue("@Shipped", "0");
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
            else
            {
                string query = "INSERT INTO orders(Product_Id,Buyer_Id,Address,City,Postcode,Revenue,Shipped) VALUES (@Product_Id,@Buyer_Id,@Address,@City,@Postcode,@Revenue,@Shipped);";
                MySqlConnection myConn = new MySqlConnection(conn);
                MySqlCommand command = new MySqlCommand(query, myConn);
                try
                {
                    myConn.Open();
                    command.Parameters.AddWithValue("@Product_Id", order.Product.Id);
                    command.Parameters.AddWithValue("@Buyer_Id", order.User.Id); //purvo suzdai usera, posle napraj kueri za novo suzdadenoto id na usera i go pusni tuka
                    command.Parameters.AddWithValue("@Address", order.User.Address);
                    command.Parameters.AddWithValue("@City", order.User.City);
                    command.Parameters.AddWithValue("@Postcode", order.User.Postcode);
                    command.Parameters.AddWithValue("@Revenue", order.Product.Price);
                    command.Parameters.AddWithValue("@Shipped", "0");
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

        public void OrderShipped(int id)
        {
            string query = $"UPDATE orders SET Shipped = @Shipped WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Shipped", "1");
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
        
        public void DropOrder(int id)
        {
            string query = "DELETE FROM orders WHERE Id = @id ;";
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
