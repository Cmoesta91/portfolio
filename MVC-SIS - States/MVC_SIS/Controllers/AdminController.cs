﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using Exercises.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("MajorName",
                   "Please enter a Major name");
                return View(major);
            }
            else
            {
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }

           
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            if (string.IsNullOrEmpty(major.MajorName))
            {
                ModelState.AddModelError("MajorName",
                   "Please enter a Major name");
                return View(major);
            }
            else
            {
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model =  StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            StateVM model = new StateVM();
            model.ValidStates = StatesList.States;
            model.State = new State();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddState(StateVM stateVM)
        {
            stateVM.ValidStates = StatesList.States;
            stateVM.State = (stateVM.State ?? new State
            {
                StateAbbreviation = "",
                StateName = null
            });
            if (ModelState.IsValid)
            {
                try
                {
                    stateVM.State.StateName = StatesList.States.FirstOrDefault(s => stateVM?.State.StateAbbreviation == s.Value)?.Text;
                }
                catch (NullReferenceException)
                { stateVM.State.StateName = null; }

                if(stateVM.State.StateName == null)
                {
                    return View(stateVM);
                }
                StateRepository.Add(stateVM.State);
                return RedirectToAction("States");
            }
            return View(stateVM);
            
        }

        [HttpGet]
        public ActionResult EditState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State state)
        {
            if (string.IsNullOrEmpty(state.StateName))
            {
                ModelState.AddModelError("StateName",
                   "Please enter a State name");
                return View(state);
            }
            else
            {
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
            
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Course()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            if(string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("CourseName",
                   "Please enter a Course name");
                return View(course);
            }
            else
            {
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Course");
            }
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            if (string.IsNullOrEmpty(course.CourseName))
            {
                ModelState.AddModelError("CourseName",
                   "Please enter a Course name");
                return View(course);
            }
            else
            {
                CourseRepository.Edit(course);
                return RedirectToAction("Course");
            }
            
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Course");
        }
    }
}