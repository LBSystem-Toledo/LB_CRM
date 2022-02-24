using Dapper;
using Dominio;
using LB_API.DAO.Interface;
using System.Text;

namespace LB_API.DAO.Repository
{
    public class UFDAO: IUF
    {
        readonly string _conexao;
        public UFDAO(IConfiguration config) { _conexao = config.GetConnectionString("conexaoHelp"); }

        public async Task<IEnumerable<UF>?> GetAsync(string ds_uf = "")
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select a.cd_uf, a.ds_uf, a.uf as Sigla")
                    .AppendLine("from TB_CRM_UF a");
                if (!string.IsNullOrWhiteSpace(ds_uf))
                    sql.AppendLine("where a.ds_uf like '%" + ds_uf.Trim() + "%'");
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                        return await conexao._conexao.QueryAsync<UF>(sql.ToString());
                    else return null;
                }
            }
            catch { return null; }
        }
        public async Task<bool> GravarAsync(UF uf)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@P_CD_UF", uf.Cd_uf, dbType: System.Data.DbType.String, size: 2);
                p.Add("@P_DS_UF", uf.Ds_uf, dbType: System.Data.DbType.String, size: 50);
                p.Add("@P_UF", uf.Sigla, dbType: System.Data.DbType.String, size: 2);
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                    {
                        int ret = await conexao._conexao.ExecuteAsync("IA_CRM_UF", param: p, commandType: System.Data.CommandType.StoredProcedure);
                        return ret > 0;
                    }
                    else return false;
                }
            }
            catch { return false; }
        }
        public async Task<bool> DeleteAsync(string cd_uf)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@P_CD_UF", cd_uf, dbType: System.Data.DbType.String, size: 2);
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                    {
                        int ret = await conexao._conexao.ExecuteAsync("EXCLUI_CRM_UF", param: p, commandType: System.Data.CommandType.StoredProcedure);
                        return ret > 0;
                    }
                    else return false;
                }
            }
            catch { return false; }
        }
    }
}
