using System.Collections.Generic;

using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Storage.Types.DataTypes;

using SLDataGateway.API.Types.Querying;
using SLDataGateway.API.Types.Repositories;

namespace Skyline.DataMiner.Net.LogHelpers
{
	/// <summary>
	/// Log entry CRUD helper component interface.
	/// </summary>
	public interface ILogEntryCrudHelperComponent
    {
		/// <summary>
		/// Gets the raw repository.
		/// </summary>
		/// <value>The raw repository.</value>
        IDataSetRepository<LogEntry> RawRepository { get; }

		/// <summary>
		/// Gets the raw searchable repository.
		/// </summary>
		/// <value>The raw searchable repository.</value>
		ISearchableRepository<LogEntry> RawSearchableRepository { get; }


        List<LogEntry> Read(IQuery<LogEntry> query);

        PagingHelper<LogEntry> PrepareSearchPaging(string query, IQuery<LogEntry> filter);

        PagingHelper<LogEntry> PreparePaging(IQuery<LogEntry> query);

        PagingHelper<LogEntry> PrepareSearchPaging(string query, long preferredPageSize, IQuery<LogEntry> filter);

        PagingHelper<LogEntry> PreparePaging(IQuery<LogEntry> query, long preferredPageSize);
    }
}