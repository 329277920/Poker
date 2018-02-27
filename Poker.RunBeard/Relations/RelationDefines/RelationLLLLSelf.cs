using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationLLLLSelf : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.LLLL_Self; } }

        public int Score { get { return 12; } }
    }
}
