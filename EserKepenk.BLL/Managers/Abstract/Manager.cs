using DTOs;
using Entities;
using EserKepenk.DAL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.BLL.Managers.Abstract
{
    public abstract class Manager<TDto, TEntity> : IManager<TDto>  where TDto : BaseDto where TEntity : BaseEntity
    {
        protected Service<TEntity, TDto> _service;
        protected Manager(Service<TEntity, TDto> service)
        {
            _service = service;
        }


        public int Add(TDto dto) { return _service.Add(dto); }
        public int Update(TDto dto) { return _service.Update(dto); }
        public int Delete(TDto dto) { return _service.Delete(dto); }
        public IEnumerable<TDto> GetAll() { return _service.GetAll(); }
        public TDto? GetById(int id) { return _service.GetById(id); }

        public TDto? GetByIdAsync(int id) { return _service.GetByIdAsync(id); }
    }
}
