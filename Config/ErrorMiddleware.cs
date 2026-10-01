using DeskFlowApi.DTO;
using DeskFlowApi.Exceptions;
using Microsoft.Identity.Client.NativeInterop;

namespace DeskFlowApi.Config
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (IDNaoExistenteOuInvalidoException err)
            {
                Console.WriteLine("Não encontrado");

                context.Response.StatusCode = 404;
                var resposta = new ErrorDTO(err.Message);
                await context.Response.WriteAsJsonAsync(resposta);
            }
            catch (AtendimentoFechadoException err)
            {
                context.Response.StatusCode = 400;
                var resposta = new ErrorDTO(err.Message);
                await context.Response.WriteAsJsonAsync(resposta);
            }
        }
    }
}