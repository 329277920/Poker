using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 关系类型
    /// </summary>
    public enum RelationTypes
    {
        /// <summary>
        /// 壹贰叁
        /// </summary>
        Big123 = 1,
        /// <summary>
        /// 一二三
        /// </summary>
        Small123 = 2,
        /// <summary>
        /// 贰柒拾
        /// </summary>
        Big2710 = 3,
        /// <summary>
        /// 二七十
        /// </summary>
        Small2710 = 4,
        /// <summary>
        /// 其他顺子
        /// </summary>
        Straight = 5,
        /// <summary>
        /// 驼峰式关系，大大小|小小大
        /// </summary>
        Hump = 6,        
        /// <summary>
        /// 大大大（碰）
        /// </summary>
        LLL = 7,
        /// <summary>
        /// 小小小（碰）
        /// </summary>
        SSS = 8,
        /// <summary>
        /// 大大大（提）
        /// </summary>
        LLL_Self = 9,
        /// <summary>
        /// 小小小（提）
        /// </summary>
        SSS_Self = 10,
        /// <summary>
        /// 大大大大（跑）
        /// </summary>
        LLLL = 11,
        /// <summary>
        /// 小小小小（跑）
        /// </summary>
        SSSS = 12,
        /// <summary>
        /// 大大大大（清）
        /// </summary>
        LLLL_Self = 13,
        /// <summary>
        /// 小小小小（清）
        /// </summary>
        SSSS_Self = 14,
        /// <summary>
        /// 特殊组合，在跑过以后允许1个这种组合（大大、小小）
        /// </summary>
        LL = 15
    }
}
