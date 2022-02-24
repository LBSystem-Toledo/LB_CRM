using Dominio;

namespace LB_API.DAO.Interface
{
    public interface IUF
    {
        Task<IEnumerable<UF>?> GetAsync(string ds_uf = "");
        Task<bool> GravarAsync(UF uf);
        Task<bool> DeleteAsync(string cd_uf);
    }
}
