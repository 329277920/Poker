using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class Relation123Big : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.Big123; } }

        public int Score { get { return 6; } }
    }
}
