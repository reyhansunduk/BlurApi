using System;
using System.Collections.Generic;
using System.Linq;
using BlurApi.Abstract;
using BlurApi.Data;
using BlurApi.Models;

namespace BlurApi.Concrete
{
    public class EnterpriceManager : IEnterpriceService
    {
        private readonly AppDbContext _context;

        public EnterpriceManager(AppDbContext context)
        {
            _context = context;
        }

        public List<Enterprices> GetAll()
        {
            return _context.Enterprices.ToList();
        }

        public Enterprices? GetById(Guid id)
        {
            return _context.Enterprices.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Enterprices entity)
        {
            _context.Enterprices.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Enterprices entity)
        {
            _context.Enterprices.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _context.Enterprices.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Enterprices.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
