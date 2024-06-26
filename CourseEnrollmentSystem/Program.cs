using AutoMapper;
using CES.Application.Entitys;
using CES.Application.Common.Mappings;
using CES.Application.Interfaces;
using CES.Infrastructur.Context;
using CES.Infrastructur.Features.CourseOP;
using CES.Infrastructur.Features.CourseTypeOP;
using CES.Infrastructur.Features.DepartmentOP;
using CES.Infrastructur.Features.InstructorOP;
using CES.Infrastructur.Features.LevelOP;
using CES.Infrastructur.Features.StudentCourseOP;
using CES.Infrastructur.Features.StudentOP;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using CES.Infrastructur.HAndeler;
using CorrelationId.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Configure Serilog

Log.Logger = new LoggerConfiguration()
    .Enrich.WithCorrelationId()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting up the application");
    

    // Add services to the container
    builder.Services.AddDefaultCorrelationId(options =>
    {
        options.RequestHeader = "X-Correlation-ID";
        options.ResponseHeader = "X-Correlation-ID";
        options.LoggingScopeKey = "CorrelationId";
        options.EnforceHeader = false;
    });
    builder.Host.UseSerilog();




    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();




// Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Portal")));


// Service Mapping
builder.Services.AddScoped<IDepartmentService, CreatDepartment>();
builder.Services.AddScoped<ICourseService, CreatCourse>();
builder.Services.AddScoped<ICoursTypeService, CraetCourseType>();
builder.Services.AddScoped<IInstructorService, CreatInstructor>();
builder.Services.AddScoped<ILevelService, CreatLevel>();
builder.Services.AddScoped<IStudentCourseService, CreatStudentCourse>();
builder.Services.AddScoped<IStudentService, CreatStudent>();



// Validators
builder.Services.AddScoped<AdminValidator>();
builder.Services.AddScoped<CourseValidator>();
builder.Services.AddScoped<CourseTypeValidator>();
builder.Services.AddScoped<DepartmentValidator>();
builder.Services.AddScoped<InstracturValidator>();
builder.Services.AddScoped<LevelValidator>();
builder.Services.AddScoped<StudentValidator>();


// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);






var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
