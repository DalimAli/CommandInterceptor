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

        public override void CommandCanceled(DbCommand command, CommandEndEventData eventData)
        {
            base.CommandCanceled(command, eventData);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override ValueTask<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            return base.NonQueryExecutingAsync(command, eventData, result, cancellationToken);
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
