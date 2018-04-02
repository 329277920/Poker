using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Resolvers
{
    /// <summary>
    /// 将相同的牌组合在一起，如果不指定大小，则返回所有的分组
    /// </summary>
    public class SameResolver : IResolver
    {
        /// <summary>
        /// 按一定的规则分解牌,将牌分解成任意组合
        /// </summary>
        /// <param name="cards">需要分解的牌</param>
        /// <param name="size">分组大小</param>       
        /// <param name="filterCards">分解出的每一组牌，必须包含filterCards中定义的牌</param>
        /// <returns>返回按规则分组后的牌</returns>
        public virtual IEnumerable<TCard[]> Resolve<TCard>(TCard[] cards, int size,  params TCard[] filterCards)
            where TCard : ICard
        {            
            List<TCard[]> cardGroups = new List<TCard[]>();
            var temp = new List<TCard>();
            var code = 0;
            for (var i = 0; i < cards.Length; i++)
            {                
                if (code != cards[i].Code)
                {
                    AddGroup(cardGroups, temp.ToArray(), size, filterCards);                    
                    temp.Clear();
                    code = cards[i].Code;
                }
                temp.Add(cards[i]);
            }
            AddGroup(cardGroups, temp.ToArray(), size, filterCards);
            return cardGroups;
        }

        private void AddGroup<TCard>(List<TCard[]> cardGroups, TCard[] group, int size, params TCard[] filterCards)
            where TCard : ICard
        {
            if (group.Length > 0 && (size <= 0 || group.Length == size))
            {
                var isAdd = filterCards == null || filterCards.Length <= 0;
                if (!isAdd)
                {                    
                    for (var i = 0; i < filterCards.Length; i++)
                    {
                        // 因为按Code值分组，固只要某个分组中第一个的Code包含在filterCards中即可.
                        if (filterCards[i].Code == group[0].Code)
                        {
                            isAdd = !isAdd;
                            break;
                        }
                    }
                }
                if (isAdd)
                {
                    cardGroups.Add(group);
                }                
            }
        }
    }
}
