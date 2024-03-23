using Agenda.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Net;

namespace Agenda.WebApi.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DbTransactionMiddleware> _logger;

        public DbTransactionMiddleware(RequestDelegate next,
            ILogger<DbTransactionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
                await HandleExceptionAsync(httpContext, e);
                _logger.LogError(e, $"Error {e.Message}");
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                errors = new string[] { "Erro inesperado. Por favor, tente novamente mais tarde ou entre em contato com o suporte." }
            });
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app)
            => app.UseMiddleware<DbTransactionMiddleware>();
    }

    public class TransactionAttribute : Attribute { }
}
