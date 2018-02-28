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
        public static IRelation[] BuildFixedRelations(Card[] cards)
        {
            List<IRelation> relations = new List<IRelation>();
            foreach (var cardArray in new CardSameResolver().Resolve(cards))
            {
                var relation = ParserFactory.Instance(ParserDefines.SameFourSelfParser).Parse(cardArray);
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.SameThreeSelfParser).Parse(cardArray);
                }
                if (relation != null)
                {
                    relations.Add(relation);
                }
            }
            return relations.ToArray();
        }

        /// <summary>
        /// 从手中的牌生成所有可变的规则集合，包括吃、碰
        /// </summary>
        /// <param name="cards">手中的牌，或者包括当前摸的牌</param>
        /// <param name="cardIds">在生成的规则中，必须包含某几张牌的Id</param>
        /// <returns></returns>
        public static IRelation[] BuildVariableRelations(Card[] cards, params int[] cardIds)
        {
            List<IRelation> relations = new List<IRelation>();
            foreach (var cardArray in new CardThreeResolver().Resolve(cards, cardIds))
            {
                var relation = ParserFactory.Instance(ParserDefines.SameThreeParser).Parse(cardArray);
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.HumpParser).Parse(cardArray);
                }
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.StraightParser).Parse(cardArray);
                }
                if (relation != null)
                {
                    relations.Add(relation);
                }
            }
            return relations.ToArray();
        }

        /// <summary>
        /// 从手中的牌生成所有可变的规则集合，包括吃、提
        /// </summary>
        /// <param name="cards">手中的牌，或者包括当前摸的牌</param>
        /// <param name="cardIds">在生成的规则中，必须包含某几张牌的Id</param>
        /// <returns></returns>
        public static IRelation[] BuildVariableRelationsBySelf(Card[] cards, params int[] cardIds)
        {
            List<IRelation> relations = new List<IRelation>();
            foreach (var cardArray in new CardThreeResolver().Resolve(cards, cardIds))
            {
                var relation = ParserFactory.Instance(ParserDefines.SameThreeSelfParser).Parse(cardArray);
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.HumpParser).Parse(cardArray);
                }
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.StraightParser).Parse(cardArray);
                }
                if (relation != null)
                {
                    relations.Add(relation);
                }
            }
            return relations.ToArray();
        }       
    }
}
