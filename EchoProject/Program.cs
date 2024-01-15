using EchoProject.Model;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.Map("{**path}", async (HttpContext context) =>
{
	var requestInfo = new Request
	{
		Url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
		Method = context.Request.Method,
		UrlParts = context.Request.Path.Value?.Split('/'),
		Params = context.Request.Query.ToDictionary(x => x.Key, x => x.Value.ToString()),
		Headers = context.Request.Headers.ToDictionary(x => x.Key, x => x.Value.ToString()),
		Body = await new StreamReader(context.Request.Body).ReadToEndAsync()
	};

	return requestInfo;
});

app.Run();
