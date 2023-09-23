using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class A
    {
        public void SayHi()
        {
            Console.WriteLine("[TestAutoFac] " + GetType().Name + " Hi");
        }
    }

    class B
    {
        A a;

        public B(A a)
        {
            this.a = a;
        }

        public void SayHi()
        {
            a.SayHi();
            Console.WriteLine("[TestAutoFac] " + GetType().Name + " Hi");
        }
    }

    internal partial class Program
    {
        static void TestAutoFac(string[] args)
        {
            var builder = new ContainerBuilder();

            // 順序可顛倒，但是相依的都必須要註冊到
            builder.RegisterType<B>();
            builder.RegisterType<A>();

            var container = builder.Build();

            var b = container.Resolve<B>();

            b.SayHi();
        }
    }
}
