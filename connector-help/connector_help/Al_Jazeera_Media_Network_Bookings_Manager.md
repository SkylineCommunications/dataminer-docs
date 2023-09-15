---
uid: Connector_help_Al_Jazeera_Media_Network_Bookings_Manager
---

# Al Jazeera Media Network Bookings Manager

This protocol provides a management application with booking, scheduling and resource management.

## About

This connector is used together with Automation scripts and a Visual Overview, allowing the creation, viewing, checking, and editing of bookings.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Bookings

This page shows a table with all the created bookings and their main information.

A page button is available to show extra details of the booking as well as to be able to configure the available booking areas and technical areas.

### Reservations

This page gives an overview of the active reservations.

### Notifications

This page gives an overview of all notifications.

### Contacts

This page provides a list of all available contacts that can be associated as well as their info:

- Name
- Role
- Number
- Email
- Company
- Type (possible to add/remove types from a page button on this page)

### Events

This provides a list of available events to be used in the bookings as well as the possibility of adding/removing events.

### Origins

This page displays a table where it is possible to configure the available options to select from when assigning a **Origin** to a **Booking**.

It is also possible to configure several parameters associated with the origin, such as,

- Name
- Address
- City
- Postal code
- Country

### Feed Type

This page displays a table where it is possible to configure the available options to select from when configuring the **Booking Feed Type**.

### External Requests

This page contains two tables that provide an overview data that has been requested by an IAS and all the incoming/outgoing internal/external messages.

### Configurations

In this page, it is possible to adjust some configuration parameters related to the **Arrivals Board**, **Offload** and **Recurrent Booking** timing.
