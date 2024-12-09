using System;

namespace Skyline.DataMiner.Net.Swarming.Helper.Interfaces
{
    /// <inheritdoc cref="SwarmingHelper"/>
    public interface ISwarmingHelper
    {
        /// <inheritdoc cref="SwarmElements(ElementID[])" />
        ITargetlessSwarmingHelper SwarmElement(int dmaId, int elementId);

        /// <inheritdoc cref="SwarmElements(ElementID[])" />
        ITargetlessSwarmingHelper SwarmElement(ElementID element);

        /// <summary>
        /// Swarms one or more elements to another hosting Agent.
        /// Chain this method together with <see cref="ITargetlessSwarmingHelper.ToAgent(int)"/>.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        ITargetlessSwarmingHelper SwarmElements(params ElementID[] elements);

        /// <inheritdoc cref="SwarmBookings(Guid[])" />
        ITargetlessSwarmingHelper SwarmBooking(Guid booking);

        /// <summary>
        /// Swarms one or more bookings to another hosting Agent.
        /// Chain this method together with <see cref="ITargetlessSwarmingHelper.ToAgent(int)"/>.
        /// </summary>
        /// <param name="bookings"></param>
        /// <returns></returns>
        ITargetlessSwarmingHelper SwarmBookings(params Guid[] bookings);
    }
}