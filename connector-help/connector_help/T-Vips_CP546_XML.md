---
uid: Connector_help_T-Vips_CP546_XML
---

# T-Vips CP546 XML

The T-Vips CP546 is a transport stream monitor than can simultaneously monitor up to 8 DVB-ASI/SMTPE-310 transport streams and up to 16 IP/Ethernet transport streams.

This connector can be used to monitor and control the T-VIPS CP546 XML device. A **serial** (TCP/IP) and **SNMP** connection are used in order to successfully retrieve and configure the information of the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

## Configuration

### Connections

**SERIAL Connection:**

- **Type of Port:** TCP/IP.
- **IP Address/host:** The polling IP of the device.
- **IP Port:** The port used for the TCP/IP connection, for instance *80.*

**TCP/IP Settings:**

- **Network:** Auto.

**SNMP Connection:**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connection device, by default *161.*
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General Page

This page contains general information about the device. It also has an extra **Login** page where you can configure the correct **Username** and **Password** in order to communicate with the device.

### Inputs Page

This page contains the following tables: **Inputs Overview** and **Services** (ASI, IP and PLP Inputs). You can add IP ports in the Inputs Overview table by means of the **Add IP Port** button.

The **Nominal Inputs** are also displayed on this page.

### PIDs Page

This page contains two tables: **PIDs** and **PCR Overview**. In addition, the **Nominal PIDs** are displayed on this page.

### Tables Page

This page contains the following tables: **PSI Table** and **SI Table**. Like on the other pages, the **Nominal** values are also available.

### Outputs Page

This page contains the information of **Outputs 1 and 2**, and also displays the **Nominal Outputs**.

### Alarms Page

This page contains the **TS Alarms** and **Current Alarms** tables. The former shows all possible alarms, with the alarms that are **currently active** highlighted. The latter only shows the **current alarms**.

On the **Filters** page, you can add custom filters using the **Add Filter Name** button. The filter will be added into the Filters table together with the number of occurrences from the current alarms index column. Filters can also contain a wildcard '\*' and can be easily edited in the table. Delete filters by clicking on the **Delete** button in the Filters table.

### Overview Page

This page contains a **tree view** of the detected inputs.

### Configurations Page

On this page, **configuration files** can be uploaded and downloaded, and the polling of **ASI and PLP** parameters can be turned off.
