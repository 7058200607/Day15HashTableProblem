using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15HashTableDemo 
{
    public class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPostion(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPostion(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPostion(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { key = key, Value = value };
            linkedList.AddLast(item);

        }
        public void Remove(K key, V value)
        {
            int position = GetArrayPostion(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItems = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItems = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItems);
            }
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }

            return linkedList;
        }

        public struct KeyValue<K, V>
        {
            public K key { get; set; }
            public V Value { get; set; }

        }

    }
}

