---
uid: mediaops_connectors
---

# Mediaops supported connectors

> [!CAUTION]
> This page has been moved to docs.dataminer.services. Please refer to the [Solutions](https://docs.dataminer.services/dataminer-overview/DataMiner_Solutions/Overview_DataMiner_Solutions.html) section for the latest version of this page and to make changes to it.

Connectors that need to be able to set up flows through flow engineering and report as-is flows to the flow monitoring app require some integration work to be done in order to work with these apps. More specifically, connectors need to:

* Implement an API that can accept a standardized message coming from flow engineering and translate this into commands that need to be sent to the device so that the connection requested by Flow Engineering can effectively be set up.
* Have certain tables where they report flows monitored on the device, so that these can be visualized in the as-is flow paths in the flow monitoring app.

The following connectors are currently already integrated to set up and monitor flows in the MediaOps solution:

> [!WARNING]
> This list provides an indicative overview of connectors that are intended to be integrated with MediaOps. However, please be aware that this list is subject to potential changes and updates prior to the initial release.

|Connector|Version|Flow Engineering|Flow Monitoring|Virtual Signal Groups (automatic import)|
|---|---|---|---|---|
|[AMWA NMOS IS-05](https://catalog.dataminer.services/details/connector/7691)|?|Yes|Yes|Yes|
|[Arista MCS](https://catalog.dataminer.services/details/connector/7867)|?|Yes|Yes||
|[EVS Cerebrum](https://catalog.dataminer.services/details/connector/7482)|?|Yes|Yes||
|[NetInsight Nimbra Edge](https://catalog.dataminer.services/details/connector/7656)|?|Yes|Yes||
|[AppearTV X20 Platform](https://catalog.dataminer.services/details/connector/5412)|?|Yes|Yes||
|Arista eOS Manager **To be started**|?||||
|Cisco OpenConfig **To be confirmed**|?||||

[TODO] Document also automatic sender/receiver generation for connectors

More detailed information for developers integrating new connectors into the solution can be found [here](https://github.com/SkylineCommunications/SLC-C-Example_Flow-Engineering/blob/main/README.md)
