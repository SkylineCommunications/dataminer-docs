---
uid: Connector_help_NPAW_Youbora
---

# NPAW Youbora

NPAW Youbora receives and displays information from the Youbora framework, monitoring several KPIs in different dimensions.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 23.02.21               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - 0

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://ui-api.npaw.com
- **IP port**: *443*
- **Device address**: *BypassProxy*

#### HTTP Connection - 1

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://api.npaw.com
- **IP port**: *443*
- **Device address**: *BypassProxy*

### Initialization

When you have created a new element with this connector, go to the **General** page, specify the **Username** and **Password**, and then click the **Login** button.

### Redundancy

There is no redundancy defined.

## How to Use

On the **General** page, you can login with your Youbora credentials, as mentioned above.

The **Polling** page allows you to enable or disable the information polling for each table.

On the **Filters** page, you can select which filter to use on the information that is polled. The information can be filtered by **Country**, **State**, or **City.**

There is also a **Dimension** page for each available information dimension. The available dimensions are:

- **Title**
- **City**
- **State Province**
- **Country**
- **Region**
- **CDN Node Host**
- **Stream Type**
- **Program**
- **Streaming Protocol**
- **Channel**
- **Device**
- **Connection**
- **ISP**

Each of these pages contains three tables, **Plays**, **Errors**, and **Metrics**, with more information related to that specific dimension.
