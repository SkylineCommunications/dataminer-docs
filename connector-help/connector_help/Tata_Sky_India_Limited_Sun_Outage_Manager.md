---
uid: Connector_help_Tata_Sky_India_Limited_Sun_Outage_Manager
---

# Tata Sky India Limited Sun Outage Manager

The Tata Sky India Limited Sun Outage Manager connector **imports a list of services from the Tata Sky MCR DB Provisioning element**.

The connector allows you to schedule a **switchover** for the inputs of one or more satellite position/polarization main or backup groups of IRDs. You can also perform a scheduled switchover for particular IRDs, and they can be combined.

The **input type** can be determined per group or per IRD, and it can be **ASI**, **IP**, or **RF**.

In order to function properly, the IRDs need to have one of the **supported connectors** using the supported range. At present, the following connectors and ranges are supported:

- Ateme Kyrion DR5000 3.0.4.x
- CISCO D9800 1.2.0.x
- Cisco D9854 1.0.0.x
- Ericsson RX8200 2.0.1.x
- Ericsson RX8330 2.0.4.x
- Harmonic Proview PVR 8130 1.0.1.x
- Motorola DSR-4460 1.0.0.x
- Scopus Network Technologies IRD-2900 1.1.2.x
- Tandberg RX1290 3.0.0.x

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No initialization is necessary for the element to function. However, there must be **exactly one** Tata Sky **MCR DB Provisioning** element running using the **production version**.

### Redundancy

There is no redundancy defined.

## How to use

### Tree View

The connector will create a tree view on the **General** page with a separate branch for every satellite/polarization combination. Below it, an icon will be shown for each of the different services on that branch.

If you click on a satellite position, extra information is displayed, as well as a **Service table**. This information is refreshed every hour.

### Adding a Schedule

On the **Add Schedule** page, you can add a schedule for a switchover.

To create a schedule:

1. Select the satellite position(s) you want to change from the Sat Positions page.

   For instance, if you select **Switch All Main to ASI**, all main IRDs for this satellite position will be switched to Main.

1. In the **Services** table below, make additional selections per IRD as necessary. You can combine the two groups of selections.

   For instance, if you want to make all backup IRDs for GSAT 30 (83.0øE)/H switch to IP, but within that group you have a couple of IRDs you want to switch to ASI, you can first select Switch All Backups to IP in the Satpositions table. All IRDs for this satellite position will then have the Backup IRD option set to IP. Next, you can select the IRDs in the Services table that you want to switch to ASI instead.

1. Finally, either select a **Switch Time**, or change the **Schedule Type** to **Immediate,** and click the **Create Schedule** button**.**

At the bottom of the page is also a **Discovery** button. This will make the connector poll the **MCR DB Provisioning** element again.

### Monitoring Switchovers

The connector will check every second if a switchover has to be performed. If yes, it will start the switchover and indicate the progress and results in the **Schedule** Table.

Once it has done all necessary sets to complete the switchover, it will wait for a certain amount of time. By default, this is **10 seconds**, but you can customize this on the General page. After this, it will read all values of the group that was just switched over. Any warnings or errors will be reported in the **Errors** table. In case IP is not available on a particular device, ASI will be chosen instead, and this will also be logged in the Errors table.

At the scheduled time, the switch will take place. You can see the result of this on the **Schedules** page:

- The **Schedule** Table contains a unique number per scheduled switch task, the time the switch should take place, and the general status of the task.
- The **Verification Time** is the time when the inputs of the selected IRDs should be polled again. By default this is **10 seconds** after the last IRD has been set. This is set with the **Verification Wait Time** parameter at the bottom of the page.
- The **Schedule Details** table contains a row per IRD, with the **Requested Input**, the **Resulting Requested Input**, the **Connector Details**, and the **Status** of the switch for that IRD.
  In case *IP* was selected as an **Input Type**, and this is not available on a particular IRD, the **Resulting Requested Input** is *ASI* instead.
- Any errors or warnings will be added to the **Errors** table, detailing the **IRD,** **date and time**, and the details of the error that was encountered**.**

### Managing Schedules

At the bottom of the **Schedules** page, you can configure to **automatically remove old schedules** and set a **maximum age for the schedules**. There is also a button to **clear all the schedules**.

You can still **change the switch time** of scheduled switches in the Schedule table after they have been planned. When you do so, the status changes to *Not Started* again, and if the event was scheduled in the past, it will restart immediately.

The right-click menu of the Schedule Table also allows you to **run a scheduled task immediately**, **add schedules**, **delete one or more schedules**, or even **clear all schedules** in the table.

When you delete a schedule, associated entries in the Schedule Details and Errors Table will also be deleted. You can also right-click the Errors Table to delete specific errors or clear the entire table.

## Notes

This connector is meant to be used with a Visio drawing to simplify the usage for an operator.
