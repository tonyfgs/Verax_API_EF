// See https://aka.ms/new-console-template for more information

using DbContextLib;
using Entities;

addArticle();
listArticle();

// Allows to list all the articles from the db
void listArticle()
{
    using (var context = new LibraryContext())
    {
        var articles = context.ArticleSet;
        foreach (var article in articles)
        {       
            Console.WriteLine($"{article.Author} - {article.Title} - {article.Description} - {article.DatePublished} - {article.LectureTime}");
        }
    }
}


// Allows to list all the articles from the db by author
void listArticleByAuthor()
{
    using (var context = new LibraryContext())
    {
        var articles = context.ArticleSet.Where(a => a.Author.Equals("Tony Fages"));
        foreach (var article in articles)
        {
            Console.WriteLine($"{article.Author} - {article.Title} - {article.Description} - {article.DatePublished} - {article.LectureTime}");
        }
    }
}

// Allows to add an article to the db
void addArticle()
{
    using (var context = new LibraryContext())
    {
        var article = new ArticleEntity
        {
            Title = "Louis is not sick anymore",
            Description = "Louis is not sick anymore, he is now healthy and happy",
            DatePublished = "16-02-2024",
            LectureTime = 1,
            Author = "Tony Fages"
        };
        context.ArticleSet.Add(article);
        context.SaveChanges();
    }
}


// Allows to modify an article from the db
void modifyArticle()
{
    using (var context = new LibraryContext())
    {
        var article = context.ArticleSet.Where(a => a.Author.Equals("Tom Smith"));

        foreach (var articles in article)
        {
            articles.Title = "Demain des l'aube";
            context.SaveChanges();
        }
    }
}

// Allows to delete an article from the db
void deleteArticle()
{
    using (var context = new LibraryContext())
    {
        var article = context.ArticleSet.Where(a => a.Author.Equals("M&M's Red"));

        foreach (var articles in article)
        {
            context.ArticleSet.Remove(articles);
            context.SaveChanges();
        }
    }
}