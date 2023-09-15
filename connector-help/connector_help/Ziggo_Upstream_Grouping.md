---
uid: Connector_help_Ziggo_Upstream_Grouping
---

# Ziggo Upstream Grouping

This connector is used to receive **Arris Alarm Central** notifications and group their **issues** on the **USSegment** level, displaying the highest severity among them.

## About

The **Ziggo Upstream Grouping** connector embeds a **web service** that listens to requests on a configurable port.

The connector identifies if any *critical* or *major* **issue** of the received **notification** corresponds to an **upstream type** and stores them.

The issues are grouped by the USSegment field and the highest severity among them is displayed.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

On this page, click the **Webservice** page button to select on which port the web service will be listening to. The specified port number can range from *1025* to *65535*.

The **Configuration** page allows the user to configure multiple settings and it is divided into sections:

- **Elements**:

  - The user can configure the **Orchestrator element** (using the Arris Alarm Central Orchestrator connector, minimum version: 1.0.0.2);
  - The user can enable or disable the alarm enrichment functionality that will add extra information to the **USSegment** alarms via the **Brain Communication** toggle button. This additional information is requested to the Ziggo Brain connector which communicates with the database. If **Brain Communication** is *enabled*, the **Brain Element** needs to be selected.
  - The **Refresh** button can be used to immediately refresh all available elements that can be chosen. Otherwise, the lists of elements are refreshed every 60 seconds.

- **Parameters**: The user can edit the **URL** parameter that will be set on the **em_url** field of the **Parameters** property.

- The **URL** parameter allows the use of placeholders. The available placeholders are enumerated in the tooltip of the parameter.

- **Hysteresis**: The user can change the **Clear Hysteresis Time** of the **USSegment** alarm.

The **Notifications** page button displays a table with all received notifications. It also displays an option to manually delete a specific notification.

**Upstream Event Types Affected Devices** is the user-defined list that filters the incoming issues by its **type**. Multiple types have to be separated by pipe characters "\|".

- E.g.: "USSPECTRAL\|USFEC" will only allow *usspectral* and *usfec* issue types to be stored and, therefore, processed.

The **USSegment** **Table** displays all the distinct **USSegments** received and their corresponding **Severity** based on the highest severity of the issues related to that **USSegment**.

- The table is updated on every incoming notification

- If a received notification contains issues that are no longer of the upstream type, those issues and notifications are cleared

- When a notification is received which would clear the **USSegment** alarm, the alarm is kept active for the amount of time defined in the **Clear Hysteresis Time**.

- In the column "**Clearing Time"** is displayed the date and time when the alarm is going to be cleared.

Besides the **Severity**, more information is displayed on the table, such as **Region**, **Customers** **Impacted**, **Event** **Tag**, **Parameters**, **Source**, etc. Some of this information is set to different properties of the **USSegment** alarms.
