using System.Collections.Generic;
using System.Linq;
using MbtaApi;
using MbtaApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MbtaApiTest
{
    [TestClass]
    public class UnitTest
    {
        private readonly MbtaApiData _mbtaApiData = new MbtaApiData();

        [TestMethod]
        public void TestGetAllRoutes()
        {
            ApiResult<MbtaRoutes> apiResult = _mbtaApiData.GetMbtaRoutesData();

            // Make sure API worked.
            Assert.IsTrue(apiResult.Success, string.Format("Failure result returned from routes API [{0}].", apiResult.Message));

            MbtaRoutes mbtaRoutes = apiResult.Result;
            
            // Make sure API returned any data.
            Assert.IsTrue(mbtaRoutes.data != null && mbtaRoutes.data.Count > 0, "No MBTA routes found.");

            IList<MbtaRoutes.Datum> noAttributeRoutes = mbtaRoutes.data.Where(d => d.attributes == null).ToList();
            
            // Make sure API returned routes data with attributes (I noticed in some cases, API returns missing data.    
            Assert.IsTrue(noAttributeRoutes.Count == 0, "Routes data contains missing attributes.");
            
            // One of task assignments was to get long names of routes.
            List<string> longNames = mbtaRoutes.data.Select(d => d.attributes.long_name).ToList();

            MbtaRoutes.Datum worcesterFramingramLine = mbtaRoutes.data.FirstOrDefault(d => string.Equals(d.attributes.long_name, "Framingham/Worcester Line"));
            
            // Make sure Worcester / Framingham line in contained in the response.
            Assert.IsTrue(worcesterFramingramLine != null, "Wrocester / Framingham line is not found");
        }


        [TestMethod]
        public void TestGetMbtaLineStops()
        {
            ApiResult<MbtaStops> apiResult = _mbtaApiData.GetMbtaStopsData();

            // Make sure API worked.
            Assert.IsTrue(apiResult.Success, string.Format("Failure result returned from stops API [{0}].", apiResult.Message));
            
            MbtaStops mbtaStops = apiResult.Result;

            Assert.IsTrue(mbtaStops.data != null && mbtaStops.data.Count > 0, "No MBTA stops found.");

            IList<MbtaStops.Datum> noAttributeRoutes = mbtaStops.data.Where(d => d.attributes == null).ToList();

            Assert.IsTrue(noAttributeRoutes.Count == 0, "Routes data contains missing attributes.");
        }

        [TestMethod]
        public void TestGetMbtaLinesWithRoutes()
        {
            ApiResult<MbtaLines> apiResult = _mbtaApiData.GetMbtaLinesData();

            // Make sure API worked.
            Assert.IsTrue(apiResult.Success, string.Format("Failure result returned from lines API [{0}].", apiResult.Message));

            MbtaLines mbtaRoutes = apiResult.Result;

            // Make sure API returned any data.
            Assert.IsTrue(mbtaRoutes.data != null && mbtaRoutes.data.Count > 0, "No MBTA routes found.");

            IList<MbtaLines.Datum> noAttributeRoutes = mbtaRoutes.data.Where(d => d.attributes == null).ToList();

            // Make sure API returned routes data with attributes (I noticed in some cases, API returns missing data.    
            Assert.IsTrue(noAttributeRoutes.Count == 0, "Routes data contains missing attributes.");

            // One of task assignments was to get long names of routes.
            List<string> longNames = mbtaRoutes.data.Select(d => d.attributes.long_name).ToList();

            MbtaLines.Datum worcesterFramingramLine = mbtaRoutes.data.FirstOrDefault(d => string.Equals(d.attributes.long_name, "Framingham/Worcester Line"));

            // Make sure Worcester / Framingham line in contained in the response.
            Assert.IsTrue(worcesterFramingramLine != null, "Wrocester / Framingham line is not found");
        }
    }
}
