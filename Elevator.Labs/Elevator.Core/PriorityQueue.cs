/*
 ***********************************************************************************
 *Name      : PriorityQueue.cs
 *Purpose   : Priority Queue implementation using Binary Heap tree data structure. Queue contains elements of generic
 *            type T which needs to mandatory implement IComparable.Priority Queue can be used both as a Max and Min Heap
 *            by changing the implementation of CompareTo method in inherited by IComparable interface.
 *Author    : Pramod
 *Date      : 03/02/2019
 ***********************************************************************************
*/

using System;
using System.Collections.Generic;

namespace Elevator.Core
{
    /// <summary>Generic Priority Queue of Type T; with Max or Min Heap Implementation</summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        #region Private Properties and methods

        private readonly List<T> _data;

        private int Count()
        {
            return _data.Count;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1; // left child index formula in an List/Array data structure.
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;// Right child index formula in an List/Array data structure.
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;// Parent index formula in an List data structure.
        }

        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) < Count();
        }

        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) < Count();
        }

        private bool HasParent(int index)
        {
            return GetParentIndex(index) < Count();
        }

        private T LeftChild(int index)
        {
            return _data[GetLeftChildIndex(index)];
        }

        private T RightChild(int index)
        {
            return _data[GetRightChildIndex(index)];
        }

        private T Parent(int index)
        {
            return _data[GetParentIndex(index)];
        }

        private void Swap(int indexOne, int indexTwo)
        {
            T temp = _data[indexOne];
            _data[indexOne] = _data[indexTwo];
            _data[indexTwo] = temp;
        }

        private void HeapifyUp()
        {
            int index = Count() - 1; // start comparision from the end; where the element has been added
            while (HasParent(index)) //continue comparison till the root; unless loop broken.
            {
                if (_data[index].CompareTo(Parent(index)) >= 0)
                {
                    break; // child item is larger than (or equal) parent so we're done
                }

                Swap(GetParentIndex(index), index); // if value not greater or equal .. then swap

                index = GetParentIndex(index); // move up one level
            }
        }

        private void HeapifyDown()
        {
            int index = 0; // Start at the root

            while (HasLeftChild(index)) //Move down the tree as long as there is left child; or loop broken
            {
                int childIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) < 0)
                {
                    childIndex = GetRightChildIndex(index);//Get the child element to swap.
                }

                if (_data[index].CompareTo(_data[childIndex]) <= 0)
                {
                    break; // parent is smaller than (or equal to) smallest child so done
                }
                Swap(index, childIndex);
                index = childIndex;// move down one level
            }
        }

        #endregion Private Properties and methods

        /// <summary>Initializes a new instance of the <see cref="PriorityQueue{T}"/> class.</summary>
        public PriorityQueue()
        {
            this._data = new List<T>();
        }

        /// <summary>Peeks the Queue to get the first element.</summary>
        /// <returns>First element in the queue</returns>
        public T Peek()
        {
            T frontItem = _data[0];
            return frontItem;
        }

        /// <summary>Determines whether this instance is empty.</summary>
        /// <returns>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        public bool IsEmpty()
        {
            return Count() == 0;
        }

        /// <summary>Enqueue's the specified item.</summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            _data.Add(item); // add item to the end of the queue
            HeapifyUp(); //Re-Heapify the queue until elements are in order
        }

        /// <summary>Dequeues this instance.</summary>
        /// <returns>Root element from the heap</returns>
        public T Dequeue()
        {
            //Assume list is not empty
            //move the last element of the root of the heap; and remove the last element
            int li = Count() - 1;
            T root = _data[0];
            _data[0] = _data[li];
            _data.RemoveAt(li);
            HeapifyDown();// Re-Heapify the queue until elements are in order
            return root;// root is always the element to be dequeue in a heap
        }
    }
}