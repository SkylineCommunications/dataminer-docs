---
uid: Connector_help_Marlink_iTop_CMDB_Manager
---

# Marlink iTop CMDB Manager

This connector gives the possibility to subscribe on parameter changes in DataMiner, and forward these changes to the CMDB platform.

## About

This is a manager protocol that allows the user to specify which KPI parameters you are interested in. Every protocol/element/parameter that is available in the DMS can be selected.

For this set of parameters, the manager element will keep track of the parameter changes and will update CMDB by connecting to a web service via HTTP and providing these KPI values towards the web service.

## Ranges of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | NA                          |

## Installation and configuration

### Creation

#### HTTP connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration

After creating a new element with this protocol, the **webservice endpoint** needs to be specified on the configuration page. Also make sure that the **DMS Identification** parameter is filled in correctly.

## Usage

### Overview

This page gives an overview of all protocols and elements that are available in the DMS. When an element is selected, the subscribed parameters are shown.

### General

Contains a **Protocols Table**, an **Elements Table** and a **Parameters Table**.

- **Protocols Table**: a list of all protocols that are detected on the DMS. Only "production" versions are shown. The **Element Filter** parameter can be used to limit the number of elements of this protocol. Only elements with a name that contain the filter value will be shown in the **Elements Table**.
- **Elements Table**: a list of all elements that are found on the DMS. Use the **Element Selected** parameter to select the elements you are interested in.
- **Parameters Table**: a list with all parameters of the selected elements. Use the **Parameter Selected** parameter to subscribe on value changes, and forward the changes to CMDB.

### Subscriptions

This page contains a table with a list of all parameters the connector is currently subscribed to.

### CMDB Webservice

This page displays the last "update installation request" that is sent to the CMDB API. Also the last received response together with the status code is displayed here.

### Configuration

On this page the administrator needs to specify the **DMS Identifier** that allows to distinguish from which DMS the call is coming from.

Also the **Webservice Endpoint URL** can be configured on this page.

## Notes

Format of the XML data that is sent to the CMDB API:

```xml
<UpdateInstallationRequest xmlns="http://BP.MDM.Artifacts/NewOrder">
  <DataMinerSystemId>string</DataMinerSystemId>
  <DataMinerAgentId>int</DataMinerAgentId>
  <EntityId>int</EntityId>
  <EntityType>ELEMENT</EntityType> <!-- ELEMENT | SERVICE | VIEW | PARAMETER | REDUNDANCYGROUP -->
  <Properties>
    <Property> <!-- 0..* -->
      <Key>
        <Id>int</Id>
        <Name>string</Name>
        <Description>string</Description>
        <Index>string</Index>
        <IndexPK>string</IndexPK>
      </Key>
      <LastValueChangeUTC>datetime</LastValueChangeUTC>
      <Values>
        <OldValue>string</OldValue>
        <NewValue>string</NewValue>
      </Values>
    </Property>
    <Property>
      ...
    </Property>
  </Properties>
</UpdateInstallationRequest>
```

Fields:

- DataMinerSystemId = identifier whereby we can distinguish from which DMS the call is coming from.
- DataMinerAgentId = identifier of the DataMiner Agent.
- EntityId = identifier of an Element/Service/etc. For example ElementId.
- EntityType = the type of the entity that belongs to the EntityId.
- Properties = list of properties that has been changed at ones.
- Property = information that you can subscribe on.
- Key.Id = identifier of property (is optional, but must be filled if is available).
- Key.Name = name of the property.
- Key.Description = description of the property (is optional, but must be filled if is available).
- Key.Index = the display key of a table row.
- Key.IndexPK = the primary key of a table row.
- LastValueChangeUTC = the date when the value changed.
- Values.OldValue = the value the property had before it changed.
- Values.NewValue = the value the property had after it changed.
