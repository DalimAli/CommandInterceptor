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
            if(command.CommandType == System.Data.CommandType.Text && 
                command.CommandText.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
            {
                command.CommandText = string.Concat(command.CommandText, " WHERE CreatorName IS NOT NULL");
            }
        }

    }
}
