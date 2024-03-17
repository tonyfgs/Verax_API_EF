// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using Entities;
using Model;

class Tests_Console
{
    static readonly HttpClient client = new HttpClient();

    
    static async Task Main(string[] args)
    {
        await TestUser();
        //await TestFormulaire();
        //await TestArticle();
    }

    private static async Task TestFormulaire()
    {
        await TestFormulaireGetAll();
        await TestFormulaireGetId();
        await TestFormulaireCreate();
        await TestFormulaireDelete();
        await TestFormulaireUpdate();
    }

    private static async Task TestUser()
    {
        await TestUserGetAll();
        await TestUserGetId();
        //await TestUserCreate();
        //await TestUserDelete();
        //await TestUserUpdate();
        await TestGetAllArticleUser();
        await TestGetArticleByUser();
        //await TestCreateArticleUser();
        //await TestDeleteArticleUser();
        await TestUpdateArticleUser();
    }


    static async Task TestArticle()
    {
        await TestArticleGetId();
        await TestArticleCreate();
        await TestArticleGetAll();
        await TestArticleDelete();
        await TestArticleUpdate();
    }
    
    static async Task TestArticleGetAll()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/api/Article");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestArticleGetId()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/article/1");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestArticleCreate()
    {
        try
        {
            var article = new Article()
            {
                Title = "Test",
                Description = "Test",
                Author = "Test",
                DatePublished = "Test",
                LectureTime = 0
            };
            var json = JsonSerializer.Serialize(article);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5052/article", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestArticleDelete()
    {
        try
        {
            var response = await client.DeleteAsync("http://localhost:5052/article/1");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestArticleUpdate()
    {
        try
        {
            var article = new Article()
            {
                Title = "Louis",
                Description = "Je",
                Author = "T'",
                DatePublished = "aime",
                LectureTime = 0
            };
            var json = JsonSerializer.Serialize(article);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:5052/article/1", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestFormulaireGetAll()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/formulaires");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestFormulaireGetId()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/formulaire/2");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestFormulaireCreate()
    {
        try
        {
            var formulaire = new Formulaire()
            {
                Theme = "Test",
                Date = "Test",
                Lien = "Test",
                UserPseudo = "Sha"
            };
            var json = JsonSerializer.Serialize(formulaire);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5052/formulaire", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestFormulaireDelete()
    {
        try
        {
            var response = await client.DeleteAsync("http://localhost:5052/formulaire/5");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestFormulaireUpdate()
    {
        try
        {
            var formulaire = new Formulaire()
            {
                Theme = "J'",
                Date = "aime",
                Lien = "Les",
                UserPseudo = "Sha"
            };
            var json = JsonSerializer.Serialize(formulaire);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:5052/formulaire/4", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUserGetAll()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/users");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUserGetId()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/user/Sha");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUserCreate()
    {
        try
        {
            var user = new User()
            {
                Pseudo = "J",
                Nom = "'",
                Prenom = "aime",
                Mail = "les",
                Mdp = "pieds",
                Role = "Admin"
            };
            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5052/user", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUserDelete()
    {
        try
        {
            var response = await client.DeleteAsync("http://localhost:5052/user/J");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUserUpdate()
    {
        try
        {
            var user = new User()
            {
                Pseudo = "Sha",
                Nom = "J'",
                Prenom = "aime",
                Mail = "les",
                Mdp = "pieds",
                Role = "Admin"
            };
            var json = JsonSerializer.Serialize(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:5052/user/Sha", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestGetAllArticleUser()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/user/article/users");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestGetArticleByUser()
    {
        try
        {
            var response = await client.GetAsync("http://localhost:5052/user/Sha/articles");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestCreateArticleUser()
    {
        try
        {
            var articleUser = new ArticleUserEntity()
            {
                ArticleEntityId = 1,
                UserEntityPseudo = "Sha"
            };
            var json = JsonSerializer.Serialize(articleUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5052/user/article", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static async Task TestDeleteArticleUser()
    {
        try
        {
            var response = await client.DeleteAsync("http://localhost:5052/user/Sha/3");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    static async Task TestUpdateArticleUser()
    {
        try
        {
            var articleUser = new ArticleUserEntity()
            {
                ArticleEntityId = 2,
                UserEntityPseudo = "Sha"
            };
            long oldId = 3;
            var json = JsonSerializer.Serialize(articleUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5052/user/Sha/{oldId}", data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}