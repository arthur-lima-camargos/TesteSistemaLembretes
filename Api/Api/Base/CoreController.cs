using Api.DbContexts;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base
{
    public abstract class CoreController<TModel> : ControllerBase, IController<TModel>  where TModel : class
    {
        protected readonly LembreteContext _context;

        public CoreController(LembreteContext context) { _context = context; }


        public void Delete(string id)
        {
            this._context.Remove(this._context.Set<TModel>().Find(id));
            this._context.SaveChanges();
        }

        public TModel? Get(string id)
        {
            return this._context.Set<TModel>().Find(id);
        }

        public IEnumerable<TModel> GetAll()
        {
            return this._context.Set<TModel>().ToList();
        }

        public void Insert(TModel model)
        {
            this._context.Add(model);
            this._context.SaveChanges();
        }

        public void Update(TModel model)
        {
            this._context.Update(model);
            this._context.SaveChanges();
        }
    }
}
