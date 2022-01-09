namespace DAL.Repository {
    public interface IRepository<T> {

        public bool Create(T data);
        public bool Update(T data);
        public T Read(string name);
        public List<T> ReadAll();
        public bool Delete(string name);

    }
}
