using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web_API_Crud_Operation_Simple.Models;
using System.Net.Http;
using System.Text;




namespace Web_API_Crud_Operation_Simple.Controllers
{
    public class APIConsumeController : Controller
    {
        // GET: APIConsume
        HttpClient client = new HttpClient();
        string url = "http://localhost:57328";

        [HttpGet]
        public ActionResult GetEMPList()
        {
            url = url + "/api/Employee/";

            List<User> list = new List<User>();
            HttpResponseMessage responce = client.GetAsync(url).Result;
            if (responce != null)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<User>>(result);

                if (data != null)
                {
                    list = data;
                }

            }
            return View(list);
        }
        public ActionResult Country()
        {
           string url1 = "http://localhost:57328/api/Employee/Country/";
            User user = new User();
            List<User> list = new List<User>();
            HttpResponseMessage responce = client.GetAsync(url1).Result;
            if (responce != null)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<User>>(result);

                if (data != null)
                {
                    list = data;
                }
                list.Insert(0, new User { CountryId = 0, Country = "--Select Country--" });
                user.CountryList = new SelectList(list, "CountryId", "Country", 0);
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult SaveEmp()
        {
            Country();
             return View(); 
        }
        [HttpPost]
        public ActionResult SaveEmp(User emp)
        {
            url = url + "/api/Employee/";
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage responce = client.PostAsync(url, content).Result;
            if (responce != null)
            {
                return RedirectToAction("GetEMPList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailsEMP(int id)
        {
           
            url = url + "/api/Employee/Edit/";

           User obj = new User();
            // List<User> list = new List<User>();
            Country();
            HttpResponseMessage responce = client.GetAsync(url+id).Result;
            if (responce != null)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<User>(result);

                if (data != null)
                {
                    obj = data;
                }

            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult DetailsEMP(User emp)
        {
            url = url + "/api/Employee/";
            string data = JsonConvert.SerializeObject(emp);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(url, content).Result;
            if (responce != null)
            {
                return RedirectToAction("GetEMPList");
            }
            return View();
        }
        public ActionResult DeleteEMP(int id)
        {
            url = url + "/api/Employee/";
            HttpResponseMessage responce = client.DeleteAsync(url+id).Result;
            if (responce != null)
            {
                return RedirectToAction("GetEMPList");
            }
            return View();
        }
    }
}