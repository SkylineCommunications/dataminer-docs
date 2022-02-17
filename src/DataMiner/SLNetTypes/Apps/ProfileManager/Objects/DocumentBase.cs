using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Skyline.DataMiner.Net.ResourceManager.Helpers;

namespace Skyline.DataMiner.Net.Profiles
{
	/// <summary>
	/// Represents a document-like object that has a name and some metadata.
	/// </summary>
	[Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class DocumentBase : LinkableObject
    {
		/// <summary>
		/// Gets or sets the name of this object.
		/// </summary>
		/// <value>The name of this object.</value>
        public virtual string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
        public virtual string Description { get; set; }

		/// <summary>
		/// Gets or sets the creator of this object.
		/// </summary>
		/// <value>The creator of this object.</value>
        public virtual string CreatedBy { get; set; }

		/// <summary>
		/// Gets or sets the creation time.
		/// </summary>
		/// <value>The creation time.</value>
        public virtual DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the name of the user that last modified this object.
		/// </summary>
		/// <value>The name of the user that last modified this object.</value>
        public virtual string LastModifiedBy { get; set; }

		/// <summary>
		/// Gets or sets the last modification time.
		/// </summary>
		/// <value>The last modification time.</value>
        public virtual DateTime LastModifiedAt { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentBase"/> class.
		/// </summary>
		public DocumentBase() : base()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentBase"/> class using the specified <see cref="DocumentBase"/> instance.
		/// </summary>
		/// <param name="db">The document base.</param>
		public DocumentBase(DocumentBase db) : base(db.ID)
        {
        }

        protected void CopyCtor(DocumentBase db)
        {
        }

        #region Custom serialization
        public bool ShouldSerializeName()
        {
			return true;
        }

        public bool ShouldSerializeDescription()
        {
            return true;
        }

        public bool ShouldSerializeCreatedBy()
        {
            return true;
        }

        public bool ShouldSerializeLastModifiedBy()
        {
            return true;
        }

        public bool ShouldSerializeCreatedAt()
        {
			return true;
        }

        public bool ShouldSerializeLastModifiedAt()
        {
            return true;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Verifies whether this object qualifies for the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns><c>true</c> if it passes the filter, otherwise, <c>false</c>.</returns>
        public bool FiltersTo(DocumentBase filter)
        {
            return true;
        }

		/// <summary>
		/// Obtains the latest document from the specified document objects that represent the same document.
		/// </summary>
		/// <param name="documents">The document objects with the same GUID.</param>
		/// <exception cref="ArgumentException"><paramref name="documents"/> is <see langword="null"/> or empty<br />
		/// -or-<br />
		/// Not all documents have the same GUID.
		/// </exception>
		/// <returns>The latest document from the specified document objects that represent the same document.</returns>
		public static DocumentBase GetLatestDocument(params DocumentBase[] documents)
        {
			return null;
		}
		#endregion

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		private bool Equals(DocumentBase other)
        {
            return true;
        }

        public IEnumerable<PieceMeal> PieceMealCompare(DocumentBase other)
        {
			return null;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="other">An object to compare with this instance.</param>
		/// <returns>
		/// <para>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="other"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="other"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(DocumentBase other)
        {
            return 1;
        }

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// <para>A value that indicates the relative order of the objects being compared. The return value can have the following meanings:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Less than zero</term>
		/// <description>This instance precedes <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <description>This instance occurs in the same position in the sort order as <paramref name="obj"/>.</description>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <description>This instance follows <paramref name="obj"/> in the sort order.</description>
		/// </item>
		/// </list>
		/// </returns>
		public int CompareTo(object obj)
        {
			return 1;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Two <see cref="DocumentBase"/> instances are considered equal by this method if the following conditions are met:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The <see cref="Type"/> of the specified object is the same.</description>
		/// </item>
		/// <item>
		/// <description>The values for <see cref="Name"/>, <see cref="Description"/>, <see cref="CreatedBy"/>, <see cref="CreatedAt"/>, <see cref="LastModifiedBy"/>, <see cref="LastModifiedAt"/> and <see cref="LinkableObject.ID"/> are equal.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public override bool Equals(object obj)
        {
			return false;
		}

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
            return 0;
        }
    }
}
