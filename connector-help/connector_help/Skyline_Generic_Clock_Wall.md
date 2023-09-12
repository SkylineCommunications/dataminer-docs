---
uid: Connector_help_Skyline_Generic_Clock_Wall
---

# Skyline Generic Clock Wall

This connector can be used to track the time of different cities, locations, or regions around the world.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Visio drawing         | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

On the "General" page of the element, a table keeps track of the time for a city, location, or regions. **Each row in the "Clocks" table represents a clock in the visual overview** for this connector.

To **add a location** to the "Clocks" table, right-click the table and select "Add Item". Then specify a name of your choice for the location and specify the UTC zone. A new row will then be added to the table.

By default, the "Time" column is set to **12h format**. However, you can change this via the **"Time Format" column** which can toggle between "12h" and "24h". The format will change accordingly.

You can also modify the content of the "Name" and "UTC Zones" columns as you see fit.

**To delete one or more rows** from the table, select the rows, right-click them, and select "Delete Selected item(s)" from the context menu. This will also remove the corresponding clock visuals in visual overview.
