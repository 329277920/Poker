using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 解析出相同的牌
    /// </summary>
    public abstract class SameBaseParser
    {
        /// <summary>
        /// 当前解析相同牌的数量
        /// </summary>
        protected abstract int Count { get; }

        protected abstract IRelation CreateRelation(params Card[] cards);
       
        public IRelation Parse(params Card[] cards)
        {
            if (cards.Length != Count)
            {
                return null;
            }
            var code = cards[0].Code;
            for (var i = 1; i < cards.Length; i++)
            {
                if (code != cards[i].Code)
                {
                    return null;
                }
            }
            return CreateRelation(cards);
        }
    }
}
