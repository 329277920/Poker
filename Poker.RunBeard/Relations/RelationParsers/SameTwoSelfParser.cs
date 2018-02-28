using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class SameTwoSelfParser : SameBaseParser, IRelationParser
    {
        /// <summary>
        /// 当前解析相同牌的数量
        /// </summary>
        protected override int Count { get { return 2; } }

        protected override IRelation CreateRelation(params Card[] cards)
        {
            return new RelationLL() { Cards = cards };
        }
    }
}
