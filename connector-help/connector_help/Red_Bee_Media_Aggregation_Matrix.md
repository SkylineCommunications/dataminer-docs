---
uid: Connector_help_Red_Bee_Media_Aggregation_Matrix
---

# Red Bee Media Aggregation Matrix

This protocol works with the Generic Matrix Virtualization connector and the Grass Valley Convergent. It is capable of routing signals through one of the Convergent devices, which is connected to the Generic Matric Virtualization element, and over the different layers of the Convergent.

## About

### Version Info

| Range            | Key Features                                                                             | Based on | System Impact |
|----------------------|----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Routing signals on multiple layers in 1 matrix. - Output path calculation for all layers. | \-           | \-                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|--|--|--|--|--|
| 1.0.0.x | No | Yes | Visio drawings:<br>- Generic vMatrix - RBM Aggregation Matrix - Main<br>Generic vMatrix - RBM Aggregation Matrix - RouterControl | - |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

All Grass Valley Convergent source matrices need to be created with version 1.0.3.1 or higher. They must be set to *All Levels Take* and layer "All", and connected to a Generic Matrix Virtualization element that is fully configured, using version 4.0.0.17 or higher.

Two element connections then need to be created:

- From the **Generic Matrix Virtualization** element, parameter: "Generic Matrix Virtualization - Info", to the **Aggregation matrix**, parameter: "Vmatrix Configuration String (write)".
- From the **Grass Valley Convergent** element, parameter: "Convergent Layer Status String", to the **Aggregation matrix**, parameter: "Convergent Layer Status String (write)".

For more information on element connections, see [Virtual elements used for element connections](xref:Virtual_elements#virtual-elements-used-for-element-connections).

### Redundancy

There is no redundancy defined.

## How to use

This driver is intended to be used in the background to support the Red Bee Media Visual Overview pages (See "Linked Components" above).
