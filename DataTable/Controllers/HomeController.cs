using DataTable.CommonModel;
using DataTable.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace DataTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult DataTables()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
       // [HttpPost]
        //public async Task<IActionResult> LoadTable([FromBody] DTParameters dtParameters)
        //{
            //    HttpResponseMessage _response = new HttpResponseMessage();

            //    string _jsonObjectModel = JsonConvert.SerializeObject(AjaxAssignModel.DataTableToAjax(dtParameters));
            //    _response = await _httpClient.Client.PostAsync(ProductsApi.ProductsController.GetPaginationList, new StringContent(_jsonObjectModel, Encoding.UTF8, "application/json"));
            //    var _dataResponse = await _response.Content.ReadAsStringAsync();
            //    DataTableModel _desObject = JsonConvert.DeserializeObject<DataTableModel>(_dataResponse);
            //    List<TableViewModel> _dataList = ConvertToViewModel(_desObject.data, dtParameters.Start);
            //    var jsonItems = Json(new
            //    {
            //        draw = dtParameters.Draw,
            //        recordsTotal = _desObject.recordsTotal,
            //        recordsFiltered = _desObject.recordsFiltered,
            //        data = _dataList
            //            .ToList()
            //    });
            //    return jsonItems;
            //}
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}