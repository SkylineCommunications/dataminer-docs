# Ticketing – Conceptual Overview

## Overview

This document describes the main concepts of the DataMiner Ticketing solution.  
It complements the high-level architecture by explaining how tickets are structured, managed, and linked within the DataMiner ecosystem.

![Ticketing Concepts](~/solutions/images/Ticketing_Concepts.png)

The Ticketing solution is inspired by the **TM Forum TMF 621 Trouble Ticket Management specification**.  
The concepts described here follow this specification where applicable, while remaining aligned with DataMiner standards.

---

## Ticket Lifecycle

### Ticket State Model

The Ticketing solution uses a predefined state model to reflect the lifecycle of a ticket.

The standard lifecycle, also referred to as the *happy path*, consists of the following states:

1. **Acknowledged**  
2. **In Progress**  
3. **Resolved**  
4. **Closed**

A ticket is typically created in the *Acknowledged* state.  
It progresses to *In Progress* when it is assigned to a contact.  
After resolution, the ticket moves to *Resolved* and is finally *Closed*.

Ticketing_Concepts.png

### Additional States

In addition to the standard lifecycle, tickets can also be moved to the following states:

- **On Hold / Pending**, when work is temporarily paused  
- **Rejected**, when the ticket is considered invalid  
- **Cancelled**, when the ticket is no longer required  

These states allow flexible handling of exceptional situations.

### State Transitions

When tickets are managed through the Ticketing Low-Code App:

- Only transitions defined by the state model are allowed  
- Tickets must follow the predefined progression rules  

When tickets are updated through the **Ticketing API Helper**:

- Tickets can transition from any state to any other state  
- Intermediate states are not required  

This approach supports integration with external ticketing systems that use different state models.

---

## Ticket Structure

### Built-In Ticket Fields

Each ticket contains a set of built-in fields that are present for all ticket types, including:

- Ticket identifier  
- Name  
- Description  
- State  
- Priority  
- Severity  
- Assignee  
- Resolution-related dates  

These fields represent the common information required to manage a ticket.

---

## Ticket Types

### Purpose

Ticket types allow tickets to be categorised based on the nature of the issue.  
Each ticket type extends the built-in ticket fields with additional, type-specific fields.

### Custom Fields

For each ticket type, custom fields can be defined to model a specific kind of incident.

Examples include:

- **Incident Report**
  - Incident category  
  - Detection time  
  - Reporting time  
  - Location  

- **Service Disruption**
  - Impact  
  - Affected customer  
  - Service degradation percentage  

- **Billing Dispute**
  - Invoice number  
  - Disputed amount  

Each custom field has a defined data type and purpose.

### Usage

When creating a ticket:

- A ticket type is selected  
- The related custom fields automatically become available  

Ticket types can also be used to:

- Filter tickets  
- Categorise incidents  
- Support reporting and analysis  

---

## Linked Items and Affected Resources

### DataMiner ObjectLinking

Tickets can be linked to DataMiner objects, referred to as **affected resources**, such as:

- Alarms  
- Elements  
- Services  

These links provide context about what is impacted by the ticket.

### Asset Linking

Tickets can also be linked to assets managed through the **Asset Manager**, which is part of the InfraOps standard solution.

### Linking Mechanism

All relationships are implemented using the **Standard Data Model (SDM) relationship layer**.

This allows:

- Other DataMiner applications to query ticket relationships  
- Visual indication of linked tickets in applications such as the Asset Manager  

For example, the Asset Manager can show whether an asset has active tickets linked to it.

---

## External Ticketing Integration

### Purpose

The Ticketing solution can be integrated with external ticketing systems, such as ServiceNow.

This allows tickets in DataMiner to be linked to incidents managed outside the DataMiner platform.

### External Identifiers

When a ticket or incident is created in an external system:

- An external identifier is returned  
- This identifier is stored in the DataMiner ticket  
- A visualisation endpoint for the external system is configured  

### Navigation

From the ticket information page in DataMiner:

- The external ticket identifier is displayed  
- Selecting the identifier opens the corresponding ticket in the external system  

This enables direct navigation between DataMiner and the external platform.

---

## Summary

The Ticketing solution provides a structured approach to incident management within DataMiner.

Key concepts include:

- A well-defined ticket lifecycle with controlled states  
- Flexible ticket types with custom fields  
- Dynamic linking to DataMiner objects and assets  
- Support for external ticketing system integration  

These concepts ensure consistent ticket handling while allowing integration with existing operational processes.
``