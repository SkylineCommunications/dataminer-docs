---
uid: Connector_help_Ziggo_CPE_WiFi_Collector
---

# Ziggo CPE WiFi Collector

The Ziggo CPE WiFi Collector is part of the Ziggo CPE setup, and works together with the IAMDB database. This connector is responsible for polling the CMs and offloading the results to a .CSV file.

## About

This connector will poll all the CMs in one fast poll cycle that will poll all CMs over a 15-minute period. The polled data will be offloaded into CSV files.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 127.0.0.1 (IP addresses will be dynamically filled in).
- **Device address**: Not needed.

SNMP Settings:

- **Port Number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: Not needed, because the connector will not perform sets.

Note: All polled CMs will share the same settings, and all polled CMTSs will share the same settings.

## Usage

### CM

This page contains the **CM Table** and some information parameters about the provisioned modems. This table shows all modems assigned to the collector. With the **Get Modems** button you can retrieve the latest changes from the IAMDB database. The **Reinitialize Modems** button is used to reinitialize the CM Table when something went wrong with the latest changes.

### Provisioning

This page shows all provisioning information. The **Last Provisioning Date**, **Last Provisioning Request** and **Last Provisioning Response** show information about the last provisioning. The **Net Provisioning Result** is the result of **Modems Provisioned** - (Previous number of provisioned modems + **New Modems** -**Deleted Modems**). For the **Provisioning Type** you can choose for **Full** or **Incremental** provisioning. If you enable **Automatic Provision**, the connector will provision on the specified **Provision Time** (24H:mm). You can always force the connector to start provisioning with the **Provision** button.

### Thread Pool Info

This page displays the thread information.

### Config

On this page, you can configure the parameters **Server**, **Database**, **Username** and **Password** to connect to the IAMDB database.

With the **Data Offload Folder**, you can configure where you want to offload the .csv files.

**Log Mac** is used to show the logging from a certain MAC address assigned to the collector. **Force Execute MAC** can be used to immediately execute the device with the MAC address configured in the Log MAC parameter.
