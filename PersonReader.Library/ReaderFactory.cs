using PersonReader.CSV;
using PersonReader.Interface;
using PersonReader.Service;
using PersonReader.SQL;
using System;

namespace PersonReader.Library
{
    public class ReaderFactory
    {
        public IPersonReader GetReader(string readertype)
        {
        switch (readertype)
        {
            case "Service": return new ServiceReader();
            case "CSV": return new CSVReader();
            case "SQL": return new SQLReader();

            default:
                throw new ArgumentException($"Invalid reader type:{readertype}");
        }
        }
    }
}
