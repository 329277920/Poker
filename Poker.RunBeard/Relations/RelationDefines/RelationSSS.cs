using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationSSS : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.SSS; } }

        public int Score { get { return 1; } }
    }
}

