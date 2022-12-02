using System;

namespace Task_9
{
    class BDList<T>
    {
        BDPoint<T> beg = null;

        public BDPoint<T> Beg
        {
            get { return beg; }
            set { beg = value; }
        }

        public BDPoint<T> End
        {
            get
            {
                if (beg == null) return beg;

                BDPoint<T> p = beg;
                while (p.next != beg) p = p.next;

                return p;
            }

            set { End = value; }
        }

        public int Length
        {
            get
            {
                if (beg == null) return 0;

                int len = 0;

                BDPoint<T> p = beg;

                while (p != End)
                {
                    p = p.next;
                    len++;
                }

                return len + 1;
            }
        }

        public BDList()
        {
            beg = null;
        }

        public BDList(params T[] mas)
        {
            beg = new BDPoint<T>(mas[0]);
            BDPoint<T> p = beg;

            for (int i = 1; i < mas.Length; i++)
            {
                BDPoint<T> temp = new BDPoint<T>(mas[i]);
                p.next = temp;
                temp.previous = p;
                p = temp;
            }

            p.next = beg;
            beg.previous = p;
        }

        // Нерекурсивный метод
        public BDList<T> GetReverseList()
        {
            if (this.Beg == null) return this;

            BDList<T> list = new BDList<T>();
            list.Beg = new BDPoint<T>(this.End.data);
            BDPoint<T> p = this.End;
            BDPoint<T> point = list.Beg;

            for (int i = 1; i < this.Length; i++)
            {
                BDPoint<T> temp = new BDPoint<T>(p.previous.data);
                point.next = temp;
                temp.previous = point;
                point = temp;

                p = p.previous;
            }

            point.next = list.Beg;
            list.Beg.previous = point;

            return list;
        }

        // Рекурсивный метод
        public void GetReverseList(BDPoint<T> p, int count)
        {
            if (count == 0) return;

            BDPoint<T> point = new BDPoint<T>(p.data);

            if (this.Beg == null)
            {
                this.Beg = point;
                this.Beg.next = this.Beg;
                this.Beg.previous = this.Beg;
                GetReverseList(p.previous, count - 1);
            }

            BDPoint<T> last = this.End;
            last.next = point;
            point.previous = last;
            point.next = this.Beg;
            this.Beg.previous = point;

            GetReverseList(p.previous, count - 1);
        }

        public void Print()
        {
            if (beg == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }

            BDPoint<T> p = beg;

            for(int i = 0; i < Length; i++)
            {
                Console.Write(p);
                p = p.next;
            }
        }
    }
}
