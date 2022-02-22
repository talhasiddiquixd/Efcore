using Hospital_Managment.Data;
using SampleApi;
using SampleApi.Models;
using System.Linq;

namespace SampleApi.Repository
{
    public class NationalParkRepository : INationalParkRepository
    { 
        private readonly ApplicationDbContext _db;

    public NationalParkRepository(ApplicationDbContext db)
    {
        _db=db;
    }
    
        public bool CreateNationalPark(NationalPark park)
        {
            
            _db.NationalPark.Add(park);  
            return Save();

        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ?true:false;
        }

        public bool DeleteNationalPark(NationalPark park)
        {
            _db.NationalPark.Remove(park);
            return Save();
        }

        public ICollection<NationalPark> GetNationalPark()//PagingParameter pagingParameter
        {
            return _db.NationalPark.ToList();
            //OrderByDescending(park => park.Id).ToList();
            //OrderByDescinding(x => x.Id).ToList();
            //return PagedList<NationalPark>.ToPagedList(_db.NationalPark.OrderBy(x=>x.Name),
            //       pagingParameter.PageNumber,
            //       pagingParameter.PageSize);

            //    return _db.NationalPark.OrderByDescending(x => x.Name).Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize)
            //.Take(pagingParameter.PageSize)
            //.ToList();
        }

        public NationalPark GetNationalPark(int id)
        {
            return _db.NationalPark.FirstOrDefault(a => a.Id ==id)!;
        }

        public bool NationalParkExists(String name)
        {
         bool value=_db.NationalPark.Any(a=>a.Name!.ToLower().Trim() ==name.ToLower().Trim());
            return value;

        }

        public bool NationalParkExists(int id)
        {
            bool value = _db.NationalPark.Any(a => a.Id ==id);
            return value;
        }

        public bool UpdateNationalPark(NationalPark park)
        {
            _db.NationalPark.Update(park);
            return Save();
        }
    }
}
public interface INationalParkRepository
{


    ICollection<NationalPark> GetNationalPark();//PagingParameter pagingParameter
    NationalPark GetNationalPark(int id);
    bool NationalParkExists(int name);
    bool NationalParkExists(string id);
    bool CreateNationalPark(NationalPark park);
    bool UpdateNationalPark(NationalPark park);
    bool DeleteNationalPark(NationalPark park);
    bool Save();

}