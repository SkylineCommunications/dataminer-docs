using Skyline.DataMiner.Net.Trending;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skyline.DataMiner.Net.Messages
{
	/// <summary>
	/// Represents a response message to a <see cref="GetTrendDataMessage"/> request.
	/// </summary>
	[Serializable]
    public class GetTrendDataResponseMessage : ResponseMessage
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetTrendDataResponseMessage"/> class.
		/// </summary>
		public GetTrendDataResponseMessage()
        {
        }

		/// <summary>
		/// Gets or sets the number of retrieved trend records.
		/// </summary>
		/// <value>The number of retrieved trend records.</value>
		public int Result { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>The message.</value>
        public string Message { get; set; }

		/// <summary>
		/// Gets or sets the values.
		/// </summary>
		/// <value>The values.</value>
        public string[] Values { get; set; }

		/// <summary>
		/// Gets or sets the column names.
		/// </summary>
		/// <value>The column names.</value>
        public string[] ColumnNames { get; set; }

		/// <summary>
		/// Gets or sets the records.
		/// </summary>
		/// <value>The records.</value>
        public Dictionary<string, List<TrendRecord>> Records { get; set; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }
    }
}
