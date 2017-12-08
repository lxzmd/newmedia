using LogisticsExpress.BLL;
using LogisticsExpress.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace LogisticsExpress.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TopicQuestionBll tq = new TopicQuestionBll();
            var model = tq.Query(x => x.Id == 2).FirstOrDefault();
            model.AskContent = "测试2017-11-15";
            model = tq.Update(model);
            //tq.Insert(new TopicQuestion { Id = 0, AskContent = "测试2017", CreatorUserId = 10, CreatorUserName = "大厨", IsShow = true, MemberId = 10, OwnerCommentId = 9, TopicId = 1 });
            return View();
        }
    }
}