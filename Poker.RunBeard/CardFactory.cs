using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard
{
    /// <summary>
    /// 封装一个生成牌的工厂
    /// </summary>
    public class CardFactory
    {
        /// <summary>
        /// 生成一副牌
        /// </summary>
        /// <returns></returns>
        public static Card[] Build()
        {
            var redCard = new int[] { 2, 7, 10 };
            var autoId = 0;
            var cards = new List<Card>();          
            // 牌号随机生成
            var ids = Utinity.BuildIntArray(1, 80).RandomSort().ToArray();
            for (var num = 1; num <= 10; num++)
            {
                for (var j = 0; j <= 3; j++)
                {
                    cards.AddRange(new Card[]
                    {
                        new Card() { Num = num, IsLarge = false, Id = ids[autoId++] },
                        new Card() { Num = num, IsLarge = true, Id = ids[autoId++]}
                    });
                }
            }
            // 洗牌
            cards.Sort((i1, i2) => i1.Id.CompareTo(i2.Id));             
            return cards.ToArray();
        }
    }
}
