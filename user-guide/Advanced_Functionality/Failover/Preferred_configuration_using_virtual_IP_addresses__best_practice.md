---
uid: Preferred_configuration_using_virtual_IP_addresses__best_practice
---

# Preferred configuration using virtual IP addresses (best practice)

When setting up a Failover pair of DMAs with virtual IP addresses, ideally you should:

- Have two different network connections.

- Define four different heartbeats.

## Two network connections

Each of the two DMAs should have two network cards, connected to two different networks.

Make sure to respect the order of the connections in the *Network Connections* list.

- The first connection in the list represents the corporate network, which is used for heartbeats and synchronization.

- The second connection represents the acquisition network, which is mainly used for communication with data sources managed by DataMiner.

> [!NOTE]
> To avoid possible issues in case a NIC is unplugged, you can specify the order of the network adapters used by a DMA (the first being used for the corporate network, the second for the acquisition network). To do so, configure the *NetworkAdapters* tag in the file *DataMiner.xml* (see [DataMiner.NetworkAdapters](xref:DataMiner.NetworkAdapters)). However, note that to do so, you will need to stop both Failover Agents and then restart them once the file has been modified. If you do this for an existing Failover setup, you will also need to make sure that the changes you make match the IP configuration in DMS.xml.

## Four heartbeats

You should configure four different heartbeats.

| Heartbeat | Type               | From  | Towards                                    |
|-----------|--------------------|-------|--------------------------------------------|
| 1         | Normal heartbeat   | DMA 1 | DMA 2                                      |
| 2         | Normal heartbeat   | DMA 2 | DMA 1                                      |
| 3         | Inverted heartbeat | DMA 1 | e.g. a Domain Controller or a local switch |
| 4         | Inverted heartbeat | DMA 2 | e.g. a Domain Controller or a local switch |

> [!NOTE]
> For more information about normal and inverted heartbeats, see [Advanced Failover options](xref:Advanced_Failover_options#heartbeats).
