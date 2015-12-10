using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace Web.Helpers
{
    public static class Utils
    {
        public static string GenerateId(string prefix)
        {
            return $"{prefix}_{Guid.NewGuid().ToString("N")}";
        }

        public static IEnumerable<PreValue> GetDataTypePreValues(string dataTypeName)
        {
            var service = ApplicationContext.Current.Services.DataTypeService;
            var dataType = service.GetDataTypeDefinitionByName(dataTypeName);
            return service.GetPreValuesCollectionByDataTypeId(dataType.Id)
                .FormatAsDictionary()
                .Values;
        }

        public static IEnumerable<IPublishedContent> ChildrenOfDocType(this IPublishedContent content, string docTypeAlias)
        {
            return content.Children.Where(i => i.DocumentTypeAlias == docTypeAlias);
        }

        public static void SendEmail(string emailFrom, string emailTo, string subject, string body)
        {
            var message = new MailMessage
            {
                From = new MailAddress(emailFrom, emailFrom),
                Subject = subject,
                SubjectEncoding = Encoding.UTF8,
                Body = body,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };
            message.To.Add(emailTo);

            var smtpClient = new SmtpClient();
            smtpClient.Send(message);
        }
    }
}
