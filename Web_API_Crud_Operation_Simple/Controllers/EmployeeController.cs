using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_Crud_Operation_Simple.Models;
using System.Data;
using System.Data.SqlClient;

namespace Web_API_Crud_Operation_Simple.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult UserList()
        
        {
            BAL bal = new BAL();
            User obj1 = new User();
            DataSet ds = new DataSet();
            ds = bal.UserList();
            List<User> list = new List<User>();
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obj = new User();
                obj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                obj.Name = ds.Tables[0].Rows[i]["User_Name"].ToString();
                obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                obj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                obj.City = ds.Tables[0].Rows[i]["CityName"].ToString();

                list.Add(obj);
            }
            // obj.UsersList = list;
            var EMPList = list.ToList();
            return Ok(EMPList);
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult SaveUser(User obj)
        {
            BAL bal = new BAL();
            obj.Id = 0;
            bal.Save(obj);
            return Ok();
        }
        
        [HttpGet]
        [Route("Edit/{id}")]
        public IHttpActionResult Edit(int id)
        {
            User user = new User();

            BAL bal = new BAL();
            DataSet ds = new DataSet();
            user.Id = id;
            ds =  bal.EditUser(user);
           // List<User> list = new List<User>();
            int i = 0;
               
            user.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
            user.Name = ds.Tables[0].Rows[i]["User_Name"].ToString();
            user.Address = ds.Tables[0].Rows[i]["Address"].ToString();
            user.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
            user.City = ds.Tables[0].Rows[i]["CityName"].ToString();
            user.CityId =  Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());

            //     list.Add(user);

            // obj.UsersList = list;
            var EMP_Details = user;
            return Ok(EMP_Details);
        }
        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(User obj)
        {
            BAL bal = new BAL();
           // obj.Id = id;
            bal.Save(obj);
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            User user = new User();
            BAL bal = new BAL();
            user.Id = id;
            bal.Delete(user);
            return Ok();
        }

        [HttpGet]
        [Route("Country")]
        public IHttpActionResult Country()
        {
            BAL bal = new BAL();
            User obj1 = new User();
            DataSet ds = new DataSet();
            ds = bal.Country();
            List<User> list = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obj = new User();
                obj.CountryId = Convert.ToInt32(ds.Tables[0].Rows[i]["CountryId"].ToString());
                obj.Country = ds.Tables[0].Rows[i]["CountryName"].ToString();

                list.Add(obj);
            }
            // obj.UsersList = list;
            var EMPList = list.ToList();
            return Ok(EMPList);
        }
        [HttpGet]
        [Route("State")]
      //  [HttpGet, ActionName("State")]
        public IHttpActionResult State(int id)
        {
            BAL bal = new BAL();
            User obj1 = new User();
            obj1.CountryId = id;
            DataSet ds = new DataSet();
            ds = bal.State(obj1);
            List<User> list = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obj = new User();
                obj.StateId = Convert.ToInt32(ds.Tables[0].Rows[i]["StateId"].ToString());
                obj.State = ds.Tables[0].Rows[i]["StateName"].ToString();

                list.Add(obj);
            }
            // obj.UsersList = list;
            var EMPList = list.ToList();
          //  return Ok(EMPList);
          return Json(list);
        }

        [HttpGet]
        [Route("City")]
        public IHttpActionResult City(int id)
        {
            BAL bal = new BAL();
            User obj1 = new User();
            obj1.StateId = id;
            DataSet ds = new DataSet();
            ds = bal.City(obj1);
            List<User> list = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obj = new User();
                obj.CityId = Convert.ToInt32(ds.Tables[0].Rows[i]["CityId"].ToString());
                obj.City = ds.Tables[0].Rows[i]["CityName"].ToString();

                list.Add(obj);
            }
            // obj.UsersList = list;
            var EMPList = list.ToList();
            //return Ok(EMPList);
            return Json(list);
        }

    }
}
