using System;

namespace Skyline.DataMiner.Analytics.DataTypes
{
    /// <summary>
    /// Class containing the DataMiner ID and element ID of a DataMiner element.
    /// </summary>
    [Serializable]
    public class ElementKey
    {
        /// <summary>
        /// Gets or sets the DataMiner ID of the element.
        /// </summary>
        public int DataMinerID { get; set; }

        /// <summary>
        /// Gets or sets the element ID of the element.
        /// </summary>
        public int ElementID { get; set; }

        /// <summary>
        /// Creates a new <see cref="ElementKey"/> instance.
        /// </summary>
        public ElementKey() : this(-1, 0) { }

        /// <summary>
        /// Creates a new <see cref="ElementKey"/> instance with the given DataMiner ID and element ID.
        /// </summary>
        /// <param name="dataMinerID">The DataMiner ID.</param>
        /// <param name="elementID">The Element ID.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the given element ID is below 0.</exception>
        public ElementKey(int dataMinerID, int elementID)
        {
        }

        /// <summary>
        /// Gets a hash code for this object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return DataMinerID.GetHashCode() ^ ElementID.GetHashCode();
        }

        /// <summary>
        /// Determines whether this element ID has the same DataMiner ID and element ID as the given object.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the given object equals the current object.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (Object.ReferenceEquals(obj, this)) return true;

            var other = obj as ElementKey;
            if (other == null) return false;

            return DataMinerID == other.DataMinerID && ElementID == other.ElementID;
        }

        /// <summary>
        /// Converts to a string of the format [DataMiner ID]/[element ID].
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}/{1}", DataMinerID, ElementID);
        }
    }
}
