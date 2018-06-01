using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            User user = new User
            {
                Age = 20,
                Name="aaaa"
            };
            int age = user.Age;
            Expression<Func<User, bool>> lambda = x => x.Age > age;
            var serializedLambda = JsonNetAdapter.Serialize(lambda);
            var deserializedLambda = JsonNetAdapter.Deserialize<Expression<Func<User, bool>>>(serializedLambda);
            var users = new List<User>
            {
                new User { Name = "Bobbie", Age = 15 },
                new User { Name = "Angie", Age = 25 },
                new User { Name = "Carol", Age = 17 },
                new User { Name = "Billy", Age = 34 },
                new User { Name = "Patrick", Age = 20 },
            };
            var gtn20 = users.Where(deserializedLambda.Compile());
            gtn20.ToList().ForEach(u => Console.WriteLine(u.Name));
            Console.ReadLine();



            //byte[] bytes = Encoding.ASCII.GetBytes("c");
            //string b = System.Text.Encoding.ASCII.GetString(bytes);
            //Console.WriteLine(b);
            //Console.ReadLine();
            ReaderExpression readerExpression = new ReaderExpression();
            Expression<Func<Class1, bool>> expression = c => c.MyProperty == "" && c.MyProperty == " " || c.cls2.MyProperty != "";
            readerExpression.exp<Class1>(expression, null,null);
            //Expression<Func<Class1, object>> expression = c => c.cls2.cls3.cls4;
        }
    }
}
