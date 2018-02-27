using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations.RelationFactories
{
    /// <summary>
    /// 从一组牌中解析出清
    /// </summary>
    public class RelationSameFourSelfFactory : RelationSameBaseFactory
    {
        private IRelationParser _parser = new SameFourSelfParser();
        protected override IRelationParser Parser => _parser;
    }
}
