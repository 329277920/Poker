using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.RunBeard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Tester
{
    [TestClass]
    public class GameRegulationTester : BaseTester
    {
        /// <summary>
        /// 测试初始化用户手中的牌
        /// </summary>
        [TestMethod]
        public void TestInitUserCards()
        {             
            var tuple3 = GameRegulation.InitUserCards(CardSource(21));

            foreach (var relation in tuple3.Item2)
            {                 
                WriteLine(relation);
            }
            foreach (var relation in tuple3.Item3)
            {
                WriteLine(relation);
            }
            WriteLine(tuple3.Item1);
        }

        /// <summary>
        /// 测试用户对某张牌允许的规则
        /// </summary>
        [TestMethod]
        public void TestCardOperations()
        {
            var cards = CardSource(80);

            // var user = new GameUser() { UserName = "cnf", Cards = cards.Take(20).ToArray() };
        }
    }
}
