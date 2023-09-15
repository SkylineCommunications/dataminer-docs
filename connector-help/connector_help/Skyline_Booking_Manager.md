---
uid: Connector_help_Skyline_Booking_Manager
---

# Skyline Booking Manager

## About

The Skyline Booking Manager is the generic application to fully manage bookings under the SRM module.

### Version Info

| **Range** | **Description**                                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------|---------------------|-------------------------|
| 2.0.1.x          | Initial Version                                                                 | No                  | True                    |
| 2.0.2.x          | Removed Booking Manager Tables. A Visio is provided To enable CRUD of Bookings. | No                  | True                    |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

The general page contains a complet set of configuration parameters, used to customize the booking wizard, the application itself and the booking execution.

The general page also gives access to sub-pages, namely:

- **Events** - this page allows the user to manage custom events to be added in future reservations.
- **Properties** - As above, this page allows the user to manage custom properties to be added in future reservations.
- **SLA Tracking** - Allows the user to configure the SLA Tracking mode for every booking state.
- **States** - Allows the user to configure the available states and state transitions.
- **State Colors** - Allows the user to specify the UI colors for every booking status.
- **Booking Block Info -** Defines the different placeholders that can be used to fill the property 'VisualBlockContent'.
- **Custom Actions** - Allows to define up to five customizable buttons on the booking detail area of the Bookings Manager.


