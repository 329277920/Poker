using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Resolvers
{
    /// <summary>
    /// 牌分解器
    /// </summary>
    public interface IResolver
    {
        /// <summary>
        /// 按一定的规则分解牌,将牌分解成任意组合
        /// </summary>
        /// <param name="cards">需要分解的牌</param>
        /// <param name="size">分组大小</param>
        /// <param name="funcEquals">校验两张牌是否为同一张</param>
        /// <param name="filterCards">分解出的每一组牌，必须包含filterCards中定义的牌</param>
        /// <returns>返回按规则分组后的牌</returns>
        IEnumerable<TCard[]> Resolve<TCard>(TCard[] cards, int size, Func<TCard, TCard, bool> funcEquals, params TCard[] filterCards);
    }
}
