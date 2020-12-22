using System.Collections.Generic;

namespace MbtaApi.Model
{
    // MbtaLines myDeserializedClass = JsonConvert.DeserializeObject<MbtaLines>(myJsonResponse); 

    public class MbtaLines
    {
        public List<Datum> data { get; set; }
        public List<Included> included { get; set; }
        public Jsonapi jsonapi { get; set; }


        public class Attributes
        {
            public string color { get; set; }
            public string long_name { get; set; }
            public string short_name { get; set; }
            public int sort_order { get; set; }
            public string text_color { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
        }

        public class Datum2
        {
            public string id { get; set; }
            public string type { get; set; }
        }

        public class Routes
        {
            public List<Datum2> data { get; set; }
        }

        public class Relationships
        {
            public Routes routes { get; set; }
        }

        public class Datum
        {
            public Attributes attributes { get; set; }
            public string id { get; set; }
            public Links links { get; set; }
            public Relationships relationships { get; set; }
            public string type { get; set; }
        }

        public class Attributes2
        {
            public string color { get; set; }
            public string description { get; set; }
            public List<string> direction_destinations { get; set; }
            public List<string> direction_names { get; set; }
            public string fare_class { get; set; }
            public string long_name { get; set; }
            public string short_name { get; set; }
            public int sort_order { get; set; }
            public string text_color { get; set; }
            public int type { get; set; }
        }

        public class Links2
        {
            public string self { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string type { get; set; }
        }

        public class Line
        {
            public Data data { get; set; }
        }

        public class RoutePatterns
        {
        }

        public class Relationships2
        {
            public Line line { get; set; }
            public RoutePatterns route_patterns { get; set; }
        }

        public class Included
        {
            public Attributes2 attributes { get; set; }
            public string id { get; set; }
            public Links2 links { get; set; }
            public Relationships2 relationships { get; set; }
            public string type { get; set; }
        }

        public class Jsonapi
        {
            public string version { get; set; }
        }
    }
}
