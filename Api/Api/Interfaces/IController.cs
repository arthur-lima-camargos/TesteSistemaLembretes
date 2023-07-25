namespace Api.Interfaces
{
    public interface IController<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel? Get(string id);
        void Delete(string id);
        void Insert(TModel model);
        void Update(TModel model);
    }
}
