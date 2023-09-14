---
uid: Connector_help_Axon_ACP_DBE08
---

# Axon ACP DBE08

The DBE08 is a Dolby-E encoder standalone or add-on card.

The **Axon ACP DBE08** connector can be used to display and configure information related to this device.

## About

There are different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1417, 1418, 1518       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

The element using this connector can be automatically created by the parent element using the **Axon ACP Frame Manager** connector, but it can also be a standalone element.

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This element has the following data pages:

- **General**: This page displays general information about the card: **Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.
- **Status**
- **AES**
- **Dolby-E**
- **Settings**
- **Meta Data**
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The Axon ACP protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Physical Interfaces

- **AES 1/2**: A single fixed interface of type **input**.
- **AES 3/4**: A single fixed interface of type **input**.
- **AES 5/6**: A single fixed interface of type **input**.
- **AES 7/8**: A single fixed interface of type **input**.
- **REF Input 1**: A single fixed interface of type **input**.
- **REF Input 2**: A single fixed interface of type **input**.
- **SYNAPSE Bus Input 1**: A single fixed interface of type **input**.
- **SYNAPSE Bus Input 2**: A single fixed interface of type **input**.
- **SYNAPSE Bus Input 3**: A single fixed interface of type **input**.
- **Dolby-E Output**: A single fixed interface of type **output**.
- **AUX Output**: A single fixed interface of type **output**.
- **SYNAPSE Bus Output 1**: A single fixed interface of type **output**.
- **SYNAPSE Bus Output 2**: A single fixed interface of type **output**.
- **SYNAPSE Bus Output 3**: A single fixed interface of type **output**.
- **SYNAPSE Bus Output 4**: A single fixed interface of type **output**.

### Connections

#### Internal Connections

When a element is created, the following connections are established:

- Between **AES 1/2** and **Dolby-E Output**.
- Between **AES 1/2** and **AUX Output**.
- Between **AES 1/2** and **SYNAPSE Bus Output 1**
- Between **AES 3/4** and **Dolby-E Output**.
- Between **AES 3/4** and **AUX Output**.
- Between **AES 3/4** and **SYNAPSE Bus Output 1**.
- Between **AES 5/6** and **Dolby-E Output**.
- Between **AES 5/6** and **AUX Output**.
- Between **AES 5/6** and **SYNAPSE Bus Output 1**.
- Between **AES 7/8** and **Dolby-E Output**.
- Between **AES 7/8** and **AUX Output**.
- Between **AES 7/8** and **SYNAPSE Bus Output 1**.
- Between **SYNAPSE Bus Input 1** and **SYNAPSE Bus Output 2**.
- Between **SYNAPSE Bus Input 2** and **SYNAPSE Bus Output 3**.
- Between **SYNAPSE Bus Input 3** and **SYNAPSE Bus Output 4**.

Depending on the state of the **Reference Input**, the following connections are established:

- **REF 1**:

- Between **REF Input 1** and **Dolby-E Output**.
  - Between **REF Input 1** and **AUX Output**.

- **REF 2**:

- Between **REF Input 1** and **Dolby-E Output**.
  - Between **REF Input 1** and **AUX Output**.

## Notes

It is recommended to use this connector in combination with the **Axon ACP Frame Manager** connector for optimal coverage of information.
