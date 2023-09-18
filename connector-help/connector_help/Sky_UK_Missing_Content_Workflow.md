---
uid: Connector_help_Sky_UK_Missing_Content_Workflow
---

# Sky UK Missing Content Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC). With this connector, alarms are generated according to predefined rules.

## About

To use this connector, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below. It will check the current and future events for missing content and raise alarms per individual video item for video content, per screen graphic ID for logo content and per event ID for others.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Instalation and configuration

### Creation

#### Service Main Connection

This connector uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC)

- **Channel From User**
  - **Data Update Trigger**

### Configuration of Elements

In this page you need to select what elements you want to include in this service.

This service needs the VICC element for the target channel intended to monitor .

## Usage

### Alarms

This page displays the **Early Warning List Table** with a unique row for each alarm scenario.

### Device Data

For this workflow, current and future events are grouped differently for each alarm type.

**Video Content Missing**: For this table, events are grouped by **Video Item**, if video content is missing, the first occurrence is mentioned by **Event ID** and **Event Time**.

**Logo Content Missing**: For this table, events are grouped by the **On Screen Graphic ID**, if logo content is missing, the first occurence is mentioned by **Event ID** and **Event Time**.

**VICC Update** is the date and time of the latest update trigger received from the **VICC** element.

**VICC DMA-Elem ID** is the identifier for the subscribed **VICC** element for use elsewhere in the connector.

**Channel Bus** is the **Channel From User** value from the **VICC** to populate the **Channel** column in the **Early Warning List Table**.

**BSS Service Status**: when this is Off-Air, this workflow won't trigger any alarms, for other values (NA or On-Air) or if the parameter isn't subscribed, the workflow will run as expected.

### Subscriptions Active

This shows the **Subscription Table** where you can find detailed information regarding each subscription made under this service. For each subcription (row), you will have:

**SourceKey** **\[IDX\]** - String Key that identifies each subscription which is composed by "DataMiner ID / Element ID / Parameter ID : Row Key Filter" of the parameter subscribed. Please note that Row Key Filter is only needed when a Cell Parameter is subscribed.

**Parameter Value** - Value of the subscribed parameter.

**DataMiner ID** - DataMiner ID from the DataMiner where the parameter subscribed is running.

**Element ID** - Element ID from the DataMiner where the element subscribed is running.

**Parameter ID** - Parameter ID from the Element where the parameter subscribed is running.

**Row Key Filter** - Row Key Filter used to selected a specific row from the table where you want to subscribe the parameter. Please note that Row Key Filter is only needed when a Cell Parameter is subscribed, otherwise it will be 'NA'.

**Protocol Name** - Name of the protocol that is running in the subscribed element.

### General Parameters

Table with subscribed parameters of the service.
