---
uid: Connector_help_Specialty_Microwave_Corp_13983-504
---

# Specialty Microwave Corp 13983-504

This panel supplies power to up to four low-noise amplifiers (LNB) and provides redundancy protection switching logic for the LNBs. The unit is designed to operate -24 VDC waveguide/coaxial switches with one indicator circuit and LNB power of +13/+18 VDC @ 250 mA to 500 mA. Control of the waveguide/coaxial switches is initially accomplished manually at the front panel or at the remote interface. Both a parallel port and a serial port are provided for remote control and monitoring. After the desired switch arrangement has been established, switching can be accomplished automatically via circuits contained in the logic panel. The current of the LNBs is monitored in order to determine if a fault has occurred and initiate automatic switching when necessary.

## About

The connector polls and displays the current status of the switch. This includes the operation mode of the controller, the local/remote status, the LNBs and the power supplies.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 02.30                       |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: *9600*
  - **Databits**: 6
  - **Stopbits**: 1
  - **Parity**: None
  - **FlowControl**:

- Interface connection:

  - **IP address/host**: 192.168.52.10
  - **IP port**: 4001
  - **Bus address**: 49

## Usage

### General

This page displays the **Operation Mode Status/Remote Control Status**, the status of the **Power Supplies** and LNBs and the switch position of the LNBs.

Each LNB either has the **LNB Main** or the **LNB Standby** status.

You can change the operation mode here and switch positions using the toggle buttons. Changing the switch positions (LNBs) is only possible if the operation mode is set to **Manual** mode and the local/remote control status is **Remote** mode. If the operation mode is **Automatic** or the local/remote status is **Local** mode, you will not be able to change the switch positions.

It is also possible to set the **Band Status** to *High* or *Low*.

### Configuration Data

This page provides general information on the device, as well as configuration data, including the firmware version, the serial number and information related to the serial communication interface (SCI2).
