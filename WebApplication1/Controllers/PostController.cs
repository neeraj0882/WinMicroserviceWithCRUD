using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreServices.Models;
using CoreServices.Repository;
using CoreServices.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        BlogDBContext db;

        IPostRepository postRepository;
        public PostController(IPostRepository _postRepository)
        {
            postRepository = _postRepository;
        }

        [HttpPost]
        [Route("AddCommPref")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddCommPref([FromBody]CommPrefRefRequestModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    await postRepository.AddCommPref(MapInputToModel(model));
                    return Ok();
  
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        public CommunicationPrefs[] MapInputToModel(CommPrefRefRequestModel commPrefReq )
        {
            List<CommunicationPrefs> communicationPrefslIST = new List<CommunicationPrefs>();
            CommunicationPrefs communicationPrefs = null;
           
            foreach (CommPrefModel item in commPrefReq.commpref)
            {
                communicationPrefs = new CommunicationPrefs();
                communicationPrefs.Membernumber = commPrefReq.MemberNumber;
                communicationPrefs.Mail = item.mailFlag;
                communicationPrefs.Email = item.emailFlag;
                communicationPrefs.Sms = item.smsFlag;
                communicationPrefs.Onlinenotification = item.onlineNotificationFlag;
                //communicationPrefs.Transactionid = item.transactionCategory;
                communicationPrefs.Transactionid = postRepository.GetTransactionId(item.transactionCategory.ToString()).Result;
                communicationPrefslIST.Add(communicationPrefs);
            }
            return communicationPrefslIST.ToArray();
        }


    }
}