using System.Globalization;
using System.Resources;

namespace LocalizationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture= new CultureInfo("my-MM");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("my-MM");
            var rm = new ResourceManager("LocalizationDemo.Resources", typeof(Program).Assembly);
            var HelloMessage = rm.GetString("helloMessage");
            Console.WriteLine(HelloMessage);
        }
    }
}
