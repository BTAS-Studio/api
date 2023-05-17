using BTAS.API.Models;
using BTAS.API.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTAS.API
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;


        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            AuthenticationRepository _authRepo = new();

            var response = JsonConvert.DeserializeObject<GeneralResponse>(await _authRepo.ValidateTokenAsync(context.Request.Headers["apikey"], context.Request.Headers["apiToken"], context.Request.Headers["shipperId"]));

            if (response.success || context.Request.Headers["web"]=="true")
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 401; //Unauthorized
                var bytes = Encoding.UTF8.GetBytes("Forbidden. Request is missing valid credentials. Token has expired.");

                await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                return;
            }
        }
    }

}
