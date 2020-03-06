using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TestConsole
{
    abstract class Storage<TItem>: IEnumerable<TItem>
    {
        private readonly List<TItem> _Items = new List<TItem>();

        private event Action<TItem> _AddObservers;

        public void Add(TItem Item)
        {
            if (_Items.Contains(Item)) return;
            _Items.Add(Item);
            _AddObservers?.Invoke(Item);
        }

        public bool Remove(TItem Item)
        {
            return _Items.Remove(Item);
        }

        public void Clear()
        {
            _Items.Clear();
        }

        public abstract void SaveToFile(string FileName);

        public virtual void LoadFromFile(string FileName)
        {
            Clear();
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            foreach (var item in _Items) yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void SubscribeToAdd(Action<TItem> AddObserver) => _AddObservers += AddObserver;
    }

    class Deconat: Storage<Student>
    {
        public override void SaveToFile(string FileName)
        {
            using (var stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = new StreamWriter(stream))
            {
                foreach(var student in this)
                {
                    writer.Write(student.Name);
                    if (student.Raitings.Count > 0) writer.Write(",{0}", string.Join(",", student.Raitings));
                    writer.WriteLine();
                }
            }
        }

        public override void LoadFromFile(string FileName)
        {
            base.LoadFromFile(FileName);

            if (!File.Exists(FileName)) return;

            using (var stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var data_elements = reader.ReadLine().Split(',');
                    if (data_elements.Length == 0) continue;
                    var student = new Student { Name = data_elements.First(), Raitings = data_elements.Skip(1).Select(int.Parse).ToList() };
                    Add(student);
                }
            }
        }
    }
}
