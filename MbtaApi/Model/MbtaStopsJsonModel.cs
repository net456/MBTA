using System.Collections.Generic;

namespace MbtaApi.Model
{
    public class MbtaStops
    {
        public Links StopLinks { get; set; }
        public List<Datum> data { get; set; }
        

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Links
        {
            public string self { get; set; }
            public string prev { get; set; }
            public string next { get; set; }
            public string last { get; set; }
            public string first { get; set; }
        }

        public class Links2
        {
            public string self { get; set; }
            public string related { get; set; }
        }

        public class Data
        {
            public string type { get; set; }
            public string id { get; set; }
        }

        public class ParentStation
        {
            public Links2 links { get; set; }
            public Data data { get; set; }
        }

        public class Relationships
        {
            public ParentStation parent_station { get; set; }
        }

        public class Links3
        {
        }

        public class Attributes
        {
            public int? wheelchair_boarding { get; set; }
            public int? vehicle_type { get; set; }
            public string platform_name { get; set; }
            public string platform_code { get; set; }
            public string on_street { get; set; }
            public string name { get; set; }
            public string municipality { get; set; }
            public double? longitude { get; set; }
            public int? location_type { get; set; }
            public double? latitude { get; set; }
            public string description { get; set; }
            public string at_street { get; set; }
            public string address { get; set; }
        }

        public class Datum
        {
            public string type { get; set; }
            public Relationships relationships { get; set; }
            public Links3 links { get; set; }
            public string id { get; set; }
            public Attributes attributes { get; set; }
        }

    }

}
