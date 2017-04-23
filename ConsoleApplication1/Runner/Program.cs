using System.Diagnostics.Eventing.Reader;
using Services.Concrete;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var st1 = new OrderService();
            st1.Update(null);
        }
    }
}
