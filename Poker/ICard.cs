using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    /// <summary>
    /// 定义一张牌的通用接口
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// 获取该牌的唯一Id
        /// </summary>
        int Id { get;  }

        /// <summary>
        /// 获取该牌的Code，用于标识两张牌是否相等
        /// </summary>
        int Code { get;  }
    }
}
