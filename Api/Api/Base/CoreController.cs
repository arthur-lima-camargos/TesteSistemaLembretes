﻿using Api.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base
{
    public abstract class CoreController<TModel> : ControllerBase where TModel : class
    {
        protected readonly LembreteContext _context;

        public CoreController(LembreteContext context) { _context = context; }

        [NonAction]
        public void Delete(string id)
        {
            this._context.Remove(this._context.Set<TModel>().Find(id));
            this._context.SaveChanges();
        }

        [NonAction]
        public TModel? Get(string id)
        {
            return this._context.Set<TModel>().Find(id);
        }

        [NonAction]
        public IEnumerable<TModel> GetAll()
        {
            return this._context.Set<TModel>().ToList();
        }

        [NonAction]
        public void Insert(TModel model)
        {
            this._context.Add(model);
            this._context.SaveChanges();
        }

        [NonAction]
        public void Update(TModel model)
        {
            this._context.Update(model);
            this._context.SaveChanges();
        }
    }
}
