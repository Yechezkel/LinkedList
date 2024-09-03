using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedList
{
    public class Node
    {
        private int Value;
        private Node Next;

        public Node(int value)
        {
            Value = value;
        }

        public int GetValue()
        {
        return Value;
        }
        public void SetValue(int value)
        {
            Value = value;
        }

        public Node GetNext()
        {
            return Next;
        }
        public void SetNext(Node next)
        {
            Next = next;
        }

    }




    public class LinkedList
    {
        private Node Head;

        public LinkedList()
        {
        }

        public LinkedList(int value)
        {
            Head = new Node(value);
        }

        // Method to add to  the end of the list
        public void Add(int value)
        {
            Node newNode = new Node(value);
            Node temp = Head;
            if (temp == null)
            {
                Head = newNode;
                return;
            }
            while (temp.GetNext()!=null)//הוספתי סוגריים
                temp = temp.GetNext();
            temp.SetNext(newNode);
        }

        public string Display()
        {
            Node temp = Head;
            if (temp == null)
                return "";
            string str = "" + temp.GetValue();
            temp = temp.GetNext();//הוספתי את השורה הזו
            while (temp != null)
            {
                str += " -> " + temp.GetValue();
                temp = temp.GetNext();
            }
            return str;   
        }

        public int Length()
        {
            int count = 0;
            Node temp = Head;
            while (temp != null)
            {
                count++;
                temp = temp.GetNext();
            }
            return count;
        }
    
        // Method to remove the first value
        public void RemoveValue(int value)
        {
            
            if (Head == null)
                return;
            if (Head.GetValue() == value)
            {
                Head=Head.GetNext();
                return;
            }
            Node current = Head;
            Node prev = new Node(-1);
            while (current.GetNext() != null)
            {
                if (current.GetValue() == value)
                {
                    prev.SetNext(current.GetNext());
                    return;//במקום break
                }
                prev = current;
                current = current.GetNext();

            }
            if (current.GetValue() == value)
            {
                prev.SetNext(null);
            }

        }

        // Method to remove all values
        public void RemoveAllValues(int value)
        {
            while (Head != null && Head.GetValue() == value)
            {
                Head = Head.GetNext();
            }
            if (Head == null)
                return;
            Node current = Head;
            Node prev = new Node(-1);
            while (current.GetNext() != null)
            {
                if (current.GetValue() == value)
                {
                    prev.SetNext(current.GetNext());
                }
                prev = current;
                current = current.GetNext();

            }
            if (current.GetValue() == value)
            {
                prev.SetNext(null);
            }
        }

        // Method to remove the value in an index
        public void RemoveIndex(int index)
        {
            if (index == 0)//הוספתי
                {
                Head = Head.GetNext();
                return;
            }
            Node current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                if (current == null)
                    return;
                current = current.GetNext();
            }
            if (current == null)
                return;
            current.SetNext(current.GetNext().GetNext());
        }

        // Method to find by value 
        public int Find(int Value)
        {
            Node temp = Head;
            int index = 0;
            while (temp != null)
            {
                if (temp.GetValue() == Value)
                    return index;
                index++;
                temp = temp.GetNext();
            }
            return -1;
        }

        // Method to get a value by  index
        public int Get(int index)
        {
            Node temp = Head;
            for (int i = 0; i < index; i++)
            {
                if (temp == null)
                    return -1;//int.MinValue;
                temp = temp.GetNext();
            }
            if (temp == null)
                return -1;//int.MinValue;
            return temp.GetValue();
        }
    }


}
