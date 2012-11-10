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

using System.IO;

namespace DCouple.IO
{
    public interface IFile : IFileSystemEntry
    {
        string Extension { get; }
        bool IsReadOnly { get; set; }
        
		void CopyTo(IDirectory directory, bool overwrite);
        void CopyTo(IDirectory directory, string fileName, bool overwrite);
		void MoveTo(IDirectory directory);
        void MoveTo(IDirectory directory, string fileName);

		Stream Open(FileMode mode);
        Stream Open(FileMode mode, FileAccess access);
        Stream Open(FileMode mode, FileAccess access, FileShare share);

        Stream Create();
        Stream Create(int bufferSize);
        Stream Create(int bufferSize, FileOptions options);
		
		/// <summary>
        /// Number of bytes in this file
        /// </summary>
        long Length { get; }

        void Delete();
        void Encrypt();
        void Decrypt();
    }
}
