using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationLL : RelationBase, IRelation
    {
        public RelationTypes RelationType => RelationTypes.LL;

        public int Score { get { return 0; } }
    }
}
