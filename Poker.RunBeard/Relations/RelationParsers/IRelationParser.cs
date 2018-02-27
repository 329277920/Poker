using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 关系解析器接口
    /// </summary>
    public interface IRelationParser
    {
        /// <summary>
        /// 从指定数量的牌中解析出关系，牌的排序规则应该是从小到大，类型从大到小
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        IRelation Parse(params Card[] cards);
    }
}
