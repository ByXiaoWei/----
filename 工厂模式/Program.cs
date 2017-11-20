using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 简单工厂模式
/// 在外面打工的人，免不了要经常在外面吃饭，当然我们也可以自己在家做饭吃，但是自己做饭吃麻烦，因为又要自己买菜，然而，出去吃饭就完全没有这些麻烦的，我们只需要到餐馆点菜就可以了，买菜的事情就交给餐馆做就可以了，这里餐馆就充当简单工厂的角色，
/// </summary>
namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Food food1 = SimpleFactory.CreateFood("西红柿炒鸡蛋");
            food1.Print();
            Food food2 = SimpleFactory.CreateFood("土豆肉丝");
            food2.Print();
            Console.ReadKey();
        }
    }
    #region 抽象物品类
    abstract class Food
    {
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
    class ShreddedPorkWithPotatoes : Food {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝");
        }
    }
    #endregion
    #region 工厂类
    class SimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            switch (type)
            {
                case "西红柿炒鸡蛋":
                    food = new TomatoScrambledEggs();
                    break;
                case "土豆肉丝":
                    food = new ShreddedPorkWithPotatoes();
                    break;
                default:break;
            }
            return food;
        }
    }
    #endregion
}
