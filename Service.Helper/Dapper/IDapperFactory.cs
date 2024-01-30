using Dapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.Dapper
{
    public interface IDapperFactory
    {
        public SqlDapper CreateClient();
    }

}
