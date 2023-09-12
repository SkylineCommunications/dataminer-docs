---
uid: Connector_help_ABC_Class_B_Site_Service_Definition
---

# ABC Class B Site Service Definition

The ABC Class B Site Service Definiton is intended to give an overview of the status of a **service** that includes several **elements**, including a **Generic Ping** **Element**.

## About

This Service Definiton will give the **status** of a service based on the status of a Generic Ping Element and the **highest alarm value** between the remaining elements included in the service.

## Installation and configuration

### Creation

As this element functions as service, it does not need any user information.

## Usage

### General

This page includes the parameter used to give the **general status** of the service. The logic behind it works like this:

- It will enter a **Critical** state if both the Ping Element is in Critical state as well as one of remaining elements.
- It will enter a **Warning** state if either the Ping Element is in Critical state and the remaining elements are not in Critical state, or vice versa.
- It will enter a **Normal** state if none of the elements is in Critical state.

### Admin

This page includes a table that shows the **elements** assigned to the service.
