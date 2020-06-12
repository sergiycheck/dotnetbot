using NUnit.Framework;
using System.IO;

namespace Bot.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var path = Path.GetRelativePath(Directory.GetCurrentDirectory(), "E:\\filesFromCDisk\\TelegramBot\\WebAppBot\\Resources");
            Assert.NotNull(path);
        }
    }
}