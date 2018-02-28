using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 驼峰式关系
    /// </summary>
    public class HumpParser : IRelationParser
    {
        public IRelation Parse(params Card[] cards)
        {
            if (cards.Length != 3)
            {
                return null;
            }
            if (cards[0].Num == cards[1].Num && cards[1].Num == cards[2].Num)
            {
                if (cards[0].IsLarge == cards[1].IsLarge &&
                    cards[1].IsLarge == cards[2].IsLarge)
                {
                    return null;
                }
                return new RelationHump() { Cards = cards };
            }
            return null;
        }
    }
}

