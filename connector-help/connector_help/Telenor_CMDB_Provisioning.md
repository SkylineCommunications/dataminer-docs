---
uid: Connector_help_Telenor_CMDB_Provisioning
---

# Telenor CMDB Provisioning

Through this connector is possible to automatically provision Elements and Services based on the information from CMDB.

## About

This is an HTTP connector that will be connected to the CMDB. Through queries to the database will be possible to create Element and Services on DataMiner.

## Installation and configuration

### Creation

### HTTP

**SERIAL Connection:**

- **IP address/host**: the polling IP or URL of the destination e.g. 10.47.23.70
- **IP port**: the port of the destination e.g. 8080
- **Bus address**: this field can be used to bypass the proxy. To do so fill in the value ByPassProxy.

## Usage

### General Page

On this page will be possible to configure the User and Password to connect to the CMDB.

If a valid connection is done the parameter **Connection Status** will display the value **Ok**.

### Element Page

This page will display a table with all provisioned element and the settings used to create them.

On this page is also present a button, **Get Deleted Elements**, that will trigger a search for deleted elements. If any element is found as deleted will be removed from the Element Table and the flag **toBeDeleted** will be set to true.

### Service Page

This page is similar to the Element Page, but for services.

### Change Orders Page

This page displays a table with the current and the future change orders. As soon as a change order ends the entry will be removed from this table.

### AppearTV Page

This page contains to tables, the **AppearTV** **Table** and the **Failed AppearTV Table**.

When a new AppearTV card is detected, this connector will pass that information to the **TWA** database.

If this process succeeds an entry will be added on the **AppearTV Table**, if for some reason this fails an entry will be added on the **Failed AppearTV Table**. Then every 10 minutes we will retry the failed one until they are successfully inserted.

### Protocol Rules Page

On this page the user has to configure the protocol rules to be used. Each protocol rule should match a Manufacturer and Model (information present on CMDB) with a protocol on DataMiner.

There are two ways to insert protocol rules:

1. Right-click the **Protocol Rule Table** and select the option **Add Protocol Rule.** A pop-up window will appear with the fields to add the Manufacturer, Model and a dropdown button to choose the desired protocol.
1. Right-click the **Protocol Rule Table** and select the option **Import Protocol Rules From File.** On the pop-up window the user should specify the complete path to a .csv file contains the desired rules. The file should have the following format: Manufacturer,Model,DataMiner Protocol.

Additionally for each Operating System class detected on CMDB an entry will be added on the **Operating System Protocol Rules**, the user should then choose a protocol from the dropdown list for each Operating System.

Note: If an element is detected but is combination Manufacturer, Model or Operating System, is not found on this tables the Element will be discarded.

### View Rules Page

This page displays a table with all the Families and Classes present on CMDB.

By default all views are empty, if the user wants to assign a view to a specific combination of Family/Class, he can choose a view from the dropdown list, or if he intends to create a new view a new name can be typed and a new View will be automatically created.

Note: If the user intends to use the same view for every Class that belongs to the same family, he just needs to specify the view on the entry of the desired Family and the Class "Any".

### Settings

On this page the user need to configure the DataMinerId and ElementId of the element using the protocol **Integral Systems Monics**.

If this parameters are not configured the protocol will not create any service that contains this Element.
