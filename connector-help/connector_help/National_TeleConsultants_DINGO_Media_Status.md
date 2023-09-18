---
uid: Connector_help_National_TeleConsultants_DINGO_Media_Status
---

# National TeleConsultants DINGO Media Status

With the **NTC DINGO Media Status** connector, you can monitor information about **SeaChange Spot** **media** problems, including conflicts and similar issues. The connector also allows alarm monitoring and trending of those problems.

## About

The Media Status connector will periodically poll the database to retrieve the media status information. By default, this happens every 30 seconds.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not need any user input during element creation.

### Installation

For the installation of this connector, make sure the following DLLs are available on the system: *SLDatabase.dll*, *System.Data.dll* and *System.Xml.dll*.

## Usage

### General

On this page, the table with all the Media Status DB entries is displayed. Alarm monitoring is possible on many of the columns in the table.

There is a configuration setting available to activate or deactivate **Automatically remove the Not Available Entries**. You can also remove entries manually by selecting a key in the drop-down list **Remove Not Available Entry** or by clicking the **Remove All Not Available Entries** button.

### Configuration

On this page you need to fill in the configuration for the media Status probe. **Username**, **Password** and **Connection String** are needed in order to set up the database connection and retrieve the database data.

The value in the **Media Alert** column on the **General** page is based on the **Media Alert Filter table**. This table has a right-click context menu with the options: **Add Row**, **Delete Selected Row(s)** and **Clear Table**. You can also populate this table from a CSV file. To do so, you need to specify the CSV file path and the filename in the **Import Table CSV File Full Path** parameter, and then click the **Set CSV** button. All those filters will be taken into account and they will be used based on the **Order of Precedence \[IDX\]** (so if a filter matches with Order of Precedence 1, all the higher filters will be ignored and the state will be taken from this first filter).
