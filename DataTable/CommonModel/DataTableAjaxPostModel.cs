namespace DataTable.CommonModel
{
    public class DataTableAjaxPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public Order order { get; set; }
        public List<Order> orderlist { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ContractsType { get; set; }
        public string FleetType { get; set; }
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
        public Nullable<long> FilterBranch { get; set; }
        public string Status { get; set; }
        public string CategoryType { get; set; }
        public string SaleStatus { get; set; }
        public string StockType { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }
    }

    public class Search
    {
        //[JsonProperty(PropertyName = "value")]
        //public string Value { get; set; }

        //[JsonProperty(PropertyName = "regex")]
        //public bool Regex { get; set; }
        public string value { get; set; }
        public string regex { get; set; }
    }
    public class Order
    {
        //[JsonProperty(PropertyName = "column")]
        //public int Column { get; set; }

        //[JsonProperty(PropertyName = "dir")]
        //public string Dir { get; set; }
        public int column { get; set; }
        public string dir { get; set; }

        public string columnstr { get; set; }
        public bool dirbool { get; set; }
    }
}
