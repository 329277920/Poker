using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 记录一个2710的关系
    /// </summary>
    public class Relation2710Big : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.Big2710; } }
       
        
        public int Score { get { return 6; } }
    }
}
