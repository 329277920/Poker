using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationLLLL : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.LLLL; } }

        public int Score { get { return 9; } }
    }
}
