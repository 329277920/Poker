using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 定义一个关系接口
    /// </summary>
    public interface IRelation
    {
        /// <summary>
        /// 获取关系类型
        /// </summary>
        RelationTypes RelationType { get; }

        /// <summary>
        /// 获取该关系的分值
        /// </summary>
        /// <returns></returns>
        int Score { get; }

        /// <summary>
        /// 获取或设置该关系包含的纸牌
        /// </summary>
        Card[] Cards { get; set; }
    }
}
