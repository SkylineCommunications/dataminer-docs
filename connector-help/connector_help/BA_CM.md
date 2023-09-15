---
uid: Connector_help_BA_CM
---

# BA CM

The **BA CM** connector interacts with a **WFM** from where an entire system can be set up and created on **DataMiner**.

This connector is part of a multiple connectors and a **WFM**.

## About

Via the **WFM** the **BA CM** connector will receive command to build up an entire system on a **DataMiner**. This includes **view**, **services**, **elements**, **correlation** **rules**, **rca**..

The tree structure and configuration details are found and saved in a custom database. In here there are two types of tables: **Remedy** and **DataMiner**. The **Remedy** tables contain the structure, while the **DataMiner** tables will contain all of the changes that were done via the **WFM** e.g. creation of a new equipment will add a row in the **DataMiner-Equipment** table.

## Installation and configuration

## Creation

This is a **virtual** connector so no device info needs to be configured on creation of the **element**.

### Database Connection

All of the info needed by the **WFM** is stored in a custom database. The connection info needs to be entered in the **Server** **Info** **Page** via the **Database** **Login**. page button.

### DataMiner Login Info

As multiple specific **DataMiner** items need to be created on the system e.g. **RCA** and **Correlation** **Rules**. A **Login** needs to be defined that will use to add these items. This is done via the **Login Info.** page button.

## CM Config

In order to have the connector execute all of the **WFM** requests correctly some additional settings need to be done via the **CM Config.** page button.

## Usage

This connector is used by the WFM. Only a few actions can be done via the element itself.

## General Page

From here it is possible to check the database connection and set the configurations via the page buttons mentioned in Installation and configuration.

There is also an extra **Toolbox.** that includes some buttons to force execute some settings on the entire system which are normally done one by one via the **WFM**. As these button will perform actions on the entire system it is possible that it will slow or block it for the time needed to and the request. E.g. **Create RCA** will create all of the **RCA's** on the system. Be careful using these.

Other displayed items are used as information during an update of the system via the **WFM.** Via the **UpdateRMU**, **Create Template** and **UpdateCorrel** tables it is possible to check what the **BA CM** connector is currently executing after a 'load on system' command was send by the **WFM**.

## Notes

There are 3 fixed types of equipment than can be created:

- Moscad: protocol **Motorola Moscad**
- ACTTS: protocol **BA ACTTS**
- TBox: protocol **Semaphore TBox** range **2.x.x.x**

For these types the **BA CM** will forward the **WFM** Command to the **Elements** using the correct protocol.
