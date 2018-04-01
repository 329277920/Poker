using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Resolvers
{
    /// <summary>
    /// 无规则分组,按指定数量分组成任意组
    /// </summary>
    public class NoneResolver : IResolver
    {
        /// <summary>
        /// 按一定的规则分解牌,将牌分解成任意组合
        /// </summary>
        /// <param name="cards">需要分解的牌</param>
        /// <param name="size">分组大小</param>
        /// <param name="funcEquals">校验两张牌是否为同一张</param>
        /// <param name="filterCards">分解出的每一组牌，必须包含filterCards中定义的牌</param>
        /// <returns>返回按规则分组后的牌</returns>
        public virtual IEnumerable<TCard[]> Resolve<TCard>(TCard[] cards, int size, Func<TCard,TCard,bool> funcEquals, params TCard[] filterCards)            
        {
            if (size <= 1 || size > cards.Length)
            {
                throw new ArgumentException("参数size必须大于1，小于或等于cards长度。");
            }

            List<TCard[]> cardGroups = new List<TCard[]>();

            // 计算需要为多少张牌计算组合
            var startCards = filterCards != null && filterCards.Length > 0
                ? filterCards : cards;

            // 复制cards副本
            var newCards = new TCard[cards.Length];
            for (var i = 0; i < cards.Length; i++)
            {
                newCards[i] = cards[i];
            }

            // 循环计算组合，每个组合以startCards的每一张牌开头，相应的在cards中需要移除该牌
            for (var i = 0; i < startCards.Length; i++)
            {
                ResolveItem(cardGroups, newCards, size, 0, funcEquals, startCards[i]);
            }
            return cardGroups;
        }

        private void ResolveItem<TCard>(List<TCard[]> cardGroups, TCard[] cards, 
            int size, int start, Func<TCard, TCard, bool> funcEquals, params TCard[] tempCards)            
        {
            for (var i = start; i < cards.Length; i++)
            {
                var currCard = cards[i];

                // 判断牌是否被移除
                if(funcEquals(currCard, default(TCard)))
                // if (EqualityComparer<TCard>.Default.Equals(currCard, default(TCard)))
                {
                    continue;
                }
                // 从cards中移除当前牌，避免重复
                if (funcEquals(tempCards[0], currCard))
                // if (EqualityComparer<TCard>.Default.Equals(tempCards[0], currCard))
                {
                    cards[i] = default(TCard);
                    continue;
                }                                
                // 将当前牌加入到tempCards,做为下一轮计算的前缀
                var nextCards = new TCard[tempCards.Length + 1];
                for (var j = 0; j < tempCards.Length; j++)
                {
                    nextCards[j] = tempCards[j];
                }
                nextCards[nextCards.Length - 1] = currCard;
                // 满足要求，加入到结果中
                if (nextCards.Length == size)
                {
                    cardGroups.Add(nextCards);
                    continue;
                }
                // 计算加入后续的牌
                ResolveItem(cardGroups, cards, size, i + 1, funcEquals, nextCards);
            }             
        }
    }
}
