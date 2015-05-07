using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.IO;
using System.Threading;

namespace FirstPartKursov
{
    class MailClass
    {
        //функция отправления сообщений 
        public static void SendMail_Click1(string emailreceiver, string myemailadd, string theme, string messbody, string password, string server, List<string> fileName)
        {
            SmtpClient clientSMTP = new SmtpClient(server, 587);

            MailAddress address = new MailAddress(emailreceiver);
            MailMessage message = new MailMessage();
            message.To.Add(address);
            message.From = new MailAddress(myemailadd + "@mail.ru");
            message.IsBodyHtml = true;
            message.Subject = theme;
            message.Body = messbody;
            clientSMTP.Credentials = new System.Net.NetworkCredential(myemailadd, password);
            clientSMTP.EnableSsl = true;
            if (fileName.Count != 0)
            {
                Attachment[] att = new Attachment[fileName.Count];
                System.Net.Mail.Attachment attachment;
                for (int i = 0; i < att.Count(); i++)
                {
                    attachment = new System.Net.Mail.Attachment(@fileName[i]);
                    att[i] = attachment;
                    message.Attachments.Add(att[i]);
                }
                clientSMTP.Send(message);
            }
            else
            {
                clientSMTP.Send(message);
            }
        }
        //функция скачивания сообщения с сервера
        public static string FetchAllMessages(string hostname, int port, bool useSsl, string username, string password, List<Message> allMessages)
        {
            string result;
            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect(hostname, port, useSsl);
                    client.Authenticate(username, password);
                    string text = "";
                    int messageCount = client.GetMessageCount();

                    for (int i = messageCount; i > 0; i--)
                    {
                        allMessages.Add(client.GetMessage(i));
                    }
                    foreach (Message message in allMessages)
                    {
                        var att = message.FindAllAttachments();
                        MessagePart mpPlain = message.FindFirstPlainTextVersion();
                        string mpTheme = message.Headers.Subject.ToString();
                        if (mpPlain != null)
                        {
                            Encoding enc = mpPlain.BodyEncoding;
                            text = enc.GetString(mpPlain.Body);
                        }
                        text += " " + mpTheme;
                        string[] text_ot = text.Split(' ');
                        bool check = false;
                        for (int i = 0; i < text_ot.Count(); i++)
                        {
                            if (text_ot[i].ToLower() == "отчет" || text_ot[i].ToLower() == "продажах" || text_ot[i].ToLower() == "продаже")
                            {
                                foreach (var ado in att)
                                {
                                    ado.Save(new System.IO.FileInfo(System.IO.Path.Combine(@"Отчеты о продажах", ado.FileName)));
                                    check = true;
                                }
                            }
                            else
                            {
                                foreach (var ado in att)
                                {
                                    ado.Save(new System.IO.FileInfo(System.IO.Path.Combine(@"Неопределенные документы", ado.FileName)));
                                }
                            }
                        }
                    }

                }
                return result = "Ok";
            }
            catch (Exception ex)
            {
                return result = "Fail";
            }
        }


    }
}
