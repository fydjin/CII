using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    class OneLinkedList<T> where T: class 
    {
        public OneLinkedListNode<T> CurrentNode { get; set; }

        public OneLinkedList(IEnumerable<T> elements)
        {
            OneLinkedListNode<T> newNode;
            OneLinkedListNode<T> prevNode = null;
            foreach (var element in elements)
            {
                newNode = new OneLinkedListNode<T>(element);
               
                if (prevNode != null)
                {
                    prevNode.NextNode = newNode;
                }
                if (CurrentNode == null)
                {
                    CurrentNode = newNode;                    
                }
                if (element == elements.Last())
                {
                    newNode.NextNode = CurrentNode;
                }
                prevNode = newNode;
            }
        }

        public void NextNode()
        {
            CurrentNode = CurrentNode.NextNode;
        }
    }
}
