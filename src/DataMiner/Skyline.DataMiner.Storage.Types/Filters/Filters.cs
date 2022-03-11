using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
	public interface IFilterElement { }

	/// <summary>
	/// Generic interface for a FilterElement.
	/// </summary>
	/// <typeparam name="T">The type that can be filtered with this element.</typeparam>
	public interface FilterElement<T> : IFilterElement
	{
		/// <summary>
		/// Retrieves a value indicating whether it is emtpy.
		/// </summary>
		/// <returns><c>true</c> if empty; otherwise, <c>false</c>.</returns>
		bool isEmpty();

		/// <summary>
		/// Returns the lambda predicate/functor which will decide whether the given element should be kept (true) or not (false).
		/// </summary>
		/// <returns>The lambda predicate/functor which will decide whether the given element should be kept (true) or not (false).</returns>
		Func<T, bool> getLambda();

		/// <summary>
		/// Returns the lambda TripleState predicate/functor which will decide whether the given element should be kept (true), not kept (false) or resulted in an exception (and cannot be fully resolved yet).
		/// </summary>
		/// <returns>The lambda TripleState predicate/functor which will decide whether the given element should be kept (true), not kept (false) or resulted in an exception (and cannot be fully resolved yet).</returns>
		Func<T, TripleState> getExtendedLambda();
	}

	/// <summary>
	/// A full filter is composed of a list of subfilters which are linked to each other.
	/// An element of type T will be in the result list when it complies to all filters,
	/// and the order of the filters is not fixed
	/// </summary>
	/// <typeparam name="T">The type for which this filter is applicable</typeparam>
	public class Filter<T>
	{
		/// <summary>
		/// The root filter element
		/// </summary>
		private FilterElement<T> root;

		/// <summary>
		/// Holds the list of compiled disjunct filters.
		/// You have to perform each of these compiled filters on the DB or list and combine the result taking into account to remove duplicates (or semi-duplicates)
		/// </summary>
		public List<CompiledFilter<T>> compiled { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Filter{T}"/> class.
		/// </summary>
		/// <param name="rootFilter">The root filter.</param>
		public Filter(FilterElement<T> rootFilter)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Filter{T}"/> class.
		/// </summary>
		/// <param name="filters">The filters.</param>
		/// <remarks>The list of filters will be translated into an AND-filter for all these sub-elements.</remarks>
		public Filter(params FilterElement<T>[] filters)
		{
		}

		/// <summary>
		/// Adds a filter element to the combined filter.
		/// </summary>
		/// <param name="filterElement">The filter element to add.</param>
		public void Add(FilterElement<T> filterElement)
		{
		}

		public Type GetDataType()
		{
			return typeof(T);
		}

		/// <summary>
		/// Compiles the filter to a lambda expression.
		/// </summary>
		/// <param name="compiler">The compiler.</param>
		/// <param name="convertToUTC"><c>true</c> to convert to UTC.</param>
		/// <param name="tableNames">The table names.</param>
		public void Compile(FilterCompiler<T> compiler, bool convertToUTC = false, string[] tableNames = null)
		{
		}

		/// <summary>
		/// This method will return the filter as parsed from the filterString.
		/// DateTimes should be of the following format: MM/dd/yyyy HH:mm:ss OR yyyy-MM-dd HH:mm:ss
		/// </summary>
		/// <param name="filterString"></param>
		/// <returns></returns>
		public static FilterElement<T> Parse(string filterString)
		{
			return null;
		}

		/// <summary>
		/// Compiles the filter to lambda expression without any intermediate translations.
		/// </summary>
		public void Compile()
		{
		}

		/// <summary>
		/// Returns the lambda expression without any intermediate translations.
		/// </summary>
		/// <returns>The lambda expression.</returns>
		public Func<T, bool> getLambda()
		{
			return root.getLambda();
		}

		/// <summary>
		/// Retrieves the filter element.
		/// </summary>
		/// <returns>The filter element.</returns>
		public FilterElement<T> GetFilterElement()
		{
			return root;
		}
	}
}
