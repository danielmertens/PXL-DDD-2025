using HarmonyTunes.Ports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/albums/create", async (CreateAlbumDto dto) =>
{
    // Create an album

    return Guid.NewGuid();
});

app.MapPost("/api/albums/change-details", async (AlbumDetailsDto dto) =>
{
    // Update an existing album
});

app.Run();
