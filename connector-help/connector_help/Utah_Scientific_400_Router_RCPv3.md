---
uid: Connector_help_Utah_Scientific_400_Router_RCPv3
---

# Utah Scientific 400 Router RCPv3

The **Utah Scientific 400 Router RCPv3** is a connector that control and presents this large **Matrix** router up to 1024x1024 (Maximum for DMA).

## About

The **Utah Scientific 400 Router RCPv3** shows us a **Matrix** with different **levels**, these levels includes **High Definition** and **Standard Definition digital video switchers** and also **AES/EBU Digital Audio switchers**.

## Installation and configuration

This connector is **smart-serial**, which will say the device sending information about his changes without asking for them. Therefor you need to configure the connector as follow:

- **Type of port:** TCP/IP
- **IP Address/host:** the IP Address of the device
- **IP Port:** This is the **IP Port** of the device on which you want to communicate. **5001 par example.**
- **Bus Address:** This has **two parts** separated by the **separator** `-`. The first part is the **level** of the router that the element want to represent. The second part is the **Panel ID** of the router.
- **Local IP Port:** For each element on the same PC/Server you use a **different TCP/IP port** (for example 50000). This is because the device needs to know to which element it has to respond. If you do not set the IP port, the connector would be confused.

## Usage

### Main View

Here you find the **Router Matrix**, here you see all the cross points that this **elements level** represents. When a **change** happens on the device it also will change in here, also the **locks** are in use. This **Matrix** resize automatically to the **size** of the **device**. The **source** and **destination** names are also taken over from the **device**.

### Signal Presence

This page presents you the **Input Presence** and **Output Presence** tables. They show you when an **input** or an **output** is **used** or not.

### Alarms

The **Alarms** page shows you all the details of the **device alarms**. If there is something important wrong with the **device**, you'll see it there.

## Notes

This connector can presents **huge matrixes**. This is a lot of load for the **GUI**. As such, we recommend that you **avoid having a large number of elements using this connector** if possible.
