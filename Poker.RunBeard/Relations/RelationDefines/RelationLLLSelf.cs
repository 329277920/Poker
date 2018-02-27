using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationLLLSelf : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.LLL_Self; } }

        public int Score { get { return 6; } }
    }
}
