---
uid: Connector_help_Nokia_Altiplano_Consumer
---

# Nokia Altiplano Consumer

The Nokia Altiplano Consumer connector can make a connection with an accessible configured Kafka service. Via this connection, it can subscribe to specific configured Kafka broker topics. Whenever one or more updates for a certain topic comes in, they will be handled sequentially. If needed, a Nokia Altiplano Collector element will only be created once for every existing Kafka producer so the linked data can be forwarded to it automatically. The focus for the Nokia Altiplano Consumer connector is on its distributor functionality, which ensures that the collector elements receive their reliable data correctly.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**      | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Nokia Altiplano Collectors | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To make sure this connector works as expected, when the element has been created, first configure the necessary settings mentioned in the "How to use" section below.

### Redundancy

There is no redundancy defined.

## How to use

### General

On the General page, you can find all created OLT Nokia Altiplano Collector elements with their needed configuration.

The **Status** cell is important, as this could show that a created element has somehow been stopped, which makes it impossible to forward the data. A failure reason can help to verify the actual issue for the specific element.

A minimum port low range can also be defined. This parameter will be used as a start value when there are no existing collector elements yet.

### Configuration

On the Configuration page, all the necessary **Kafka bus** parameters must be specified. These parameters will be used in the background to connect and subscribe to the Kafka service.

The Kafka bus configuration parameters work closely together with the **Kafka topic subscriptions**. You need to specify certain topics to subscribe to, as otherwise nothing will be handled by the connector. You can add these via the right-click menu.

## Notes

A smart-serial connection is used to establish the forwarding mechanism of the data to the collector elements.
