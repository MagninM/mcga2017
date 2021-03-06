﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.OrderDetails.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetails/OrderDetail
        public ActionResult Index()
        {
            var Order = Int32.Parse(Request.Cookies["OrderNumber"].Value);

            var op = new OrderProcess();
            var orderconid = op.FindByOrderNumber(Order);

            var odp = new OrderDetailProcess();
            var lista = odp.FindeByOrderId(orderconid.Id);

            var cookie = Request.Cookies[".AspNet.ApplicationCookie"].Value;
            Response.Cookies[".AspNet.ApplicationCookie"].Value = cookie + 2;

            return View(lista);
        }

        // GET: OrderDetails/Details
        public ActionResult Details(int id)
        {
            var op = new OrderDetailProcess();
            var order = op.Find(id);

            return View(order);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // POST: OrderDetails/Create
        public ActionResult Create(OrderDetail orderDetails)
        {
            var op = new OrderDetailProcess();
            op.Insert(orderDetails);
            return RedirectToAction("Index");
        }

        // GET: OrderDetails/Delete
        public ActionResult Delete(int id)
        {
            var op = new OrderDetailProcess();
            op.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: OrderDetails/Edit
        public ActionResult Edit(int id)
        {
            var op = new OrderDetailProcess();
            var order = op.Find(id);

            return View(order);
        }

        [HttpPost]
        // POST: OrderDetails/Edit
        public ActionResult Edit(OrderDetail orderDetails)
        {
            var op = new OrderDetailProcess();
            op.Edit(orderDetails);
            return RedirectToAction("Index");
        }

    }
}