---
uid: Connector_help_Cellent_EMS
---

# Cellent EMS

The cellent EMS makes it possible to send text messages with an automation script using an http request.

## About

With an automation script the number and message separated by an '\|' can be given to this driver. After which the driver will process this information together with the information set on the driver itself like the username, password, etc. to make the http request. Statistics of the request and responses are kept next to a history table of the last messages.

Ranges of the driver

**This subsection can only be omitted in case of an exported driver**

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP main connection

Style: Heading 4 Intense Quote

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy* (by default).

## Usage

### General

On the **General** page the configuration of the http request can be made. Next to these parameters there are also some statistics.

### History

On this page a **History Table** is shown with the last 100 messages. The amount of rows in the history table can be changed.

## Notes

Special characters like '\[', '\]', '{', '}', 'æ', etc. can cause problems in the message. Http response gives an acknowledgment that text message has been send, but text message never arrives at cellphone.Best to check if the API of Cellent supports special characters.
