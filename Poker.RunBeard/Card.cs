using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard
{
    /// <summary>
    /// 定义一张纸牌
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 唯一编号(1-80)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 点数(1-10)
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 是否为大牌
        /// </summary>
        public bool IsLarge { get; set; }

        /// <summary>
        /// 获取或设置该牌在用户手中的唯一Id
        /// </summary>
        public int UserUniqueId { get; set; }

        /// <summary>
        /// 获取或设置该牌的Code值，小牌为1-10，大牌未11-20
        /// </summary>
        public int Code { get { return IsLarge ? 10 + Num : Num; } }
        
        public override string ToString()
        {
            return  IsLarge ? largeNums[Num - 1] : smallNums[Num - 1];
        }

        private static string[] largeNums = new string[] { "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
        private static string[] smallNums = new string[] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
         
    }
}
