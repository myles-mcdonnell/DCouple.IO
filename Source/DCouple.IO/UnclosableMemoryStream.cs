using System;
using System.IO;

namespace DCouple.IO
{
    public class UnclosableMemoryStream : Stream
    {
        private readonly MemoryStream _stream = new MemoryStream();

        public bool ClosedCalled
        {
            get; private set;
        }

        public bool DisposeCalled
        {
            get; private set;
        }

        #region implemented abstract members of System.IO.Stream
        public override void Flush ()
        {
            _stream.Flush();
        }

        public override int Read (byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override long Seek (long offset, System.IO.SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override void SetLength (long value)
        {
            _stream.SetLength(value);
        }

        public override void Write (byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
        }

        public override bool CanRead
        {
            get
            {
                return _stream.CanRead;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return _stream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return _stream.CanWrite;
            }
        }

        public override long Length
        {
            get
            {
                return _stream.Length;
            }
        }

        public override long Position
        {
            get
            {
                return _stream.Position;
            }
            set
            {
                _stream.Position = value;
            }
        }
        #endregion

        public override void Close ()
        {
            ClosedCalled = true;
        }
    }
}

