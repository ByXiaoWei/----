using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 下面让我们看看适配器的定义，适配器模式——把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作。适配器模式有类的适配器模式和对象的适配器模式两种形式
/// </summary>
namespace 适配器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeHelo threeHelo = new PowerAdapter();
            threeHelo.Request();
            Console.ReadKey();
        }
    }

    abstract class AbTwoHelo
    {
        public abstract void SpecificRequest();
    }
    
    interface IThreeHelo {
        void Request();
    }
    class TwoHelo : AbTwoHelo
    {
        public override void SpecificRequest()
        {
            Console.WriteLine("二插口");
        }
    }
    class ThreeHelo : IThreeHelo
    {
        public virtual void Request()
        {
            Console.WriteLine("三插口");
        }
    }
    class PowerAdapter : ThreeHelo
    {
        TwoHelo two = new TwoHelo();
        public override void Request()
        {
            base.Request();
            two.SpecificRequest();
        }
    }

}
