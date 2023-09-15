---
uid: Connector_help_Al_Jazeera_Media_Network_Rack_Passive_Device_Generator
---

# Al Jazeera Media Network Rack Passive Device Generator

This connector contains one table where you can add lines corresponding to particular equipment. This table will contain all passive equipment of Al Jazeera that is not being monitored in DataMiner. This equipment will then be visualized by visual overviews on the rack views.

## About

This is virtual connector because there is no communication with a device. Instead of communicating with a device, this connector will merely show all the equipment that is not being monitored in DataMiner.

This connector is discontinued. Replaced by Skyline Generic Rack Passive Device Generator connector.

### Version Info

| **Range** | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version \[Obsolete\] | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Rack Passive Device Generator

This is the only page of this connector. It contains the **Equipment** table, which allows you to add or delete rows via a button. Each row corresponds to a piece of passive equipment that is not being monitored by DataMiner.

This table has basic information, such as the **Unit Name**, **Unit Rack Position**, **Unit Height**, **Rack View Name** and **Front/Rear Position**.
