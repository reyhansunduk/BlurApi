using BlurApi.Models;
using System;
using System.Collections.Generic;

namespace BlurApi.Abstract
{

    public interface IEnterpriceService
    {
        List<Enterprices> GetAll();
        Enterprices? GetById(Guid id);
        void Add(Enterprices entity);
        void Update(Enterprices entity);
        void Delete(Guid id);
    } 
}