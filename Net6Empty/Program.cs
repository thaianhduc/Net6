// Enable <ImplicitUsing> allows to have a set of default global using for Web Application

var builder = WebApplication.CreateBuilder(args);

/*
 * The builder has a couple of things
 * 1. Configuration: Setup configuration
 * 2. Services: Setup services and dependencies
 * 3. Host, WebHost: Configure the host
 * 4. Environment: Access the environment variables
 * 
 * Finally, it Build the app
 */

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

