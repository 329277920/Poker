﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.RunBeard;
using System.Linq;
using Poker.RunBeard.CardResolvers;
using Poker.RunBeard.Relations;

namespace Poker.Tester
{
    [TestClass]
    public class ResolverTester : BaseTester
    {
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

       
    }
}
