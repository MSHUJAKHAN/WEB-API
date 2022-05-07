using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using DALayer;

namespace UILayer.Controllers
{
    public class EmpUIController : Controller
    {
        private HttpClient EmpkSer;



        public EmpUIController()
        {
            EmpkSer = new HttpClient();
            EmpkSer.BaseAddress = new Uri("http://localhost:56556/api/");
        }

        // GET: EmpUI
        public ActionResult Index()
        {

            IEnumerable<EmployeeDetail> lst = null;

            // to call showAllbank(Get) function
            var res = EmpkSer.GetAsync("EmpService");
            res.Wait();

            var output = res.Result;
            if (output.IsSuccessStatusCode)
            {
                //var readData = output.Content.ReadAsAsync<IEnumerable<Bank>>();
                //readData.Wait();
                //lst = readData.Result;

                lst = output.Content.ReadAsAsync<IEnumerable<EmployeeDetail>>().Result;
            }

            return View(lst);
        }



        [System.Web.Mvc.HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }



        [System.Web.Mvc.HttpPost]
        public ActionResult AddEmployee(EmployeeDetail NewBank)
        {

            var SendData = EmpkSer.PostAsJsonAsync<EmployeeDetail>("EmpService", NewBank);
            SendData.Wait();
            var res = SendData.Result;

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(NewBank);
        }



        public ActionResult DeleteEmp(int Id)
        {
            var response = EmpkSer.DeleteAsync("EmpService/" + Id);
            response.Wait();



            var res = response.Result;



            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }



        public ActionResult ShowEmpDetail(int Id)
        {
            EmployeeDetail Rec = null;
            var res = EmpkSer.GetAsync("EmpService?id=" + Id);

            res.Wait();
            var output = res.Result;

            if (output.IsSuccessStatusCode)
            {
                var readData = output.Content.ReadAsAsync<EmployeeDetail>();
                readData.Wait();
                Rec = readData.Result;
            }

            return View(Rec);
        }



        public ActionResult EditEmpDetail(int Id)
        {
            EmployeeDetail Rec = null;
            var res = EmpkSer.GetAsync("EmpService?id=" + Id);

            res.Wait();
            var output = res.Result;

            if (output.IsSuccessStatusCode)
            {
                var readData = output.Content.ReadAsAsync<EmployeeDetail>();
                readData.Wait();
                Rec = readData.Result;
            }

            return View(Rec);
        }




        [System.Web.Mvc.HttpPost]
        public ActionResult EditEmpDetail(EmployeeDetail UpdBank)
        {


            var res = EmpkSer.PutAsJsonAsync<EmployeeDetail>("EmpService", UpdBank);
            res.Wait();
            var output = res.Result;


            if (output.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }



            return View(UpdBank);
        }
    }
}
