---
uid: Switching_to_Failover_with_shared_hostname
---

# Switching Failover from virtual IP to hostname

If you already have a fully configured Failover setup that uses virtual IP addresses, but you want to switch to a Failover setup with shared hostname, we recommend **[decommissioning the current Failover setup](xref:Ending_a_Failover_configuration)** first and then [setting up Failover](xref:Failover_configuration_in_Cube) again to use the shared hostname instead.

Alternatively, you can shut down both DataMiner Agents and adjust the Failover configuration directly in [DataMiner.xml](xref:DataMiner_xml). However, we advise against this approach unless shutting down both DMAs simultaneously is not a problem for you and you are familiar with the *DataMiner.xml* configuration.
