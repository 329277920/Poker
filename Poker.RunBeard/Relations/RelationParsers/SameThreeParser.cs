using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class SameThreeParser : SameBaseParser, IRelationParser
    {
        /// <summary>
        /// 当前解析相同牌的数量
        /// </summary>
        protected override int Count { get { return 3; } }

        protected override IRelation CreateRelation(params Card[] cards)
        {
            if (cards[0].IsLarge)
            {
                return new RelationLLL() { Cards = cards };
            }
            return new RelationSSS() { Cards = cards };
        }
    }
}
