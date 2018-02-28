using Poker.RunBeard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Tester
{
    public abstract class BaseTester
    {
        protected Card[] CardSource(int num)
        {
            var cards = (from card in (from card in CardFactory.Build().Take(num) select card)
                         orderby card.Num ascending, card.IsLarge descending
                         select card).ToArray();
            Console.WriteLine(string.Join(",", cards.Select(card => card.ToString())));
            return cards;
        }
    }
}
