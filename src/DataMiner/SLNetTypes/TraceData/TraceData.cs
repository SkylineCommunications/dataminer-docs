using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Skyline.DataMiner.Net
{

	/// <summary>
	/// Contains all kinds of data that the server could generate while handling a request.
	/// </summary>
	[Serializable]
    public class TraceData
    {
		/// <summary>
		/// Gets the error data that was generated while handling the request.
		/// </summary>
		/// <value>The error data that was generated while handling the request.</value>
		public ReadOnlyCollection<ErrorData> ErrorData;

		/// <summary>
		/// Gets the warning data that was generated while handling the request.
		/// </summary>
		/// <value>The warning data that was generated while handling the request.</value>
		public ReadOnlyCollection<WarningData> WarningData;

		/// <summary>
		/// Gets the info data that was generated while handling the request.
		/// </summary>
		/// <returns>The info data that was generated while handling the request.</returns>
		public ReadOnlyCollection<InfoData> InfoData;

		/// <summary>
		/// Initializes a new instance of the <see cref="TraceData"/> class.
		/// </summary>
		public TraceData()
        {
        }

		/// <summary>
		/// Retrieves the error data objects of the specified type.
		/// </summary>
		/// <typeparam name="T">The error data type.</typeparam>
		/// <returns>The error data.</returns>
		public List<T> GetErrorDataOfType<T>()
        {
            return null;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }

		/// <summary>
		/// Adds the specified trace data.
		/// </summary>
		/// <param name="data">The trace data to add.</param>
		public void Add(ITracingData data)
        {
        }

		/// <summary>
		/// Adds the specified trace data range.
		/// </summary>
		/// <param name="data">The trace data range to add.</param>
		public void AddRange(IEnumerable<ITracingData> data)
        {
        }

		/// <summary>
		/// Adds the specified trace data.
		/// </summary>
		/// <param name="traceData">The trace data to add.</param>
		public void Add(TraceData traceData)
        {
        }

		/// <summary>
		/// Retrieves a value indicating whether the error, info and warning data is empty.
		/// </summary>
		/// <returns><c>true</c> if the error, info and warning data is empty; otherwise, <c>false</c>.</returns>
		public bool IsEmpty()
        {
            return true;
        }

		/// <summary>
		/// Retrieves a value indicating whether the operation succeeded.
		/// </summary>
		/// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
		/// <remarks>The operation is considered successful in case the error data is empty.</remarks>
		public bool HasSucceeded()
        {
            return true;
        }

		/// <summary>
		/// Retrieves a value indicating whether the warning data is empty.
		/// </summary>
		/// <returns><c>true</c> if the warning data is not empty; otherwise, <c>false</c>.</returns>
		public bool HasWarnings()
        {
            return true;
        }
    }
}
