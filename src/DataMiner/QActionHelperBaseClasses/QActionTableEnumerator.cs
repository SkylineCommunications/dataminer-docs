using System;
using System.Collections;
using System.Collections.Generic;

namespace Skyline.DataMiner.Scripting
{
	/// <summary>
	/// Supports a simple iteration over a <see cref="QActionTableRow"/> collection.
	/// </summary>
	/// <typeparam name="T">The type of the rows in the table.</typeparam>
	public class QActionTableEnumerator<T> : IEnumerator<T> where T : QActionTableRow
	{
		private QActionTable _table;
		private int _index;

		/// <summary>
		/// Initializes a new instance of the <see cref="QActionTableEnumerator&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="table">The table.</param>
		public QActionTableEnumerator(QActionTable table)
		{
			_table = table;
			_index = -1;
		}

		/// <summary>
		/// Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		/// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		public void Reset()
		{
			_index = -1;
		}

		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns><c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the enumerator has passed the end of the collection.</returns>
		/// <exception cref="InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		public bool MoveNext()
		{
			_index++;

			return _index < _table.RowCount;
		}

		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		/// <value>The element in the collection at the current position of the enumerator.</value>
		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		/// <value>The element in the collection at the current position of the enumerator.</value>
		public T Current
		{
			get
			{
				try
				{
					return (T)Convert.ChangeType(_table[_index], typeof(T));

				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		void IDisposable.Dispose()
		{

		}
	}
}