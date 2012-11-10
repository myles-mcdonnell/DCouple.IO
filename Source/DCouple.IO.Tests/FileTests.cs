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
    public class FileTests : FileSystemTestsBase
    {
        [Test]
        public void Suffix()
        {
			var file = GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt"));
            Assert.AreEqual(".txt", file.Extension);
        }

        [Test]
        public void IsSamePath()
        {
            Assert.IsTrue(GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder,Path.DirectorySeparatorChar, "root_file0.txt")).FullName.Equals(GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt")).FullName));
            Assert.IsFalse(GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder,Path.DirectorySeparatorChar, "root_file0.txt")).FullName.Equals(GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file1.txt")).FullName));
        }

        [Test]
        public void Parent()
        {
            Assert.IsTrue(GetFileSystem().GetDirectory(RootFolder).FullName.Equals(GetFileSystem().GetFile(string.Format("{0}{1}{2}", RootFolder, Path.DirectorySeparatorChar, "root_file0.txt")).Parent.FullName));
        }
    }
}
