---
uid: TicketingHighLevelOverview
---

# High-Level Overview


### High-Level Architecture Diagram

![Ticketing_HighLevel](~/solutions/images/Ticketing_HighLevel.png)


## Architecture

The Ticketing Standard Solution consists of two main building blocks:

- Ticketing Back End  
- Ticketing Front End  

These blocks work together to provide ticket lifecycle management, integration with other DataMiner components, and user interaction.

## Ticketing Back End

The Ticketing Back End implements the core logic of the Ticketing application and is built on top of the **DataMiner Standard Data Model (SDM)**. This allows the Ticketing application to expose a **Ticketing API Helper** that can be used by other DataMiner components, such as:

- Automation scripts  
- DataMiner Connectors/Elements  
- Other Standard Solution applications

The Ticketing Back End uses  **SDM Relationships** (formerly known as **SDM Object Linking**) to associate tickets with other DataMiner objects or objects from other applications, including:

- Alarms  
- Elements  
- Services  
- Assets from the Asset Manager of InfraOps

This SDM Relationships layer can be consulted by other DataMiner applications to determine which tickets are linked to which objects.

## Ticketing Front End

The Ticketing Front End is the user interface of the application which is implemented as a **Low-Code App (LCA)**.  

All tickets, fields, and related values are stored in the **DataMiner Object Model (DOM)**.

The user interaction is handled through forms, the logic for which is implemented using **Interactive Automation Scripts (IAS)**. These are responsible for:

- Input validation  
- Business logic checks  
- Ticket processing actions  

### Usage modes

The Ticketing application can be used as a standalone app as well as via its API Helper. Both methods support full ticket lifecycle management, from creation to resolution.

### Ticket Creation

Tickets can be created in several ways:

- Directly from the Ticketing application  
- From a Cube alarm using the right-click context menu
- From an automation script triggered by a correlation rule

When a ticket is created from a Cube alarm using the right-click context menu:

- An automation script is launched to collect additional details  
- The Ticketing API Helper is used to create the ticket  
- The alarm and the element on which the alarm occurred are automatically linked to the ticket

If the element is linked to an asset in the Asset Manager, that asset is also linked to the ticket.

### Ownership and Assignment (using People & Organizations)

Ownership ensures that it is always clear who is responsible for progressing a ticket towards closure. Therefore tickets can be assigned to a Contact or a Team as defined in the **People & Organizations** Module.  

The Ticketing application can technically operate without the **People & Organizations** module. However, in that case tickets cannot be assigned thereby losing the benefit of structured ticket ownership.

Therefore it is strongly recommended to use the Ticketing application together with the **People & Organizations** module.

## Navigation and Integration

From the ticket information page:

- Clicking an alarm opens it in the Monitoring app  
- Clicking an element opens it in the Monitoring app  
- Clicking an asset opens it in the Asset Manager  

From the Asset Manager:

- Assets display an indication of linked tickets  
- The list of linked tickets in the Ticketing application can be opened directly from the asset

## External Ticketing System Integration

The Ticketing solution can integrate with external ticketing systems such as:

- ServiceNow  
- Jira  
- Remedy  

This integration is implemented using an element (based on a dedicated connector) that communicates with the external system.

The element is responsible for:

- Creating incidents or tickets in the external ticketing system  
- Retrieving the external ticket ID (known as the external reference)  
- Feeding the external ticket ID back into the Ticketing application
- Synchronizing status updates between the Ticketing application and the external ticketing system

External ticketing systems may however use different:

- Fields  
- States  
- Severity values  
- Priority values  

The connector performs the required mapping and translation between the DataMiner Ticketing ticket fields and states and the external ticketing system ticket fields and states. This mapping and translation works in both directions and ensures consistency between both systems.

When a Ticketing ticket is linked to a ticket in an external ticketing system:

- The external ticket ID is stored on the DataMiner ticket  
- The ticket information page contains a direct link to the ticket on the external ticketing system
- Users can open the ticket on the external ticketing system directly from DataMiner  

## Supported Use Cases

- Manual ticket creation and tracking  
- Alarm-driven ticket creation  
- Linking tickets to elements, alarms, and assets  
- Cross-application navigation within DataMiner
- Integrate with external ticketing systems