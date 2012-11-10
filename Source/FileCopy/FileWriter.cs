using System;
using DCouple.IO;
using System.IO;

namespace FileCopy
{
    public class FileWriter
    {
        private readonly string _path;
        private readonly string _contents;

        public FileWriter (string path, string contents)
        {
            _path = path;
            _contents = contents;
        }

        public void Write()
        {
            var fileSystem = IoCContainer.Resolve<IFileSystem>();

            var file = fileSystem.GetFile(_path);

            using(var stream = file.Open(System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write))
            using(var writer = new StreamWriter(stream))
            {
                writer.Write(_contents);
            }
        }

    }
}

