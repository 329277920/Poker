using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationStraightSmall : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.Straight; } }

        public int Score { get { return 0; } }
    }
}

