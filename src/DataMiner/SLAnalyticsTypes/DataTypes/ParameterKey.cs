using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyline.DataMiner.Analytics.DataTypes
{
    /// <summary>
    /// Object representing a specific parameter or instance of a parameter in DataMiner.
    /// </summary>
    [Serializable]
    public class ParameterKey : ElementKey
    {
        /// <summary>
        /// Gets or sets the parameter ID.
        /// </summary>
        public int ParameterID { get; set; }

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// Gets or sets the display instance.
        /// </summary>
        public string DisplayInstance { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterKey"/> class.
        /// </summary>
        public ParameterKey() : this(-1, 0, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterKey"/> class with the specified parameters. 
        /// The <see cref="DisplayInstance"/> is set to the same value as <paramref name="instance" /> and <paramref name="instance"/> is converted to lowercase.
        /// </summary>
        /// <param name="dataMinerID">The DataMiner ID.</param>
        /// <param name="elementID">The element ID.</param>
        /// <param name="parameterID">The parameter ID.</param>
        /// <param name="instance">The instance.</param>
        public ParameterKey(int dataMinerID, int elementID, int parameterID, string instance = "")
            : this(dataMinerID, elementID, parameterID, instance, instance) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterKey"/> class with the specified parameters. The <paramref name="instance"/> is converted to lowercase.
        /// </summary>
        /// <param name="dataMinerID">The DataMiner ID.</param>
        /// <param name="elementID">The element ID.</param>
        /// <param name="parameterID">The parameter ID.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="displayInstance">The display instance.</param>
        public ParameterKey(int dataMinerID, int elementID, int parameterID, string instance, string displayInstance)
            : base(dataMinerID, elementID)
        {
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return 0;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>Returns true if the specified object is equal to the current object, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return false;
        }

        /// <summary>
        /// Returns a string of the format [DataMiner ID]/[Element ID]/[Parameter ID]/[Instance]/[Display Instance] that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Empty;
        }

        /// <summary>
        /// Deconstructs the <see cref="ParameterKey"/> into its components.
        /// </summary>
        /// <param name="dmaID">The DataMiner ID.</param>
        /// <param name="eID">The element ID.</param>
        /// <param name="pID">The parameter ID.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="displayInstance">The display instance.</param>
        public void Deconstruct(out int dmaID, out int eID, out int pID, out string instance, out string displayInstance)
        {
            dmaID = DataMinerID;
            eID = ElementID;
            pID = ParameterID;
            instance = string.Empty;
            displayInstance = DisplayInstance;
        }
    }
}
