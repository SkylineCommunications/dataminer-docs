---
uid: Connector_help_Envivio_Halo_Redundancy
---

# Envivio Halo Redundancy

## About

The **Envivio Halo Redundancy** will retrieve a list of configured "**Envivio Halo**" elements on the DMS and the user can register on **max. 2** of those elements to receive the alarm status. When both of the configured elements have the same alarm, the redundancy element will also show the alarm in the Alarm table.

## Creation

It is a **virtual element**, no IP is needed.

## Timing

Every hour the list of configured "Envivio Halo" elements will be updated.

Every 5min there is a check if the elements are active or not and clean alarm entries if needed.

## Usage

The element contains 5 pages :

- Redundancy Config:

Provides an overview of all the installed "Envivio Halo" elements which are using the "production" version. Using the Registration button, it is possible to enable or disable the registration on the alarms table of maximum 2 elements.

- Services:

This page is not being filled in at the moment.

- Outputs


This page is not being filled in at the moment.

- Recording:

This page is not being filled in at the moment

- Alarms

This page provides a summary alarm overview of the configured "Envivio Halo" elements. When the **same alarms** are active on both devices, it will be shown also in this alarm table of the Halo Redundancy.

## Latest Verison

1.0.0.3
