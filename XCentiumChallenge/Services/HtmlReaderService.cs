using System;
using System.IO;
using System.Net;
using System.Text;

namespace XCentiumChallenge.Services
{
    public class HtmlReaderService : IHtmlReaderService
    {
        public string GetHtml(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (string.IsNullOrWhiteSpace(response.CharacterSet))
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream,
                            Encoding.GetEncoding(response.CharacterSet));
                    var html = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();

                    return html;
                }
                else
                {
                    throw new Exception("An error happened trying get HTML code from " + url + ". Details: " + response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}