---
uid: Connector_help_Globo_MCR_Manager
---

# Globo MCR Manager

With the **Globo MCR Manager** protocol, users can configure signal paths for events and follow up on the activation of the events.

This is a virtual protocol that will maintain the reservations and resource bookings for events. Devices can be reserved into time slots, and will be configured and connected by different Automation scripts.

## About

The Globo MCR Manager connector is used in conjunction with a Visio file, which is the Visual Overview layer of the corresponding element.
Commands are sent between the Visio file and the manager element in order to execute actions.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Installation

To install this application, create an element using this protocol, and assign the Visio file "*Globo MCR Manager.vsdx*" to it.

You must also add a property on the element with the name **Language**, and set the property value either to **English** or to **Portuguese**, depending on which language you wish to see in the labels.

## Usage

### Events

On this page, there are two tables with all the event information, and a **Users** table, which logs the actions for all the users. In the event table, you can find the **Event Name**, **Start & Stop Times** and **states**.

### Configuration

On this page, you can configure default parameters such as **Pre-Roll Duration**, **Post-Roll Duration**, **On Air Default Duration**, **On Air Default Start Delay**, and **Extension Time**. These configuration parameters are taken into account when an new event is created.
This information will then be stored in the Events table.

The configuration parameter **Disconnect Time** is used to determine after how many minutes of inactivity a user should be disconnected. If a user is disconnected, they are removed from the Users table. The Visual Overview UI will not longer display the selected actions and connections for that user. This prevents endlessly growing tables.

### Action Shapes

On this page, there are two saved tables that contain all the action shapes and connection lines. With these, Visual Overview displays how the signal path is configured for a specific event.

### Resources

On this page, there are three volatile tables, which contain all the resources per type: **Sources**, **Processors** and **Destinations**. The UserGUID is added in the tables, so that it is possible to filter on the correct resources for each user in Visual Overview.

## Notes

This Manager connector is used together with a Visio file, Automation scripts and the Resource Manager Module. Please contact your TAM if you need more information about any of these items.
