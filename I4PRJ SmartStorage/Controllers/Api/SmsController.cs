using System.Web.Http;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class SmsController : ApiController
  {
    // POST: api/Sms
    public IHttpActionResult Callback(string messageid, string statuscode, string sentdate, string donedate)
    {

      return Ok();
    }
  }
}
