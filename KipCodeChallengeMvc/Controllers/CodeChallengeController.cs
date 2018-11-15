﻿using KipCodeChallengeMvc.Constants;
using KipCodeChallengeMvc.Models;
using KipCodeChallengeMvcPerson.Models;
using KipCodeChallengeMvcServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KipCodeChallengeMvc.Controllers
{
    public class CodeChallengeController : Controller
    {
        private readonly IPersonService _personService;

        public CodeChallengeController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            var person = _personService.GetPerson(Request.Cookies[CookieKey.KipMvcCodeChallenge]);

            return View((PersonModel)person);
        }
        [HttpPost]
        public IActionResult Index(PersonModel person)
        {
            return RedirectToAction("Edit");
        }
        public IActionResult Edit()
        {
            var person = new Person();
            var cacheKey = Request.Cookies[CookieKey.KipMvcCodeChallenge];

            if (cacheKey != null)
            {
                person = _personService.GetPerson(cacheKey);
            }

            return View((PersonModel)person);
        }
        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                var cacheKey = Request.Cookies[CookieKey.KipMvcCodeChallenge];

                if (cacheKey == null)
                {
                    cacheKey = $"{person.FirstName}{person.LastName}-{DateTime.Now}";
                    Response.Cookies.Append(CookieKey.KipMvcCodeChallenge, cacheKey, new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(7)
                    });
                }

                _personService.SavePerson(cacheKey, (Person)person);

                return RedirectToAction("Index");
            }
            // add model errors
            return View(person);
        }
    }
}