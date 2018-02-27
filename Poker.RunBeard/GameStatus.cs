using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard
{
    public enum GameStatus
    {
        /// <summary>
        /// 默认装填
        /// </summary>
        None = 0,
        /// <summary>
        /// 进行中
        /// </summary>
        Start = 1,
        /// <summary>
        /// 已完成
        /// </summary>
        Complete = 2
    }
}
