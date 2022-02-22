namespace DataTable.CommonModel
{
    public static class AjaxAssignModel
    {
        public static DataTableAjaxPostModel DataTableToAjax(DTParameters dtModel)
        {
            DataTableAjaxPostModel ajaxPostModel = new DataTableAjaxPostModel();
            var searchBy = dtModel.searchBy;
            ajaxPostModel.StartDate = dtModel.StartDate;
            ajaxPostModel.EndDate = dtModel.EndDate;
            ajaxPostModel.CompanyId = dtModel.CompanyId;
            ajaxPostModel.BranchId = dtModel.BranchId;
            ajaxPostModel.Status = dtModel.Status;
            ajaxPostModel.SaleStatus = dtModel.SaleStatus;
            ajaxPostModel.StockType = dtModel.StockType;
            Search search = new Search();
            search.value = searchBy;
            ajaxPostModel.search = search;
            ajaxPostModel.CategoryType = dtModel.CategoryType;
            ajaxPostModel.FilterBranch = dtModel.FilterBranch;
            Order order = new Order();


            if (dtModel.Order != null)
            {
                order.columnstr = dtModel.Columns[dtModel.Order[0].Column].Data;
                order.dirbool = dtModel.Order[0].Dir.ToString().ToLower() == "asc";
            }
            //else if (dtModel.Order== "productName")
            //{

            //}
            else
            {
                order.columnstr = "Id";
                order.dirbool = true;
            }
            ajaxPostModel.order = order;
            ajaxPostModel.draw = dtModel.Draw;
            ajaxPostModel.start = dtModel.Start;
            ajaxPostModel.length = dtModel.Length;
            return ajaxPostModel;
        }
    }
}
