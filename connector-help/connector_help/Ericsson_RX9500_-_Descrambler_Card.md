---
uid: Connector_help_Ericsson_RX9500_-_Descrambler_Card
---

# Ericsson RX9500 - Descrambler Card

The Descrambler Card is a component of the Ericsson RX9500 base unit. This card contains a single satellite tuner and two CAMs. The function of the bulk descrambler is to **receive a single Multi-Program Transport Stream** containing scrambled and unscrambled services, to **descramble a subset of the scrambled services selected by the user**, and to output a set of MPTS and SPTS containing unscrambled services.

## About

This **HTTP** connector implements the REST API to communicate with the Ericsson RX9500 device.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.0                       |
| 2.0.0.x          | 1.0.0                       |

## Installation and Configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector Ericsson RX9500, from version 2.0.0.1 onwards.

## Usage

The connector contains 4 pages: **Active Alarms**, **Card Properties**, **Input Services** and **Transport** **Stream**.

### Active Alarms Page

This table contains a list of all current active alarms on the card/slot.

### Card Properties Page

This page displays each entry/card of the **Cards** **Properties** **Collection** table (which displays all cards installed in the system).

### Input Services Page

For each card, this page displays the relevant set of channels along with its components.

### Transport Stream Page

This page displays each entry/card of the **Transport Stream Source** table (which displays all sources for the transport stream of which one is active at one time).
