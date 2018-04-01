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
        [TestMethod]
        public void TestSameResolver()
        {
            var source = CardSource(21);

            var groups1 = new SameResolver().Resolve(source, 2).ToArray();

            for (var i = 0; i < groups1.Count(); i++)
            {              
                System.Diagnostics.Debug.WriteLine(
                    string.Join(",", groups1[i].Select(item => item.ToString()))
                    );
            }

            var groups2 = new SameResolver().Resolve(source, 3).ToArray();

            for (var i = 0; i < groups2.Count(); i++)
            {
                System.Diagnostics.Debug.WriteLine(
                    string.Join(",", groups2[i].Select(item => item.ToString()))
                    );
            }
        }


        [TestMethod]
        public void TestNoneResolver()
        {
            var source = CardSource(21);

            var groups1 = new NoneResolver().Resolve(source, 3).ToArray();

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
