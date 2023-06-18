using System.Linq;
namespace Pragma.Domain.Entities;

public class Conta
{
    public Conta(List<Carteira> carteiras)
    {
        Carteiras = carteiras;
    }

    public List<Carteira> Carteiras { get; set; }
    public void AdicionarCarteira(Carteira carteira)
    {
        Carteiras.Add(carteira);
    }
}

public class Carteira
{
    public Carteira()
    {
        Ativos = new List<Ativo>();
    }

    public List<Ativo> Ativos { get; set; }
}

public class Ativo
{
    public string Codigo { get; set; }
    public TipoAtivoEnum TipoAtivo { get; set; }
}

public enum TipoAtivoEnum
{
    B3 = 1,
    CriptoMoeda = 2,
    Usa = 3
}