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
        /// <param name="includeCards">输出计算该规则包含的牌</param>
        /// <returns></returns>
        public static IRelation[] BuildFixedRelations(Card[] cards,out Card[] outputCards)
        {
            List<IRelation> relations = new List<IRelation>();
            List<Card> includeCards = new List<Card>();
            foreach (var cardArray in new CardSameResolver().Resolve(cards))
            {
                var relation = ParserFactory.Instance(ParserDefines.SameFourSelfParser).Parse(cardArray);
                if (relation == null)
                {
                    relation = ParserFactory.Instance(ParserDefines.SameThreeSelfParser).Parse(cardArray);
                }
                if (relation != null)
                {
                    includeCards.AddRange(relation.Cards);
                    relations.Add(relation);
                }
            }
            outputCards = includeCards.ToArray();
            return relations.ToArray();
        }

        /// <summary>
        /// 从手中的牌生成所有可变的规则集合，包括吃、碰
        /// </summary>
        /// <param name="cards">手中的牌，或者包括当前摸的牌</param>
        /// <param name="outputCards">输出计算该规则包含的牌</param>
        /// <param name="cardIds">在生成的规则中，必须包含某几张牌的Id</param>
        /// <returns></returns>
        public static IRelation[] BuildVariableRelations(Card[] cards, out Card[] outputCards, params int[] cardIds)
        {
            return BuildCustomVariableRelations(cards, cardIds, out outputCards,
                ParserDefines.SameThreeParser,
                ParserDefines.HumpParser,
                ParserDefines.StraightParser);             
        }

        /// <summary>
        /// 从手中的牌生成所有可变的规则集合，包括吃、提
        /// </summary>
        /// <param name="cards">手中的牌，或者包括当前摸的牌</param>
        /// <param name="outputCards">输出计算该规则包含的牌</param>
        /// <param name="cardIds">在生成的规则中，必须包含某几张牌的Id</param>
        /// <returns></returns>
        public static IRelation[] BuildVariableRelationsBySelf(Card[] cards, out Card[] outputCards, params int[] cardIds)
        {
            var relations = BuildCustomVariableRelations(cards, cardIds, out outputCards,
                ParserDefines.SameThreeSelfParser,
                ParserDefines.HumpParser,
                ParserDefines.StraightParser);
            foreach (var relation in relations)
            {
                // 判断如果包含提，则直接返回
                if (relation.RelationType == RelationTypes.LLL || relation.RelationType == RelationTypes.SSS)
                {
                    outputCards = relation.Cards;
                    return new IRelation[] { relation };
                }
            }
            return relations;
        }

        /// <summary>
        /// 从手中的牌生成所有可变的规则集合（3张）
        /// </summary>
        /// <param name="cards">手中的牌，或者包括当前摸的牌</param>
        /// <param name="cardIds">在生成的规则中，必须包含某几张牌的Id</param>
        /// <param name="includeCards">输出计算该规则包含的牌</param>
        /// <param name="parsers">解析规则列表</param>
        /// <returns></returns>
        public static IRelation[] BuildCustomVariableRelations(Card[] cards, int[] cardIds, out Card[] outputCards,  params ParserDefines[] parsers)
        {
            List<IRelation> relations = new List<IRelation>();
            List<Card> includeCards = new List<Card>();
            foreach (var cardArray in new CardThreeResolver().Resolve(cards, cardIds))
            {
                IRelation relation = null;
                foreach (var parser in parsers)
                {
                    relation = ParserFactory.Instance(parser).Parse(cardArray);
                    if (relation != null)
                    {
                        break;
                    }
                }
                if (relation != null)
                {
                    relations.Add(relation);
                    for (var i = 0; i < relation.Cards.Length; i++)
                    {
                        if (!includeCards.Contains(relation.Cards[i]))
                        {
                            includeCards.Add(relation.Cards[i]);
                        }
                    }
                }
            }
            outputCards = includeCards.ToArray();
            return relations.ToArray();
        }

        /// <summary>
        /// 从固定规则中生成新规则，跑、提
        /// </summary>
        /// <param name="relations">已经规定的规则，包括碰、提</param>
        /// <param name="outputRelation">输出被变更的规则</param>
        /// <param name="card">当前的牌</param>
        /// <param name="isUserPlay">是否为用户打出的牌</param>
        /// <param name="isCurrUser">是否为当前用户</param>
        /// <returns></returns>
        public static IRelation BuildRelationsByRelations(IRelation[] relations, out IRelation outputRelation, Card card, bool isUserPlay, bool isCurrUser)
        {
            outputRelation = null;
            List<Card> tempCards = new List<Card>();
            IRelation resultRelation = null;
            foreach (var relation in relations)
            {
                // 校验是否能跑
                if (relation.RelationType == RelationTypes.LLL || relation.RelationType == RelationTypes.SSS)
                {
                    // 用户打出的牌，不允许碰-》跑
                    if (isUserPlay)
                    {
                        continue;
                    }
                    tempCards.AddRange(relation.Cards);
                    tempCards.Add(card);
                    resultRelation = ParserFactory.Instance(ParserDefines.SameFourParser).Parse(tempCards.ToArray());
                }

                // 校验是否能跑、清
                if (relation.RelationType == RelationTypes.LLL_Self || relation.RelationType == RelationTypes.SSS_Self)
                {                     
                    tempCards.AddRange(relation.Cards);
                    tempCards.Add(card);
                    if (isCurrUser)
                    {
                        // 检测清
                        resultRelation = ParserFactory.Instance(ParserDefines.SameFourSelfParser).Parse(tempCards.ToArray());
                    }
                    else
                    {
                        // 检测跑
                        resultRelation = ParserFactory.Instance(ParserDefines.SameFourParser).Parse(tempCards.ToArray());
                    }
                }
                if (resultRelation != null)
                {
                    outputRelation = relation;
                    break;
                }                 
            }
            return resultRelation;
        }         
    }
}
