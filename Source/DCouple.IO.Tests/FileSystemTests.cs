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
using NUnit.Framework;
using System.IO;

namespace DCouple.IO.Tests
{
	[TestFixture]
    public class FileSystemTests : FileSystemTestsBase
    {
        [Test]
        public void DirectoryExists()
        {
            Assert.IsTrue(GetFileSystem().DirectoryExists(RootFolder));
            Assert.IsTrue(GetFileSystem().DirectoryExists(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "Sub0")));
            Assert.IsTrue(GetFileSystem().DirectoryExists(string.Format("{0}{1}{2}{1}{3}", RootFolder, Path.DirectorySeparatorChar, "Sub0","Sub1")));
            Assert.IsFalse(GetFileSystem().DirectoryExists(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "Sub2")));
        }

        [Test]
        public void FileExists()
        {
            Assert.IsTrue(GetFileSystem().FileExists(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt")));
            Assert.IsTrue(GetFileSystem().FileExists(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file1.txt")));
            Assert.IsFalse(GetFileSystem().FileExists(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file2.txt")));
        }

        [Test]
        public void GetFile()
        {
            var fileSystem = GetFileSystem();
            var entry = fileSystem.GetFile( string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt"));
            var nada = fileSystem.GetFile("nada");
         
            Assert.IsNotNull(entry);
            Assert.IsTrue(entry.FullName.Equals(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt")));

            Assert.IsFalse(nada.Exists);
        }

        [Test]
        public void GetDirectory()
        {
            var fileSystem = GetFileSystem();
            var entry = fileSystem.GetDirectory(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "Sub0"));
            var nada = fileSystem.GetDirectory("nada");

            Assert.IsNotNull(entry);
            Assert.IsTrue(entry.FullName.Equals( string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "Sub0")));

            Assert.IsFalse(nada.Exists);
        }

        [Test]
        public void GetSameFile()
        {
            var path = string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt");
            var fileSystem = GetFileSystem();
            
            Assert.AreEqual(fileSystem.GetFile(path).FullName, fileSystem.GetFile(path).FullName);
        }
    }
}
