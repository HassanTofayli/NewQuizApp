using NewQuizApp.Interfaces;
using NewQuizApp.Models;

namespace NewQuizApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using NewQuizApp.Interfaces;
using NewQuizApp.Models;

[Area("userteacher")]

public class ClassroomController : Controller
{
    private readonly IClassroomRepo _classroomRepo;
    private readonly IQuizRepo _quizRepo;

    public ClassroomController(IClassroomRepo classroomRepo){
        this._classroomRepo = classroomRepo;
    }

    public async Task<IActionResult> Index(){
        IEnumerable<Classroom> classrooms = await _classroomRepo.GetAllClassroomsAsync();
        return View(classrooms);
    }

    [HttpPost]
    public async Task<IActionResult> AddClassroom(Classroom classRoom)
    {
        if (ModelState.IsValid)
        {
            if (await _classroomRepo.AddClassroomAsync(classRoom))
            {
                return RedirectToAction("Index");
            }
        }

        return View(classRoom);
    }

    [HttpGet]
    public IActionResult AddClassroom()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> EditClassroom(Classroom classRoom)
    {
        if (ModelState.IsValid)
        {
            if (await _classroomRepo.UpdateClassroomAsync(classRoom))
            {
                return RedirectToAction("Index");
            }
        }

        return View(classRoom);
    }
    
    [HttpGet]
    public async Task<IActionResult> EditClassroom(int id)
    {
        var classroom = await _classroomRepo.GetClassroomByIdAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }

        return View(classroom);
    }


    [HttpPost]
    public async Task<IActionResult> DeleteClassroom(int id)
    {
        if (await _classroomRepo.DeleteClassroomAsync(id)){
            return RedirectToAction("Index");
        }
        return BadRequest("Error");
    }

    [HttpGet]
    public IActionResult CreateQuiz()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateQuiz(Quiz quiz)
    {
        _quizRepo.AddQuizAsync(quiz);
        return View();
    }

    public IActionResult AttendQuiz()
    {
        return View();
    }

    
}