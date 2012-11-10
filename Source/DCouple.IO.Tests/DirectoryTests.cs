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

using System.Linq;
using Moq;
using NUnit.Framework;
using System.IO;

namespace DCouple.IO.Tests
{
	[TestFixture]
    public class DirectoryTests : FileSystemTestsBase
    {
        [Test]
        public void Parent()
        {
            var fileSystem = GetFileSystem();

            var root = fileSystem.GetDirectory(RootFolder);
            var sub0Parent = fileSystem.GetDirectory(string.Format("{0}{1}{2}",RootFolder, Path.DirectorySeparatorChar, "Sub0")).Parent;

            Assert.IsTrue(root.FullName == sub0Parent.FullName);
        }

        [Test]
        public void Files()
        {
            var fileSystem = GetFileSystem();

            var files = fileSystem.GetDirectory(RootFolder).Files;

            Assert.AreEqual(2, files.Count());
            Assert.IsTrue(files.Any(f => f.Name == "root_file0.txt"));
            Assert.IsTrue(files.Any(f => f.Name == "root_file1.txt"));
        }

        [Test]
        public void IsRoot()
        {
            Assert.IsTrue(GetFileSystem().GetDirectory(RootFolder).Root.IsRoot);    
        }

        [Test]
        public void GetLogicalDrives()
        {
            Assert.IsTrue(GetFileSystem().LogicalDrives.Count()>0);
        }
    }
}
