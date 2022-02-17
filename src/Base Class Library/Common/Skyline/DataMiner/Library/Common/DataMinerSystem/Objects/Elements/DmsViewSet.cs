namespace Skyline.DataMiner.Library.Common
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Represents a set of <see cref="IDmsView"/> items.
	/// </summary>
	[Serializable]
	public sealed class DmsViewSet : ISet<IDmsView>
	{
		/// <summary>
		/// The views in the set.
		/// </summary>
		private readonly HashSet<IDmsView> views = new HashSet<IDmsView>(new DmsViewEqualityComparer());

		/// <summary>
		/// Gets the number of views that are contained in a set.
		/// </summary>
		/// <value>The number of views that are contained in the set.</value>
		public int Count
		{
			get
			{
				return views.Count;
			}
		}

		/// <summary>
		/// Gets a value indicating whether a collection is read-only.
		/// </summary>
		/// <value><c>true</c> if the collection is read-only; otherwise, <c>false</c>.</value>
		bool ICollection<IDmsView>.IsReadOnly
		{
			get
			{
				return ((ICollection<IDmsView>)views).IsReadOnly;
			}
		}

		/// <summary>
		/// Adds the specified item to a set.
		/// </summary>
		/// <param name="item">The item to add to the set.</param>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if the item is added to the set; <c>false</c> if the item is already present.</returns>
		public bool Add(IDmsView item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			return views.Add(item);
		}

		/// <summary>
		/// Adds the specified item to a set.
		/// </summary>
		/// <param name="item">The item to add to the set.</param>
		/// <exception cref="ArgumentNullException">The value of a set operation is <see langword="null"/>.</exception>
		void ICollection<IDmsView>.Add(IDmsView item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}

			views.Add(item);
		}

		/// <summary>
		/// Removes all items from the collection.
		/// </summary>
		/// <remarks>
		/// <para>This method is an O(n) operation, where <c>n</c> is Count.</para>
		/// </remarks>
		public void Clear()
		{
			views.Clear();
		}

		/// <summary>
		/// Determines whether the collection contains the specified item.
		/// </summary>
		/// <param name="item">The item to locate in the set.</param>
		/// <returns><c>true</c> if the collection contains the specified item; otherwise, <c>false</c>.</returns>
		/// <remarks>This method is an O(1) operation.</remarks>
		public bool Contains(IDmsView item)
		{
			return views.Contains(item);
		}

		/// <summary>
		/// Copies the items of a ICollection&lt;IDmsView&gt; object to an array, starting at the specified array index.
		/// </summary>
		/// <param name="array">The one-dimensional array that is the destination of the items copied from the object. The array must have zero-based indexing.</param>
		/// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
		/// <exception cref="ArgumentNullException"><paramref name="array"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
		/// <exception cref="ArgumentException"><paramref name="arrayIndex"/> is greater than the length of the destination <paramref name="array"/>.</exception>
		public void CopyTo(IDmsView[] array, int arrayIndex)
		{
			views.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection object.
		/// </summary>
		/// <returns>A enumerator object for the object.</returns>
		public IEnumerator<IDmsView> GetEnumerator()
		{
			return views.GetEnumerator();
		}

		/// <summary>
		/// Removes the specified item from the collection.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		/// <returns><c>true</c> if the item is successfully found and removed; otherwise, <c>false</c>. This method returns <c>false</c> if the item is not found in the collection.</returns>
		public bool Remove(IDmsView item)
		{
			return views.Remove(item);
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>An <see cref="IEnumerator&lt;T&gt;"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)views).GetEnumerator();
		}

		/// <summary>
		/// Modifies the current set to contain all items that are present in itself, the specified collection, or both.
		/// </summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		public void UnionWith(IEnumerable<IDmsView> other)
		{
			views.UnionWith(other);
		}

		/// <summary>
		/// Modifies the current set to contain only items that are present in that object and in the specified collection.
		/// </summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		public void IntersectWith(IEnumerable<IDmsView> other)
		{
			views.IntersectWith(other);
		}

		/// <summary>
		/// Removes all items in the specified collection from the current set.
		/// </summary>
		/// <param name="other">The collection of items to remove from the set.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// <para>The ExceptWith method is the equivalent of mathematical set subtraction.</para>
		/// <para>This method is an O(<c>n</c>) operation, where <c>n</c> is the number of elements in the <c>other</c> parameter.</para>
		/// </remarks>
		public void ExceptWith(IEnumerable<IDmsView> other)
		{
			views.ExceptWith(other);
		}

		/// <summary>
		/// Modifies the current set to contain only items that are present either in this object or in the specified collection, but not both.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <remarks>
		/// If the other parameter is a collection with the same equality comparer as the current object, this method is an O(n) operation.
		///  Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name="other"/> and m is Count.
		/// </remarks>
		public void SymmetricExceptWith(IEnumerable<IDmsView> other)
		{
			views.SymmetricExceptWith(other);
		}

		/// <summary>
		/// Determines whether this set is a subset of the specified collection.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if this object is a subset of other; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>An empty set is a subset of any other collection, including an empty set.
		/// Therefore, this method returns true if the collection represented by the current object is empty, even if the other parameter is an empty set.</para>
		/// <para>This method always returns false if Count is greater than the number of items in <paramref name="other"/>.</para>
		/// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
		/// Otherwise, this method is an O(n + m) operation, where n is Count and m is the number of items in <paramref name="other"/>.</para>
		/// </remarks>
		public bool IsSubsetOf(IEnumerable<IDmsView> other)
		{
			return views.IsSubsetOf(other);
		}

		/// <summary>
		/// Determines whether this object is a superset of the specified collection.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if the object is a superset of other; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>All collections, including the empty set, are supersets of the empty set.
		/// Therefore, this method returns true if the collection represented by the other parameter is empty, even if the current object is empty.</para>
		/// <para>This method always returns false if Count is less than the number of items in <paramref name="other"/>.</para>
		/// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
		///  Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name="other"/> and m is Count.</para>
		/// </remarks>
		public bool IsSupersetOf(IEnumerable<IDmsView> other)
		{
			return views.IsSupersetOf(other);
		}

		/// <summary>
		/// Determines whether the object is a proper superset of the specified collection.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if this object is a proper superset of other; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>An empty set is a proper superset of any other collection.
		/// Therefore, this method returns true if the collection represented by the other parameter is empty unless the current collection is also empty.</para>
		/// <para>This method always returns <c>false</c> if Count is less than or equal to the number of elements in other.</para>
		/// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
		///  Otherwise, this method is an O(n + m) operation, where n is the number of elements in other and m is Count.</para>
		/// </remarks>
		public bool IsProperSupersetOf(IEnumerable<IDmsView> other)
		{
			return views.IsProperSupersetOf(other);
		}

		/// <summary>
		/// Determines whether this object is a proper subset of the specified collection.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if this object is a proper subset of other; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>An empty set is a proper subset of any other collection.
		/// Therefore, this method returns <c>true</c> if the collection represented by the current object is empty unless the other parameter is also an empty set.</para>
		/// <para>This method always returns <c>false</c> if Count is greater than or equal to the number of items in other.</para>
		/// <para>If the collection represented by other is a collection with the same equality comparer as the current object, then this method is an O(n) operation.
		///  Otherwise, this method is an O(n + m) operation, where n is Count and m is the number of items in <paramref name="other"/>.</para>
		/// </remarks>
		public bool IsProperSubsetOf(IEnumerable<IDmsView> other)
		{
			return views.IsProperSubsetOf(other);
		}

		/// <summary>
		/// Determines whether the current object and a specified collection share common items.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if this object and other share at least one common element; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// This method is an O(<c>n</c>) operation, where <c>n</c> is the number of items in <paramref name="other"/>.
		/// </remarks>
		public bool Overlaps(IEnumerable<IDmsView> other)
		{
			return views.Overlaps(other);
		}

		/// <summary>
		/// Determines whether this object and the specified collection contain the same items.
		/// </summary>
		/// <param name="other">The collection to compare to the current object.</param>
		/// <exception cref="ArgumentNullException"><paramref name="other"/> is <see langword="null"/>.</exception>
		/// <returns>true if this set is equal to <paramref name="other"/>; otherwise, false.</returns>
		/// <remarks>
		/// <para>The SetEquals method ignores duplicate entries and the order of items in the <paramref name="other"/> parameter.</para>
		/// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
		/// Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name="other"/> and m is Count.</para>
		/// </remarks>
		public bool SetEquals(IEnumerable<IDmsView> other)
		{
			return views.SetEquals(other);
		}
	}
}
