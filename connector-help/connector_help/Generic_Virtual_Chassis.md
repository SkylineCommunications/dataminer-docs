---
uid: Connector_help_Generic_Virtual_Chassis
---

# Generic Virtual Chassis

This connector is used for the Rack Layout Manager integration of module elements that do not have a parent chassis element. A virtual chassis element will be assigned a location on the rack, and the element will show a visual overview with the modules.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

### Adding an element

Right-click the table and select the option to add an element. This will open a pop-up window where you will need to specify the Element Name, Slot, and Width. After you have provided the element name, the DMA ID/Element ID will automatically be retrieved, and the table will be filled in with the new element, if it exists, and if the element has not been added already.

### Deleting one or more elements

You can delete one or more elements by selecting them in the table, right-clicking them and selecting **Delete selected module(s)**. This will show a confirmation prompt. When you confirm, the selected elements will be deleted.

### Modifying an element

Click the pencil icon in a slot or width cell to modify the value. Note that you cannot assign multiple elements to a single slot.
