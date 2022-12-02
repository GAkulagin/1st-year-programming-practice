namespace Task_10
{
    public class BDPoint
    {
        public int degree;
        public int coeff;
        public BDPoint next;
        public BDPoint previous;

        public BDPoint()
        {
            degree = 0;
            coeff = 0;
            next = null;
            previous = null;
        }

        public BDPoint(int d, int c)
        {
            degree = d;
            coeff = c;
            next = null;
            previous = null;
        }

        public override string ToString()
        {
            return degree.ToString() + " " + coeff.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            BDPoint point = (BDPoint)obj;

            return this.degree == point.degree && this.coeff == point.coeff;
        }

        public override int GetHashCode()
        {
            return this.degree.GetHashCode() + this.coeff.GetHashCode();
        }
    }
}
