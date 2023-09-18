---
uid: Connector_help_Cellent_EMS
---

# Cellent EMS

The Cellent EMS makes it possible to send text messages with an Automation script using an HTTP request.

## About

With an Automation script, the number and message separated by an '\|' can be given to this connector.

After this, the connector will process this information together with the information set in the element like the username, password, etc. to make the HTTP request.

Statistics of the request and responses are kept next to a history table of the last messages.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Configuration

### Connections

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy* (by default).

## Usage

### General

On the **General** page, the configuration of the HTTP request can be done. Next to these parameters, there are also some statistics.

### History

On this page, a **History Table** is shown with the last 100 messages. The number of rows in the history table can be changed.

## Notes

Special characters like '\[', '\]', '{', '}', 'æ', etc. can cause problems in the message. A HTTP response acknowledges that a text message has been sent, but the text message never arrives. Check if the API of Cellent supports the special characters.
