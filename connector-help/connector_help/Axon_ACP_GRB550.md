---
uid: Connector_help_Axon_ACP_GRB550
---

# Axon ACP GRB550

The GRB550 is a 3 Gb/s, HD, SD digital or analog audio de-embedder, re-embedder and embedded domain shuffler.

The **Axon ACP GRB550** connector can be used to display and configure information related to this device.

## About

There also different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1413                        |

## Installation and configuration

### Creation

This element is automatically created by the element using the **Axon ACP Frame Manager** connector, but can be used as standalone connector.

## Usage

This element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **I/O**
- **Status**
- **Add-On**
- **Local Audio**
- **Local Outputs**
- **Video**
- **Preset**
- **Miscellaneous**
- **Embedder**
- **Shuffler**
- **Meta Data**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for this connector is managed by the connector itself, but creation can be done by the parent connector Axon ACP Frame Manager.

### Interfaces

#### Physical Interfaces

- **SDI Input 1**: A single fixed interface of type **input**.
- **SDI Input 2**: A single fixed interface of type **input**.
- **REF Input 1**: A single fixed interface of type **input**.
- **REF Input 2**: A single fixed interface of type **input**.
- **AUDIO Input 1**: A single fixed interface of type **input**.
- **AUDIO** **Input 2**: A single fixed interface of type **input**.
- **AUDIO** **Input 3**: A single fixed interface of type **input**.
- **AUDIO** **Input 4**: A single fixed interface of type **input**.
- **SYNAPSE Bus Audio Input 2**: A single fixed interface of type **input**.
- **SYNAPSE Bus Audio Input 4**: A single fixed interface of type **input**.
- **SDI Output 1**: A single fixed interface of type **output**.
- **SDI Output 2**: A single fixed interface of type **output**.
- **AUDIO Output 1**: A single fixed interface of type **output**.
- **AUDIO Output 2**: A single fixed interface of type **output**.
- **AUDIO Output 3**: A single fixed interface of type **output**.
- **AUDIO Output 4**: A single fixed interface of type **output**.
- **SYNAPSE Bus Audio Output 1**: A single fixed interface of type **output**.
- **SYNAPSE Bus Audio Output 3**: A single fixed interface of type **output**.

#### Virtual Interfaces

- **Multiplexer**: A single fixed interface of type **inout**.

### Connections

#### Internal Connections

When a DVE child element is created, the following connections are established:

- Between **SDI Input 1** and **Multiplexer**.
- Between **SDI Input 2** and **Multiplexer**.
- Between **AUDIO Input 1** and **Multiplexer**.
- Between **AUDIO Input 2** and **Multiplexer**.
- Between **AUDIO Input 3** and **Multiplexer**.
- Between **AUDIO Input 4** and **Multiplexer**.
- Between **SYNAPSE Bus Audio Input 2** and **Multiplexer**.
- Between **SYNAPSE Bus Audio Input 4** and **Multiplexer**.
- Between **Multiplexer** and **SDI Output 1**.
- Between **Multiplexer** and **SDI Output 2**.
- Between **Multiplexer** and **AUDIO Output 1**.
- Between **Multiplexer** and **AUDIO Output 2**.
- Between **Multiplexer** and **AUDIO Output 3**.
- Between **Multiplexer** and **AUDIO Output 4**.
- Between **Multiplexer** and **SYNAPSE Bus Audio Output 1**.
- Between **Multiplexer** and **SYNAPSE Bus Audio Output 3**.

Depending on the state of **Active Output 1**, the following connections are established:

- **SDI-1**: Between **SDI Input 1** and **SDI Output 1**.
- **SDI-2**: Between **SDI Input 2** and **SDI Output 1**.

Depending on the state of **Active Output 2**, the following connections are established:

- **SDI-1**: Between **SDI Input 1** and **SDI Output 2**.
- **SDI-2**: Between **SDI Input 2** and **SDI Output 2**.
