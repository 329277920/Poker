using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard.Relations
{
    public class RelationHump : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.Hump; } }

        public int Score { get { return 0; } }
    }
}