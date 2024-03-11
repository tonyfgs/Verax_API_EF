// See https://aka.ms/new-console-template for more information

using DbContextLib;
using Entities;

//Article
//addArticle();
listArticle();
//modifyArticle();
//deleteArticle();
//listArticleByAuthor();

//Form
//addForm();
listForms();
//updateForm();
//deleteForm();

//User
//listUser();
//addUser();
//updateUser();
//deleteUser();

//ArticleUser
//listArticleUser();
//addArticleUser();
//updateArticleUser();
//deleteArticleUser();

//FormUser
listFormUser();
//addFormUser();


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

// Allow to get all forms
void listForms()
{
    using (var context = new LibraryContext())
    {
        var forms = context.FormSet;
        foreach (var form in forms)
        {
            Console.WriteLine($"{form.Id} - {form.Link} - {form.DatePublication} - {form.Pseudo} - {form.Theme} - {form.UserEntityId}");
        }
    }
}

void addForm()
{
    using (var context = new LibraryContext())
    {
        var form = new FormEntity
        {
            Id = 5,
            Theme = "Covid",
            DatePublication = "16-02-2024",
            Link = "https://www.covid.com",
            Pseudo = "Tony Fages",
            UserEntityId = 1
        };
        context.FormSet.Add(form);
        context.SaveChanges();
    }
}

void updateForm()
{
    using (var context = new LibraryContext())
    {
        var form = context.FormSet.Where(f => f.Id.Equals(5));

        foreach (var forms in form)
        {
            forms.Theme = "Demain des l'aube";
            context.SaveChanges();
        }
    }
}

void deleteForm()
{
    using (var context = new LibraryContext())
    {
        var form = context.FormSet.Where(f => f.Id.Equals(5));

        foreach (var forms in form)
        {
            context.FormSet.Remove(forms);
            context.SaveChanges();
        }
    }
}

void listUser()
{
    using (var context = new LibraryContext())
    {
        var users = context.UserSet;
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id} - {user.Pseudo} - {user.Nom} - {user.Prenom} - {user.Mail} - {user.Role}");
        }
    }
}

void addUser()
{
    using (var context = new LibraryContext())
    {
        var user = new UserEntity
        {
            Id = 7, Nom = "Fages", Prenom = "Tony", Pseudo = "TonyF", Mail = "tony@gmail.com", Mdp = "1234", Role = "Admin"
        };
        context.UserSet.Add(user);
        context.SaveChanges();
    }
    listUser();
}

void updateUser()
{
    using (var context = new LibraryContext())
    {
        var user = context.UserSet.Where(u => u.Id.Equals(7));

        foreach (var users in user)
        {
            users.Nom = "Thomas";
            context.SaveChanges();
        }
    }
    listUser();
}

void deleteUser()
{
    using (var context = new LibraryContext())
    {
        var user = context.UserSet.Where(u => u.Id.Equals(7));

        foreach (var users in user)
        {
            context.UserSet.Remove(users);
            context.SaveChanges();
        }
    }
    listUser();
}

void listArticleUser()
{
    using (var context = new LibraryContext())
    {
        var articleUsers = context.ArticleUserSet;
        foreach (var articleUser in articleUsers)
        {
            Console.WriteLine($"{articleUser.ArticleEntityId} - {articleUser.UserEntityId}");
        }
    }
}

void addArticleUser()
{
    using (var context = new LibraryContext())
    {
        var articleUser = new ArticleUserEntity
        {
            ArticleEntityId = 2,
            UserEntityId = 1
        };
        context.ArticleUserSet.Add(articleUser);
        context.SaveChanges();
    }
    listArticleUser();
}

void updateArticleUser()
{
    using (var context = new LibraryContext())
    {
        var articleUser = context.ArticleUserSet.FirstOrDefault(au => au.UserEntityId.Equals(2));
        if (articleUser != null) articleUser.UserEntityId = 3;
        context.SaveChanges();
    }
    listArticleUser();
}

void deleteArticleUser()
{
    using (var context = new LibraryContext())
    {
        var articleUser = context.ArticleUserSet.Where(au => au.UserEntityId.Equals(1)).Where(u => u.ArticleEntityId.Equals(1));

        foreach (var articleUsers in articleUser)
        {
            context.ArticleUserSet.Remove(articleUsers);
            context.SaveChanges();
        }
    }
    listArticleUser();
}

void listFormUser()
{
    using (var context = new LibraryContext())
    {
        var formUsers = context.FormSet;
        foreach (var formUser in formUsers)
        {
            Console.WriteLine($"{formUser.UserEntityId}");
        }
    }
}

void addFormUser()
{
    using (var context = new LibraryContext())
    {
        var formUser = new FormEntity
        {
            UserEntityId = 1
        };
        context.FormSet.Add(formUser);
        context.SaveChanges();
    }
}

