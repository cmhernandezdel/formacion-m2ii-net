using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Example.EntityFramework.Infrastructure.EntityFramework.Interceptors;

public sealed class LoggingInterceptor() : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        Console.WriteLine(command.CommandText);
        return base.ReaderExecuting(command, eventData, result);
    }

    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        Console.WriteLine(command.CommandText);
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
    {
        Console.WriteLine(command.CommandText);
        return base.ScalarExecuting(command, eventData, result);
    }
}
