using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;


namespace programText
{
    [TestClass]
    public class UnitTest1 
    {
        Order person1 = new Order("hjy","2017302580084");
        OrderDetails person1temp1 = new OrderDetails("1", "computer", 5599);
        OrderService newPerson = new OrderService();
        [TestMethod]
        public void AddTest()
        {
            OrderService.data.Add(person1);
            string name = "hjy";string clent = "2017302580084";
            string name2 = "yxl";double clent2 = 2017302580098;
            Order TEMP=newPerson.Addway(name, clent);
           
           // Order TEMP2 = newPerson.Addway(name2, clent2);
            //Assert.AreEqual(Order.Equals(person1, TEMP), 1);
        }
    }
}
