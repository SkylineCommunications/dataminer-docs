---
uid: SwarmingBookings
---

# Swarming bookings

To swarm bookings, the *BookingSwarming* [soft-launch option](xref:SoftLaunchOptions) must be enabled. If you are using a version of DataMiner starting from DataMiner 10.4.4/10.5.0 and prior to 10.5.1/10.6.0, the *Swarming* soft-launch option must be enabled instead. From DataMiner 10.5.1/10.6.0 onwards, you can also enable only the *BookingSwarming* option but not the *Swarming* option to allow the swarming of bookings without enabling the swarming of other DataMiner objects. Swarming of contributing bookings is supported from DataMiner 10.5.2/10.6.0 onwards.<!-- RN 41706 -->

When an Agent hosts a booking, it will register the booking and execute the start, end, and event actions. If you want this to happen on a different Agent than the current hosting Agent, you can swarm the booking to a different Agent in the cluster. While swarming, DataMiner will try to unregister the booking from the Agent where it is currently hosted and wait until all ongoing actions have been completed. When this is done, DataMiner will try to register the booking on the new hosting Agent. When the booking is swarmed to the new Agent, event scripts of that booking will be executed on the new Agent.

For more detailed information on how to configure this, see [Configuring a script to swarm bookings](xref:SwarmingScriptBooking).
