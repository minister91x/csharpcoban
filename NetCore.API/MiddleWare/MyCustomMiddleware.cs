namespace NetCore.API.MiddleWare
{
    public class MyCustomMiddleware
    {
        // có hàm khởi tạo

        public RequestDelegate _next { get; set; }
        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // xử lý request
            //await _next(context);// gọi đến middleware tiếp theo
            // xử lý response
            context.Response.Headers.Add("Hackerby", "MRQUAN");
            await _next(context);
            // await context.Response.WriteAsync("Hello world!");
        }
        // có hàm invoke để xử lý request
    }
}
