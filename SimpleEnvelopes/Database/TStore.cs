using DnetIndexedDb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SimpleEnvelopes.Database
{
    public class TStore<T> : IndexedDbStore where T : class
    {
        private IndexedDbStoreParameter _key;

        private readonly List<IndexedDbIndex> _indexes = new List<IndexedDbIndex>();

        public TStore(string pluralName)
        {
            BuildStore();
            Name = pluralName;
            Key = _key;
            Indexes = _indexes;
        }

        private void BuildStore()
        {
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                var keyAttribute = info.GetCustomAttribute<KeyAttribute>();
                if (keyAttribute != null)
                {
                    _key = new IndexedDbStoreParameter
                    {
                        KeyPath = info.Name,
                        AutoIncrement = true
                    };
                }

                _indexes.Add(new IndexedDbIndex
                {
                    Name = info.Name,
                    Definition = new IndexedDbIndexParameter { Unique = false }
                });
            }
        }
    }
}