using Dominio;

namespace LB_API.DAO.Interface
{
    public interface ISegmento
    {
        Task<IEnumerable<Segmento>?> GetAsync(string Ds_segmento);
        Task<bool> UpersertAsync(Segmento segmento);
        Task<bool> DeleteAsync(int Id_segmento);
    }
}
