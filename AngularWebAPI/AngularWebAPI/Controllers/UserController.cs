using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using AngularWebAPIDataAccess;
namespace AngularWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<CORUSERMST> Get()
        {
            using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
            {
                return (entities.CORUSERMSTs).ToList();
            }
        }
        public CORUSERMST Get(int id)
        {
            using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
            {
                return entities.CORUSERMSTs.SingleOrDefault(e => e.User_ID == id);
            }
        }
        [EnableCorsAttribute("*", "*", "*")]
        public void Post([FromBody] CORUSERMST user)
        {
            using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
            {
                entities.CORUSERMSTs.Add(user);
                entities.SaveChanges();
            }
        }
        [HttpGet]
        [Authorize]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                //Email = identityClaims.FindFirst("Email").Value,
                //FirstName = identityClaims.FindFirst("FirstName").Value,
                //LastName = identityClaims.FindFirst("LastName").Value,
                //LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
                {
                    var entity = entities.CORUSERMSTs.FirstOrDefault(e => e.User_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.CORUSERMSTs.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody]CORUSERMST user)
        {
            try
            {
                using (AngularWebAPIEntities entities = new AngularWebAPIEntities())
                {
                    var entity = entities.CORUSERMSTs.FirstOrDefault(e => e.User_ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.User_Address = user.User_Address;
                        entity.User_EmailID = user.User_EmailID;
                        entity.User_Name = user.User_Name;
                        entity.User_Password = user.User_Password;
                        entity.User_Username = user.User_Username;
                        

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
