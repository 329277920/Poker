using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public class RelationSSSSSelf : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.SSSS_Self; } }

        public int Score { get { return 9; } }
    }
}
