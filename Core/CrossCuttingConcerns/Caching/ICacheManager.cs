namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration); //Cache'e ekle.
        bool IsAdd(string key); //Cache'de var mı?
        void Remove(string key); //Cache'den sil.
        void RemoveByPattern(string pattern);
    }
}
