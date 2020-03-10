using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class AsynchronousFactoryMethod
    {
        private AsynchronousFactoryMethod()
        {
            
        }
        private async Task<AsynchronousFactoryMethod> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<AsynchronousFactoryMethod> CreateAsync()
        {
            var obj = new AsynchronousFactoryMethod();
            return obj.InitAsync();
        }

    }

    public class Consumer
    {
        public static async Task Main(string[] args)
        {
            AsynchronousFactoryMethod asynchronousFactoryMethod = await AsynchronousFactoryMethod.CreateAsync();

        }
    }
}
