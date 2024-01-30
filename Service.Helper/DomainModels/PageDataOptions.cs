using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.DomainModels
{
    public class PageDataOptions
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 每一页行数，不分页可不传
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 总数，可不传
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 表名，可不传
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 要排序的字段名称
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 排序方式，asc/desc
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 使用dapper查询时排序的字符串
        /// </summary>
        public string OrderByString { get; set; }
        /// <summary>
        /// 查询条件，按照SearchParameters的对象格式转为json字符串
        /// </summary>
        public string Wheres { get; set; }
        /// <summary>
        /// 是否用作导出
        /// </summary>
        public bool Export { get; set; }
        /// <summary>
        /// 额外传入的值
        /// </summary>
        public object Value { get; set; }
        public string Language { get; set; }
        /// <summary>
        /// 绑定的字典表数据
        /// </summary>
        public List<Dictionary> Dictionaries { get; set; }
        /// <summary>
        /// 导出时传入的字段信息，包含多语系和绑定的字典数据
        /// </summary>
        public List<Column> Columns { get; set; }
    }

    public class Column
    {
        public Title Title { get; set; }
        public string Index { get; set; }
        public bool? IsI18n { get; set; }
        public Title ParentTitle { get; set; }
        public List<Column> Children { get; set; }
    }

    public class Title
    {
        public string Text { get; set; }
        public string I18n { get; set; }
        public string TextValue { get; set; }
    }

    public class SearchParameters
    {
        /// <summary>
        /// 查询的字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 查询的字段值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 查询条件，对应HtmlElementType中的类型
        /// </summary>
        public string DisplayType { get; set; }
        /// <summary>
        /// 查询的字段值数组，一般用来处理in等多个选中的条件
        /// </summary>
        public string[] Values { get; set; }
        /// <summary>
        /// 值类型,当为时间类型时需要指定
        /// </summary>
        public string ValueType { get; set; }
    }

    public class Dictionary
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string index { get; set; }
        /// <summary>
        /// 字典数据
        /// </summary>
        public List<Data> datas { get; set; }
    }

    public class Data
    {
        public string key { get; set; }
        public string value { get; set; }
        public string label { get; set; }
    }
    public class MachineErrorCode
    {
        public string copy_From { get; set; }
        public string copy_To { get; set; }
    }

    public class StringSelectOption
    {
        public string value { get; set; }
        public string label { get; set; }
    }

    public class ExportColumn
    {
        /// <summary>
        /// 栏位名称
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 导出顺序
        /// </summary>
        public int? OrderIndex { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 翻译后栏位名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// 小数精确位数
        /// </summary>
        public int Digit { get; set; }
        public Title Title { get; set; }
        public Title ParentTitle { get; set; }
        public List<ExportColumn> ChildColumns { get; set; }
    }
}
