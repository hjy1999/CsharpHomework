using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        readonly string clent1 = "20181024001";
        readonly string name1 = "Alu";
        readonly string clent2 = "20181024002";
        readonly string name2 = "Yili";
        readonly string product = "flower";
        readonly string poduct2 = "freshfish";
        readonly string num = "2";
        readonly string num2 = "3";
        readonly double price = 99.9;
        readonly double price2 = 999.999;


        [TestMethod]
        public void AddwayTest()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.Addway(name1, clent1);
            Assert.IsNotNull(temp);
        }
        [TestMethod]
        public void IntoOrderTest()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.Addway(name1, clent1);

            var search = tempTest.IntoOrder(name1);
            string tempName;
            foreach (Order n in search)
            {
                tempName = n.Name;
                Assert.IsTrue(tempName == name1);
            }
        }
        [TestMethod]
        public void DeletewayTest()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.Addway(name1, clent1);

            tempTest.Deleteway(name1);
            Assert.IsNull(temp);
        }
        [TestMethod]
        public void IntoOrderAddTest()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.Addway(name1,clent1);
            var search = tempTest.IntoOrder(name1);

            tempTest.IntoOrderAdd(num, product, price, search);
            Assert.IsNotNull(temp.Items);
        }
        [TestMethod]
        public void IntoOrderDeleteTest()
        {
            OrderService tempTest = new OrderService();
            Order temp = tempTest.Addway(name1, clent1);
            var search = tempTest.IntoOrder(name1);
            tempTest.IntoOrderAdd(num, product, price, search);
            
            tempTest.IntoOrderDelete(product, search);
            Assert.IsNull(temp.Items);
        }
        [TestMethod]
        public void ExportTest()
        {
            
        }

    }
}