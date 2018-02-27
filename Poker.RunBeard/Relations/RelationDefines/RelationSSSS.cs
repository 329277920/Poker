using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationSSSS : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.SSSS; } }

        public int Score { get { return 6; } }
    }
}

