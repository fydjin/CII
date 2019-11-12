using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo
{
    internal class OneLinkedListNode<T>
    {
        public OneLinkedListNode<T> NextNode { get; set; }
        public T Data { get; set; }

        public OneLinkedListNode(T data): this(data, null)
        {
            
        }
        public OneLinkedListNode(T data, OneLinkedListNode<T> nextNode)
        {
            Data = data;
            NextNode = nextNode;
        }

    }
}
