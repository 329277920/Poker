using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationSSSSelf : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.SSS_Self; } }

        public int Score { get { return 3; } }
    }
}

