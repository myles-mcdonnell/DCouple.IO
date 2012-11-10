using MPM.EyeOh.FTP;

namespace MPM.EyeOh.Tests.Ftp
{
    public class FtpDirectoryTests : DirectoryTests
    {
        protected override IFileSystem GetFileSystem()
        {
            return new FtpFileSystem("ftp://localhost/");
        }

        protected override string Root
        {
            get { return "ftp://localhost/"; }
        }
    }
}
