using Poker.RunBeard;
using Poker.RunBeard.Relations;
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
            WriteLine(cards);             
            return cards;
        }

        protected void WriteLine(IRelation relation)
        {
            Console.WriteLine("{0}:{1}", relation.RelationType, string.Join(",", from card in relation.Cards select card.ToString()));
        }

        protected void WriteLine(params Card[] cards)
        {
            Console.WriteLine(string.Join(",", cards.Select(card => card.ToString())));
        }
    }
}
