using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PBADataAccessLayerLib;
using PBABusinessLayerLib;
using PBAEntitiesLayerLib;
using PBAExceptionLib;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace PBAWebApi.Controllers
{
    public class PBAController : ApiController
    {
        public List<ContactCategory> Get()
        {
            PBABusiness bll = new PBABusiness();
            var lstCat = bll.GetAllcategoryNames();
            return lstCat;
        }
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Found");
            try
            {
                PBABusiness bll = new PBABusiness();
                var lstContacts = bll.GetAllContactsById(id);
                return res = Request.CreateResponse<List<Contact>>(lstContacts);
            }
            catch (Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        public HttpResponseMessage Post([FromBody] ContactCategory cat)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Inserted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.AddContactCategory(cat);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record not found");
            }
            return errRes;
        }
        [Route("api/PBA/AddContact")]
        public HttpResponseMessage AddContact([FromBody] Contact contact)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Inserted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.AddContact(contact);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Records Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.DeleteCategoryById(id);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        [Route("api/PBA/DeleteContact/{id}")]
        public HttpResponseMessage DeleteContact(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Records Deleted");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.DeleteContactById(id);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        public HttpResponseMessage Put([FromBody]ContactCategory cat,int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Records Updated");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.UpdateCategoryById(cat);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        [Route("api/PBA/UpdateContact/{id}")]
        public HttpResponseMessage PutContact([FromBody]Contact contact,int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Records Updated");
            try
            {
                PBABusiness bll = new PBABusiness();
                bll.UpdateContactById(contact);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
    
    }
}





