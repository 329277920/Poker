using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 解析出顺子，包括2710
    /// </summary>
    public class StraightParser : IRelationParser
    {
        public IRelation Parse(params Card[] cards)
        {
            IRelation relation = null;
            if (cards.Length != 3)
            {
                return relation;
            }
            if (cards[0].IsLarge != cards[1].IsLarge || cards[1].IsLarge != cards[2].IsLarge)
            {
                return relation;
            }           
            if (cards[0].Num + 2 == cards[2].Num && cards[1].Num + 1 == cards[2].Num)
            {
                if (cards[0].Num == 1)
                {
                    relation = cards[0].IsLarge ? new Relation123Big() : (IRelation)new Relation123Small();
                }
                relation = cards[0].IsLarge ? new RelationStraightBig() : (IRelation)new RelationStraightSmall();
            }
            if (cards[0].Num == 2 && cards[1].Num == 7 && cards[2].Num == 10)
            {
                relation = cards[0].IsLarge ? new Relation2710Big() : (IRelation)new Relation2710Small();
            }
            if (relation != null)
            {
                relation.Cards = cards;
            }
            return relation;                        
        }
    }
}
