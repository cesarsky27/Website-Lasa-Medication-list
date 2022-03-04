using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Hub;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using Siloam.System.Data;
using Siloam.System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Controllers
{
    public class UserController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContext;

        public UserController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
        {
            messageHubContext = _messageHubContext;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ParamLogin>>), 200)]
        public IActionResult Login_User([FromBody]ParamLogin paramLogin)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_MS_User().Login_User(paramLogin);
                //var data = IUnitOfWork.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                //var data = IUnitOfWork.

                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ViewLogin>>("Get data profile!", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    //Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no data profile available", total);
                }
            }
            catch (Exception exx)
            {
                int exCode = exx.HResult;

                if (exCode == -2147467259)
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.InternalServerErrorException, StatusMessage.Error, exx.Message, total);
                }
                else
                {
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.UnprocessableEntity, StatusMessage.Fail, exx.Message, total);
                }
            }

            return HttpResponse(HttpResults);
        }
    }
}
