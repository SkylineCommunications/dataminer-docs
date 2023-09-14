---
uid: Connector_help_Ericsson_IP_Transport_NMS_-_Device
---

# Ericsson IP Transport NMS - Device

The Ericsson IP Transport NMS/Ericsson ServiceOn Element Management System (SO-EM) is a standard software-based application, designed to support equipment focused on management of optical, microwave, broadband access and packet-based network elements.

## About

This connector is exported by the **Ericsson IP Transport NMS** parent connector. The connector polls information from the **Ericsson SO-EM** (EMS) through the **PF-SNMP** northbound interface via SNMP. Control over the device will depend on the access type of the SNMP parameters available in the Management Information Base (MIB). The connector handles parameters such as network element information, alarm event details, and all system reference catalogs.

For each Network Element (NE) that is managed by the NMS, a corresponding DVE can be exported, containing alarm event information for this NE.

DVEs are created by switching the value of the parameter **NE State** to *Enabled* in the **Device Table** of the parent element (**Ericsson IP Transport NMS**). The deletion of a DVE is executed in a similar fashion, by changing the NE State to *Disabled*. Generated DVEs will receive the name of the NE, without any parent element name suffix.

### Product Info

| **Range** | **Device Firmware Version**                       |
|------------------|---------------------------------------------------|
| 1.0.0.x          | Performance Management System (PFM) version 18.3. |
| 1.0.1.x          | Performance Management System (PFM) version 18.3. |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Ericsson IP Transport NMS](xref:Connector_help_Ericsson_IP_Transport_NMS).

## Usage (1.0.0.x onwards)

### Alarms

This page displays information about all the alarm events that are currently affecting the operation of this specific Network Element.

The **Alarm Table** contains all numeric and descriptive information about the system's alarms for a specific Network Element. The content in the Alarm Table of the parent element that relates to this Network Element will be the same as the data represented in the Alarm Table of this DVE, since each row in the Alarm Table of the parent element corresponds to the alarm events for a specific Network Element. The information in this table includes the **Alarm ID (Index)**, **Raising Time**, **Network Element ID (NE ID)** and **Severity**. The table also receives trap events that update each parameter when there is a change in a Network Element.

## Usage (1.0.1.x onwards)

### Alarms

This page displays information about all the alarm events that are currently affecting the operation of this specific Network Element.

- **Alarm Table**: This table contains all numeric and descriptive information about the system's alarms for a specific Network Element. The content in the Alarm Table of the parent element that relates to this Network Element will be the same as the data represented in the Alarm Table of this DVE, since each row in the Alarm Table of the parent element corresponds to the alarm events for a specific Network Element. The information in this table includes the **Alarm ID (Index)**, **Raising Time**, **Network Element ID (NE ID)** and **Severity**. This table also receives trap events that update each parameter when there is a change in a Network Element.
- **New Alarm Table:** This is an exact replication of the Alarm Table, with one difference, which is that the index used for the table is a combination of 8 different bindings of the trap. All 8 bindings were concatenated as **\[mv36AlarmStrNeUniqueName\]/\[mv36AlarmStrCard\].\[mv36AlarmPortId\]/\[mv36AlarmStrScheme\]/\[mv36AlarmStr\]/\[mv36AlarmStrProbCause\]/\[mv36AlarmStrSource\]/\[mv36AlarmField1\]** to form the index of the New Alarm Table.
- **Detailed Alarm Table**: This table is a smaller version of the Alarm Table, which contains descriptive information about the alarm events. All entries (i.e. alarm events) present in the Alarm Table will have a corresponding entry in the Detailed Alarm Table, so that it can be used as a quick overview of the state of the system. The same set of traps as mentioned above is also received for this table.
