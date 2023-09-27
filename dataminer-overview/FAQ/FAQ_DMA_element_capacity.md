---
uid: FAQ_DMA_element_capacity
---

# How does Skyline define the DMA element capacity?

DataMiner Professional/Enterprise server licenses are applicable for the management of small up to large volumes of heterogeneous collections of objects in high-availability, mission-critical central-core processing environments (e.g. video headend, playout, MCR, data center, regional headends, earth station, hub, core IP networking, CMTS, etc.).

For this type of environment, typically an E0250 license is used (one DMA – physical or virtual server – manages a maximum of 250 elements), as there are a lot of different parameters that are managed by DataMiner. The DMA server needs to be able to cope with the load and be responsive at all times. See also [DataMiner System Requirements](https://community.dataminer.services/documentation/dataminer-system-requirements/) on DataMiner Dojo.

Monitoring the health of a DataMiner Agent requires attention to several key metrics, including but not necessarily limited to processor load, physical memory and commit charge, disk space, disk busy time, network throughput, threads, virtual bytes, handles, database queue, etc. While it is not possible to provide an exact definition for when a DMA reaches its limits, Skyline has guidelines to be considered for these individual metrics.

If, for some cases, the complexity is rather low and/or the number of managed parameters is limited, Skyline might decide to approve an E500 or E1000 license. This allows more elements (up to 1000) to be managed by one DMA server, but  this is only available for specific approved applications. These applications, usually including elements of low complexity, are defined by Skyline based on many years of expertise in this field.
