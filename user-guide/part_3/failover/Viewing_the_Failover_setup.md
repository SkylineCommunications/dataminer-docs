## Viewing the Failover setup

To view a graphical representation of how two DMAs are set up as each other’s backup:

1. In Cube, go to *Apps* > *System Center \> Agents*.

2. In the lower right corner of the *manage* tab, click the *Failover* button.

The screenshot below shows such a graphical representation with two teamed DMAs acting as one virtual DMA, with corporate IP address 10.10.54.2 and acquisition IP address 169.254.46.16. In the screenshot, the second DMA in the team is online, while the first one is standing by.

Note that the active as well as the passive team member are connected to both the corporate and the acquisition network. Although they act as one single DMA, accessible to all other DMAs in the cluster via a pair of shared virtual IP addresses, each separate team member is also accessible via its own pair of fixed IP addresses.

![](../../images/dma_failover.png)



From DataMiner 10.2.0/10.1.8 onwards, the layout of this window is different, as this DataMiner version introduces the possibility to use a shared hostname instead of two virtual IP addresses to represent the Failover pair. However, the active and passive DMA are still indicated in the same manner.

![](../../images/FailoverConfig1018.png)


