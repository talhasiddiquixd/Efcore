using DataTable.Models;
using DataTable.Repository;

namespace DataTable.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public NationalParkRepository(IHttpClientFactory clientFactory):base(clientFactory)
        {
            _clientFactory=clientFactory;

        }
    }

}
interface INationalParkRepository:IRepository<NationalPark>
{

}