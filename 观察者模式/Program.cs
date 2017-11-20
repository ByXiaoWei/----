using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace 观察者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //TencentGame game = new TencentGame();
            //game.Attach(new TencentPlayer("Jack"));
            //game.Attach(new TencentPlayer("LiLi"));
            //game.Notify("游戏有新版本更新");
            Boss boss = new Boss();
            boss.Attach(new Staff("李明"));
            boss.Attach(new Staff("王红"));
            Message message = new Message();
            message.Content = "召开大会";
            message.Date = DateTime.Now.Date;
            message.Sender = "李忠";
            boss.Notify(message);
            Console.ReadKey();
        }
    }
    /**
    使用事件和委托强的观察者模式
        
    class SinaWeiBo {
        public delegate void NotifyEventHandler(object sender);
        public void Attach(object sender)
        {

        }
    }*/
    /*
    class Program
    {
        // 委托充当订阅者接口类
        public delegate void NotifyEventHandler(object sender);

        // 抽象订阅号类
        public class TenXun
        {
            public NotifyEventHandler NotifyEvent;

            public string Symbol { get; set; }
            public string Info { get; set; }
            public TenXun(string symbol, string info)
            {
                this.Symbol = symbol;
                this.Info = info;
            }

            #region 新增对订阅号列表的维护操作
            public void AddObserver(NotifyEventHandler ob)
            {
                NotifyEvent += ob;
            }
            public void RemoveObserver(NotifyEventHandler ob)
            {
                NotifyEvent -= ob;
            }

            #endregion

            public void Update()
            {
                if (NotifyEvent != null)
                {
                    NotifyEvent(this);
                }
            }
        }

        // 具体订阅号类
        public class TenXunGame : TenXun
        {
            public TenXunGame(string symbol, string info)
                : base(symbol, info)
            {
            }
        }

        // 具体订阅者类
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrint(Object obj)
            {
                TenXun tenxun = obj as TenXun;

                if (tenxun != null)
                {
                    Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
                }
            }
        }

        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
            Subscriber lh = new Subscriber("Learning Hard");
            Subscriber tom = new Subscriber("Tom");

            // 添加订阅者
            tenXun.AddObserver(new NotifyEventHandler(lh.ReceiveAndPrint));
            tenXun.AddObserver(new NotifyEventHandler(tom.ReceiveAndPrint));

            tenXun.Update();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除Tom订阅者");
            tenXun.RemoveObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();

            Console.ReadKey();
        }
    }*/
    /**
    下面以微信订阅号的例子来说明观察者模式的实现。现在要实现监控腾讯游戏订阅号的状态的变化。这里一开始不采用观察者模式来实现，而通过一步步重构的方式，最终重构为观察者模式。因为一开始拿到需求，自然想到有两个类，一个是腾讯游戏订阅号类，另一个是订阅者类。订阅号类中必须引用一个订阅者对象，这样才能在订阅号状态改变时，调用这个订阅者对象的方法来通知到订阅者对象
    */
    #region 抽象主题
    interface IObserver {
        void Attach(ISubject subject);
        void Detach(ISubject subject);
        void Notify(Message message);
    }
    #endregion
    #region 具体主题
    class Boss : IObserver
    {
        public List<ISubject> subjects;
        public Boss()
        {
            subjects = new List<ISubject>();
        }
        public void Attach(ISubject subject)
        {
            if (!subjects.Contains(subject))
            {
                subjects.Add(subject);
            }
        }

        public void Detach(ISubject subject)
        {
            if (!subjects.Contains(subject))
            {
                subjects.Remove(subject);
            }
        }

        public void Notify(Message message)
        {
           foreach(var item in subjects)
            {
                item.Update(message);
            }
        }
    }
    #endregion
    #region 抽象观者
    interface ISubject {
        void Update(Message message);
    }
    #endregion
    #region 具体观察者
    class Staff : ISubject
    {
        public string Name { get; set; }
        public Staff(string name)
        {
            Name = name;
        }
        public void Update(Message message)
        {
            Console.WriteLine(Name + ":");
            Console.WriteLine("\t" + message.Content);
            Console.WriteLine("\t\t\t" + message.Date.ToString());
            Console.WriteLine("\t\t\t" + message.Sender);
        }
    }
    #region 消息
    class Message {
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
    }
    #endregion
    /// <summary>
    /// 腾讯游戏
    /// </summary>
    class TencentGame {
        public List<TencentPlayer> players;
        public TencentGame()
        {
            players = new List<TencentPlayer>();
        }
        public void Attach(TencentPlayer player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
            }
        }
        public void Detach(TencentPlayer player)
        {
            if (players.Contains(player))
            {
                players.Remove(player);
            }
        }
        public void Notify(string message) {
            foreach(var item in players)
            {
                item.Update(message);
            }
        }
            
    }
    class TencentPlayer {
        public string Name { get; set; }
        public TencentPlayer(string name)
        {
            Name = name;
        }
        public void Update(string message) {
            Console.WriteLine(Name + ":" + message);
        }
    }
   
}
