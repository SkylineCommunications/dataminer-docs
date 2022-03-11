using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Apps.ManagerStore;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using SLDataGateway.API.Types.Querying;

namespace Skyline.DataMiner.Net.ManagerStore
{
	/// <summary>
	/// A generic component of a helper that provided helper methods for the CRUD of one object.
	/// </summary>
	/// <typeparam name="T">The type.</typeparam>
	public class CrudHelperComponent<T> : ICrudHelperComponent<T>
        where T : DataType
    {
		/// <summary>
		/// Gets the message handler.
		/// </summary>
		/// <value>The message handler.</value>
		protected Func<DMSMessage[], DMSMessage[]> MessageHandler { get; private set; }

		/// <summary>
		/// The trace data of the last call.
		/// </summary>
		protected TraceData TraceDataLastCall;
        private readonly string _extraTypeIdentifier;
        protected readonly string ModuleId;

		/// <summary>
		/// Gets or sets a value indicating whether the CRUD methods will throw <see cref="CrudFailedException"/> exceptions.
		/// </summary>
		/// <value><c>true</c> if the CRUD methods will throw <see cref="CrudFailedException"/> exceptions; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>Default: true.</para>
		/// </remarks>
		public bool ThrowExceptionsOnErrorData { get; set; } = true;

		/// <summary>
		/// Creates the specified object.
		/// </summary>
		/// <param name="obj">The object to create.</param>
		/// <returns>The created object or <see langword="null"/> if the creation failed.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null" />.</exception>
		/// <exception cref="CrudFailedException">The operation failed. Only thrown when <see cref="ThrowExceptionsOnErrorData"/> is <c>true</c>.</exception>
		/// <remarks>Check <see cref="GetTraceDataLastCall"/> in case the operation failed.</remarks>
		public virtual T Create(T obj)
        {
            return default(T);
        }


		/// <summary>
		/// Returns the items that match the specified filter.
		/// </summary>
		/// <param name="filter">The filter to match.</param>
		/// <returns>The items that match the specified filter.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="filter"/> is <see langword="null" />.</exception>
		/// <exception cref="CrudFailedException">The operation failed. Only thrown when <see cref="ThrowExceptionsOnErrorData"/> is <c>true</c>.</exception>
		/// <remarks>Check <see cref="GetTraceDataLastCall"/> in case the operation failed.</remarks>
		public List<T> Read(FilterElement<T> filter)
        {
            return null;
        }

		/// <summary>
		/// Returns all the objects matching the query.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <exception cref="CrudFailedException"> if <see cref="ThrowExceptionsOnErrorData"/> is <c>true</c> and the TraceData contains errors.</exception>
		/// <returns>Never a <see langword="null" /> reference.</returns>
		public virtual List<T> Read(IQuery<T> query)
        {
			return null;
        }

        protected List<T> InnerRead(IQuery<T> query, IAdditionalOperationMeta operationMeta)
        {
			return null;
        }

		/// <summary>
		/// Updates the specified item.
		/// </summary>
		/// <param name="obj">The item to update.</param>
		/// <returns>The updated item.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null" />.</exception>
		/// <exception cref="CrudFailedException">The operation failed. Only thrown when <see cref="ThrowExceptionsOnErrorData"/> is <c>true</c>.</exception>
		public virtual T Update(T obj)
        {
			return default(T);
        }

        protected T InnerUpdate(T obj, IAdditionalOperationMeta operationMeta)
        {
			return default(T);
		}

		/// <summary>
		/// Deletes the specified item.
		/// </summary>
		/// <param name="obj">The item to delete.</param>
		/// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null" />.</exception>
		/// <exception cref="CrudFailedException">The operation failed. Only thrown when <see cref="ThrowExceptionsOnErrorData"/> is <c>true</c>.</exception>
		public virtual void Delete(T obj)
        {
        }

        protected void InnerDelete(T obj, IAdditionalOperationMeta operationMeta)
        {
        }

		/// <summary>
		/// Prepares the paging using the specified filter elements and preferred page size.
		/// </summary>
		/// <param name="filter">The filter elements.</param>
		/// <param name="preferredPageSize">The preferred page size.</param>
		/// <returns>The paging helper instance.</returns>
		public PagingHelper<T> PreparePaging(FilterElement<T> filter, long preferredPageSize)
        {
			return null;
        }

		/// <summary>
		/// Prepares the paging.
		/// </summary>
		/// <param name="filter">The filter elements.</param>
		/// <returns>The paging helper instance.</returns>
		public PagingHelper<T> PreparePaging(FilterElement<T> filter)
        {
			return null;
        }

		/// <summary>
		/// Prepares the paging using the specified query and preferred page size.
		/// </summary>
		/// <param name="query">The query.</param>
		/// <param name="preferredPageSize">The preferred page size.</param>
		/// <returns>The paging helper instance.</returns>
		public virtual PagingHelper<T> PreparePaging(IQuery<T> query, long preferredPageSize)
        {
			return null;
        }

        protected PagingHelper<T> InnerPreparePaging(IQuery<T> query, long preferredPageSize,
            IAdditionalOperationMeta operationMeta)
        {
			return null;
        }

		/// <summary>
		/// Prepares the paging using the specified query and default preferred page size (500).
		/// </summary>
		/// <param name="query">The query.</param>
		/// <returns>The paging helper instance.</returns>
		public virtual PagingHelper<T> PreparePaging(IQuery<T> query)
        {
			return null;
        }

		/// <summary>
		/// Returns the <see cref="TraceData"/> from the last call that was made for this CRUD component.
		/// </summary>
		/// <returns>The <see cref="TraceData"/> from the last call that was made for this CRUD component.</returns>
		public virtual TraceData GetTraceDataLastCall()
        {
			return null;
        }

		/// <summary>
		/// Retrieves the response.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns>The response.</returns>
		/// <exception cref="DataMinerException">Got <see langword="null"/>/empty response from the message handler.</exception>
		protected DMSMessage RetrieveResponse(DMSMessage request)
        {
			return null;
        }

        protected TResp RetrieveResponse<TResp>(DMSMessage request)
        {
			return default(TResp);
        }

        protected ManagerStoreCrudResponse<T> RetrieveCrudResponse(DMSMessage request)
        {
			return null;
		}

        protected void CheckTraceDataLastCall()
        {
        }

        protected void CheckTraceData(TraceData traceData)
        {
        }

    }

    public static class CrudHelperComponentExtension
    {
        /// <summary>
        /// Reads all the given objects of type T using a TRUEFilterElement{T}.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="comp">The component.</param>
        /// <returns></returns>
        public static List<T> ReadAll<T>(this CrudHelperComponent<T> comp)
            where T : DataType
        {
			return null;
        }
    }

}
