---
uid: Connector_help_Belgacom_RTES_Farm
---

# Belgacom RTES Farm

With this connector it is possible to monitor multiple **Verimatrix RTES Pairs**.

## About

The **Belgacom RTES Farm** monitors multiple redundant pairs of **Verimatrix RTES Pair** elements. It also monitors the connections with the selected **CISCO Manager** element.

## Installation and configuration

### Creation

The Belgacom RTES Farm is a **virtual** connector, so no user information is required during element creation.

### Configuration

To select all the **Verimatrix RTES Pairs** that are to be monitored:

1. Go to the **General** page.
1. Click the **Refresh RTES** button.
1. Select the desired **RTES Pair** in the drop-down list.
1. Click the **Add RTES** button.
1. Repeat steps 3 and 4 for all the **RTES Pairs** you want to add.

To configure the **CISCO Manager:**

1.  Go to the **Switch** page.
1.  Click the **Refresh Discreets** button.
1.  Select Primary and Backup Switches from the drop-down list.
1.  Select the primary and secondary ports from the Switches to access the main and backup router.

After configuring the Primary and Backup Switches on the **RTES Status** page, you can configure the switch ports for which each RTE Pair is to monitor the transmission and receiving bit rate.

## Usage

### General Page

On this page, you can configure which **RTES Pairs** are to be monitored by this farm (see "Configuration" section above).

### RTES Status Page

This page displays a table with the error values and communication states of each monitored RTES Pair. A **Farm Preference** parameter is shown, which depends on these parameters.

The page also allows the user to configure to which **Switch** port the RTES devices are connected, and provides information about the transmission and receiving bit rate.

### Switch Page

On this page, you can configure the **CISCO Manager** and choose which element represents the primary and backup switches (see "Configuration" section above). You can also select the primary and backup ports that connect the switch to the routers and have information about the transmission and receiving bit rate.
