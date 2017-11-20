using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 
/// </summary>
namespace 责任链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Staff staff = new Staff();
            staff.Name = "小李";

            Manager manager = new Manager();
            manager.Name = "王经理";
            VicePresident vice = new VicePresident();
            vice.Name = "钱总";
            staff.NextApprover = manager;
            manager.NextApprover = vice;
            staff.ProcessRequest(new PurchaseHandle(5000,"大力丸"));
            staff.ProcessRequest(new PurchaseHandle(30000, "数控床"));
            staff.ProcessRequest(new PurchaseHandle(700000, "机器手套"));
            Console.ReadKey();
        }
    }
    class PurchaseHandle
    {
        public float Price { get; set; }
        public string ProductName { get; set; }
        public PurchaseHandle(float price,string product)
        {
            this.Price = price;
            this.ProductName = product;
        }
    }
    abstract class Approver {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }
      
        public abstract void ProcessRequest(PurchaseHandle request);
    }
    class Staff : Approver {
        public override void ProcessRequest(PurchaseHandle request)
        {
            if(request.Price < 10000)
            {
                Console.WriteLine(Name + "同意购买" + request.ProductName + "价格:" + request.Price);
            }
            else
            {
                this.NextApprover.ProcessRequest(request);
            }
        }
    }
    class Manager : Approver
    {
        public override void ProcessRequest(PurchaseHandle request)
        {
            if (request.Price > 10000 && request.Price < 50000)
            {
                Console.WriteLine(Name + "同意购买" + request.ProductName + "价格:" + request.Price);
            }
            else
            {
                this.NextApprover.ProcessRequest(request);
            }
        }
    }
    class VicePresident : Approver {
        public override void ProcessRequest(PurchaseHandle request)
        {
            if (request.Price > 50000 && request.Price < 100000)
            {
                Console.WriteLine(Name + "同意购买" + request.ProductName + "价格:" + request.Price);
            }
            else
            {
                Console.WriteLine("需要大家开会来决定");
            }
        }
    }


}
