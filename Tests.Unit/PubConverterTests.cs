namespace Tests.Unit;

using NUnit.Framework;
using Simple.BTC.Helpers;

[TestFixture]
public class PubConverterTests
{
    // Jaonoctus example keys
    private const string xpub = "xpub6CYYYw6h668PkCSXxH9yxBG32zCMEb6N9DuVY8Ax8U7RSV86qKrrhjJfS6nL5jSoikLpd1Qw9qgHv5vyRi7V4nfV3ymLfGpFShsYsFmQiT8";
    private const string zpub = "zpub6rD5AGSXPTDMSnpmczjENMT3NvVF7q5MySww6uxitUsBYgkZLeBywrcwUWhW5YkeY2aS7xc45APPgfA6s6wWfG2gnfABq6TDz9zqeMu2JCY";

    [Test]
    public void TestJaonoctusExample_xpub()
    {
        var newXfromZ = PubCovnerter.ChangeVersionBytes(zpub, "xpub");
        Assert.That(newXfromZ, Is.EqualTo(xpub));
    }
    [Test]
    public void TestJaonoctusExample_zpub()
    {
        var newZfromX = PubCovnerter.ChangeVersionBytes(xpub, "zpub");
        Assert.That(newZfromX, Is.EqualTo(zpub));
    }
}
