using Agenda.Data.Contexts;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Agenda.WebApi.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;
        

        public DbTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, AgendaDbContext agendaDbContext)
        {
            // Método GET não precisa de transação.
            if (httpContext.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                await _next(httpContext);
                return;
            }

            // Em caso de TransactionAttribute não definido pula a transação.
            var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
            var attribute = endpoint?.Metadata.GetMetadata<TransactionAttribute>();
            if (attribute is null)
            {
                await _next(httpContext);
                return;
            }

            IDbContextTransaction transaction = null;

            try
            {
                transaction = agendaDbContext.Database.BeginTransaction();

                await _next(httpContext);

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app)
            => app.UseMiddleware<DbTransactionMiddleware>();
    }

    public class TransactionAttribute : Attribute { }
}
