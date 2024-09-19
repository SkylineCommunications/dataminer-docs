---
uid: Custom_DataMiner_notification
---

# Custom DataMiner notification

## Custom notification OID

Syntax:

```txt
1.3.6.1.4.1.8813.1.1.2.3.[Custom suffix]
```

- **1.3.6.1.4.1.**

    Private enterprise

- **8813.**

    Skyline Communications

- **1.1.2.3.**

    (fixed)

- **\[Custom suffix\]**

    To be entered under *Use custom bindings with OID* in Cube.

    > [!TIP]
    > See also:
    > [Configuring an SNMP manager in DataMiner Cube](xref:Configuring_an_SNMP_manager_in_DataMiner_Cube)

## Custom bindings

| Binding | OID | Comments |
|--|--|--|
| Alarm ID | 1.3.6.1.4.1.8813.1.1.2.4.1.1 | |
| DataMiner ID | 1.3.6.1.4.1.8813.1.1.2.4.1.2 | |
| Element ID | 1.3.6.1.4.1.8813.1.1.2.4.1.3 | |
| Parameter ID | 1.3.6.1.4.1.8813.1.1.2.4.1.4 | |
| Type ID | 1.3.6.1.4.1.8813.1.1.2.4.1.5 | Possible values:<br> - Escalated (8)<br> - Dropped (9)<br> - New alarm (10)<br> - Cleared (11)<br> - Acknowledged (19)<br> - Resolved (20)<br> - Unresolved (21)<br> - Comment Added (22)<br> - Unmasked (27)<br> - Dropped from critical (31)<br> - Dropped from major (32)<br> - Dropped from minor (33)<br> - Dropped from warning (34)<br> - Escalated from warning (35)<br> - Escalated from minor (36)<br> - Escalated from major (37)<br> - Flipped (38)<br> - Service impact changed (40)<br> - Value changed (41)<br> - Name changed (42)<br> - RCA level changed (43)<br> - Properties changed (50) |
| State ID | 1.3.6.1.4.1.8813.1.1.2.4.1.6 | Possible values:<br> - Cleared (11)<br> - Open (12)<br> - Masked (25) |
| Severity ID | 1.3.6.1.4.1.8813.1.1.2.4.1.7 | Possible values:<br> - Critical (1)<br> - Major (2)<br> - Minor (3)<br> - Warning (4)<br> - Normal (5)<br> - Information (13)<br> - Timeout (17)<br> - Error (24)<br> - Notice (28)  |
| Severity range | 1.3.6.1.4.1.8813.1.1.2.4.1.8 | Possible values:<br> - Normal (5)<br> - High (6)<br> - Low (7) |
| Previous alarm ID | 1.3.6.1.4.1.8813.1.1.2.4.1.9 | |
| User status ID | 1.3.6.1.4.1.8813.1.1.2.4.1.10| Possible values:<br> - Not assigned (18)<br> - Acknowledged (19)<br> - Resolved (20)<br> - Unresolved (21) |
| Alarm root ID | 1.3.6.1.4.1.8813.1.1.2.4.1.11| |
| Source ID | 1.3.6.1.4.1.8813.1.1.2.4.1.12| Possible values:<br> - DataMiner (16)<br> - Correlation engine (23)<br> - Automation engine (26) |
| Table display index| 1.3.6.1.4.1.8813.1.1.2.4.1.13| What is returned depends on how the table is indexed:<br>- Primary key only: Returns primary key value.<br>- Table with naming option, but no display key column: Returns what has been defined with the naming option.<br>- Table with naming option and column of type DisplayKey: Returns the value in the display key column.|
| Full RCA level | 1.3.6.1.4.1.8813.1.1.2.4.1.14| A 32-bit integer<br> Up to DMS version 6.0.2:<br> - Parameter RCA: Bytes 4 and 3<br> - Element RCA: Bytes 2 and 1<br> As from DMS version 6.0.3:<br> - Service RCA: Byte 4<br> - Parameter RCA: Byte 3<br> - Element RCA: Bytes 2 and 1<br> Examples:<br> - Element RCA = 1, Parameter RCA = 2, Service RCA = 3 \>\>\> Full RCA: 0x03020001<br> - Element RCA = none, Parameter RCA = 1, Service RCA = 2 \>\>\> Full RCA: 0x0201FFFF<br> - Element RCA = none, Parameter RCA = none, Service RCA = none \>\>\> Full RCA: 0xFFFFFFFF |
| Element type | 1.3.6.1.4.1.8813.1.1.2.4.1.15| |
| Root time | 1.3.6.1.4.1.8813.1.1.2.4.1.16| A fixed time format is used: <br>"yyyy-mm-dd HH:MM:SS". |
| Table index (primary key) | 1.3.6.1.4.1.8813.1.1.2.4.1.17| |
| Protocol name | 1.3.6.1.4.1.8813.1.1.2.4.1.18| |
| Alarm presence | 1.3.6.1.4.1.8813.1.1.2.4.1.19| |
| Polling IP    | 1.3.6.1.4.1.8813.1.1.2.4.1.20| The polling IP address of the element raising the alarm.    |
| Service impact | 1.3.6.1.4.1.8813.1.1.2.5.1.1 | |
| Element properties | 1.3.6.1.4.1.8813.1.1.2.4.4.1.\[ASCII values\] | See [Syntax of OIDs referring to properties](#syntax-of-oids-referring-to-properties). |
| Service properties | 1.3.6.1.4.1.8813.1.1.2.4.4.2.\[ASCII values\] | See [Syntax of OIDs referring to properties](#syntax-of-oids-referring-to-properties). |
| Alarm properties   | 1.3.6.1.4.1.8813.1.1.2.4.4.3.\[ASCII values\] | See [Syntax of OIDs referring to properties](#syntax-of-oids-referring-to-properties). |
| View properties    | 1.3.6.1.4.1.8813.1.1.2.4.4.4.\[ASCII values\] | See [Syntax of OIDs referring to properties](#syntax-of-oids-referring-to-properties). |
| Parameter ID (Information template) | 1.3.6.1.4.1.8813.1.1.2.4.5.1 | This OID and the below OIDs with prefix 1.3.6.1.4.1.8813.1.1.2.4.5 refer to the information template. |
| Custom Name    | 1.3.6.1.4.1.8813.1.1.2.4.5.2 | |
| Text   | 1.3.6.1.4.1.8813.1.1.2.4.5.3 | |
| Detailed Description    | 1.3.6.1.4.1.8813.1.1.2.4.5.4 | |
| Includes   | 1.3.6.1.4.1.8813.1.1.2.4.5.5 | |
| Category   | 1.3.6.1.4.1.8813.1.1.2.4.5.6 | |
| Corrective Action  | 1.3.6.1.4.1.8813.1.1.2.4.5.7 | |
| Alarm Description  | 1.3.6.1.4.1.8813.1.1.2.4.5.8 | |
| Filter | 1.3.6.1.4.1.8813.1.1.2.4.5.9 | |
| Description    | 1.3.6.1.4.1.8813.1.1.2.4.5.10| |
| Key point  | 1.3.6.1.4.1.8813.1.1.2.4.5.11| |
| Offline Impact | 1.3.6.1.4.1.8813.1.1.2.4.5.12| |
| Component Info | 1.3.6.1.4.1.8813.1.1.2.4.5.13| |
| Exact Access Level | 1.3.6.1.4.1.8813.1.1.2.4.5.14| |
| Access Level   | 1.3.6.1.4.1.8813.1.1.2.4.5.15| |
| Impacted Service Name   | 1.3.6.1.4.1.8813.1.1.2.5.1.2.1.1  | |
| Impacted Service ID| 1.3.6.1.4.1.8813.1.1.2.5.1.2.1.2  | |

## Syntax of OIDs referring to properties

OIDs of custom bindings referring to properties of elements, services, alarms, and so on, have the following syntax:

```txt
[Private enterprise][Skyline][Property][Type of Property][Name of Property]
```

- **Private enterprise**: 1.3.6.1.4.1.

- **Skyline**: 8813.

- **Property**: 1.1.2.4.4.

- **Type of Property**: A digit from 1 to 4:

  1. Element Property

  1. Service Property

  1. Alarm Property

  1. View Property

- **Name of Property**: Property name spelled in decimal ASCII values (0-255), separated by dots.

**Example:**

The element property called "Redundancy Type" will be assigned the following OID:

```txt
1.3.6.1.4.1.8813.1.1.2.4.4.1.82.101.100.117.110.100.97.110.99.121.32.84.121.112.101
```
