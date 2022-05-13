

using Microsoft.EntityFrameworkCore;
using TEST_API1.Middleware.Extensions;
using TESTAPI1.Application.Interfaces.Users;
using TESTAPI1.Application.UseCases.Comments;
using TESTAPI1.Application.UseCases.Comments.Create;
using TESTAPI1.Application.UseCases.Comments.Delete;
using TESTAPI1.Application.UseCases.Comments.Edit;
using TESTAPI1.Application.UseCases.Comments.Get;
using TESTAPI1.Application.UseCases.Posts;
using TESTAPI1.Application.UseCases.Posts.Create;
using TESTAPI1.Application.UseCases.Posts.Delete;
using TESTAPI1.Application.UseCases.Posts.Get;
using TESTAPI1.Application.UseCases.Posts.GetByUser;
using TESTAPI1.Application.UseCases.Posts.GetPending;
using TESTAPI1.Application.UseCases.Posts.GetPosts;
using TESTAPI1.Application.UseCases.Posts.Review;
using TESTAPI1.Application.UseCases.Posts.Update;
using TESTAPI1.Application.UseCases.Users;
using TESTAPI1.Application.UseCases.Users.Register;
using TESTAPI1.Domain.Enities.Comment;
using TESTAPI1.Domain.Enities.Post;
using TESTAPI1.Domain.Enities.User;
using TESTAPI1.Infrastructure.Repositories;
using TESTAPI1.Infrastructure.Repositories.Comments;
using TESTAPI1.Infrastructure.Repositories.Posts;
using TESTAPI1.Infrastructure.Repositories.Users;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            //.WithOrigins("http://localhost:4200/", "https://localhost:4200/");
            .AllowAnyOrigin();
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
//user
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IRegisterUseCase, RegisterUseCase>();
//post
builder.Services.AddScoped<ICreatePostUseCase, CreatePostUseCase>();
builder.Services.AddScoped<IDeletePostUseCase, DeletePostUseCase>();
builder.Services.AddScoped<IUpdatePostUseCase, UpdatePostUseCase>();
builder.Services.AddScoped<IReviewPostUseCase, ReviewPostUseCase>();
builder.Services.AddScoped<IGetPendingPostsUseCase, GetPendingPostsUseCase>();
builder.Services.AddScoped<IGetByUserUseCase, GetByUserUseCase>();
builder.Services.AddScoped<IGetPostsUseCase, GetPostsUseCase>();
builder.Services.AddScoped<IGetUseCase, GetUseCase>();
//comment
builder.Services.AddScoped<ICreateCommentUseCase, CreateCommentUseCase>();
builder.Services.AddScoped<IDeleteCommentUseCase, DeleteCommentUseCase>();
builder.Services.AddScoped<IGetCommentsUseCase, GetCommentsUseCase>();
builder.Services.AddScoped<IEditCommentUseCase, EditCommentUseCase>();

builder.Services.AddDbContext<PostsContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionMiddleware();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
