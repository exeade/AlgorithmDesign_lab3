using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class IndexFile
    {
        private List<IndexEntry> IndexEntries { get; set; } = [];

        public void AddIndexEntry(int firstKey, int blockNumber)
        {
            IndexEntries.Add(new IndexEntry { Key = firstKey, BlockNumber = blockNumber });
        }

        public IEnumerable<Record> GetAllRecords()
        {
            var allRecords = new List<Record>();

            foreach (var entry in IndexEntries)
            {
                var block = Block.ReadBlockFromDisk(entry.BlockNumber);
                foreach (var record in block.Records)
                {
                    if (record != null)
                        allRecords.Add(record);
                }
            }

            return allRecords;
        }

        public int FindBlockNumberForKeyBinary(int key, out int comparisonCount)
        {
            comparisonCount = 0;
            int left = 0, right = IndexEntries.Count - 1;

            while (left <= right)
            {
                comparisonCount++;
                int mid = (left + right) / 2;

                if (key >= IndexEntries[mid].Key && (mid == IndexEntries.Count - 1 || key < IndexEntries[mid + 1].Key))
                    return IndexEntries[mid].BlockNumber;

                if (key < IndexEntries[mid].Key)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }

        public void ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                IndexEntries.Add(new IndexEntry
                {
                    Key = int.Parse(parts[0]),
                    BlockNumber = int.Parse(parts[1])
                });
            }
        }

        public void WriteToFile(string filePath)
        {
            using var writer = new StreamWriter(filePath);
            foreach (var entry in IndexEntries)
            {
                writer.WriteLine($"{entry.Key},{entry.BlockNumber}");
            }
        }

    }
}
