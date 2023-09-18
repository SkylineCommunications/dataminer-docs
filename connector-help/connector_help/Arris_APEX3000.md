---
uid: Connector_help_Arris_APEX3000
---

# Arris APEX3000

The **Arris APEX3000** is an ultra-dense, fully redundant, state-of-the-art chassis-based edge QAM platform. Its ability to save power and provide excellent RF performance for QAM delivery is ideal for linear broadcast applications as well as narrowcast applications such as VOD, Cloud DVR, SDV and M-CMTS.

## About

The **Arris** **APEX3000** provides up to 32 RF ports in a 4 RU chassis and supports up to 48 Annex B 6-MHz QAM channels per RF port for a maximum of 1536 QAM channels (384 QAM channels per RU). At maximum density, the power draw is sub 1 Watt/QAM. In Annex A mode (8 MHz channels) the APEX3000 supports up to 36 8-MHz QAM channels per RF port, for a maximum of 1152 QAM channels.

This connector requires a **large amount** **of polling** and will therefore use a **large amount of bandwidth**.

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                                                                                                                  | No                  | No                      |
| 2.0.0.x          | Full protocol review based on version 1.0.0.7: - PIDs, names and descriptions of parameters are modified to align the connector with the guidelines. - Redundant connection name changed. - Layout revised and modified. - Naming is used instead of displayColumn. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and configuration

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address:** The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port Number:** The port of the connected device, by default *161.*
- **Get community string:** *public*
- **Set community string:** *apex3kprivate*

#### SNMP redundant connection

This connector supports **redundant polling**, for which the connection also needs to be configured during element creation.
However, if there is no redundant device, you can simply fill in the connection information of the main connection for the redundant connection.

SNMP CONNECTION:

- **IP address/host**: The polling IP of the connected redundant device.

SNMP Settings:

- **Port number**: The port of the connected redundant device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage (range 1.0.0.x)

### Alarms

This page displays information related to the **Hardware**, **Output**, **Input** and **Other Alarms**.

### Temperature

This page displays the **Host Module Temperatures**, **GigE Module Temperatures**, **Temperature Settings and Status**, **RF Switch Temperatures** and **Other Temperatures.**

### HW/SW Event

This page displays all **Hardware and Software Events.**

### Invalid Cfg

This page displays all **Invalid Configuration** information.

### Map Events

This page displays all **Map Events.**

### RTSP Events

This page displays all **RTSP Events.**

### Input Events

This page displays all **Input Events.**

### System

This page displays parameters related to **Time Configuration**, **Output Configuration**, **UDP Port Mapping**, **Advanced Options** and **Trap Configuration**. In this last section, you can also find the **Trap Receivers Table.**

### Host/Enet

This page displays the **Host Ethernet Settings**, with the following page buttons:

- **Static Routes**: Displays the **Fast Enet Routing Table.**
- **Generic QAM Devices**: Displays the **Generic QAM Device Configuration Table.**
- **Boot Info**: Displays all the boot information for the device.
- **DNS Configuration**: Displays the **DNS Client Config Server IP Table** and other **DNS Configuration settings.**

The page also displays the **Host Module Status Treeview**, which shows all **Host Modules** with their statuses.

At the bottom of the page, parameters related to the **Host Module Redundancy** are displayed. This section also contains the **Redundancy Events** page button, which displays the **Host Module Redundancy Event Table.**

### Gig E

This page displays parameters related to the **GigE Interface Configuration**, **Global Settings** and **GigE Module Status.**

In the GigE Module Status section, the page button **Frame Statistics** displays the **Gbe Status Frame Counter Table.**

### RDS/CTE

This page contains parameters related to **RDS Configuration**, **RDS Status** and **CTE Configuration**.

In the CTE Configuration section, the **Service List** page button displays the **Rds Source Lookup Table.**

### SDV

This page displays parameters related to the **Session Control Configuration**, **RPC Configuration**, **RTSP/MHA Edge Group Configuration**, and **RTSP/MHA Configuration**.

The RTSP/MHA Edge Group Configuration section contains the following page buttons:

- **GigE BW Reported Status**: Displays the RTSP Status Bw Reported Table.
- **Virtual IP BW Reported**: Displays the RTSP Status Virtual IP Bw Table.
- **Blade Allocated BW**: Displays the RTSP Status Blade Bw Table.

Finally, the RTSP/MHA Configuration section contains the following page buttons:

- **RTSP Rates**: Displays all statuses of the RTSP rates.
- **RTSP Debug**: Contains all settings for the RTSP debug modes.

### Blade Redundancy

This page displays the **Blade Redundancy Configuration** and **Blade Redundancy Status.**

### DEPI

This page displays parameters related to the **Control Pane**, **QAM Parameter Modification**, **DEPI Statistics**, **Connection Control** and **Connection Status.**

### HW Modules

This page displays parameters related to the **Front Panel Status** and **DTI Module Status**.

It also contains two tables, the **RF Switch Module Table** and **Power Supply Status Table**.

### Blades

This page contains a **tree view** of all the **blades** in the device, displaying the different **RF Modules** and properties of the blades and the properties of each **RF Module**.

### Output Stats

This page displays the **Routing Status Blade Table**.

### Simulcrypt General

This page displays all settings for the **SimulCrypt Configuration** and **SimulCrypt Alarms**.

### ECMG Config

This page displays a tree view of all **ECMGs** in the device.

It also contains the page buttons **Host Configuration** and **SuperCAS**.

### EIS

On this page, you can enable/disable the **Internal EIS** functionality. It also allows you to configure the **EIS TCP Port** and **Internal EIS Provisioning Mode**.

The **EIS Statistics** page button displays more information on EIS statistics.

### EMMG Config

This page displays the **EMMG Connection Configuration** and **EMM PID Configuration**.

It also contains two page buttons, **CAT Private Data** and **CAT Permanence**.

### EMMG Status

This page displays a tree view of all **EMMGs** in the device.

### Output TS

This page displays one table with the **Output TS Utilization**.

### Traps

This page contains the **Trap Table**, which displays all traps with their latest **avoiding time**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface

## Notes (range 1.0.0.x)

### Enable/Disable Polling button

Most of the above-mentioned pages contain the **Enable/Disable Polling - \[Page Name\]** toggle button and **Refresh** button. **Enable** the toggle button and then **Refresh** the page to poll the parameters on that page. **Disable** the toggle button to stop polling parameters on that specific page.

### Correct order of settings

Whenever you change a setting in the element, for instance if you change text or IP addresses, traps are sent. However, if the order in which the settings are configured is wrong, it could be that certain settings are not set. For example, if you first change the IP address and then the subnet mask, only the subnet mask will be set, because the **subnet mask must be set before the IP address** is changed. Therefore, if you notice that a particular setting is not working, first check if the **order of the changes** you configured is **correct**.

## Usage (range 2.0.0.x)

### General

This page contains general device information.

### Hardware/Other Alarms

This page displays information related to the **Hardware** and **Other Alarms.**

### Input/Output Alarms

This page displays **Output** and **Input** alarm information.

### Temperature

This page displays the **Host Module**, **GigE Module**, **RF Switch** and **Other Temperatures** and additional **Temperature Settings and Status** information.

### HW/SW Event

This page displays the **Hardware-**related log information.

### Invalid Configuration

This page displays all **Invalid Configuration** information.

### Map Events

This page displays **Mapping Error** information.

### RTSP Events

This page displays **RTSP Events** log information.

### Input Events

This page displays **Gigabit Ethernet Input Transport Stream Events** information.

### SimulCrypt Events

This page displays **Simulcrypt Events** information.

### DOCSIS

This page displays **Depi Events** information.

### System

This page displays parameters related to **Time** and **Output Configuration**, **UDP Port Mapping** and **Advanced Options**.

### Host/Enet

This page displays the **Host Ethernet Settings**, with the following page buttons:

- **Static Routes**: Displays the **Fast Enet Routing** information.
- **Generic QAM Devices**: Displays the **Generic QAM Device Configuration** information.
- **Boot Info**: Displays all the boot information for the device.
- **DNS Configuration**: Displays the **DNS Server IPs** and other **DNS Configuration settings.**
- **Host Redundancy Events:** Contains **Host Module Redundancy Events** information.

The page also displays the **Host Module Status Treeview**, which shows all **Host Modules** with their status.

Additional parameters related to the **Host Module Redundancy** are also displayed in the second column of the page**.**

### Gig E

This page displays parameters related to the **GigE Interface Configuration**, **Global Settings** and **GigE Module Status.**

The **Frame Statistics** page button displays the **Gigabit Ethernet** **Frame Counter statistics** information.

### RDS/CTE

This page contains parameters related to **RDS** and **CTE Configuration**, and **RDS Status**.

The **Service List** page button contains a table that provides a list of source IDs and provider IDs with additional descriptions**.**

### SDV

This page displays parameters related to the **Session Control**, **RPC**, **Edge Group**, and **RTSP/MHA Configurations**.

This page also contains the following page buttons:

- **GigE BW Reported Status**: Contains a table with the reported bandwidth status for the Gbe interface.
- **Virtual IP BW Reported**: Contains a table with bandwidth values for reported virtual IPs.
- **Blade Allocated BW**: Contains a table with the bandwidth currently being sent to each blade.
- **RTSP Rates**: Displays all statuses of the RTSP rates.
- **RTSP Debug**: Contains all settings for the RTSP debug modes.

### Blade Redundancy

This page displays the **Blade Redundancy Configuration**, **Status** and **Alarms.**

### DEPI

This page displays parameters related to the **Control Plane**, **QAM Parameter Modification**, **DEPI Statistics**, **Connection Control** and **Connection Status.**

### HW Modules

This page displays information related to the **Front Panel**, **DTI**, **RF Switch**, **Power Supply** and **Host Modules**.

### Blades

This page contains a **tree view** of all **blades** in the device, displaying the different **RF Modules** and properties of the blades and the properties of each **RF Module**.

### Output Status

This page displays the **Routing Status Blade Table**.

### SimulCrypt General

This page displays all settings for the **SimulCrypt Configuration** and **Alarms**.

### ECMG Config

This page displays a tree view of all **ECMGs** in the device.

It also contains the following page buttons:

- **Host Configuration:** Contains a table of configuration parameters for the **ECMG Host** (IP and port).
- **Super CAS** **Configuration:** Contains a table of configuration parameters for the Super CAS entity.

### EIS

On this page, you can enable/disable the **Internal EIS** functionality, as well as configure the **EIS TCP Port** and **Internal EIS Provisioning Mode**.

More information on EIS statistics is also displayed in the second column of the page.

### EMMG Configuration

This page displays the **EMMG Connection** and **EMM PID Configuration** information.

The **CAT** page button contains **CAT Private Data** and **Permanence** information and settings.

### EMMG Status

This page displays a tree view with all **EMMG channel and stream** information.

### Output TS

This page displays one table with the **Output TS Utilization**.

### Traps

This page contains the **Trap and Trap Receiver** information.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface

## Notes (range 2.0.0.x)

### Polling Status toggle buttons

Most of the above-mentioned pages contain a **\[Page Name\]** **Polling Status** toggle button. **Enabling** the toggle button will allow the information on that specific page to be polled. **Disable** the toggle button to stop polling parameters on that specific page.

### Correct order of settings

Whenever you change a setting in the element, for instance if you change text or IP addresses, traps are sent. However, if the order in which the settings are configured is wrong, it could be that certain settings are not set. For example, if you first change the IP address and then the subnet mask, only the subnet mask will be set, because the **subnet mask must be set before the IP address** is changed. Therefore, if you notice that a particular setting is not working, first check if the **order of the changes** you configured is **correct**.
