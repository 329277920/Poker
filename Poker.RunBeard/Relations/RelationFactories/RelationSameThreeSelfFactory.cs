using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 从一组牌中解析出提
    /// </summary>
    public class RelationSameThreeSelfFactory : RelationSameBaseFactory
    {
        private IRelationParser _parser = new SameThreeSelfParser();
        protected override IRelationParser Parser => _parser;
    }
}

