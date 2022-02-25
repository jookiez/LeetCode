using System;

namespace LeetCode148
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));

            var result = SortList(head);
        }

        static ListNode SortList(ListNode head)
        {
            //times out but it works. Not doing merge sort
            if (head == null || head.next == null) return head;
            ListNode start;
            ListNode tail;
            ListNode middle;

            bool changed = true;

            while (changed)
            {
                changed = false;
                start = head;
                middle = null;
                tail = null;
                do
                {
                    if (middle == null && tail == null)
                    {
                        middle = head.next;
                        if (start.val > middle.val)
                        {
                            start.next = middle.next;
                            middle.next = start;
                            head = middle;
                            changed = true;

                            start = head;
                            middle = head.next;
                        }

                        tail = middle.next;
                    }
                    else if(middle.val > tail.val)
                     {

                        var temp = tail.next;
                        start.next = tail;
                        tail.next = middle;
                        middle.next = temp;
                        changed = true;

                        start = start.next;
                        middle = start.next;
                        tail = middle.next;
                    }
                    else
                    {
                        start = start.next;
                        middle = middle.next;
                        tail = tail.next;
                    }
                } while (tail != null);
            }

            return head;
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
