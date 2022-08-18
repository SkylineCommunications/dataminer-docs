namespace Skyline.DataMiner.Library.Common
{
    using System;

    using Skyline.DataMiner.Net;

    /// <summary>
    /// Defines extension methods on the IConnection class.
    /// </summary>
    ///
    public static class ConnectionInterfaceExtensions
    {
        /// <summary>
        /// Gets an object implementing the <see cref="IDms"/> interface using an object that implements the IConnection class.
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

            return null;
        }
    }
}