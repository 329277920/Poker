using Poker.RunBeard.CardResolvers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 关系生成工厂类
    /// </summary>
    public sealed class RelationFactory
    {
        /// <summary>
        /// 从手中的牌生成符合固定规则的规则集合，包括提、清
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static IRelation[] BuildFixedRelations(params Card[] cards)
        {
            List<IRelation> relations = new List<IRelation>();
            foreach (var cardArray in new CardSameResolver().Resolve(cards))
            {

            }
            return relations.ToArray();
        }
    }
}
