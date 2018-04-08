using DBContextSQLite;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public abstract class RepositoryBase<Model> : IDisposable where Model : ModelBase
    {
        protected VeiculoContext _context { get; set; }
        public RepositoryBase(VeiculoContext context)
        {
            _context = context;
        }
        protected void Update(Model model)
            => Update<Model>(model);
        protected void Update<ModelType>(ModelType model) where ModelType : ModelBase
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        protected void Delete(Guid id)
            => Delete<Model>(id);
        protected void Delete<ModelType>(Guid id) where ModelType : ModelBase
        {
            ModelType model = _context.Set<ModelType>().SingleOrDefault(m => m.Id == id && m.Ativo);
            model.Ativo = false;
            _context.SaveChanges();
        }

        protected void Save(Model model)
            => Save<Model>(model);
        protected void Save<ModelType>(ModelType model) where ModelType : ModelBase
        {
            model.Id = Guid.NewGuid();
            model.DataCriacao = DateTime.Now;
            model.Ativo = true;
            _context.Add(model);
            _context.SaveChanges();
        }

        protected bool IsExist(Expression<Func<Model, bool>> where)
            => IsExist<Model>(where);
        protected bool IsExist<ModelType>(Expression<Func<ModelType, bool>> where) where ModelType : ModelBase
            => _context.Set<ModelType>().Where(m => m.Ativo).Any(where);

        protected bool IsExist(Expression<Func<Model, bool>> where, out Model model)
            => IsExist<Model>(where, out model);
        protected bool IsExist<ModelType>(Expression<Func<ModelType, bool>> where, out ModelType model) where ModelType : ModelBase
        {
            model = _context.Set<ModelType>().Where(m => m.Ativo).Where(where).FirstOrDefault();
            return model != null;
        }

        protected IQueryable<Model> Read(Expression<Func<Model, bool>> where = null, params Expression<Func<Model, object>>[] includes)
            => Read<Model>(where, includes);
        protected IQueryable<ModelType> Read<ModelType>(
            Expression<Func<ModelType, bool>> where = null,
            params Expression<Func<ModelType, object>>[] includes) where ModelType : ModelBase
        {
            IQueryable<ModelType> query = _context.Set<ModelType>().Where(m => m.Ativo);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            if (where != null)
                query = query.Where(where);

            return query;
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
