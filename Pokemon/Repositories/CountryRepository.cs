using AutoMapper;
using Pokemon.Data;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(DataContext context,IMapper mapper) 
        {
            _context = context;   
            _mapper = mapper;
        }

        public bool CountryEixsts(int Id)
        {
            return _context.Countries.Any(c => c.Id == Id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(int Id)
        {
            return _context.Countries.Where(c => c.Id == Id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int Id)
        {
            return _context.Owners.Where(c => c.Id == Id).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int Id)
        {
            return _context.Owners.Where(o => o.Country.Id == Id).ToList();
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return save();
        }

        public bool save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
