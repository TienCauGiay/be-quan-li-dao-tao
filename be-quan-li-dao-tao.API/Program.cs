using be_quan_li_dao_tao.BL.BL;
using be_quan_li_dao_tao.BL.Interfaces.BL;
using be_quan_li_dao_tao.BL.Interfaces.DL;
using be_quan_li_dao_tao.BL.Interfaces.UnitOfWork;
using be_quan_li_dao_tao.DL.DL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Policy
builder.Services.AddCors();

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddScoped<IRoleDL, RoleDL>();
builder.Services.AddScoped<IRoleBL, RoleBL>();
builder.Services.AddScoped<IUnitOfWork>(provider => new UnitOfWork(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
