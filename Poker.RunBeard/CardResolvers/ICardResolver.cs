using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.CardResolvers
{
    /// <summary>
    /// 牌分解器接口
    /// </summary>
    public interface ICardResolver
    {
        /// <summary>
        /// 按一定的规则分解牌
        /// </summary>
        /// <param name="cards">需要分解的牌</param>
        /// <param name="cardIds">分解出的牌必须包含cardIds的其中一个</param>
        /// <returns></returns>
        List<Card[]> Resolve(Card[] cards, params int[] cardIds);
    }
}
