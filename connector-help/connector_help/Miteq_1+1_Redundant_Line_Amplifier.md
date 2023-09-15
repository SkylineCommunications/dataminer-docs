---
uid: Connector_help_Miteq_1+1_Redundant_Line_Amplifier
---

# Miteq 1:1 Redundant Line Amplifier

The **Miteq 1:1 Redundant Line Amplifier** connector is used to ensure a continuous operation without disruption of signal transmission.

## About

The protocol can be used to monitor the device and configure basic parameters.

## Installation and configuration

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, e.g. *4005.*
- **Bus address**: The bus address of the connected device, by default *64.*

## Usage

### System

This page displays the type of system under **System Configuration**, as well as the summary statuses of the **Amplifiers, Switches** and **Power Supplies**.

The page includes 3 page buttons:

- **Clock Settings**: Allows you to change the **Internal Clock/Calendar** of the device.
- **Redundancy**: Allows you to change the **Mode** to *Automatic* or *Manual*. The **Redundancy Interface** can either be *Local* or *Remote.*
- **Power Supply:** Shows a more detailed views of both power supplies.

### Amplifiers

This page shows a more detailed view of the amplifier. The number of amplifiers used (with **Amplifier Active Mode** either *Online* or in *Standby*) depends on the **System Configuration.** The parameters of the unused amplifiers have the value *Not Used* and are *disabled*.

Aside from the **Amplifier Status, Active Mode**, **Slope** and **Current** parameters, amplifiers 1 and 2 also have the possibility to change the **Limits** of the current. The **Attenuation** can also be checked and configured.

The **Amplifier Priority** is used to indicate the priority of a primary amplifier, should all backup amplifiers be unavailable or faulty. The amplifier with the lowest priority will be used as a backup amplifier.

### Attenuators

Depending on the **System Configuration** (*1:1, 1:2* or *Dual 1:1*) and on whether **Slope Equalization** is supported, the device can support up to 4 modules of attenuators.

The settings of the attenuators can't be retrieved from the device, which means that the configuration has to be done manually. To do so, first define the **Type of Attenuators**, then specify the **Attenuator \#**. If the value of the latter is filled in as *Module \#,* then **Attenuator Path Module \#** needs to be filled in as well.

For more information on the correct settings, refer to the manual of the device.

### Slope Equalization

The value of the **Slope Path Module \#** parameters depends on the **System Configuration**. Like for the **Attenuators,** these settings need to be done manually.

Protocol version 1.0.0.1 can support up to 4 slope modules, while version 1.3.9.1 only supports 2 (see note).

For more information on the correct settings, refer to the manual of the device.

### Logging

The device can only store up to 32 entries of logging, but the connector can store up to 400 entries. The current number of entries in the device is shown as the **Number of Expected Entries.** The user can **Refresh the Log** or **Clear the Log**.

All entries are shown in the **Event Log Table**, with the latest entries on top. Some logging entries are specific for each **System Configuration.**

**Warning:** It is absolutely necessary to configure the device manually or else there will not be any log entries. For the configuration, go to the **System** page and fill in the parameter **Slope Supported** under the **Configuration...** page button.

## Note

Protocol version 1.0.0.1 is based on the manual from October 2009.

Protocol version 1.3.9.1 is based on firmware version 3.0.9 and even though the manual doesn't indicate the support for attenuation or slope equalization, according to Miteq it should be possible and limited for slope.
