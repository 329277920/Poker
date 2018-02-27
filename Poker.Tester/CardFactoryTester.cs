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
    public class CardFactoryTester
    {
        [TestMethod]
        public void TestBuild()
        {
            var cards = CardFactory.Build();
            for (var i = 0; i < cards.Length; i++)
            {
                System.Diagnostics.Debug.Write(cards[i].ToString());
            }
        }
    }
}
