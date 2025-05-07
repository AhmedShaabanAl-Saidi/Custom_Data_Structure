using System.Collections;

namespace Custom_Data_Structures
{
    public class MyList<T> : IEnumerable<T> , ICollection<T> , IList<T>
    {
        // Properties
        #region Properties
        T[] items;
        public int Count { get; set; }

        public bool IsReadOnly => false;

        int currentIndex;
        const int capacty = 4;
        IEqualityComparer<T> equalityComparer;
        #endregion

        // Constructors
        #region Constructors
        public MyList()
        {
            items = new T[capacty];
            Count = 0;
            currentIndex = 0;
            equalityComparer = EqualityComparer<T>.Default;
        }

        public MyList(IEqualityComparer<T> comparer)
        {
            items = new T[capacty];
            Count = 0;
            currentIndex = 0;
            equalityComparer = comparer;
        }

        public MyList(int capacty)
        {
            items = new T[capacty];
            Count = 0;
            currentIndex = 0;
            equalityComparer = EqualityComparer<T>.Default;
        }

        public MyList(IEnumerable<T> collection)
        {
            int count = GetEnumrableCount(collection);

            items = new T[count];

            foreach(T item in collection)
                Add(item);

            equalityComparer = EqualityComparer<T>.Default;
        }
        #endregion

        // Indexers
        #region Indexers
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= currentIndex)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

                return items[index];
            }
            set
            {
                if (index < 0 || index >= currentIndex)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

                items[index] = value;
            }
        }

        public List<T> this[string indexs]
        {
            get
            {
                if (string.IsNullOrEmpty(indexs))
                    throw new ArgumentException("Index string cannot be null or empty.");

                string[] indexesArray = indexs.Split(',');

                List<T> list = new List<T>();

                foreach (string index in indexesArray)
                {
                    if (int.TryParse(index, out int parsedIndex))
                    {
                        if (parsedIndex >= 0 && parsedIndex < items.Length && items[parsedIndex] != null)
                        {
                            list.Add(items[parsedIndex]);
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Invalid index value: {index}");
                    }
                }

                return list;
            }
        }
        #endregion

        // Methods
        #region Methods
        // Adding Methods
        #region Adding Methods
        public void Add(T item)
        {
            if (currentIndex >= items.Length)
                Resize(items.Length * 2);

            items[currentIndex] = item;

            currentIndex++;
            Count++;
        }

        public void AddRange(IEnumerable<T> newItems)
        {
            int count = GetEnumrableCount(newItems);

            if (items.Length < Count + count)
                Resize(Count + count);

            foreach (var item in newItems)
            {
                items[currentIndex] = item;
                currentIndex++;
                Count++;
            }
        }

        public void Insert(int index, T item)
        {
            // Check if the index is valid
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

            // Check if the list is full and needs to be resized
            if (Count == items.Length)
                Resize(items.Length * 2);

            // Shift elements to the right to make space for the new item
            ShiftRight(index, 1);

            // Insert the new item at the specified index
            items[index] = item;

            // Update the current index and count
            currentIndex++;
            Count++;
        }

        public void InsertRange(int index, IEnumerable<T> newItems)
        {
            int count = GetEnumrableCount(newItems);

            // Check if the index is valid
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

            // Check if the list is full and needs to be resized
            if (Count + count > items.Length)
                Resize(Count + count);

            // Shift elements to the right to make space for the new items
            ShiftRight(index, count);

            // Insert the new items at the specified index
            foreach (var item in newItems)
            {
                items[index + 1] = item;
                currentIndex++;
                Count++;
            }
        }
        #endregion

        // Removing Methods
        #region Removing Methods
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= currentIndex)
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");

            ShiftLift(index);

            currentIndex--;
            Count--;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            ShiftLift(index);

            currentIndex--;
            Count--;

            return true;
        }

        public void RemoveRange(int start, int count)
        {
            if (start < 0 || start > Count || count < 0 || start + count > items.Length)
                throw new IndexOutOfRangeException("Invalid range specified.");

            for (int i = start + count; i < items.Length; i++)
            {
                items[start] = items[i];
                start++;
            }

            for (int i = items.Length - 1; i > items.Length - count - 1; i--)
            {
                items[i] = default(T);
                currentIndex--;
                Count--;
            }

            if (items.Length / 2 > Count)
                Resize(items.Length / 2);
        }

        public void RemoveAll()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default(T);
            }
            Count = 0;
            currentIndex = 0;
        }

        public void Clear()
        {
            items = new T[capacty];
            Count = 0;
            currentIndex = 0;
        }
        #endregion

        // Searching Methods
        #region Searching Methods
        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (equalityComparer.Equals(items[i], item))
                    return i;
            }

            return -1;
        }
        #endregion

        // Reversing and Sorting Methods
        #region Reversing and Sorting Methods
        public T[] ToArray()
        {
            T[] newArray = new T[Count];
            Array.Copy(items, newArray, Count);
            return newArray;
        }

        public void Reverse()
        {
            T[] newArray = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[Count - 1 - i];
            }
            items = newArray;
        }

        public void Sort()
        {
            Array.Sort(items);
        }
        #endregion

        // Helper Methods
        #region Helper Methods
        private void Resize(int newSize)
        {
            T[] newItems = new T[newSize];

            Array.Copy(items, newItems, Count);

            items = newItems;
        }

        private void ShiftLift(int index)
        {
            for (int i = index; i < items.Length - 1; i++)
            {
                if (items[i] == null)
                    break;

                items[i] = items[i + 1];
            }

            if (items[items.Length - 1] != null)
            {
                items[items.Length - 1] = default(T);
            }
        }

        private void ShiftRight(int index, int numberOfItems)
        {
            for (int i = items.Length - 1; i > index; i--)
            {
                items[i] = items[i - numberOfItems];
            }
            for (int i = index; i < index + numberOfItems; i++)
            {
                items[i] = default(T);
            }
        }

        private int GetEnumrableCount(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (var item in collection)
                count++;

            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
               yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, Count);
        }
        #endregion
        #endregion
    }
}
