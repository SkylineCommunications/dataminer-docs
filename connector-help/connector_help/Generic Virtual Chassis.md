---
uid: Connector_help_Generic_Virtual_Chassis
---

# Generic Virtual Chassis

This protocol is used for the Rack Layout manager integration of module elements that don't have a parent chassis element. A virtual chassis element will be assigned a location on the rack, and the element will show a visio with the modules.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

- Adding an element

Right clicking on the table will show a popup with mandatory input for Element Name, Slot, and Width. After the element name is provided, the DMA/Element ID will automatically be retrieved, and the table will be filled with the new element if it exists, and if the element is not already added.

- Deleting element(s)

After choosing one or multiple elements right clicking and clicking Delete selected module(s) will show a confirmation prompt. After confirming, the chosen elements will be deleted.

- Modifying elements

Clicking on a pencil icon in the slot or width cells will allow us to modify the value. Do note that you will not be allowed to assign multiple elements to a single slot.

Examples

You can find all the information you need on the General data page, and in the How to Use section of this guide.
