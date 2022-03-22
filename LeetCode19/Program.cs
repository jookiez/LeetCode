using System;

namespace LeetCode19
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomList = CreateList(5);
            RemoveNthFromEnd(randomList, 2);
            var randomList2 = CreateList(1);
            RemoveNthFromEnd(randomList2, 1);
            var randomList3 = CreateList(2);
            RemoveNthFromEnd(randomList3, 1);
            Console.WriteLine("Hello World!");
        }

        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode beginning = null;
            ListNode remove = head;
            ListNode end = head;

            for (int i = 1; i < n; i++)
            {
                end = end.next;
            }

            while(end.next != null)
            {
                end = end.next;
                beginning = remove;
                remove = remove.next;
            }

            if (beginning == null)
            {
                head = remove.next;
            }
            else if (remove.next == null)
            {
                beginning.next = null;
            }
            else
            {
                beginning.next = remove.next;
            }

            return head;
        }

        static ListNode CreateList(int length)
        {
            var start = new ListNode(length);
            for (int i = length - 1; i > 0; i--)
            {
                var temp = new ListNode(i, start);
                start = temp;
            }

            return start;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
