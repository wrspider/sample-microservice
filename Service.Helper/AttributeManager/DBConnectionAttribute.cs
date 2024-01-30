/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;

namespace Service.Helper.AttributeManager
{
    public class DBConnectionAttribute : Attribute
    {
        public string DBName { get; set; }
    }
}