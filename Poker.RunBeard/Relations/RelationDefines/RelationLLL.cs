using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationLLL : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.LLL; } }

        public int Score { get { return 3; } }
    }
}
