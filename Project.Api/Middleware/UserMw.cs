using Microsoft.AspNetCore.Http;
using Project.Business.Logger;
using System;
using System.Threading.Tasks;

namespace Project.Api.Middleware {
    public class UserMw {
        public readonly RequestDelegate _next;
        public readonly ILogger _logger;
        public UserMw(RequestDelegate next, ILogger logger) {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext context) {
            Logging(context);
            await _next(context);
        }

        private void Logging(HttpContext context) {
            var logMesg = ("**" + DateTime.Now + $" : Request method: {context.Request?.Method} & url: {context.Request?.Path.Value} & status: {context.Response?.StatusCode} & connectionId: {context.Connection.Id}");
            _logger.WriteLog(logMesg);
        }
    }
}
