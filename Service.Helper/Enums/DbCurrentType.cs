﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helper.Enums
{
    public enum DbCurrentType
    {
        Default = 0,
        MySql = 1,
        MsSql = 2,//2020.08.08修改sqlserver拼写
        PgSql = 3,
        Vertica = 4
    }
}
