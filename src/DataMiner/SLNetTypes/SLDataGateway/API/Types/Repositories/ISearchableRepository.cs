using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDataGateway.API.Types.Repositories
{
	/// <summary>
	///     Non-generic version of <see cref="ISearchableRepository{T}" />
	/// </summary>
	public interface ISearchableRepository
	{
	}

	public interface ISearchableRepository<T> //: ISearchableRepository, IBasicRepository<T>
											  //where T : class, DataType
	{
	}
}
