namespace ProjectEulerDataContracts
{
    public partial class Problem
    {
        public long CalculatedIncludedUpperBound 
        { 
            get
            {
                if (!UpperBound.HasValue) return 0;

                if (!IsClosedOnRight.HasValue || !IsClosedOnRight.Value) return UpperBound.Value - 1;

                return UpperBound.Value;
            }
        }
    }
}