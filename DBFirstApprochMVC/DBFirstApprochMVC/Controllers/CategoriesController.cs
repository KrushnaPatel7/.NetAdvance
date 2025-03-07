﻿using DB_Logic;
using DBFirstApprochMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstApprochMVC.Controllers
{
    public class CategoriesController : Controller
    {
        NorthwindEntities obj = new NorthwindEntities();
        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable <Category> Cat = obj.Categories;
            List<CategoriesModel> catList = new List<CategoriesModel>();
            foreach (var item in Cat)
            {
                catList.Add(new CategoriesModel { CategoryID = item.CategoryID, CategoryName = item.CategoryName, Description = item.Description, Picture = item.Picture });
            }
            return View(catList);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
