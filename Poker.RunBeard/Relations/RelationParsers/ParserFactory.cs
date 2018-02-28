using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Poker.RunBeard.Relations
{
    /// <summary>
    /// 解析器工厂类，负责创建一个解析器实例
    /// </summary>
    public class ParserFactory
    {
        private static UnityContainer Container;

        static ParserFactory()
        {
            Container = new UnityContainer();
            Container.RegisterSingleton<IRelationParser, SameFourParser>(ParserDefines.SameFourParser.ToString());
            Container.RegisterSingleton<IRelationParser, HumpParser>(ParserDefines.HumpParser.ToString());
            Container.RegisterSingleton<IRelationParser, SameFourSelfParser>(ParserDefines.SameFourSelfParser.ToString());
            Container.RegisterSingleton<IRelationParser, SameThreeParser>(ParserDefines.SameThreeParser.ToString());
            Container.RegisterSingleton<IRelationParser, SameThreeSelfParser>(ParserDefines.SameThreeSelfParser.ToString());
            Container.RegisterSingleton<IRelationParser, SameTwoSelfParser>(ParserDefines.SameTwoSelfParser.ToString());
            Container.RegisterSingleton<IRelationParser, StraightParser>(ParserDefines.StraightParser.ToString());
        }

        /// <summary>
        /// 获得一个解析器实例
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static IRelationParser Instance(ParserDefines parser)
        {
            return Container.Resolve<IRelationParser>(parser.ToString());
        }
    }
}
