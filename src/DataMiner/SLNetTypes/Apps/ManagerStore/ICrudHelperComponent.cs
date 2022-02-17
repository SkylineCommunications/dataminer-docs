using System.Collections.Generic;

using Skyline.DataMiner.Net.Messages.SLDataGateway;

using SLDataGateway.API.Types.Querying;

namespace Skyline.DataMiner.Net.ManagerStore
{
	public interface ICrudHelperComponent<T>
		where T : DataType
	{
		T Create(T obj);

		List<T> Read(FilterElement<T> filter);

		List<T> Read(IQuery<T> query);

		T Update(T obj);

		void Delete(T obj);

		PagingHelper<T> PreparePaging(FilterElement<T> filter, long preferredPageSize);

		PagingHelper<T> PreparePaging(FilterElement<T> filter);

		PagingHelper<T> PreparePaging(IQuery<T> query, long preferredPageSize);

		PagingHelper<T> PreparePaging(IQuery<T> query);

		TraceData GetTraceDataLastCall();
	}
}
