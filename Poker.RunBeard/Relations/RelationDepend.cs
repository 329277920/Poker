using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 封装一个依赖，代表一个关系的出现，必须带上子关系中的一个，如吃、比
    /// </summary>
    public class RelationDepend
    {
        public IRelation Relation { get; set; }

        public IRelation[] DependRelations { get; set; }
    }
}
