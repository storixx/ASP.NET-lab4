namespace WebApplication4.Controllers;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class LibraryController : Controller
{
    public IActionResult Index()
    {
        return Content("Welcome to the Library!");
    }

    public IActionResult Books()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration files", "books.json");

        if (System.IO.File.Exists(filePath))
        {
            var books = JsonConvert.DeserializeObject<List<string>>(System.IO.File.ReadAllText(filePath));
            return View(books);
        }
        else
        {
            return Content("Books file not found.");
        }

    }

    public IActionResult Profile(int? id)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration files", "users.json");

        if (System.IO.File.Exists(filePath))
        {
            var users = JsonConvert.DeserializeObject<Dictionary<int, string>>(System.IO.File.ReadAllText(filePath));

            if (id.HasValue && users.ContainsKey(id.Value))
            {
                return Content($"User Profile: {users[id.Value]}");
            }
            else
            {
                return Content("User Profile: Default User");
            }
        }
        else
        {
            return Content("Users file not found.");
        }
    }

}
