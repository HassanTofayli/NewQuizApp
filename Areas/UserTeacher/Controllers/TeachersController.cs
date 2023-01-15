using Microsoft.AspNetCore.Mvc;
using NewQuizApp.Interfaces;
using NewQuizApp.Models;

namespace NewQuizApp.Controllers;
[Area("userteacher")]

public class TeachersController : Controller
{
    private readonly ITeacherRepo _repo;

    public TeachersController(ITeacherRepo repo){
        this._repo = repo;
    }

    public async Task<IActionResult> Index(){
        IEnumerable<Teacher> teachers = await _repo.GetAllTeachersAsync();
        return View(teachers);
    }

    [HttpPost]
    public async Task<IActionResult> AddTeacher(Teacher teacher)
    {
        if(await _repo.AddTeacherAsync(teacher)){
            return RedirectToAction("Index");
        }
        return BadRequest("ERROR");
    }

    [HttpGet]
    public IActionResult AddTeacher()
    {
        return View();
    }

    
    [HttpPost]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        if (await _repo.DeleteTeacherAsync(id)){
            return RedirectToAction("Index");
        }
        return BadRequest("Error");
    }
    
    
    

    public IActionResult CreateQuiz()
    {
        return Redirect("/Views/ClassRoom/CreateQuiz.cshtml");
    }


}