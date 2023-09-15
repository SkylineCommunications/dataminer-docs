---
uid: Connector_help_UPC_Nederland_CPD_Event_Manager
---

# UPC Nederland CPD Event Manager

The **UPC Nederland CPD Event Manager** is a connector that receives information when a ticket is created or closed by CPD.

## About

CPD is a tool used by operations to monitor and send engineers into the field for HFC issues. It is developed in-house and detects issues on amplifier, node and segment level.

Whenever CPD creates or closes a ticket, this information will be forwarded to the northbound SOAP XML interface of DataMiner, which triggers a parameter to be set in the **UPC Nederland CPD Event Manager**.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation..

### Configuration

On the **General** page, the **Max Duration Events** parameter can be configured. With this parameter you can define the number of days that a closed ticket will be kept before it is removed. If this value is not filled in, a default value of 90 days will be used.

## Usage

### General

This page contains the **Max Duration Events** parameter (see "Configuration" section above).

The **Event Table** contains all the tickets, and the **Event Tag Table**, **Services Table** and **Interface Table** contain items linked to the **Event Table**. To easily select a ticket and see all the linked items, it is advisable to use a Visio drawing. In Data Display, the quick filter can be used to filter on Event IDs.

The **Messages** page button displays the parameters **CPD Create Event** and **CPD Close Event**. These parameters display the incoming data and can be used for debugging.
