using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.RunBeard.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.RunBeard;

namespace Poker.Tester
{
    [TestClass]
    public class RelationFactoryTester : BaseTester
    {
        [TestMethod]
        public void TestBuildFixedRelations()
        {
            var source = CardSource(21);
            foreach (var relation in RelationFactory.BuildFixedRelations(source, out Card[] outputCards))
            {
                WriteLine(relation);
            }
        }

        /// <summary>
        /// 生成任意3张规则
        /// </summary>
        [TestMethod]
        public void TestBuildVariableRelations()
        {            
            var source = CardSource(21);
            foreach (var relation in RelationFactory.BuildVariableRelations(source, out Card[] outputCards))
            {
                WriteLine(relation);
            }
        }

        /// <summary>
        /// 生成任意3张规则，仅包含某张牌
        /// </summary>
        [TestMethod]
        public void TestBuildVariableRelations2()
        {           
            var source = CardSource(21);
            foreach (var relation in RelationFactory.BuildVariableRelations(source, out Card[] outputCards, source[0]))
            {
                WriteLine(relation);                 
            }
        }

        /// <summary>
        /// 生成任意3张规则，仅包含某张牌
        /// </summary>
        [TestMethod]
        public void BuildVariableRelationsBySelf()
        {
            var source = CardSource(21);
            foreach (var relation in RelationFactory.BuildVariableRelationsBySelf(source,out Card[] outputCards, source[0]))
            {
                WriteLine(relation);                 
            }
        }
    }
}
