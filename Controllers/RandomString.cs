using System;
using System.Linq;
namespace blogApi.Controllers
{

    public class RandomString
    {
        RandomString() { }
        private static Random random = new Random();
        public static string _RandomString(int length)
        {
            const string chars = "abcdefghijklmnop0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}