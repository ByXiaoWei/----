using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 由于工厂的多元化，一个工厂可以生成多种物品
/// 下面就以生活中 “绝味” 连锁店的例子来实现一个抽象工厂模式。例如，绝味鸭脖想在江西南昌和上海开分店，但是由于当地人的口味不一样，在南昌的所有绝味的东西会做的辣一点，而上海不喜欢吃辣的，所以上海的所有绝味的东西都不会做的像南昌的那样辣，然而这点不同导致南昌绝味工厂和上海的绝味工厂生成所有绝味的产品都不同，也就是某个具体工厂需要负责一系列产品(指的是绝味所有食物)的创建工作
/// </summary>
namespace 抽象工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ShangHaiFactory shangHaiFactory = new ShangHaiFactory();
            ShangHaiYaBo shangHaiYaBo = (ShangHaiYaBo)shangHaiFactory.CreateYaBo();
            shangHaiYaBo.Print();

            Console.ReadKey();
        }
    }
    #region 抽象工厂类
    abstract class AbstractFactory {
        public abstract YaBo CreateYaBo();
        public abstract YaJia CreateYaJia();
    }
    #endregion
    #region 具体工厂类
    class NanChangFactory :AbstractFactory {
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }
        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }
    class ShangHaiFactory : AbstractFactory
    {
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }
    #endregion
    #region 抽象物品类
    abstract class YaBo
    {
        public abstract void Print();
    }
    abstract class YaJia
    {
        public abstract void Print();
    }
    #endregion 
    #region 具体物品类
    class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌鸭脖");
        }
    }
    class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌鸭架");
        }
    }
    class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭脖");
        }
    }
    class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海鸭架");
        }
    }
    #endregion
  
}
