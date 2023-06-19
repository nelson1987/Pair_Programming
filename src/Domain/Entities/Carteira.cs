using System.Linq;
namespace Pragma.Domain.Entities;

public class Conta
{
    public Conta()
    {
        Carteiras = new List<Carteira>();
    }

    public List<Carteira> Carteiras { get; set; }
}

public class Carteira
{
    public Carteira()
    {
        Ativos = new List<Ativo>();
    }
    public decimal Saldo { get; set; }
    public List<Ativo> Ativos { get; set; }
    private void Creditar(decimal valor)
    {
        Saldo += valor;
    }
    private void Debitar(decimal valor)
    {
        Saldo -= valor;
    }
    public void Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Não é possível realizar depósito nesse valor.");
        Creditar(valor);
    }
    public void Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Não é possível realizar saque nesse valor.");

        if (valor > Saldo)
            throw new ArgumentException("Não é possível realizar débito nesse valor.");
        Debitar(valor);
    }
    public void Comprar(Ativo ativo)
    {
        if (this.Saldo >= ativo.Valor)
        {
            Ativos.Add(ativo);
            Debitar(ativo.Valor);
        }
        else
            throw new ArgumentException("Saldo indisponível.");
    }
}

public class Ativo
{
    public Ativo(string codigo, TipoAtivoEnum tipoAtivo, decimal valor)
    {
        Codigo = codigo;
        TipoAtivo = tipoAtivo;
        Valor = valor;
    }
    public decimal Valor { get; set; }
    public string Codigo { get; set; }
    public TipoAtivoEnum TipoAtivo { get; set; }
}

public enum TipoAtivoEnum
{
    B3 = 1,
    CriptoMoeda = 2,
    Usa = 3
}