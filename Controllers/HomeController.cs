using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//inkluderar models
using Moment2MVC.Models;
//adderar funktionalitet för att newtonsoft
using Newtonsoft.Json;


namespace Moment2MVC.Controllers
{
    [Route("/")]
    [Route("/hem")]
    //skapar en klass som ärver från controller-klassen 
    public class HomeController : Controller
    {
        //skapar en metod (action) för vad som ska hända på för de olika sidorna
        public IActionResult Index()
        {
            //hämtar datum
            var todaysDate = DateTime.Now;

            ViewBag.todaysDate = todaysDate;

            //skicka data till json-fil
            var JsonStr = System.IO.File.ReadAllText("workouts.json");

            //deserialiserar och konverterar till en lista för att loopa
            var JsonObj = JsonConvert.DeserializeObject<List<WorkoutModel>>(JsonStr);
            return View(JsonObj);
        }

        //lägger till alternativa sökvägar
        [Route("/about")]
        [Route("/omsidan")]
        [Route("/om")]
        public IActionResult About()
        {
            return View();
        }

        //lägger till alternativa sökvägar
        [Route("/allaträningspass")]
        [Route("/allworkouts")]
        public IActionResult Allworkouts()
        {
            //skicka data till json-fil
            var JsonStr = System.IO.File.ReadAllText("workouts.json");

            //deserialiserar och konverterar till en lista för att loopa
            var JsonObj = JsonConvert.DeserializeObject<List<WorkoutModel>>(JsonStr);
            return View(JsonObj);
        }

        //lägger till alternativa sökvägar
        [Route("/träningspass")]
        [Route("/workout")]
        public IActionResult Workout()
        {
            //skapa en lista för att populera min dropdown i vyn
            List<string> difficulty = new List<string>()
            {
                "Easypeasy",
                "Medium",
                "Hardcore",
                "Neardeathexperience"
            };

            //sparar listan med hjälp av viewbag för att användas i vyn
            ViewBag.Difficulty = new SelectList(difficulty);

            return View();
        }

        //definerar att endast lyssna på http-anrop
        [HttpPost("/träningspass")]
        public IActionResult Workout(WorkoutModel model)
        {
            //kontroll om formuläret är korrekt ifyllt
            if (ModelState.IsValid)
            {
                //skicka data till json-fil
                var JsonStr = System.IO.File.ReadAllText("workouts.json");

                //deserialiserar och konverterar till en lista för att loopa
                var JsonObj = JsonConvert.DeserializeObject<List<WorkoutModel>>(JsonStr);

                //kontroll för att se om json finns
                if (JsonObj != null)
                {
                    //lägger till JSON-datat i listan med Add
                    JsonObj.Add(model);

                    //skriver till filen och serialiserar till json-data, formatterar för läsbart format
                    System.IO.File.WriteAllText("workouts.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                    //dirigerar om till sidan för alla träningspass
                    return RedirectToAction("Allworkouts", "Home");
                }
            }

            return View();
        }

    }
}