---
uid: Connector_help_Verizon_Reports_and_Dashboards_Solution
---

# Verizon Reports and Dashboards Solution

The Verizon Reports and Dashboards Solution is a DataMiner connector with the goal of exporting and importing data related to different collector elements.

## About

The Verizon Reports and Dashboards Solution is intended for the generation of custom reports targeting different data groups within the DataMiner System, including key performance indicators (KPIs), configuration statistics, and alarm history data.
In order to efficiently integrate the requirements, this solution comprises two different scopes, the connector side on the one hand and the custom report side on the other.

### Version Info

| **Range** | **Description**                                                   | **DCF Integration** | **Cassandra Compliant** |
|-----------|-------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version                                                   | No                  | Yes                     |
| 1.0.1.x   | Minimum DataMiner required version increased to 10.0.10.0 - 9454. | No                  | Yes                     |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

Below, you can find detailed information on the different pages of the connector.

### General

This page contains the following parameters:

- **Entity Levels**: Displays how many different entities are present in the **Entity Subscribers Table**. These entities are for example Hub Networks, Hub Forward, Circuits, NMS, Customers, etc.
- **KPI Levels**: Contains the different key performance indicators present in the **KPI Entry Subscribers Table**.
- **Last Update**: Displays the date and time of the last update.
- **Processing Status**: Displays the processing status, i.e. *Processing* while an update is being processed or *Idle* when the update process has finished. If the logic was somehow interrupted, the status is *Interrupted*.
- **Update**: This button will execute a global refresh, which means that it executes an update of the KPI Entry Subscribers, Entity Subscribers, and Config Entry Subscribers.

The **Debugging** subpage contains the parameter **Debugging Log Message State**, which can be used to enable or disable the log messages present in the connector to help the debugging process when needed. By default, it is set to disabled. When it is enabled, an additional page is also available for debugging purposes.

### Entity

This page displays the **Entities Overview Status** and the **Entities Overview** table.

With the **Update** button, you can execute an update of the Entities Subscribers, which means that the Entities Overview table and Entities Levels will be updated with the most recent data.

The **Levels** and **Subscriptions** page buttons display the **Entities Levels** and **Entities Subscribers** tables, respectively.

### Entity Relation

This page contains the **Entities Relations Overview** table, which contains an entry for all the relations detected in the Entities Subscribers Table, for example *GXL05 Circuit PLN11 NMS.*

Note that there will be just **one entry per relation**, since it can be bi-directional.

The subpage **Entity Relation Levels** displays the different levels based on the above. For example, Circuit NMS would be one entry.

### KPI Entry

This page displays the **KPI Entry Overview Status** and the **KPI Entry Overview** table.

With the **Update** button, you can execute an update of the KPI Entry Subscribers, which means that the KPI Entry Overview table and KPI Entry Levels will be updated with the most recent data.

The **Levels** and **Subscriptions** page buttons display the **KPI Entry Levels** and **KPI Entry Subscribers** tables, respectively.

### Config Entry

This page displays the **Config Entry Overview Status** and the **Config Entry Overview** table.

With the **Update** button, you can execute an update of the Config Entry Subscribers, which means that the Config Entry Overview table and Config Entry Levels will be updated with the most current data.

The **Levels** and **Subscriptions** page buttons display the **Config Entry Levels** and **Config Entry Subscribers** tables, respectively.

### Profile DCAT

This page contains the **Profile DCAT Metric** and **Profile DCAT Fault** tables.

- Profile DCAT Metric:

  - For the "Value" column, depending on the "Operator" column selection, many different entries are possible:

    - Equal to (==): The logic will return "OK" if this value equals that of the corresponding metric (i.e. FWD C/N) for the given entity (i.e. Circuit x). Otherwise, "Failed" will be returned.

    - Not Equal to (!=): The logic will return "OK" if this value does not equal that of the corresponding metric for the given entity. Otherwise, "Failed" will be returned.

    - Less Than (\<): The logic will return "OK" if this value is greater than that of the corresponding metric for the given entity. Otherwise, "Failed" will be returned.

    - Less Than or Equal To (\<=): The logic will return "OK" if this value is equal to or greater than that of the corresponding metric for the given entity. Otherwise, "Failed" will be returned.

    - Greater Than (\>): The logic will return "OK" if this value is less than that of the corresponding metric for the given entity. Otherwise, "Failed" will be returned.

    - Greater Than or Equal To (\>=): The logic will return "OK" if this value is equal to or less than that of the corresponding metric for the given entity. Otherwise, "Failed" will be returned.

    - Between (BETWEEN): The logic will return "OK" if the value of the corresponding metric for the given entity is between the values entered using "BETWEEN" as separator (including the limits). Otherwise, "Failed" will be returned. Supported options are:

      - \[numeric value\] BETWEEN \[numeric value\]
      - \[metric name\] BETWEEN \[metric name\]
      - \[metric name\] \[+-\*/\] \[numeric value\] BETWEEN \[metric name\] \[+-\*/\] \[numeric value\]
      - \[avg, min, max\] \[metric name\] BETWEEN \[avg, min, max\] \[metric name\]
      - A combination of the above.

    - Not Between (!BETWEEN): The logic will return "OK" if the value of the corresponding metric for the given entity is not between the values entered using "!BETWEEN" as separator (including the limits). Otherwise, "Failed" will be returned. Supported options are:

      - \[numeric value\] !BETWEEN \[numeric value\]
      - \[metric name\] !BETWEEN \[metric name\]
      - \[metric name\] \[+-\*/\] \[numeric value\] !BETWEEN \[metric name\] \[+-\*/\] \[numeric value\]
      - \[avg, min, max\] \[metric name\] !BETWEEN \[avg, min, max\] \[metric name\]
      - A combination of the above.

  - For the "Exception" column, some metrics will be included/excluded in the DCAT analysis, depending on the values of other metrics.

    - \[metric name\]\[==\]\[value\]

      - The logic will only include the metric specified under "Name" in the DCAT analysis if the metric "metric name" equals "value".

    - \[metric name\]\[==\]\[value\] OR \[metric nameX\]\[!=\]\[valueX\] AND \[metric nameY\]\[!=\]\[valueY\]

      - The logic will only include the metric specified under "Name" in the DCAT analysis if the metric "metric name" equals "value" or the metric "metric nameX" equals "valueX" and the metric "metrixY" equals "valueY".

    - Any combination of the above.

    - Supported math operators:

      - Equal to (==)
      - Not Equal to (!=)
      - Less Than (\<)
      - Less Than or Equal To (\<=)
      - Greater Than (\>)
      - Greater Than or Equal To (\>=)

    - Supported logical operators:

      - OR
      - AND

- Profile DCAT Fault:

  - Filter logic: The Value Filter, Display Key Filter, and Severity Filter columns allow for the logical inclusion or exclusion of alarm events in the "Operator" logic. The following options are possible:

    - All: All values will be considered towards the "Operator" logic.
    - \![value\]: The value "value" will not be considered towards the "Operator" logic.
    - \![value1\]/\![value2\]/\![valueX\]: The values "value1", "value2", and "valueX" will not be considered towards the "Operator" logic.
    - \[value\]: Only the value "value" will be considered towards the "Operator" logic.
    - \[value1\]/\[value2\]/\[valuex\]: Only the values "value1", "value2", and "valueX" will be considered towards the "Operator" logic.
    - \[value1\]/\[value2\]/\![valueX\]: The values "value1" and "value2" will be considered towards the "Operator" logic, but the value "valueX" will not.
    - \[\*value1\*\]/\[value2\*\]/\![\*valueX\]: Values matching the wildcards "\*value1\*" and "value2\*" will be considered towards the "Operator" logic, but values matching the wildcard "valueX" will not.
    - A combination of the above.

Each table has a corresponding **Update** button under it. Click this button to execute an update of the table, so that it is updated with the most recent data from the Profile Manager.

The **Profile DCAT Setup** page button displays the **Profile DCAT Listing** and **Profile DCAT FUW** tables.

### Configuration

This page is divided in several sections.

The **Update Settings** section contains the following parameters:

- **Update Status**: Can be enabled or disabled in order to determine whether updates can happen at any level.
- **Entity Cycle**: Determines how often the Entity Subscribers update will be executed. By default, this is set to 1 hour, but it can be set to any value between 20 seconds and 24 hours. This information is then requested from the Profile Manager app to obtain the current profile definitions.
- **KPI Cycle**: Determines how often the KPI Entry Subscribers update will be executed. By default, this is set to 1 hour, but it can be set to any value between 20 seconds and 24 hours. This information is then requested from the Profile Manager app to obtain the current profile definitions.
- **Config Cycle**: Determines how often the Config Entry Subscribers update will be executed. By default, this is set to 1 hour, but it can be set to any value between 20 seconds and 24 hours. This information is then requested from the Profile Manager app to obtain the current profile definitions.

The **Reporter Authentication** section contains the following parameters:

- **Username**: The username for the reporter module.
- **Password**: The password for the reporter module.

The **File Handling** section contains only the **File Handling** parameter, which allows you to enable or disable the regular execution of the import and export actions. However, note that though this parameter is disabled by default, the import/export operation is always executed after startup.

The **Import Configuration** section contains the following parameters:

- **File Import**: Determines whether the import operation can be executed. By default set to disabled. If this is enabled, but the **File Handling** parameter is disabled, the import will not occur.
- **File Import Path**: The file path for the import files.
- **Import Processing Time**: Determines how often the import is executed. By default, this is set to 1 hour, but it can be set to any value between 20 seconds and 24 hours.
- **Import Provisioning File**: Displays the import processing status, which can be either *Idle* or *Processing*.
- **Apply**: Allows you to manually execute the import without taking the **File Handling** or **File Import** parameters into account.

The **Export Configuration** section contains the following parameters:

- **File Export**: Determines whether the export operation can be executed. By default set to disabled. If this is enabled, but the **File Handling** parameter is disabled, the export will not occur.
- **File Export Path**: The file path for the export files.
- **Export Processing Time**: Determines how often the export is executed. By default, this is set to 1 hour, but it can be set to any value between 20 seconds and 24 hours.
- **Export Provisioning File**: Displays the export processing status, which can be either *Idle* or *Processing*.
- **Apply**: Allows you to manually execute the export without taking the **File Handling** or **File Export** parameters into account.
