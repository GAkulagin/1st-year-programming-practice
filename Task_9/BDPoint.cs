namespace Task_9
{
    class BDPoint<T>
    {
        public T data;
        public BDPoint<T> next;
        public BDPoint<T> previous;

        public BDPoint()
        {
            data = default(T);
            next = null;
            previous = null;
        }

        public BDPoint(T d)
        {
            data = d;
            next = null;
            previous = null;
        }

        public override string ToString()
        {
            return data.ToString() +  " ";
        }
    }

}
