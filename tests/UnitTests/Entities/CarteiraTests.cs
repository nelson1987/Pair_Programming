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
        carteira.Depositar(10M);
    }

    [Test]
    public void Criar_Carteira_Com_Sucesso()
    {
        Assert.That(carteira.Ativos.Count, Is.EqualTo(0));
        Assert.That(carteira.Saldo, Is.EqualTo(10M));
    }

    [Test]
    public void Depositar_Valor_Com_Sucesso()
    {
        carteira.Depositar(5M);
        Assert.That(carteira.Saldo, Is.EqualTo(15M));
    }
    
    [Test]
    public void Depositar_Valor_Com_Erro()
    {
        Assert.That(() => carteira.Depositar(0M), Throws.Exception);
    }
    
    [Test]
    public void Sacar_Valor_Com_Sucesso()
    {
        carteira.Sacar(5M);
        Assert.That(carteira.Saldo, Is.EqualTo(5M));
    }

    [Test]
    public void Sacar_Valor_Com_Erro_Valor_Igual_Zero()
    {
        Assert.That(() => carteira.Sacar(0M), Throws.Exception);
    }

    [Test]
    public void Sacar_Valor_Com_Erro_Saldo_Insuficiente()
    {
        Assert.That(() => carteira.Sacar(20M), Throws.Exception);
    }

    [Test]
    public void Comprar_Acao_Com_Sucesso()
    {
        decimal valorAcao = 5M;
        Ativo acao = new Ativo("Qualquer Ação",TipoAtivoEnum.B3, valorAcao);
        carteira.Comprar(acao);
        Assert.That(carteira.Ativos.Count, Is.EqualTo(1));
        Assert.That(carteira.Saldo, Is.EqualTo(5M));
    }

    [Test]
    public void Comprar_Acao_Com_Erro()
    {
        //Arrange
        decimal valorAcao = 15M;
        //Act
        Ativo acao = new Ativo("Qualquer Ação",TipoAtivoEnum.B3, valorAcao);
        //Assert
        Assert.That(() => carteira.Comprar(acao), Throws.Exception);
        Assert.That(carteira.Ativos.Count, Is.EqualTo(0));
        Assert.That(carteira.Saldo, Is.EqualTo(10));
    }

}