using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DALayer;
using DALayer.Repo;


namespace UILayer.Controllers
{
    public class EmpServiceController : ApiController
    {
        private IRepo<EmployeeDetail> Bser;



        public EmpServiceController()
        {
            Bser = new RepositoryService<EmployeeDetail> ();
        }



        [HttpGet]
        public IHttpActionResult ShowEmployee()
        {
            try
            {
                var BankList = Bser.GetAll();
                return Ok(BankList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet]
        public IHttpActionResult ShowEmpById(int Id)
        {
            try
            {
                var BankRec = Bser.GetDetailById(Id);
                return Ok(BankRec);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        public IHttpActionResult AddEmp(EmployeeDetail NewBank)
        {
            try
            {
                Bser.AddDetail(NewBank);
                return Ok("Record Inserted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete]
        public IHttpActionResult DeleteEmp(int Id)
        {
            try
            {
                Bser.Delete(Id);
                return Ok("Record Deleted successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut]
        public IHttpActionResult UpdateEmp(EmployeeDetail UpdBank)
        {
            try
            {
                Bser.UpdateDetail(UpdBank);
                return Ok("Record Updated successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

