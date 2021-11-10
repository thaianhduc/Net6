using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

var name = "Thai Anh Duc";
string customName;

string cn = (name) switch
{
    "Hello" => customName = name,
    _ => throw new global::System.NotImplementedException(),
};

switch (name) {
    case "Hello":
        break;
    case "H":
        break;
}

app.MapGet("/", (Func<string>)(() => "Hello World!"));
app.MapGet("/hello", (Func<string>)(() => "Hello Thai Anh Duc!"));


await app.RunAsync();

