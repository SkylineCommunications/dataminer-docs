---
uid: DataAggregator_2.1.1
---

# Data Aggregator 2.1.1

## Changes

### Enhancements

#### Logging now mentions the DMA handling a GQI query [ID_37511]

To make it easier to find out which DMA handled a GQI request, the DataAggregator logging will now include the DMA that handled such a request.

The CoreGateway DxM has also been modified to include this information when it creates a new GQI session.
