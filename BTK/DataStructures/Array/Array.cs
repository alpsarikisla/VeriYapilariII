using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;
        public int Count { get; private set; }
        public int Capacity => InnerList.Length;

        // Dizideki en son gelen elemanı silme
        public T Remove()
        {
            if (Count==0)
                throw new Exception("Array'de kaldırılacak eleman bulunmamaktadır!");
            // Dizinin boyutunu otomatik olarak yarıya indirme durumu
            if (InnerList.Length/4==Count)
            {
                HalfArray();
            }
            var temp = InnerList[Count - 1];
            if (Count>0)
            Count--;
            return temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length>2)
            {
                var temp = new T[InnerList.Length/2];
                System.Array.Copy(InnerList, temp, InnerList.Length/4);
                InnerList = temp;
            }
        }

        public object Clone()
        {
            //return this.MemberwiseClone(); // Kopyalama işlemi 1. yöntem
            var arr = new Array<T>();
            foreach (var item in this)
                arr.Add(item);
            return arr;
        }
        public Array()
        {
            InnerList = new T[2];
            Count = 0;
        }
        public void Add(T item) // Diziye ekleme yapma
        {
            if (InnerList.Length==Count)
            {
                DoubleArray();
            }
            InnerList[Count] = item;
            Count++;
        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2]; // Dizimin uzunluğunun 2 katı olacak şekilde artır
            /*
            for (int i = 0; i < InnerList.Length; i++)
            {
                temp[i] = InnerList[i];
            }
            */
            System.Array.Copy(InnerList,temp,InnerList.Length);
            InnerList = temp;
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Diziye eleman ekleme Constructor ile
        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item);
            }
        }
        // Veri yapılarının IEnumerable ile çıktı alma
        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach(var item in collection)
            {
                Add(item);
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }
    }
}
