using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstLikeApp.Model;
using InstLikeApp.DataLayer.Sql;

namespace ConsoleApplication1
{
    class Program
    {
        private const string ConnectionString = "Data Source=vladimir-pc; Initial Catalog=InstLikeApp2; Integrated Security=True";
        static void Main(string[] args)
        {
            
            //arrange
            var user = new C_User
            {
                User_Name = Guid.NewGuid().ToString().Substring(10)
            };
            var dataLayer = new DataLayer(ConnectionString);
            //act
            user = dataLayer.AddUser(user);
            //asserts
            var resultUser = dataLayer.GetUser(user.User_ID);

            Console.WriteLine(user.User_Name);
            Console.WriteLine(resultUser.User_Name);
            Console.Read();


        }
    }
}
