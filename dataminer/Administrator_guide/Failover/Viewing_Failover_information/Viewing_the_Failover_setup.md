---
uid: Viewing_the_Failover_setup
---

# Viewing the Failover setup

> [!NOTE]
> To monitor the history of a Failover setup, you can use the [Generic Failover Status](https://catalog.dataminer.services/details/bef0ba8b-3145-48b7-a83e-cd1ee784024e) connector. This allows you to activate monitoring and trending on the Failover state.

To view a graphical representation of how two DMAs are set up as each other’s backup:

1. In Cube, go to *Apps* > *System Center \> Agents*.

1. In the lower-right corner of the *manage* tab, click the *Failover* button.

The screenshot below (from DataMiner 10.1.0) shows such a graphical representation with two teamed DMAs acting as one virtual DMA, with corporate IP address 10.10.54.2 and acquisition IP address 169.254.46.16. In the screenshot, the second DMA in the team is online, while the first one is standing by.

Note that the active as well as the passive team member are connected to both the corporate and the acquisition network. Although they act as one single DMA, accessible to all other DMAs in the cluster via a pair of shared virtual IP addresses, each separate team member is also accessible via its own pair of fixed IP addresses.

![Failover window in DataMiner 10.1.0](~/dataminer/images/dma_failover.png)

From DataMiner 10.2.0/10.1.8 onwards, the layout of this window is different, as this DataMiner version introduces the possibility to use a shared hostname instead of two virtual IP addresses to represent the Failover pair. However, the active and passive DMA are still indicated in the same manner.

For example, this is a Failover configuration in DataMiner 10.1.8:

![Failover window in DataMiner 10.1.8](~/dataminer/images/FailoverConfig1018.png)
