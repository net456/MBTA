using System;
using System.Collections.Generic;
using System.Linq;
using MbtaApi;
using MbtaApi.Model;

namespace MbtaApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MbtaApiData mbtaApiData = new MbtaApiData();

            ApiResult<MbtaRoutes> apiResult = mbtaApiData.GetMbtaRoutesData();

            // Make sure API worked.
            if (!apiResult.Success)
            {
                WriteFailureMessage(string.Format("Failure result returned from routes API [{0}].", apiResult.Message));
                return;
            }


            MbtaRoutes mbtaRoutes = apiResult.Result;

            // Make sure API returned any data.
            if (mbtaRoutes.data == null || mbtaRoutes.data.Count == 0)
            {
                WriteFailureMessage("No MBTA routes found.");
                return;
            }

            IList<MbtaRoutes.Datum> noAttributeRoutes = mbtaRoutes.data.Where(d => d.attributes == null).ToList();

            // Make sure API returned routes data with attributes (I noticed in some cases, API returns missing data).  

            if (noAttributeRoutes.Count > 0)
            {
                WriteFailureMessage("Routes data contains missing attributes.");
                return;
            }

            // One of task assignments was to get long names of routes.
            List<string> longNames = mbtaRoutes.data.Select(d => d.attributes.long_name).ToList();
            
            Console.Write(string.Join(Environment.NewLine, longNames));

            MbtaRoutes.Datum worcesterFramingramLine = mbtaRoutes.data.FirstOrDefault(d => string.Equals(d.attributes.long_name, "Framingham/Worcester Line"));

            // Make sure Worcester / Framingham line in contained in the response.
            if(worcesterFramingramLine == null)
            {
                WriteFailureMessage("Wrocester / Framingham line is not found.");
                return;
            }

            Console.Write(Environment.NewLine);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static void WriteFailureMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
