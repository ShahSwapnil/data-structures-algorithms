namespace algorithmTests.Utilities
{
    public class RandomUnitTestObject : IComparable<RandomUnitTestObject>, IEquatable<RandomUnitTestObject>
    {
        public int ID { get; set; }

        public int SecondaryID { get; set; }

        public int CompareTo(RandomUnitTestObject? other)
        {
            if (other is null)
                throw new ArgumentNullException("other");

            return ID.CompareTo(other.ID);
        }

        public bool Equals(RandomUnitTestObject? other)
        {
            if (other is null)
                return false;

            return ID == other.ID && SecondaryID == other.SecondaryID;
        }

        public override string ToString()
        {
            return $"{ID}|{SecondaryID}";
        }
    }
}
