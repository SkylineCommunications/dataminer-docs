---
uid: Connector_help_Arris_CHP_Max5000_-_CHP-CW4
---

# Arris CHP Max5000 - CHP-CW4

This **exported connector** can show data from a CHP CORWaver 4 module in an [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000) chassis.

The CHP CORWaver 4 module features Quad Density modular transmitter design, 40 transmitters per CHP chassis for 20TX/RU density, 1.2 GHz full spectrum supporting DOCSISr 3.1 upgrades, optimized headend and hub efficiency, support for multiple optical architectures including full spectrum and RFoG, Internal Electronic Slope Adjustment to compensate for headend combining and cable loss at high frequencies, and more.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.003                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** |
|-----------|---------------------|-------------------------|-----------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    |

## Configuration

This SNMP connector is used by DVE child elements that are automatically created by the parent connector [Arris CHP Max5000](xref:Connector_help_Arris_CHP_Max5000) if the respective row in the **DVE Control Table** is enabled.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This DVE child element has the following data pages:

- **General, Status and Configuration:** These pages contain the information and configuration that is common to all DVE modules, like **Temperature, Slot State, Physical ID, Factory default**, etc.
- **Optical Transmitter**: Allows you to check status information related to the optical transmitter, such as **Laser Button Status, Temperature** and **Bias Current**. You can also configure some of the transmitter parameters, such as **Fiber Length, Modulation Mode**, etc.
- **RF Transmitter:** Displays the **RF Transmitter Input and Output Tables** and allows you to adjust some output-related parameters.
- **RF Transmitter Configuration:** Allows you to configure **AGC Mode, Laser Drive, RF Gain** and **Flatness Tilt.**
