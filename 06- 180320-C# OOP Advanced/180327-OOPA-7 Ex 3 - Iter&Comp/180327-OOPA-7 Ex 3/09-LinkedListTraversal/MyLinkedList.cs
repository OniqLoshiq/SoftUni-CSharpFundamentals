using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MyLinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public void Add(T item)
    {
        Node old = this.Tail;
        this.Tail = new Node(item);

        if (this.IsEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }
        this.Count++;
    }

    public bool Remove(T item)
    {
        if (this.IsEmpty())
            return false;

        bool foundItem = false;
        Node currentNode = this.Head;
        
        if(currentNode.Value.Equals(item))
        {
            this.Head = this.Head.Next;
            this.Count--;
        }

        if (this.IsEmpty())
        {
            this.Tail = null;
            return true;
        }

        Node nextNode = null;

        while (currentNode.Next != null)
        {
            nextNode = currentNode.Next;

            if (nextNode.Value.Equals(item))
            {
                foundItem = true;
                break;
            }
            currentNode = currentNode.Next;
        }

        if(foundItem)
        {
            currentNode.Next = nextNode.Next;
            this.Count--;
            if(currentNode.Next == null)
            {
                this.Tail = currentNode;
            }
        }

        return foundItem;
    }

    private bool IsEmpty()
    {
        return this.Count == 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
