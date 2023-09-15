---
uid: Connector_help_Teracom_Remote_Ear_Allocation
---

# Teracom Remote Ear Allocation

The **Teracom Remote Ear Allocation** manager connector is used to keep track of all running audio streams across the different sites.

## About

The purpose of the Teracom Remote Ear functionality is to remotely listen to an audio stream coming from the **Audemat Aztec GoldenEagle FM** audio monitor.

This connector keeps track of all running audio sessions of all users. An Automation script will communicate with the connector. In case two different users attempt to access different audio streams on the same device, a warning message will be displayed to the user, indicating that the device is already in use. The operator can choose to either stop the running session and continue setting up the new remote ear session, or abort the request.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a **virtual connection** and does not require any input during element creation.

## Usage

### General

This page displays a page with all currently active remote ear sessions.

### Configuration

On this page, you can configure the **Session Timeout** time. Every minute, the connector does a check of all active sessions, deleting every session that exceeds that timeout time. When such a session is detected, an Automation script is executed to stop the streaming on the corresponding element.
