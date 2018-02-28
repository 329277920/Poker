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


    }
}
