using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Poker.RunBeard.Relations;

namespace Poker.RunBeard
{
    /// <summary>
    /// 封装一个参与用户
    /// </summary>
    public class GameUser
    {
        public string UserName { get; set; }

        /// <summary>
        /// 获取该用户的下家
        /// </summary>
        internal GameUser NextUser { get; set; }

        /// <summary>
        /// 是否为该局的庄家
        /// </summary>
        public bool IsMakers { get; set; }

        /// <summary>
        /// 手里的牌
        /// </summary>
        public List<Card> Cards { get; private set; }

        /// <summary>
        /// 记录手中的，固定的关系，通常是提
        /// </summary>
        public List<IRelation> SelfRelations { get; private set; }

        /// <summary>
        /// 记录牌桌的，固定的关系
        /// </summary>
        public List<IRelation> Relations { get; private set; }

        /// <summary>
        /// 是否准备
        /// </summary>
        public bool IsReady { get; set; }        

        public GameUser()
        {
            IsMakers = false;
            Cards = new List<Card>();
            SelfRelations = new List<IRelation>();
            Relations = new List<IRelation>();
            IsReady = false;
        }

        /// <summary>
        /// 出牌
        /// </summary>
        /// <param name="cardId">牌唯一Id</param>
        public void ThrowCard(int cardId)
        {
            // 检测牌是否在用户手中
            var card = Cards.FirstOrDefault(item => item.Id == cardId);
            if (card == null)
            {
                throw new Exception("出错,没有牌");
            }
            Cards.Remove(card);
        }
    }
}
