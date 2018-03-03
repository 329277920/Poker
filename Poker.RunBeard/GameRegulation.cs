using Poker.RunBeard.Relations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard
{
    /// <summary>
    /// 封装游戏规则
    /// </summary>
    public class GameRegulation
    {
        /// <summary>
        /// 初始化用户手中的牌,提取出固定规则的牌
        /// </summary>
        /// <param name="cards"></param>
        /// <returns>返回Item1:剩余的牌,Item2:手中的固定规则,Item3:牌桌上的规定规则</returns>
        public static Tuple<Card[], IRelation[], IRelation[]> InitUserCards(params Card[] cards)
        {
            var relations = RelationFactory.BuildFixedRelations(cards, out Card[] outputCards);

            return new Tuple<Card[], IRelation[], IRelation[]>(
                    (from card in cards
                     where !outputCards.Contains(card)
                     select card).ToArray(),
                    (from relation in relations
                     where relation.RelationType == RelationTypes.LLL_Self
                        || relation.RelationType == RelationTypes.SSS_Self
                     select relation).ToArray(),
                    (from relation in relations
                     where relation.RelationType == RelationTypes.LLLL_Self
                        || relation.RelationType == RelationTypes.SSSS_Self
                     select relation).ToArray()
                );
        }

        /// <summary>
        /// 计算当前用户对当前牌允许的操作，不包含胡牌
        /// </summary>
        /// <param name="user"></param>
        /// <param name="currCard"></param>
        /// <returns></returns>
        public static IRelation[] CardOperations(GameUser user, CardPlay currCard)
        {           

            var isCurrUser = currCard.User.UserName.Equals(user.UserName);
            var isNext = !isCurrUser && currCard.User.NextUser.UserName.Equals(user.UserName);

            // 从固定规则中解析出跑、清
            IRelation outputRelation;
            var relation = RelationFactory.BuildRelationsByRelations(user.SelfRelations.ToArray(), out outputRelation, currCard.Card, currCard.IsUserPay, isCurrUser);
            if (relation == null)
            {
                relation = RelationFactory.BuildRelationsByRelations(user.Relations.ToArray(), out outputRelation, currCard.Card, currCard.IsUserPay, isCurrUser);
            }
            if (relation != null)
            {
                return new IRelation[] { relation };               
            }

            // 解析出其他规则
            Card[] outputCards;
            List<Card> tempCards = new List<Card>();
            tempCards.AddRange(user.Cards);
            tempCards.Add(currCard.Card);
            // 当前用户，解析出吃或提
            if (isCurrUser)
            {
                return RelationFactory.BuildVariableRelationsBySelf(tempCards.ToArray(),
                    out outputCards, currCard.Card.Id);
            }
            // 其他用户
            else
            {
                // 不是下家，只能碰
                if (!isNext)
                {
                    return RelationFactory.BuildCustomVariableRelations(tempCards.ToArray(),
                        new int[] { currCard.Card.Id }, out outputCards,
                        ParserDefines.SameThreeParser);
                }
                // 下家，可以碰、吃
                return RelationFactory.BuildVariableRelations(tempCards.ToArray(),
                    out outputCards, currCard.Card.Id);
            }                         
        }
    }
}
