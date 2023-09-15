---
uid: Connector_help_Grass_Valley_SAM_IQHCO50
---

# Grass Valley SAM IQHCO50

This connector is used to monitor and configure the Grass Valley SAM IQHCO50. This device provides backup protection for SDI signal paths. Inputs are monitored for signal errors; when an error state is recognized, a backup feed is automatically switched to. A rules engine is available to provide logical conditions for auto-switching, while GPIO or RollTrack inputs can force the unit to switch independently of signal state.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.28.10                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *10.0D* is for unit address *0x10* and unit port *0x0D*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below. In each case, you can **enable or disable polling**.

- **General**: Displays general information about the device. With the **Polling Buttons** toggle button, you can enable or disable all polling buttons of the element at the same time.
- **Connection Info**: Contains information about the status and details of the connection, as well as variable timer settings.
- **Summary**: Provides a general overview of information related to the module. On the **Inputs** subpage, you can find information on the device inputs.
- **Input 1/2/3 valid**: For each input, a page is available with controls related to the validity checks applied to the input and used by the rules engine.
- **Outputs**: Displays outputs information for both main and monitor.
- **Video ProcAmp**: Contains ProcAmp settings for each input.
- **Color Correction**: Contains color corrector settings for each input.
- **Caption and Test Pattern Generators**: Contains test pattern and caption generator settings for each input, and for the dedicated test pattern and caption generator.
- **GPIO 1 - 4/5 - 8**: These pages contain settings for the general purpose IO.
- **Ethernet**: Contains controls for the RJ45 interface.
- **SFP**: Allows you to configure SFPs and monitor various related parameters.
- **Memories**: Allows you to save and recall up to 16 setups. You can provide more meaningful descriptions instead of the default memory names.
- **RollTrack**: Allows information to be sent via the RollCall network to other compatible units connected on the same network.
- **Logging**: These pages allow different kinds of information to be logged: for basic parameters (**Logging - Misc**), for each of the four inputs (**Logging - Input**), for the audio inputs (**Logging - Audio Inputs 1-3**), for outputs (**Logging - Output**) and for errors or events which cause a failover (**Logging - Changeover**).
