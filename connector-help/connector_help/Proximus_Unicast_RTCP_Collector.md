---
uid: Connector_help_Proximus_Unicast_RTCP_Collector
---

# Proximus Unicast RTCP Collector

The **Proximus Unicast RTCP Collector** will receive RTCP packets coming from Cisco VQE servers that are responsible for unicast streams for STBs.

## About

On a TCP port, the element will listen to the incoming stream with RTCP packets.

The processed data will not be stored on this element but will be forwarded to the **Belgacom RTCP Collector** element that stores the other KPIs, such as the broadcast KPIs, of the STB from which this data originates.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**    |
|------------------|--------------------------------|
| 1.0.0.x          | RTCP Compound Packet version 4 |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: As the element needs to listen to incoming streams, this is the IP of the DMA itself. In case there are multiple network cards, this is the IP of the network card where the stream will enter.
  - **IP port**: This is the TCP port that the element has to listen to for incoming streams.

### Configuration of Collector Type

On the **General** page, the **Collector Type** can be set. The value of this parameter depends on the type of VQE server. A first type of VQE server can get unicast requests from STBs that all reside in the same POP. These VQE servers mostly contain popular content. A second type of VQE server could get unicast requests from all STBs in the network. In that case, the VQE servers contain content that is not requested often.

The four possible values are:

- *General Standalone*: The incoming stream originates from a VQE server that can get requests from any STB in the network. To be able to forward the data to the correct element, the connector needs to store the mapping between every STB and element to which data is to be forwarded.
- *General Shared*: The same VQE server type as *General Standalone*; however, instead of storing the same mapping in memory, the connector checks the mapping from the *General Standalone* element in memory, which improves performance. This setting should only be used if there is another element on the same DMA with the **Collector Type** set to *General Standalone* and if there is only one SLScripting process running.
- *POP Standalone*: The incoming stream comes from a VQE server that can only get requests from STBs that belong to a certain POP. To be able to forward the data to the correct element, the connector only needs to look up the configuration of the elements that are responsible for this POP. In this case, the **POP** parameter needs to be filled in with the name of the POP.
- *POP Shared*: The same VQE server type as *POP Standalone*; however, instead of storing the same configuration in memory, the connector checks the configuration from the *POP* *Standalone* element in memory, which improves performance. This setting should only be used if there is another element on the same DMA with the **Collector Type** set to *POP* *Standalone* with the same **POP** and if there is only one SLScripting process running. In this case, the **POP** parameter needs to be filled in with the name of the POP.

## Usage

### General

On this page, the parameter **RTCP Packets Received Last 10s** displays how many RTCP packets were received during the last 10 seconds. **XR Packets Received Last 15min** displays how many XR packets were received during the last 15 minutes. It is possible that RTCP packets are received that do not contain XR packets, which is then indicated by these two parameters.

For more information on the **Collector Type** and **POP** parameters, refer to the "Configuration of Collector Type" section above.

The **Get MAC** button can be used to do a force readout of the STB configuration. By default, the STB configuration is read out automatically every 12 hours.
