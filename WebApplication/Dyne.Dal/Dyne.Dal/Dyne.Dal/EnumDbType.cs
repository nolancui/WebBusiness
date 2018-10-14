using System;
using System.Collections.Generic;
using System.Text;

namespace Dyne.Dal
{
    /// <summary>
    /// 操作数据库类型
    /// </summary>
    public enum EnumDbType
    {
        /// <summary>
        /// oracle数据库
        /// </summary>
        DbOracle,
        /// <summary>
        /// sqlServer数据库
        /// </summary>
        DbSqlServer,
        /// <summary>
        /// oledb数据库
        /// </summary>
        DbOleDb
    }
}
