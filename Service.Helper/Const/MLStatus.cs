using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helper.Const
{
    /// <summary>
    /// 排线的状态
    /// </summary>
    public struct MLStatus
    {
        /// <summary>
        /// 开线
        /// </summary>
        public const string OPEN = "OPEN";
        /// <summary>
        /// 切线
        /// </summary>
        public const string CHANGEOVER = "CHANGEOVER";
        /// <summary>
        /// 关线
        /// </summary>
        public const string CLOSE = "CLOSE";

    }

}
