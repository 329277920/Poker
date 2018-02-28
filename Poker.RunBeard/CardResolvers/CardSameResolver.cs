using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard.CardResolvers
{
    /// <summary>
    /// 将相同的牌分解在一组
    /// </summary>
    public class CardSameResolver : ICardResolver
    {
        public List<Card[]> Resolve(Card[] cards, params int[] cardIds)
        {
            var result = new List<Card[]>();
            var temp = new List<Card>();
            var code = 0;
            for (var i = 0; i < cards.Length; i++)
            {
                if (cardIds != null && cardIds.Length > 0 && !cardIds.Contains(cards[i].Id))
                {
                    continue;
                }
                if (code != cards[i].Code)
                {
                    if (temp.Count > 0)
                    {
                        result.Add(temp.ToArray());
                    }
                    temp.Clear();
                    code = cards[i].Code;
                }
                temp.Add(cards[i]);
            }
            if (temp.Count > 0)
            {
                result.Add(temp.ToArray());
            }
            return result;
        }
    }
}
