using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetStateItems(StateRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var student = StudentRepository.Get(id);
            
            var vM = new StudentVM();
            vM.Student = StudentRepository.Get(id);
            vM.SetStateItems(StateRepository.GetAll());
            vM.SetCourseItems(CourseRepository.GetAll());
            vM.SetMajorItems(MajorRepository.GetAll());
            return View(vM);
        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Student.Major = MajorRepository.Get(viewModel.Student.Major.MajorId);
                viewModel.Student.Address.State = StateRepository.Get(viewModel.Student.Address.State.StateAbbreviation);

                StudentRepository.Edit(viewModel.Student);
                return RedirectToAction("List");
            }
            else
            {
                viewModel.SetStateItems(StateRepository.GetAll());
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}