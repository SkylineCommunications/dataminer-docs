---
uid: Connector_help_Vodafone_Service_Definition
---

# Vodafone Service Definition

The basic connector for enhanced services specific for Vodafone.

## About

This connector is based on the "Skyline Service Definition Basic" connector, but adds some specific functionality for customer Vodafone.

The "Skyline Service Definition Basic" connector already contains a **Service Severity** parameter, but if alarming would be enabled on that parameter the service would always get "stuck" in an alarmed state. This is because the alarm state of all parameters in the service itself are also taken into account to calculate the summary state (loop). To solve that problem, this connector adds a new **Service Elements Summary Status** that only uses the severity states of the includes services and alarms to calculate the summary state. The parameters in this service itself are then ignored.

Enhanced services require a DataMiner version of **9.0.3.0** or higher.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | DataMiner 9.0.3.0           |

## Installation and configuration

### Creation

When editing a service, open the **Advanced** tab and select the desired **Definition**, in this case *Skyline Service Definition Basic*. Also select the desired **Version**.

### Configuration

To monitor the individual alarms in the **Active Service Alarms** table, set **Monitor Active Alarms** to *Enabled*.

## Usage

### General

The **Service Severity** displays the current alarm state of the service.

### Alarms

The **Active Service Alarms** table lists the alarms involved in this service. To enable this table, please set **Monitor Active Alarms** to *Enabled*.

### Elements

The **Service Element Status** table lists the child elements of the service and their alarm state. The **Service Elements Summary Status** parameter displays the summary alarm status of all elements + services that are included in this service.
