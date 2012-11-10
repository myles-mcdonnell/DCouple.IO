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
using System;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

namespace DCouple.IO.Tests
{
    public abstract class FileSystemTestsBase
    {
        protected IFileSystem GetFileSystem()
        {
            return new DCouple.IO.SystemIO.FileSystem();
        }

        protected string RootFolder
        {
            get 
			{ 
				return string.Format("{0}{1}{2}",
                   new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName, 
                   Path.DirectorySeparatorChar, 
                   "TestRoot");
			}
        }

        [SetUp]
        public void SetUp()
        {
            var rootSource = string.Format("{0}{1}{2}",
                   new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName, 
                   Path.DirectorySeparatorChar,
                   "Root");

            if (Directory.Exists(RootFolder))
                Directory.Delete(RootFolder, true);

            CopyDirectory(rootSource, RootFolder);
        }

        public static void CopyDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));
        
            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    File.Copy(file, Path.Combine(folders.Target, Path.GetFileName(file)));
                }
        
                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
        }
        
        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }
        
            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }
    }
}
