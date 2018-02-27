using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    public abstract class RelationSameBaseFactory : IRelationFactory
    {       
        protected abstract IRelationParser Parser { get; }

        public virtual IRelation[] Build(params Card[] cards)
        {
            List<IRelation> relations = new List<IRelation>();
            List<Card> tempCards = new List<Card>();
            var code = 0;
            for (var i = 0; i < cards.Length; i++)
            {
                var card = cards[i];
                if (card.Code != code)
                {
                    var relation = Parser.Parse(tempCards.ToArray());
                    if (relation != null)
                    {
                        relations.Add(relation);
                    }
                    tempCards.Clear();
                }
            }
            return relations.ToArray();
        }
    }
}
