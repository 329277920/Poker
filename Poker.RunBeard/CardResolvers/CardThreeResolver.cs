using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard.CardResolvers
{
    /// <summary>
    /// 任意三张牌分解器
    /// </summary>
    public class CardThreeResolver : ICardResolver
    {
        public List<Card[]> Resolve(Card[] cards, params int[] cardIds)
        {
            List<Card[]> result = new List<Card[]>();
            for (var i = 0; i < cards.Length; i++)
            {
                if (cardIds != null && !cardIds.Contains(cards[i].Id))
                {
                    continue;
                }
                for (var j = i + 1; j < cards.Length; j++)
                {
                    for (var k = j + 1; k < cards.Length; k++)
                    {
                        result.Add(new Card[] 
                        {
                             cards[i],cards[j],cards[k]
                        });                        
                    }
                }
            }
            return result;
        }
    }
}
