using System;
using System.Linq;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Swarming.Helper.Interfaces;

namespace Skyline.DataMiner.Net.Swarming.Helper
{
    /// <summary>
    /// Helper class for Swarming action in scripts.
    /// Create an instance by calling one of the static <see cref="Create(IConnection)" /> or
    /// <see cref="Create(Func&lt;DMSMessage, DMSMessage[]&gt;)" /> methods.
    /// Example usage:
    /// 
    /// First create a helper. This can be stored somewhere and reused between requests.
    /// 
    /// <code>
    /// var helper = SwarmingHelper.Create(_connection);
    /// </code>
    /// 
    /// Then do the actual swarming actions:
    ///
    /// <code>
    /// var results = helper
    ///    .SwarmElement(elementId)
    ///    .ToAgent(targetAgentId);
    /// </code>
    ///    
    /// Note: The <see cref="ToAgent">ToAgent</see> call does the actual swarming request.
    /// </summary>
    /// <remarks>
    /// While instances of <see cref="SwarmingHelper"/> can be re-used, they are not
    /// thread-safe.
    /// </remarks>
    public class SwarmingHelper : ISwarmingHelper, ITargetlessSwarmingHelper
    {
        /// <summary>
        /// Creates a new <see cref="SwarmingHelper" /> instance.
        /// </summary>
        /// <param name="connection">Active connection that can be used to send swarming requests through.</param>
        /// <returns>Swarming Helper</returns>
        /// <exception cref="ArgumentNullException">No connection specified</exception>
        public static ISwarmingHelper Create(IConnection connection)
        {
            if(connection is null) 
                throw new ArgumentNullException(nameof(connection));

            return new SwarmingHelper(connection.HandleMessage);
        }

        /// <summary>
        /// Creates a new <see cref="SwarmingHelper" /> instance.
        /// </summary>
        /// <param name="handleMessageFunc">Callback that the helper can use to send requests to the DataMiner Agent.</param>
        /// <returns>Swarming Helper</returns>
        /// <exception cref="ArgumentNullException">No callback handler specified</exception>
        public static ISwarmingHelper Create(Func<DMSMessage, DMSMessage[]> handleMessageFunc)
            => new SwarmingHelper(handleMessageFunc);

        private SwarmingHelper(Func<DMSMessage, DMSMessage[]> handleMessageFunc)
        {
        }

        /// <summary>
        /// Prepares the helper to swarm one specific element. Call <see cref="ITargetlessSwarmingHelper.ToAgent"/>
        /// on the result to do the actual swarming.
        /// </summary>
        /// <param name="dmaId"></param>
        /// <param name="elementId"></param>
        /// <returns>An <see cref="ITargetlessSwarmingHelper"/> object on which you can call <see cref="ITargetlessSwarmingHelper.ToAgent"/>.</returns>
        public ITargetlessSwarmingHelper SwarmElement(int dmaId, int elementId)
            => SwarmElements(new ElementID(dmaId, elementId));

        /// <summary>
        /// Prepares the helper to swarm one specific element. Call <see cref="ITargetlessSwarmingHelper.ToAgent"/>
        /// on the result to do the actual swarming.
        /// </summary>
        /// <param name="element">Element ID reference</param>
        /// <returns>An <see cref="ITargetlessSwarmingHelper"/> object on which you can call <see cref="ITargetlessSwarmingHelper.ToAgent"/>.</returns>
        public ITargetlessSwarmingHelper SwarmElement(ElementID element)
            => SwarmElements(element);

        /// <summary>
        /// Prepares the helper to swarm a series of elements. Call <see cref="ITargetlessSwarmingHelper.ToAgent"/>
        /// on the result to do the actual swarming.
        /// </summary>
        /// <param name="elements">Element ID references</param>
        /// <returns>An <see cref="ITargetlessSwarmingHelper"/> object on which you can call <see cref="ITargetlessSwarmingHelper.ToAgent"/>.</returns>
        public ITargetlessSwarmingHelper SwarmElements(params ElementID[] elements)
        {
            return this;
        }

        /// <summary>
        /// Prepares the helper to swarm one specific booking. Call <see cref="ITargetlessSwarmingHelper.ToAgent"/>
        /// on the result to do the actual swarming.
        /// </summary>
        /// <param name="booking">Booking reference</param>
        /// <returns>An <see cref="ITargetlessSwarmingHelper"/> object on which you can call <see cref="ITargetlessSwarmingHelper.ToAgent"/>.</returns>
        public ITargetlessSwarmingHelper SwarmBooking(Guid booking)
            => SwarmBookings(booking);

        /// <summary>
        /// Prepares the helper to swarm a series of bookings. Call <see cref="ITargetlessSwarmingHelper.ToAgent"/>
        /// on the result to do the actual swarming.
        /// </summary>
        /// <param name="bookings">Booking references</param>
        /// <returns>An <see cref="ITargetlessSwarmingHelper"/> object on which you can call <see cref="ITargetlessSwarmingHelper.ToAgent"/>.</returns>
        public ITargetlessSwarmingHelper SwarmBookings(params Guid[] bookings)
        {
            return this;
        }

        /// <summary>
        /// Swarms the objects previously prepared by calling the SwarmElements or SwarmBookings methods to the specified Agent.
        /// </summary>
        /// <param name="dmaId">ID of the target DataMiner Agent.</param>
        /// <returns></returns>
        public SwarmingResult[] ToAgent(int dmaId)
        {
            return null;
        }
    }
}