using AutoMapper;
using Hospital_Managment.Data;
using Microsoft.EntityFrameworkCore;
using SampleApi;
using SampleApi.Mapper;
using SampleApi.Models;

namespace SampleApi.Repository
{
    public class TrailRepository:ITrailRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TrailRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db=db;
            _mapper=mapper;
        }
        public bool CreateTrail(Trail trail)
        {
            
            _db.Trail.Add(trail);
            return Save();

        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ? true : false;
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trail.Remove(trail);
            return Save();
        }

        public ICollection<Trail> GetTrail(PagingParameter pagingParameter)
        {
            return PagedList<Trail>.ToPagedList(_db.Trail.Include(x => x.NationalPark),
                   pagingParameter.PageNumber,
                   pagingParameter.PageSize);

            //return _db.NationalPark.OrderBy(r => Guid.NewGuid()).ToList();
            //OrderByDescending(park => park.Id).ToList();
            //OrderByDescinding(x => x.Id).ToList();
        //    return _db.Trail.Include(x => x.NationalPark).Skip((pagingParameter.PageNumber - 1) * pagingParameter.PageSize)
        //.Take(pagingParameter.PageSize)
        //.ToList();
        }

        public Trail GetTrailById(int id)
        {
            return _db.Trail.Include(x => x.NationalPark).FirstOrDefault(a => a.Id ==id)!;
            //var obj = _db.Trail.FirstOrDefault(a => a.Id==id);
           

           
        }

        public bool TrailExists(String name)
        {
            bool value = _db.Trail.Any(a => a.Name!.ToLower().Trim() ==name.ToLower().Trim());
            return value;

        }

        public bool TrailExists(int id)
        {
            bool value = _db.Trail.Any(a => a.Id ==id);
            return value;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trail.Update(trail);
            return Save();
        }

        public ICollection<Trail> GetTrailInNationalPark(int npId)
        {
            return _db.Trail.Include(x => x.NationalPark).Where(x => x.NationalParkId==npId).ToList();

        }
    }
}
public interface ITrailRepository
{


    ICollection<Trail> GetTrail(PagingParameter paging);
    ICollection<Trail> GetTrailInNationalPark(int npId);
    Trail GetTrailById(int id);
    bool TrailExists(int name);
    bool TrailExists(string id);
    bool CreateTrail(Trail trail);
    bool UpdateTrail(Trail trail);
    bool DeleteTrail(Trail trail);
    bool Save();

}