using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.WebApi.Utilities.ApiServices
{
    public class MessageFactory
    {
        private Logger.Logger _Logger;
        public MessageFactory(Logger.Logger Logger)
        {
            this._Logger = Logger;
        }
        public T SendRequest<T>(string EndPointUrl, string Action, string Payload, HttpMethod Method)
        {
            string _Response = string.Empty;
            DateTime dt1 = DateTime.Now;
            for (int i = 0; i < 4; i++)
            {
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.DefaultConnectionLimit = 9999;
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13 | System.Net.SecurityProtocolType.Ssl3 | SecurityProtocolType.SystemDefault;
                System.Net.ServicePointManager.SecurityProtocol =
    SecurityProtocolType.Tls |
    SecurityProtocolType.Tls11 |
    SecurityProtocolType.Tls12;


                using (HttpClient _HttpClient = new HttpClient())
                using (HttpRequestMessage _HttpRequestMessage = new HttpRequestMessage(Method, EndPointUrl + Action))
                {
                    _HttpClient.DefaultRequestHeaders.Clear();
                    _HttpClient.MaxResponseContentBufferSize = 2147483647;
                    _HttpClient.Timeout = TimeSpan.FromMilliseconds(5400000);

                    // Agrega la autorización como "Basic" con el valor del API KEY
                    //_HttpClient.DefaultRequestHeaders.Add("API-KEY", apiKey);

                    // Configura el contenido JSON en el cuerpo de la solicitud
                    _HttpRequestMessage.Content = new StringContent(Payload, Encoding.UTF8, "application/json");
                    using (HttpResponseMessage _HttpResponseMessage = _HttpClient.SendAsync(_HttpRequestMessage).Result)
                    {
                        if (!_HttpResponseMessage.IsSuccessStatusCode)
                        {
                            switch (_HttpResponseMessage.StatusCode)
                            {
                                case System.Net.HttpStatusCode.BadRequest:
                                    Console.WriteLine(((int)_HttpResponseMessage.StatusCode).ToString() + " " + _HttpResponseMessage.ReasonPhrase + " " + _HttpResponseMessage.Content.ReadAsStringAsync().Result);
                                    Console.WriteLine(EndPointUrl);
                                    Console.WriteLine(Payload);
                                    throw new Exception(((int)_HttpResponseMessage.StatusCode).ToString() + " " + _HttpResponseMessage.ReasonPhrase + " " + _HttpResponseMessage.Content.ReadAsStringAsync().Result);
                                case System.Net.HttpStatusCode.Unauthorized:
                                case System.Net.HttpStatusCode.NotFound:
                                    throw new Exception(((int)_HttpResponseMessage.StatusCode).ToString() + " " + _HttpResponseMessage.ReasonPhrase + " " + _HttpResponseMessage.Content.ReadAsStringAsync().Result);
                                default:
                                    TimeSpan span = (DateTime.Now) - dt1;
                                    Console.WriteLine("Execution time: " + span.TotalMilliseconds.ToString() + " milliseconds, retried " + i.ToString() + " times.");
                                    Console.WriteLine(EndPointUrl);
                                    Console.WriteLine(Payload);
                                    if (i >= 3)
                                    {
                                        Console.WriteLine(((int)_HttpResponseMessage.StatusCode).ToString() + " " + _HttpResponseMessage.ReasonPhrase + " " + _HttpResponseMessage.Content.ReadAsStringAsync().Result);
                                        Console.WriteLine(EndPointUrl);
                                        Console.WriteLine(Payload);
                                        throw new Exception(((int)_HttpResponseMessage.StatusCode).ToString() + " " + _HttpResponseMessage.ReasonPhrase + " " + _HttpResponseMessage.Content.ReadAsStringAsync().Result);
                                    }
                                    break;
                            }
                            continue;
                        }
                        _Response = _HttpResponseMessage.Content.ReadAsStringAsync().Result;
                        break;
                    }
                }
            }
            return Serializer.JsonSerializer.Deserialize<T>(_Response);
        }
    }
}
