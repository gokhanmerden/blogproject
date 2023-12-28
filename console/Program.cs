// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Linq;
using data;
using data.tables;
using data.uows;
using Microsoft.EntityFrameworkCore;
using services.Query;
/*
using var db = new BlogContext();

//Console.WriteLine($"Database path: {db.DbPath}.");

// Create
/*
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();


var blog = new Blog();
blog.Url = "http://www.google.com";
blog.Rating = 5;

var post = new Post();
post.Title = "New Post";
post.Content = "New Content";
//post.BlogId = blog.id;
blog.Posts.Add(post);
db.Add(blog);
db.SaveChanges();
*/
/*
var uow = new BlogUnitOfWork();
var data = await uow.blogRepository.GetQuery().Where(w=> w.id == 100).FirstOrDefaultAsync();

try
{
    if (data.id == 100) {
        System.Console.WriteLine(data);
    }
}
catch (System.Exception ex)
{
  System.Console.WriteLine($"Hata Oluştu {ex.Message}");
  System.Console.WriteLine(string.Format("Hata Oluştu {0}",ex.Message));
  System.Console.WriteLine("Hata Oluştu " + ex.Message);
}*/
string jsonData = @"[
                    {
                        
                        ""ay"":103.46567927995798,
                        ""tl"":1247.338151359496,
                        ""oran"":2.69,
                        ""name"":""İyi ki Tanışmışız, dedirten kredi"",
                        ""bank-code"":""qnb-finansbank"",
                        ""status"":""iyi-ki-tanismisiz-dedirten-kredi""
                    }
                ]";

            // JSON verilerini bir nesne koleksiyonuna dönüştürün.
            var result = System.Text.Json.JsonSerializer.Deserialize<List<Krediler>>(jsonData);

            // Nesne koleksiyonunu yazdırın.
            foreach (var kredi in result)
            {
                AddKredilerCommand command = new AddKredilerCommand();
                command.kredi = kredi;
                
                AddKredilerCommand.Handler handler = new AddKredilerCommand.Handler();
                var data = await handler.Handle(command,CancellationToken.None);
            };