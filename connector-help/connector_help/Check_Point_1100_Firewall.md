---
uid: Connector_help_Check_Point_1100_Firewall
---

# Check Point 1100 Firewall

With this connector, information can be gathered and viewed from the **Check Point 1100 Firewall**.

## About

This connector is used to interface with the **Check Point 1100 Firewall**.

Range 1.0.0.x of the connector uses SNMPv1 to communicate with the device. From range 1.0.1.x onwards, the connector uses SNMPv3 and has full support for SNMPv3 contexts.

### Version Info

| **Range** | **Description**             | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version             | No                  | Yes                     |
| 1.0.1.x          | Support for SNMPv3 contexts | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 9                           |
| 1.0.1.x          | 9                           |

### Exported connectors

| **Exported Connector**                      | **Description**                                |
|--------------------------------------------|------------------------------------------------|
| Check Point 1100 Firewall - Virtual Switch | Virtual Switch Only supported in range 1.0.1.x |
| Check Point 1100 Firewall - Virtual Router | Virtual Router Only supported in range 1.0.1.x |
| Check Point 1100 Firewall - Virtual System | Virtual System Only supported in range 1.0.1.x |
| Check Point 1100 Firewall - VSX Gateway    | Main Module Only supported in range 1.0.1.x    |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv1 Settings (1.0.0.x):

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

SNMPv3 Settings (1.0.1.x):

- **Port number**: The port of the connected device, by default *161*.
- **Security level and protocol**: The type of security used.
- **User name**: The user name.
- **Authentication Password**: The user password.
- **Authentication** **algorithm**: The used authentication algorithm.

## Usage (1.0.0.x)

### General Page

This page displays general parameters of the **Check Point 1100 Firewall** device, such as **Module State** and **Filter Name**.

### Policy Page

This page contains policy settings of the device, such as **Policy Name** and **Install Time**.

### Network Interfaces Page

This page contains a table with the interfaces of the device.

### Connections Statistics

This page contains the device connection statistics, such as the **TCP Connections** and the **Total Number of Connections**.

### Log Server Connection Page

This page displays information regarding the log servers. It shows the status and the available log servers.

### Hash Kernel Memory Page

This page displays hash kernel memory statistics of the device, such as **Hmem-Block-Size** and **Hmem-Requested-Bytes**.

### Firewall Memory Page

This page displays firewall memory statistics of the device, such as **Kmem-System-Physical-Mem** and **Kmem-Available-Physical-Mem**.

### Inspection Page

This page displays inspection statistics of the device, such as **Inspected Packets** and **Inspected Operations**.

### Cookies Page

This page displays cookies statistics of the device, such as **Cookies Total** and **Cookies Allocated**.

### Chains Page

This page displays chains statistics of the device, such as **Allocated Chains** and **Free Chains**.

### Fragments Page

This page displays fragments statistics of the device, such as **Fragments** and **Expired Fragments**.

### SS HTTP Page

This page displays HTTP metrics of the device, such as **HTTP Blocked Count** and **HTTP Passed total**.

### SS FTP Page

This page displays FTP metrics of the device, such as **FTP Blocked Total** and **FTP Scanned Total**.

### SS SMTP Page

This page displays SMTP metrics of the device, such as **SMTP Blocked by File Type** and **SMTP Passed by AV Settings**.

### SS POP3 Page

This page displays POP3 metrics of the device, such as **POP Blocked by Size Limit** and **SMTP Passed by Internal Error**.

### SS Anti Virus Page

This page displays antivirus metrics of the device, such as **Total Blocked for all Services** and **Total Passed**.

## Usage (1.0.1.x)

### Virtual Systems Page

From range 1.0.1.x onwards, virtual devices are supported. The main protocol will only display a table with the current virtual systems and it will allow the creation of Dynamic Virtual Elements. All detailed data will be available via the DVEs.
