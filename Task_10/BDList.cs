using System;

namespace Task_10
{
    public class BDList
    {
        BDPoint beg = null;

        public BDPoint Beg
        {
            get { return beg; }
            set { beg = value; }
        }

        public BDPoint End
        {
            get
            {
                if (beg == null) return beg;

                BDPoint p = beg;

                while (p.next != null) p = p.next;

                return p;
            }
        }

        public int Length
        {
            get
            {
                if (beg == null) return 0;
                int len = 0;
                BDPoint p = beg;
                while (p != null)
                {
                    p = p.next;
                    len++;
                }
                return len;
            }
        }


        public BDList()
        {
            beg = null;
        }

        public BDList(int[,] matrix)
        {
            int i = 0;

            while (i < matrix.GetLength(1) && matrix[1, i] == 0) i++;

            if (i >= matrix.GetLength(1)) beg = null;
            else
            {
                beg = new BDPoint(matrix[0, i], matrix[1, i]);
                BDPoint point = beg;
               
                for (i = i + 1; i < matrix.GetLength(1); i++)
                    if (matrix[1, i] != 0)
                    {
                        BDPoint temp = new BDPoint(matrix[0, i], matrix[1, i]);
                        point.next = temp;
                        temp.previous = point;
                        point = temp;
                    }
            }
        }


        public void AddPoint(BDPoint point)
        {

            if (Beg == null)
            {
                Beg = point;
                return;
            }
                
            BDPoint last = this.End;
            last.next = point;
            point.previous = last;
        }

        public void DeletePoint(BDPoint point)
        {
            if (Beg == null) return;

            if (Length == 1 && Beg.Equals(point))
            {
                Beg = null;
                return;
            }

            if (Beg.Equals(point))
            {
                Beg = Beg.next;
                return;
            }

            BDPoint temp = Beg.next;

            while (!temp.Equals(End))
            {
                if (temp.Equals(point))
                {
                    temp.previous.next = temp.next;
                    temp.next.previous = temp.previous;
                    return;
                }
                temp = temp.next;
            }

            // Здесь temp = end
            if(temp.Equals(End)) temp.previous.next = null;
        }

        public void Print()
        {
            if (this == null || beg == null)
            {
                Console.WriteLine("Пустой список");
                return;
            }

            BDPoint p = beg;

            while (p != null)
            {
                Console.Write(p);
                p = p.next;
            }
        }

        public void RemoveZeroElements()
        { 
            if (Beg == null) return;

            if(Length == 1 && Beg.coeff == 0)
            {
                Beg = null;
                return;
            }

            if (Length == 1 && Beg.coeff != 0) return;

            while (Beg != null && Beg.coeff == 0) beg = beg.next;
            if (Beg == null) return;

            BDPoint temp = Beg.next;

            while (!temp.Equals(End))
            {
                if (temp.coeff == 0)
                {
                    temp.previous.next = temp.next;
                    temp.next.previous = temp.previous;
                }
                temp = temp.next;
            }

            // Здесь temp = end
            if(temp.coeff == 0) temp.previous.next = null;

            return;
        }

        public BDList SumOfPolymonials(BDList list)
        {
            if (this.Length == 0 && list.Length == 0) return null;
            if (this.Length == 0) return list;
            if (list.Length == 0) return this;

            BDList sumList = new BDList();
            BDPoint point = this.Beg;

            // добавляем эл-ты из первого списка (или их суммы с эл-тами из второго)
            while (point != null)
            {
                BDPoint temp = list.Beg;

                while(temp != null)
                {
                    if (point.degree == temp.degree)
                    {
                        point.coeff += temp.coeff;
                        list.DeletePoint(temp);
                    }
                    temp = temp.next;
                }
                sumList.AddPoint(new BDPoint(point.degree, point.coeff));
                point = point.next;
            }

            // добавляем оставшиеся эл-ты из второго списка
            if (list.Length > 0)
            {
                BDPoint temp = list.Beg;
                while(temp != null)
                {
                    sumList.AddPoint(new BDPoint(temp.degree, temp.coeff));
                    temp = temp.next;
                }
            }

            return sumList;
        }
    }
}
