using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard
{
    /// <summary>
    /// 定义一张打出或系统发出的牌
    /// </summary>
    public class CardPlay
    {
        /// <summary>
        /// 获取当前牌
        /// </summary>
        public Card Card { get; private set; }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        public GameUser User { get; private set; }

        /// <summary>
        /// 获取是否用户打出的牌
        /// </summary>
        public bool IsUserPay { get; private set; }

        public CardPlay(Card card, GameUser user, bool isUserPay)
        {
            Card = card;
            User = user;
            IsUserPay = isUserPay;
        }
    }
}
