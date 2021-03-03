﻿using Lot.BLL;
using Lot.IBLL;
using Lot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Lot.UI.Controllers
{
    public class ChannelController : Controller
    {
        // GET: Channel
        public ActionResult Index()
        {
            return View();
        }
        //添加渠道
        public ActionResult AddChannel()
        {
            return View();
        }
        [HttpPost]
        public JsonResult List(CHANNELINFO filter)
        {
            UserService userService = new UserService();
            Expression<Func<USERINFO, bool>> wherelambda = p => 1 == 1;
            IQueryable<USERINFO> allSu= userService.GetEntityByLambda(wherelambda);
            foreach (var item in allSu)
            {
                Console.WriteLine(item.NAME);   
            }
            List<CHANNELINFO> list = new List<CHANNELINFO>();
            for (int i = 0; i < 1100; i++)
            {
                list.Add(new CHANNELINFO
                {
                    ID = 1,
                    ChannelCode = "E_Express" + i,
                    ChannelStyle = "香港E特快" + i,
                    CnName = "香港E特快" + i,
                    EnName = "HK E-Express" + i,
                    Status = "1"
                });
            }
            if (!string.IsNullOrEmpty(filter.ChannelCode))
            {
                list = list.Where(x => x.ChannelCode == filter.ChannelCode.Trim()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.CnName))
            {
                list = list.Where(x => x.CnName == filter.CnName.Trim()).ToList();
            }
            if (!string.IsNullOrEmpty(filter.EnName))
            {
                list = list.Where(x => x.EnName == filter.EnName.Trim()).ToList();
            }

            //构造成Json的格式传递 iTotalRecords ：总记录数 iTotalDisplayRecords ：每页显示的记录数
            var result = new { iTotalRecords = 1100, iTotalDisplayRecords = 10, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}