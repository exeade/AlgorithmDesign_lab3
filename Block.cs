using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Block
    {
        public const int BlockSize = 500;

        public List<Record?> Records { get; set; } = [];
        private List<Record?> Overflow { get; set; } = [];

        private bool IsFull => Records.Count >= BlockSize;

        public void AddRecord(Record? record)
        {
            if (!IsFull)
            {
                Records.Add(record);
                Records = [.. Records.OrderBy(r => r?.Key)];
            }
            else
            {
                Overflow.Add(record);
                Overflow = [.. Overflow.OrderBy(r => r?.Key)];
            }
        }

        public bool DeleteRecord(int key)
        {
            var recordToDelete = Records.FirstOrDefault(r => r?.Key == key);
            if (recordToDelete != null)
            {
                Records.Remove(recordToDelete);
                return true;
            }

            var overflowRecordToDelete = Overflow.FirstOrDefault(r => r?.Key == key);
            if (overflowRecordToDelete != null)
            {
                Overflow.Remove(overflowRecordToDelete);
                return true;
            }

            return false;
        }

        public Record? FindRecordBinary(int key, out int comparisonCount)
        {
            comparisonCount = 0;
            int left = 0, right = Records.Count - 1;

            while (left <= right)
            {
                comparisonCount++;
                int mid = (left + right) / 2;

                if (Records[mid]!.Key == key)
                    return Records[mid];

                if (Records[mid]!.Key < key)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        public static void WriteBlockToDisk(int blockNumber, Block block)
        {
            string filePath = $"block_{blockNumber}.txt";
            using var writer = new StreamWriter(filePath);

            foreach (var record in block.Records)
            {
                if (record != null)
                {
                    writer.WriteLine(record.ToString());
                }
            }

            foreach (var record in block.Overflow)
            {
                if (record != null)
                {
                    writer.WriteLine(record.ToString());
                }
            }
        }

        public static Block ReadBlockFromDisk(int blockNumber)
        {
            string filePath = $"block_{blockNumber}.txt";
            if (!File.Exists(filePath)) return new Block();

            var block = new Block();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var record = Record.FromString(line);
                block.AddRecord(record);
            }

            return block;
        }
    }
}
