using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helper.Enums
{
    public enum ActionPermissionOptions
    {
        add = 0,
        delete = 1,
        update = 2,
        search=3,
        export=4,
        audit,
        upload,//上传文件
        import //导入表数据Excel
    }
}
