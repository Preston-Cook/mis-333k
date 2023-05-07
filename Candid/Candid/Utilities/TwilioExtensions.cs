using Twilio;
using Twilio.Rest.Api.V2010.Account;

using Candid.Models;
using Microsoft.AspNetCore.Identity;
using Candid.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Candid.Utilities
{
    public static class TwilioExtensions
    {
        public static void SendMessage(string msg, string Phone)
        {
            string accountSid = "";
            string authToken = "";
            string TwilioPhone = "+";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber(TwilioPhone),
                to: new Twilio.Types.PhoneNumber(Phone)
            );
        }
    }
}