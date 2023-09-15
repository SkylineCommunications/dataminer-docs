---
uid: Connector_help_Cobham_Sea_Tel_6012_VSAT
---

# Cobham Sea Tel 6012 VSAT

This connector retrieves status information from an ACU.

## About

This is a smart-serial connector. It uses the telnet protocol to retrieve the necessary status information from the device.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:
**SERIAL CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.224.85.37.*
- **IP port:** The IP port of the device, e.g. *2003.*
- **Bus address:** The bus address of the device. Not required.

### Connection configuration

In order to be able to retrieve information from the device, first go to the **Connection** page of the element and enter the appropriate credentials. For more information, refer to the "Connection" section below.

## Usage

### Connection

On this page, you can enter your **User Name** and **Password**. To connect with the information you provided, click the **Connect** button. The **Logged on** parameter indicates when you are identified on the device and data will be retrieved.

Note that while the element is starting up, the connection first needs to be initialized. During this initialization process, the **User Name** and **Password** parameters display a message asking the user to wait. Once initialization is complete, a new message invites the user to introduce their credentials.

### General

On this page, you can find the important status parameters concerning the **Ship** (**HDG, Ship LAT, Ship LON**), the **Satellite** (**FREQ, SEARCH PATTERN, SKEW, THRS, ...**) and the **Antenna** (**AZ, CIRCULAR POL, EL, REL, ...**).

### ACU Status

On this page, the **Status Overview Table** shows trending information regarding the most important status parameters, with an interval of 5 minutes (**HDG Status, AZ Status, CL Status, ...**).

### ACU Settings

This page displays several configuration parameters such as the **Antenna AGC** or the **MODEM LOCK.**

### Blind Sector Settings

On this page, you can configure blind sectors. When you click the **Add New Row** page button, you can then specify the **Blind Sector Azimuth Start, Blind Sector Azimuth Stop, Blind Sector Elevation Start** and **Blind Sector Elevation Stop** positions.

The configuration is added in the **Blind Sector Overview** table. The **Blind Sector Status** column shows when the system is in one of the blind sectors you have created. You can remove a line or clear the entire table if necessary.

Every time an outage occurs, an entry is added in the **Blind Sector History Table**, which can be displayed by clicking the **History** page button. In this table, you can specify the **Outage Period**, which determines the oldest record to save in the table. The table indicates the **Start Time, End Time** and **Timespan** of each outage.

### Alarms

This page contains alarm information corresponding to the **Initializing, Searching, Targeting, ...**
