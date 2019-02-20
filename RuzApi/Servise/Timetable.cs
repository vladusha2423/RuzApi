using Newtonsoft.Json;
using RuzApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RuzApi.Servise
{
    public class Timetable
    {
        public static List<RuzLesson> GetListLesson(DateTime fromDate, DateTime toDate, string email)
        {
            string sURL;
            sURL = "https://www.hse.ru/api/timetable/lessons?fromdate=" + fromDate.ToString("yyyy.MM.dd") + "&todate=" + toDate.ToString("yyyy.MM.dd") + "&email=" + email;
            Console.WriteLine(sURL);
            WebRequest request;
            request = WebRequest.Create(sURL);
            Stream stream;
            stream = request.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(stream);

            string sLine = "";
            string jsonData = "";

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                jsonData += sLine;
            }

            RootObject obj = JsonConvert.DeserializeObject<RootObject>(jsonData);
            return obj.Lessons;

        }

        internal static List<RuzLesson> GetListLesson(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        //private string API { get; set; } = "https://www.hse.ru/api/timetable/lessons?";

        //public async Task<List<RuzLesson>> GetLessons(DateTime fromDate, DateTime toDate,
        //    string email)
        //{
        //    RootObject obj = new RootObject();
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(API + "fromdate=" +
        //        fromDate.ToString("yyyy.MM.dd") + "&todate=" + toDate.ToString("yyyy.MM.dd")
        //        + "&email=" + email);
        //    var a = API + "fromdate=" +
        //        fromDate.ToString("yyyy.MM.dd") + "&todate=" + toDate.ToString("yyyy.MM.dd")
        //        + "&email=" + email;
        //    Console.WriteLine(a);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        obj = await response.Content.ReadAsAsync<RootObject>();
        //    }
        //    return obj.Lessons;
        //}
    }
}
