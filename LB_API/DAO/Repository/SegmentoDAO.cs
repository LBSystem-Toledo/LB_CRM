using Dapper;
using Dominio;
using LB_API.DAO.Interface;
using System.Data;
using System.Text;

namespace LB_API.DAO.Repository
{
    public class SegmentoDAO : ISegmento
    {
        readonly string _conexao;
        public SegmentoDAO(IConfiguration config) { _conexao = config.GetConnectionString("conexaoHelp"); }

        public async Task<bool> DeleteAsync(int Id_segmento)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@P_ID_SEGMENTO", Id_segmento);
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                    {
                        int ret = await conexao._conexao.ExecuteAsync("EXCLUI_CRM_SEGMENTO", param: p, commandType: System.Data.CommandType.StoredProcedure);
                        return ret > 0;
                    }
                    else return false;
                }
            }
            catch { return false; }
        }

        public async Task<IEnumerable<Segmento>?> GetAsync(string Ds_segmento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select a.id_segmento, a.ds_segmento")
                    .AppendLine("from TB_CRM_Segmento a");
                if (!string.IsNullOrWhiteSpace(Ds_segmento))
                    sql.AppendLine("where a.ds_segmento like '%" + Ds_segmento.Trim() + "%'");
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                        return await conexao._conexao.QueryAsync<Segmento>(sql.ToString());
                    else return null;
                }
            }
            catch { return null; }
        }

        public async Task<bool> UpersertAsync(Segmento segmento)
        {
            try
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@P_ID_SEGMENTO", segmento.Id_segmento);
                p.Add("@P_DS_SEGMENTO", segmento.Ds_segmento);
                using (TConexao conexao = new TConexao(_conexao))
                {
                    if (await conexao.OpenConnectionAsync())
                    {
                        int ret = await conexao._conexao.ExecuteAsync("IA_CRM_SEGMENTO", param: p, commandType: System.Data.CommandType.StoredProcedure);
                        return ret > 0;
                    }
                    else return false;
                }
            }
            catch { return false; }
        }
    }
}
