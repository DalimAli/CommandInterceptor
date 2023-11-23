using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace CommandInterceptor.Data
{
    public class CheckQueryCommandInterceptor : DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            ManipulateCommand(command);
            return base.ReaderExecuting(command, eventData, result);
        }

        private void ManipulateCommand(DbCommand command)
        {
            // do something 
        }

    }
}
