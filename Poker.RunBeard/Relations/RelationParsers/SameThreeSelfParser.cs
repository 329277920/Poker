using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class SameThreeSelfParser : SameBaseParser
    {
        /// <summary>
        /// 当前解析相同牌的数量
        /// </summary>
        protected override int Count { get { return 3; } }

        protected override IRelation CreateRelation(params Card[] cards)
        {
            if (cards[0].IsLarge)
            {
                return new RelationLLLSelf() { Cards = cards };
            }
            return new RelationSSSSelf() { Cards = cards };
        }
    }
}
