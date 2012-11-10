//   Copyright 2011 Myles McDonnell (myles.mcdonnell.public@gmail.com)

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//     http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using DCouple.IO;
using Moq;
using NUnit.Framework;

namespace FileCopy.UnitTests
{
    [TestFixture]
    public class FileCopierTests
    {
        [Test]
        public void CopyFileTest()
        {
            const string fileToCopyPath = @"c:\test.txt";
            const string targetDirectoryPath = @"d:\";

            var fileSystem = new Mock<IFileSystem>();
            var fileToCopy = new Mock<IFile>();
            var targetDirectory = new Mock<IDirectory>();

            fileSystem.Setup(s => s.GetFile(fileToCopyPath)).Returns(fileToCopy.Object);
            fileSystem.Setup(s => s.GetDirectory(targetDirectoryPath)).Returns(targetDirectory.Object);
            fileToCopy.Setup(f => f.CopyTo(targetDirectory.Object, true));

            IoCContainer.Clear();
            IoCContainer.RegisterInstance(typeof (IFileSystem), fileSystem.Object);

            var fileCopier = new FileCopier();

            fileCopier.CopyFile(fileToCopyPath, targetDirectoryPath, true);

            fileSystem.VerifyAll();
            fileToCopy.VerifyAll();
            targetDirectory.VerifyAll();
        }
    }
}
