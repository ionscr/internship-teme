using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class GenericArray<T>
    {
        public const int MaxSize = 50;
        public T[] Items;
        public GenericArray()
        {
            Items = new T[MaxSize];
        }
        public T GetItem(int index)
        {
            if (index < MaxSize)
                return Items[index];
            else throw new IndexOutOfRangeException();
        }
        public void SetItem(T item, int index)
        {
            if (index < MaxSize && index >= 0) Items[index] = item;
            else throw new IndexOutOfRangeException();
        }
        public void SwapItemsByIndex(int index1, int index2)
        {
            if (index1 < MaxSize && index1 >= 0 && index2 < MaxSize && index2 >= 0)
            {
                T aux = Items[index1];
                Items[index1] = Items[index2];
                Items[index2] = aux;
            }
            else throw new IndexOutOfRangeException();
         }

        
        public int find(T item)
        {
            for(int i = 0; i < MaxSize; i++)
            {
                if (Items[i] != null && Items[i].ToString() == item.ToString()) return i;
            }
            return -1;
        }
        public void SwapItems(T item1, T item2)
        {
            int index1 = find(item1);
            int index2 = find(item2);
            if (index1 != -1 && index2 != -1)
            {
                T aux = Items[index1];
                Items[index1] = Items[index2];
                Items[index2] = aux;
            }
            else throw new ArgumentException("Item not found");
        }
    }
}
