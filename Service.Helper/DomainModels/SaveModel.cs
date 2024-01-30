using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.DomainModels
{
    public class SaveModel
    {
        /// <summary>
        /// 单条主表数据
        /// </summary>
        public Dictionary<string, object> MainData { get; set; }
        /// <summary>
        /// 多条子表数据
        /// </summary>
        public List<Dictionary<string, object>> DetailData { get; set; }
        /// <summary>
        /// 要删除的子表数据的主键
        /// </summary>
        public List<object> DelKeys { get; set; }
        public string Language { get; set; }

        /// <summary>
        /// 从前台传入的其他参数(自定义扩展可以使用)
        /// </summary>
        public object Extra { get; set; }
    }
}
