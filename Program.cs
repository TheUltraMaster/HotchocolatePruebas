using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

builder.AddGraphQL().AddTypes().AddInMemorySubscriptions().AddProjections().AddFiltering().AddSorting().AddPagingArguments().AddSubscriptionDiagnostics();   // (Opcional) Habilitar ordenamiento;

builder.Services.AddDbContext<DbventaBlazorContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")).UseLazyLoadingProxies();
});
var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();


app.RunWithGraphQLCommands(args);
