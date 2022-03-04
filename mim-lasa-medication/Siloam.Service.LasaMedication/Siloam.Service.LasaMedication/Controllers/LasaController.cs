using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Hub;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using Siloam.System.Data;
using Siloam.System.Web;
using Steeltoe.Discovery.Eureka.AppInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LasaController : BaseController
    {
        private readonly IHubContext<MessageHub> messageHubContext;

        public LasaController(IUnitOfWork unitOfWork, IHubContext<MessageHub> _messageHubContext) : base(unitOfWork)
        {
            messageHubContext = _messageHubContext;
        }

        [HttpGet("getAllDataLasa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<CekLasa>>), 200)]
        public IActionResult GetAllData_LasaData()
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                //var data = IUnitOfWork.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                //var data = IUnitOfWork.
               
                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<CekLasa>>("Get All Data Lasa", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    //Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no lasa data available", total);
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

        [HttpPost("PostLasa")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<ParamLasa>>), 200)]
        public IActionResult PostLasa([FromBody] ParamLasa paramLasa)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().PostLasa(paramLasa);
                //var data = IUnitOfWork.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                //var data = IUnitOfWork.

                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<ResponseLasa>>("Get data profile!", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
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

        [HttpGet("getLasaById/{SalesItemId}")]
        [ProducesResponseType(typeof(ResponseData<IEnumerable<CekLasa>>), 200)]
        public IActionResult GetLasaById(Int64 SalesItemId)
        {
            int total = 0;

            try
            {
                var data = IUnitOfWorks.UnitOfWork_TR_Lasa().GetLasaById(SalesItemId);
                //var data = IUnitOfWork.UnitOfWork_TR_Lasa().GetAllData_Lasa();
                //var data = IUnitOfWork.

                total = data.Count();

                if (data.Count() != 0)
                {
                    HttpResults = new ResponseData<IEnumerable<CekLasa>>("Get data lasa!!", Siloam.System.Web.StatusCode.OK, StatusMessage.Success, data);
                }
                else
                {
                    //Exception ex = new Exception();
                    HttpResults = new ResponseMessage(Siloam.System.Web.StatusCode.OK, StatusMessage.Fail, "no lasa data available", total);
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
        //----------------------------------------------------------------------------------------------------------------------------------------------------------

        //control fungsi get data aplikasi by nama aplikasi

    }
}
