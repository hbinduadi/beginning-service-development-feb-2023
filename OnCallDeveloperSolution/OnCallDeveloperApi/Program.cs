using OnCallDeveloperApi.Models;

var builder = WebApplication.CreateBuilder(args);

//the builder is the thing we use to configure our application "behind the scenes" - this is mostly hooking up
//services that outr is going to need

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// The builder "builds" our configured application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/oncalldeveloper", () =>
{
    var contact = new OnCallDeveloperContact("Bob", "Smith", "Bob@aol.com", "xt123");
    var response = new OnCallDeveloperResponse(contact);
    return Results.Ok(response);
});

app.Run(); // This is a "Blocking call"
// It basically starys a loop where it will Listen for incoming HTTP request and try to precess them
//until the application is shut down.


