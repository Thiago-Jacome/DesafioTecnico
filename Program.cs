var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();




app.MapControllers();

app.Run();
