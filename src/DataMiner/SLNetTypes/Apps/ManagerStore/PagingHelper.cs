using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using SLDataGateway.API.Types.Querying;

namespace Skyline.DataMiner.Net.ManagerStore
{
	/// <summary>
	/// Helper class to retrieve data that matches a <see cref="Query"/> in a paged fashion.
	/// </summary>
	/// <typeparam name="T">The type of the data that is paged.</typeparam>
	public class PagingHelper<T>
        where T : DataType
    {
		/// <summary>
		/// Gets or sets the message handler.
		/// </summary>
		/// <value>The message handler.</value>
		protected Func<DMSMessage[], DMSMessage[]> MessageHandler { get; set; }

		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>The filter for which this paging helper is created.</value>
		public FilterElement<T> Filter => null;

		/// <summary>
		/// Gets the query.
		/// </summary>
		/// <value>The query for which this paging helper is created.</value>
		public IQuery<T> Query { get; private set; }

		/// <summary>
		/// Gets the trace data.
		/// </summary>
		/// <value>The cumulative trace data that is returned during all the paging requests.</value>
		public TraceData TraceData { get; private set; }

		/// <summary>
		/// Gets the preferred page size.
		/// </summary>
		/// <value>The preferred page size.</value>
		public long PreferedPageSize { get; private set; }

		/// <summary>
		/// Retrieves the current page.
		/// </summary>
		/// <returns>The current page.</returns>
		/// <remarks>
		/// Returns the objects of the last paging request.
		/// After creation of the <see cref="PagingHelper{T}"/> this list is empty.
		/// </remarks>
		public List<T> GetCurrentPage()
        {
			return null;
        }

		/// <summary>
		/// Retrieves a value indicating whether there is a next page.
		/// </summary>
		/// <returns><c>true</c> if there is a next page; otherwise, <c>false</c>.</returns>
		public bool HasNextPage()
        {
			return true;
        }

		/// <summary>
		/// Moves to the next page.
		/// </summary>
		/// <returns><c>true</c> if moved to the next page; otherwise, <c>false</c>.</returns>
		public bool MoveToNextPage()
        {
            return true;
        }

		/// <summary>
		/// Retrieves all items.
		/// </summary>
		/// <returns>All retrieved items matching the query.</returns>
		/// <exception cref="InvalidOperationException">You can only call GetAll once on a PagingHelper.</exception>
		/// <remarks>
		/// Will keep sending page requests to the server until all data is retrieved.
		/// </remarks>
		/// <exception cref="InvalidOperationException">This method was invoked more than once on this helper instance.</exception>
		public List<T> GetAll()
        {
			return null;
		}

        protected virtual DMSMessage PreProcessStartRequest(ManagerStoreStartPagingRequest<T> request)
        {
			return null;
		}

        protected virtual DMSMessage PreProcessNextRequest(ManagerStoreNextPagingRequest<T> request)
        {
			return null;
		}

        protected virtual ManagerStorePagingResponse<T> ProcessResponse(ManagerStorePagingResponse<T> response)
        {
			return null;
		}

        protected virtual ManagerStorePagingResponse<T> ProcessReponse(ManagerStoreCrudResponse<T> response)
        {
			return null;
        }

        protected virtual ManagerStorePagingResponse<T> GetInitialPage()
        {
			return null;
		}

        protected virtual ManagerStorePagingResponse<T> GetNextPage()
        {
			return null;
		}

        protected virtual List<T> ConstructNextPage()
        {
			return null;
		}
    }
}
