using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Skyline.DataMiner.Net.Messages.SLDataGateway
{
	/// <summary>Represents an exposer.</summary>
	/// <remarks>
	/// An exposer is a type safe approach to expose a field from a type in the fastest possible manner.
	/// This field is to be used in filtering the data
	/// The exposer has a non-public constructor, allowing the existing instances of the exposer to be known. 
	/// This allows the exposer to be managed and checked for equivalence, allowing to translate a filter partly into DB-query code,
	/// and partly in-memory filtering using the best of lambda expressions in C#. 
	/// </remarks>
	/// <typeparam name="T">The type from which to filter the field </typeparam>
	/// <typeparam name="F">The field on which to filter </typeparam>
	[Serializable]
	public class Exposer<T, F> : FieldExposer
	{
		/// <summary>
		/// The functor mapping the type on its field data.
		/// </summary>
		[NonSerialized] public Func<T, F> internalFunc;

		/// <summary>
		/// The filter type.
		/// </summary>
		public Type FilterType => typeof(T);

		/// <summary>
		/// The field type.
		/// </summary>
		public Type FieldType { get; } = typeof(F);

		/// <summary>
		/// Executes the internal function in a manner that can be called from the exposed execute function.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns>The result.</returns>
		public object execute(object source)
		{
			return internalFunc.Invoke((T)source);
		}

		/// <summary>
		/// Gets or sets the field name that can be used for translating the exposer into query code.
		/// </summary>
		/// <value>The field name that can be used for translating the exposer into query code.</value>
		public string fieldName { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Exposer{T, F}"/> class.
		/// </summary>
		public Exposer()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Exposer{T, F}"/> class with the specified field names.
		/// </summary>
		/// <param name="fieldNames">The field names.</param>
		public Exposer(params string[] fieldNames)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Exposer{T, F}"/> class with the specified functor and field names.
		/// </summary>
		/// <param name="temp">The functor.</param>
		/// <param name="fieldNames">The field names.</param>
		/// <remarks>
		/// The constructor takes the functor together with the field name.
		/// This fieldname will be used in translating the Exposer part of a filter in the query code.
		/// </remarks>
		public Exposer(Func<T, F> temp, params string[] fieldNames)
			: this(fieldNames)
		{
			this.internalFunc = temp;
		}

		/// <summary>
		/// Returns a fieldExposer for the given type and with the given exposer name.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="name">The name.</param>
		/// <returns>A fieldExposer for the given type and with the given exposer name</returns>
		public static Exposer<T, F> findExposer(Type type, string name)
		{
			return null;
		}

		/// <summary>
		/// fINDS the exposer based on the generic type of the call.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static Exposer<T, F> findExposer(string name)
		{
			return findExposer(typeof(T), name);
		}

		public ISerializableExposer ToSerializableExposer()
		{
			return null;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><c>true</c> if the current object is equal to the other parameter; otherwise, <c>false</c>.</returns>
		public bool Equals(FieldExposer other)
		{
			return this == other;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return typeof(T).Name + "." + this.fieldName + "[" + typeof(F).Name + "]";
		}
	}
}
