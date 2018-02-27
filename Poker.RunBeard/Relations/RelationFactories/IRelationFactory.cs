using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 关系建立工厂接口
    /// </summary>
    public interface IRelationFactory
    {
        /// <summary>
        /// 从一组牌中解析出任意关系集合
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        IRelation[] Build(params Card[] cards);
    }
}
