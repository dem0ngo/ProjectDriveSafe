﻿using ProjectDriveSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjectDriveSafe.Models.ViewModels;

namespace ProjectDriveSafe.Controllers
{
    public class HomeController : Controller
    {
        private ICollisionRepository repo { get; set; }

        public HomeController(ICollisionRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var crash = repo.Crashes.ToList();
            return View(crash);
        }

        public IActionResult ViewCrashes(int pageNum = 1)
        {
            int pageSize = 5;

            var x = new CrashesViewModel
            {
                Crashes = repo.Crashes
                .OrderBy(c => c.MAIN_ROAD_NAME)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes = repo.Crashes.Count(),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

    }
}
