using Pragma.Domain.Entities;

namespace Pragma.UnitTests.Entities;

//ConsultaSaldoCarteira
public class CarteiraTests
{
    private Carteira carteira {get; set;}
    
    [SetUp]
    public void Setup()
    {
        carteira = new Carteira();
    }

    [Test]
    public void Criar_Carteira_Com_Sucesso()
    {
        Assert.That(carteira.Ativos.Count, Is.EqualTo(0));
    }
    [Test]
    public void Comprar_Acao_Com_Sucesso()
    {
        decimal valorAcao = 10M;
        decimal saldoDisponivelEmCarteira = 30M;
        Ativo acao = new Ativo("Qualquer Ação",TipoAtivoEnum.B3, valorAcao);
        carteira.Depositar(saldoDisponivelEmCarteira);
        carteira.Comprar(acao);
        Assert.That(carteira.Ativos.Count, Is.EqualTo(1));
        Assert.That(carteira.Saldo, Is.EqualTo(20M));
    }
    [Test]
    public void Comprar_Acao_Com_Erro()
    {
        //Arrange
        decimal valorAcao = 10M;
        decimal saldoDisponivelEmCarteira = 5M;
        //Act
        Ativo acao = new Ativo("Qualquer Ação",TipoAtivoEnum.B3, valorAcao);
        carteira.Depositar(saldoDisponivelEmCarteira);
        //Assert
        Assert.That(() => carteira.Comprar(acao), Throws.Exception);
        Assert.That(carteira.Ativos.Count, Is.EqualTo(0));
    }
}