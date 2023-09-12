---
uid: Connector_help_Aurora_Network_Node_FA3527
---

# Aurora Network CX3001 - FA3527

This driver is used by DVEs created by the Aurora Network CX3001 parent driver. It represents a high-power EDFA module.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                           | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Trap receiver only.                                                                                                                                        | \-           | \-                |
| 2.0.0.x              | Updated driver based on MIB, consisting of Aurora Node NC 4000 chassis and DVEs.                                                                           | 1.0.0.x      | \-                |
| 2.0.1.x \[SLC Main\] | Fixed DVE label name and full review. Information is displayed on the Status, Alarming, User Setup and Module Info pages (see "How to use" section below). | 2.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.1.x   | N/A                    |

## Configuration

This driver is used by DVE child elements that are **automatically created** by the parent driver [Aurora Network CX3001](xref:Connector_help_Aurora_Network_CX3001).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver has the following data pages:

- **Status**: Displays status information for the Optical Power, Lasers, and Module.
- **Alarming**: Allows you to configure the alarm severity/state for the module, EDFA, and lasers. Also shows whether an alarm is active or if it was active in the past. The clear button allows you to clear the complete alarm history.
  Note: Because the device is slow to implement a parameter set, a delay of 1.5 seconds is used. In some rare situations, it can occur that this delay is not enough. In that case, it will be changed to 30 seconds when the driver polls next. Please take this into account if you use Automation scripts.
- **User Setup**: Contains information regarding the Mode Selection, Laser Setup, and Alarm Setup.
- **Module Info**: Displays information about the module itself.
