---
uid: Connector_help_A10_Networks_AX_Series
---

# A10 Networks AX Series

The **A10 Networks AX Series** connector can be used for displaying and configuring information of the A10 Networks AX Series platform.

## About

This connector can be used to monitor and control the **A10 Networks AX Series** platform. The device supports two different types of connections:

- An **SNMP** connection, used to retrieve the information of the device.
- An **HTTP** connection, used to retrieve and configure the device.

The connector also features **alarm monitoring** and **trending**.

## Installation and configuration

### Creation

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *220.120.114.99.*

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL Connection:**

- **IP address/host**: The polling IP or URL of the destination e.g. *220.120.114.99.*
- **IP port**: The port of the destination e.g. *443*.
- **Bus address**: A field that can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

### Configuration

The HTTP connection requires authentication. To authenticate yourself:

1. Go to the **General Page.**
1. Click the page button **Login...**
1. Fill in the **Username** and **Password**
1. Click the button **Login.**

## Usage

### General Page

This page displays some general info about the device. E.g.:

- Serial Number
- Firmware Version
- System Temperature
- Disk Usage
- Etc.

The page also contains several page buttons. The page buttons **Disk Status...**, **Memory Status...**, **Fans' Status...**, **More CPU Status** and **Resource Usage...** are used to display the status of the disk, memory, fans, CPU and resources, respectively. The page button **Login.** allows the user to fill in the **Username** and **Password** for the HTTP connection.

### Interface Page

This page displays a table containing information regarding the device **interfaces**. E.g.:

- Interface Name
- Interface Status
- Miscellaneous Statistics

The page also contains a page button, **Vlan.**, that can be used to find information regarding the configured Vlans on the device.

### Real Server Page

This page allows you to check and configure the **Real Servers** on the device. It contains a table with information about the servers and a tree control with servers and port information.

This page also contains two page buttons:

- **Create Server.**
- **Delete Server.**

The **Create Server** page button allows you to create a new server. To do so:

1. Fill in the **mandatory attributes** and at least **one port**. The values that are already filled in when you click the page button are the default values for that parameter.
1. Click the **Create Server** button to create the server. The result of this query will be shown on the **Create Server Result** parameter.

With the **Delete Server** page button, it is possible to delete **Servers** and **Ports.** To delete:

- A server: select the **Server Name** from the available list, and click the button **Delete Server**.
- All servers: just click the **Delete All Servers** button.
- A port from a server: select the **Server Name** and the **Server** **Port** from the available list (the server port list is available only after you select the **Server Name**), then click the **Delete Port** button to delete the port.
- All ports from a server: select the **Server Name** from the available list, and click the button **Delete All Ports**.

### Virtual Server Page

This page allows you to check and configure the **Virtual Servers** on the device. It contains a table with information about the virtual servers and a tree control with servers and services information.

This page also contains two page buttons:

- **Create Virtual Server.**
- **Delete Virtual Server.**

The **Create Virtual Server** page button allows you to create a new virtual server. To do so:

1. Fill in the **mandatory attributes** and at least **one service**.
1. Click the **Configure Services.** page button to configure the services further. This page has a tree control with the virtual server's services.
1. When these values are filled in, click the **Create Virtual Server** button to create the virtual server. The result of this query will be shown on the **Create Virtual Server Result** parameter.

The **Delete Virtual Server** page button allows you to delete **Virtual Servers** and **Members.** To delete:

- A virtual server: select the **Virtual Server Name** and click the button **Delete Virtual Server**.
- All virtual servers: just click the **Delete All V. Servers** button.
- A service from a virtual server: select the **Virtual Server Name** and the **Service Port** from the available list (the list is available only after you select the **Virtual** **Server Name**), then click the **Delete Service** button to delete the service.
- All services from a virtual server: select the **Virtual Server Name** and click the button **Delete All Services**.

### Service Group Page

This page allows you to check and configure the **Service Group** on the device. It contains a table with information about the groups and a tree control with groups and member information.

This page also contains two page buttons:

- **Create Group.**
- **Delete Group.**

The **Create Group** page button allows you to create a new server. To do so:

1. Fill in the **mandatory attributes** and at least **one member**.
1. Click the **Create Group** button to create the server. The result of this query will be shown on the **Create Group Result** parameter.

The **Delete Group** page button allows you to delete **Groups** and **Members.** To delete:

- A group: select the **Group Name** and click the button **Delete Group**.
- All groups: just click the **Delete All Groups** button.
- A member from a group: select the **Group Name** and the **Member IP Address** from the available list (the list is available only after you select the **Group Name**), then click the **Delete Member** button to delete the member.
- All members from a group: fill in the **Group Name** and then click the button **Delete All Members**.
