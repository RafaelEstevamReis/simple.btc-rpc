namespace Tests.Unit;

using NUnit.Framework;

[TestFixture]
public class DescriptorsTests
{
    // Jaonoctus example keys
    private const string zpub = "zpub6rD5AGSXPTDMSnpmczjENMT3NvVF7q5MySww6uxitUsBYgkZLeBywrcwUWhW5YkeY2aS7xc45APPgfA6s6wWfG2gnfABq6TDz9zqeMu2JCY";

    [Test]
    public void Test_Descriptor()
    {
        var expected = "wpkh([3f635a63/84h/0h/0h]xpub6CYYYw6h668PkCSXxH9yxBG32zCMEb6N9DuVY8Ax8U7RSV86qKrrhjJfS6nL5jSoikLpd1Qw9qgHv5vyRi7V4nfV3ymLfGpFShsYsFmQiT8/0/*)#9m66mdj4";
        var descriptor = DescriptorHelper.ToDescriptor(zpub, "3f635a63", "m/84h/0h/0h", true);
        Assert.That(expected, Is.EqualTo(descriptor));
    }
}
