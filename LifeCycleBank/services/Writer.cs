using LifeCycleBank.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifeCycleBank.services
{
    public class Writer : IWriter
    {
        private readonly string _path;
        private readonly bool _append;
        private readonly StreamWriter _writer;

        public Writer(string path, bool append)
        {
            _path = path;
            _append = append;
            _writer = new StreamWriter(path, append);
        }

        public void Dispose()
        {
            var writer = _writer as IDisposable;
            if (writer != null)
            {
                writer.Dispose();
            }
        }

        public void WriteLine(string value)
        {
            _writer.WriteLine(value);
        }
    }
}
