using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 工厂方法模式
/// 工厂方法模式之所以可以解决简单工厂的模式，是因为它的实现把具体产品的创建推迟到子类中，此时工厂类不再负责所有产品的创建，而只是给出具体工厂必须实现的接口，这样工厂方法模式就可以允许系统不修改工厂类逻辑的情况下来添加新产品，这样也就克服了简单工厂模式中缺点
/// 易于维护，把工厂和对象实现一一映射
/// 设计模式的单一原则
/// </summary>
namespace 工厂方法模式
{
    class Program
    {
       
        static void Main(string[] args)
        {
            TomatoScrambledEggsFactory tomatoFactory = new TomatoScrambledEggsFactory();
            TomatoScrambledEggs tomato = (TomatoScrambledEggs)tomatoFactory.CreateFood();
            tomato.Print();
            Console.ReadKey();
        }
    }
    #region 抽象物品类
    abstract class Food {
        public abstract void Print();
    }
    #endregion
    #region 具体物品类
    class TomatoScrambledEggs : Food {
        public override void Print()
        {
            Console.WriteLine("西红柿炒鸡蛋");
        }
    }
    class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝");
        }
    }
    class MincedMeatEggplant : Food
    {
        public override void Print()
        {
            Console.WriteLine("肉末茄子");
        }
    }
    #endregion
    #region 抽象工厂类
    abstract class Factory {
        public abstract Food CreateFood();
    }
    #endregion
    #region 具体工厂类
    class ShreddedPorkWithPotatoesFactory : Factory
    {
        public override Food CreateFood()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }
    class TomatoScrambledEggsFactory : Factory
    {
        public override Food CreateFood()
        {
            return new TomatoScrambledEggs();
        }
    }
    //扩展类品
    class MincedMeatEggplantFactory : Factory
    {
        public override Food CreateFood()
        {
            return new MincedMeatEggplant();
        }
    }
    #endregion
}
