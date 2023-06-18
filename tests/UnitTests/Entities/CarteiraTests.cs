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
}