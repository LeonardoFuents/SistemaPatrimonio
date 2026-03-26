using SistemaPatrimonio.Domains;

namespace SistemaPatrimonio.Interfaces
{
    public interface ILocalizacaoRepository
    {
        List<Localizacao> Listar();

        Localizacao BuscarPorId(Guid localizacaoId);

        void Adicionar(Localizacao localizacao);

        bool AreaExiste(Guid areaId);

        void Atualizar(Localizacao localizacao);
    }
}
