using Pragma.Domain;

namespace Pragma.UnitTests;

public class EntidadeBaseTest
{
    private EntidadeBase entidade {get; set;}
    [SetUp]
    public void Setup()
    {
        entidade = new EntidadeBase();
    }

    [Test]
    public void After_Implement_Id_Value()
    {
        Assert.AreEqual(entidade.Id, 0);
    }
}