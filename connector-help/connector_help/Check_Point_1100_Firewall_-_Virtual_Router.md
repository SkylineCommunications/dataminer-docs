---
uid: Connector_help_Check_Point_1100_Firewall_-_Virtual_Router
---

# Check Point 1100 Firewall - Virtual Router

With this connector, information can be gathered and viewed from the **Check Point 1100 Firewall Virtual Router**.

## About

This connector is used to interface with the **Check Point 1100 Firewall Virtual Router**. It uses SNMPv3 to communicate with the device.

### Version Info

| **Range** | **Description**             | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------|---------------------|-------------------------|
| 1.0.1.x          | Support for SNMPv3 contexts | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 9                           |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Check Point 1100 Firewall](xref:Connector_help_Check_Point_1100_Firewall).

## Usage

### General Page

This page displays general parameters of the Check Point 1100 Firewall device, such as **Module State** and **Filter Name**.

### Policy Page

This page contains policy settings of the device, such as **Policy Name** and **Install Time**.

### Network Interfaces Page

This page contains a table with the interfaces of the device.

### Connections Statistics

This page contains the device connections statistics, for example **TCP Connections** and **Total Number of Connections**.

### Log Server Connection Page

This page displays information regarding log servers. It will show the status and the available log servers.

### Hash Kernel Memory Page

This page displays the hash kernel memory statistics of the Check Point 1100 Firewall device, such as **Hmem-Block-Size** and **Hmem-Requested-Bytes**.

### Firewall Memory Page

This page displays the firewall memory statistics of the Check Point 1100 Firewall device, such as **Kmem-System-Physical-Mem** and **Kmem-Available-Physical-Mem**.

### Inspection Page

This page displays the inspection statistics of the Check Point 1100 Firewall device, such as **Inspected Packets** and **Inspected Operations**.

### Cookies Page

This page displays the cookie statistics of the Check Point 1100 Firewall device, such as **Cookies Total** and **Cookies Allocated**.

### Chains Page

This page displays the chain statistics of the Check Point 1100 Firewall device, such as **Allocated Chains** and **Free Chains**.

### Fragments Page

This page displays the fragments statistics of the Check Point 1100 Firewall device, such as **Fragments** and **Expired Fragments**.

### SS HTTP Page

This page displays the HTTP metrics of the Check Point 1100 Firewall device, such as **HTTP Blocked Count** and **HTTP Passed total**.

### SS FTP Page

This page displays the FTP metrics of the Check Point 1100 Firewall device, such as **FTP Blocked Total** and **FTP Scanned Total**.

### SS SMTP Page

This page displays the SMTP metrics of the Check Point 1100 Firewall device, such as **SMTP Blocked by File Type** and **SMTP Passed by AV Settings**.

### SS POP3 Page

This page displays the POP3 metrics of the Check Point 1100 Firewall device, such as **POP Blocked by Size Limit** and **SMTP Passed by Internal Error**.

### SS Anti Virus Page

This page displays the antivirus metrics of the Check Point 1100 Firewall device, such as **Total Blocked for all Services** and **Total Passed**.
