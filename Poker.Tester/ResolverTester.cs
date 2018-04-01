using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.RunBeard;
using System.Linq;
using Poker.RunBeard.CardResolvers;
using Poker.RunBeard.Relations;
using System.Collections.Generic;
using Poker.Resolvers;

namespace Poker.Tester
{
    [TestClass]
    public class ResolverTester : BaseTester
    {
        public bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }

        [TestMethod]
        public void Test()
        {
            System.Diagnostics.Debug.WriteLine(Compare<object>(null, null));
        }

        [TestMethod]
        public void TestCardSameResolver()
        {            
            foreach (var cards in new CardSameResolver().Resolve(CardSource(20)))
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Join(",", from card in cards select card.ToString())
                    );
            }
        }

        [TestMethod]
        public void TestCardThreeResolver()
        {
            var source = CardSource(5);
            
            foreach (var cards in new CardThreeResolver().Resolve(source))
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Join(",", from card in cards select card.ToString())
                    );
            }
        }        

        [TestMethod]
        public void TestCardThreeResolver2()
        {
            var source = CardSource(5);
            Console.WriteLine(string.Join(",", source.Select(card => card.ToString())));
            foreach (var cards in new CardThreeResolver().Resolve(source, source[0].Id, source[1].Id))
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Join(",", from card in cards select card.ToString())
                    );
            }
        }


        [TestMethod]
        public void TestNoneResolver()
        {
            var source = CardSource(21);

            var groups1 = new NoneResolver().Resolve<Card>(source, 3, (t1, t2) => t1 == t2).ToArray();

            var groups2 = new CardThreeResolver().Resolve(source).ToArray();

            if (groups1.Count() != groups2.Count())
            {
                Assert.Fail("数量不一致");
            }

            for (var i = 0; i < groups1.Count(); i++)
            {
                var str1 = string.Join(",", groups1[i].Select(item => item.ToString()));
                var str2 = string.Join(",", groups2[i].Select(item => item.ToString()));
                if (str1 != str2)
                {
                    Assert.Fail("结果不一致");
                }
                System.Diagnostics.Debug.WriteLine(str1 + "  " + str2);
            }
        }
    }
}
