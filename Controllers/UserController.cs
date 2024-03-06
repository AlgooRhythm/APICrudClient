﻿using Microsoft.AspNetCore.Mvc;
using APICrudClient.Models;

namespace APICrudClient.Controllers
{
    public class UserController : Controller
    {
        private readonly APIGateway apiGateway;

        public UserController(APIGateway apiGateway)
        {
            this.apiGateway = apiGateway;    
        }

        public IActionResult Index()
        {
            List<user> users;

            users = apiGateway.ListUsers();

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            user user = new user();

            return View();
        }

        [HttpPost]
        public IActionResult Create(user users)
        {
            apiGateway.CreateUsers(users);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            user users = new user();

            users = apiGateway.GetUser(id);

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            user users;

            users = apiGateway.GetUser(id);

            return View(users);
        }

        [HttpPost]
        public IActionResult Edit(user users)
        {
            apiGateway.UpdateUser(users);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            user users;

            users = apiGateway.GetUser(id);

            return View(users);
        }

        [HttpPost]
        public IActionResult Delete(user users)
        {
            apiGateway.DeleteUser(users.id);

            return RedirectToAction("Index");
        }


    }
}