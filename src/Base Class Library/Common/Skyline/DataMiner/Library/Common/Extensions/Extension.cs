namespace Skyline.DataMiner.Library.Common
{
    using Skyline.DataMiner.Net;

    using System;

    /// <summary>
    /// Defines extension methods on the <see cref="IConnection"/> class.
    /// </summary>
    ///
    [Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
    public static class ConnectionInterfaceExtensions
    {
        /// <summary>
        /// Gets an object implementing the <see cref="IDms"/> interface using an object that implements the  <see cref="IConnection"/> class.
        /// </summary>
        /// <param name="connection">The connection interface.</param>
        /// <exception cref="ArgumentNullException"><paramref name="connection"/> is <see langword="null" />.</exception>
        /// <returns>Object implementing the <see cref="IDms"/> interface.</returns>
        public static IDms GetDms(this IConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            return new Dms(new ConnectionCommunication(connection));
        }
    }
}