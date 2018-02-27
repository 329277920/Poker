using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker.RunBeard.Relations
{
    public class Relation123Small : RelationBase, IRelation
    {
        public RelationTypes RelationType { get { return RelationTypes.Small123; } }

        public int Score { get { return 3; } }
    }
}

