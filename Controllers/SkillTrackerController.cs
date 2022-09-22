using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SkillsTracker.Controllers
{
    [Route("/skills/")]
    public class SkillTrackerController : Controller
    {
        //Get: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = @"
                <h1>Skills Tracker</h1>
                <h2>Coding skills to learn:</h2>
                <ol> 
                    <li>C#</li>
                    <li>JavaScript</li>
                    <li>Java</li>
                </ol>
                <h3>Go to the <a href='/skills/form'>form</a>.</h3>
                ";
            return Content(html, "text/html");
        }
        [Route("/skills/form/")]
        [HttpGet]
        public IActionResult CreateForm()
        {
            string skillOptions = "<option value='learning basics'>learning basics</option>" +
                "<option value='making apps'>making apps</option>" +
                "<option value='master coder'>master coder</option>";

            string html = @"
                <form method='post' action='/skills/form/posted'>
                <label for='date'>Date:</label>
                <input type='date' name='date' /><br>
                <label>C#:</label>
                <select name='csharp'>" +
                skillOptions +
                @"</select><br>
                <label>JavaScript:</label>
                <select name='javascript'>" +
                skillOptions +
                @"</select><br>
                <label>Java:</label>
                <select name='java'>" +
                skillOptions +
                @"</select><br>
                <input type='submit' value='Submit' />
                </form>
                ";

            return Content(html, "text/html");
        }

        [Route("/skills/form/posted")]
        [HttpPost]
        public IActionResult DisplaySkills(string date, string csharp, string javascript, string java)
        {
            string html = $"<h1>{date}</h1>" +
                "<ol>" +
                    $"<li>C#: {csharp}</li>" +
                    $"<li>JavaScript: {javascript}</li>" +
                    $"<li>Java: {java}</li>" +
                "</ol>";

            return Content(html, "text/html");
        }

    }
}
