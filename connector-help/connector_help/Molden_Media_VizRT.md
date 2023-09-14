---
uid: Connector_help_Molden_Media_VizRT
---

# Molden Media VizRT

The Molden Media VizRT provides a Real Time Graphics Solution.

## About

The connector allows the Assigning of Video **Channels** to **Engines**.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify: *bypassproxy*.

## Usage

### General

Provides a list with all **Client Hosts** and **Engine Hosts** that can be selected. This parameter must be configured, it is not polled.
A toggle button **Debug Logging** allows a user to dynamically enable or disable extra logging in the Element Log File.

### Channel Assignment

On this page a user can select a **Client Host Name** and an **Engine Host Name** and then **Assign** a **Channel**. The results of the assignment attempt will be displayed in the **Result Message Assign** **Channel** and **Result Assign Channel.**
