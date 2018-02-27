using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard
{
    /// <summary>
    /// 游戏引擎，封装一个牌局
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// 牌局号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 牌局状态
        /// </summary>
        public GameStatus Status { get; set; }

        /// <summary>
        /// 记录当前应出牌用户
        /// </summary>
        public GameUser CurrentUser { get; private set; }

        /// <summary>
        /// 记录庄家
        /// </summary>
        public GameUser MakerUser { get; private set; }

        /// <summary>
        /// 记录未发的牌
        /// </summary>
        public Queue<Card> Cards { get; private set; }

        /// <summary>
        /// 记录所有用户
        /// </summary>
        public List<GameUser> Users { get; private set; }

        /// <summary>
        /// 设置最大用户数
        /// </summary>
        private int _maxUser = 3;

        /// <summary>
        /// 初始化牌局
        /// </summary>
        public GameEngine()
        {
            Status = GameStatus.None;
            Cards = new Queue<Card>();
            Users = new List<GameUser>();
            Shuffle();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(GameUser user)
        {
            if (Status != GameStatus.None)
            {
                throw new Exception("出错,已经开始");
            }
            var oldUser = FindUser(user.UserName);
            if (oldUser != null)
            {
                return;
            }
            if (Users.Count >= _maxUser)
            {
                throw new Exception("出错,用户数太多");
            }
            if (user.IsMakers)
            {
                if (MakerUser != null)
                {
                    throw new Exception("出错,两个庄家");
                }
                MakerUser = user;
            }
            Users.Add(user);
            if (CurrentUser != null)
            {
                CurrentUser.NextUser = user;
            }
            CurrentUser = user;
            if (Users.Count == _maxUser)
            {
                user.NextUser = Users[0];
            }
        }

        /// <summary>
        /// 用户开始打牌
        /// <paramref name="userName"/>
        /// </summary>
        public void UserStart(string userName)
        {
            if (Status != GameStatus.None)
            {
                throw new Exception("出错,已经开始");
            }
            var user = FindUser(userName);
            if (user == null)
            {
                throw new Exception("出错,用户不存在");
            }
            user.IsReady = true;

            if (Users.Count == _maxUser &&
                Users.FirstOrDefault(item => item.IsReady == false) == null)
            {
                InitSendCard();
            }
        }

        /// <summary>
        /// 发牌
        /// </summary>
        public Card SendCard()
        {
            return null;
        }

        /// <summary>
        /// 出牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void ThrowCard(GameUser user, Card card)
        {
            //// 校验是否为当前用户
            //if (user.UserName != CurrentUser.UserName)
            //{
            //    throw new Exception("出错,不是当前用户");
            //}
            //var oldUser = FindUser(user.UserName);
            //if (oldUser == null)
            //{
            //    throw new Exception("出错,用户未找到");
            //}
            //oldUser.ThrowCard(card);

            //CurrentUser = oldUser.NextUser;

            // todo: 通知其他用户
        }

        #region 私有成员

        /// <summary>
        /// 洗牌
        /// </summary>
        public Card[] Shuffle()
        {
            var redCard = new int[] { 2, 7, 10 };
            var autoId = 0;
            var cards = new List<Card>();
            Cards = new Queue<Card>();
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
            foreach (var card in cards)
            {
                Cards.Enqueue(card);
            }
            return cards.ToArray();
        }

        /// <summary>
        /// 初始化发牌
        /// </summary>
        private void InitSendCard()
        {
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < Users.Count; j++)
                {
                    Users[j].Cards.Add(Cards.Dequeue());
                }
            }
            MakerUser.Cards.Add(Cards.Dequeue());
            // 设置第一次出牌用户为庄家
            CurrentUser = MakerUser;
            Status = GameStatus.Start;
        }

        private GameUser FindUser(string user)
        {
            return Users.FirstOrDefault(u => u.UserName.Equals(user));
        }
        #endregion
    }
}

