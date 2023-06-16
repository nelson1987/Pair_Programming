using Pragma.Domain;

namespace Pragma.UnitTests;

public class EntidadeBaseTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        EntidadeBase entidade = new EntidadeBase();
        Assert.AreEqual(entidade.Id, 0);
    }
}