using System;
using DCouple.IO;
using Moq;
using NUnit.Framework;
using System.IO;

namespace FileCopy.UnitTests
{
    [TestFixture]
    public class FileWriterTests
    {
        [Test]
        public void Contents()
        {
            var path = "c:\file.txt";
            var contents = "testContents";
            var stream = new UnclosableMemoryStream();

            var fileSystem = new Mock<IFileSystem>();
            var file = new Mock<IFile>();

            file.Setup(f=>f.Open(System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write)).Returns(stream);

            fileSystem.Setup(f=>f.GetFile(path)).Returns(file.Object);

            IoCContainer.Clear();
            IoCContainer.RegisterInstance(typeof(IFileSystem), fileSystem.Object);

            var writer = new FileWriter(path, contents);

            writer.Write();

            Assert.IsTrue(stream.ClosedCalled);

            stream.Position = 0;

            var reader = new StreamReader(stream);

            Assert.AreEqual(contents, reader.ReadToEnd());
        }
    }
}

