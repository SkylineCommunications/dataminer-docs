---
uid: Connector_help_Fox_Corp_PlayBook_Manager
---

# Fox Corp PlayBook Manager

This connector interacts with the PlayBook API. It allows Health Check operations in both directions. It can receive requests from Playbook to create bookings and will reply to Playbook with status information and updates. To interact with DataMiner, it uses scripts to configure the system and receive updates.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                   |
|----------------------|------------------|--------------|-----------------------------------------------------|
| 1.0.0.x              | Initial version  | \-           | \-                                                  |
| 1.0.1.x \[SLC Main\] | Initial version  | 1.0.0.14     | Element data is lost because of the Unicode option. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial IP Connection

This connector uses a serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: *any*
  - **IP port**: *3000*

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://\[PlayBook address\]
- **IP port**: *443*
- **Bus address**: *bypassproxy*

### Initialization

When you have created the element:

- Configure the authentication parameters on the **Authentication** page. The authentication uses OAuth 2.0. You will need to specify the **URL**, **Client ID**, and **Client Secret**.
- On the **General** page, configure the **Listen Token**, **Integration Script**, **Health Check URL**,and **Update Booking URL** parameters (see "How to Use" section below).

## How to Use

The **Authentication** page contains the following settings and information:

- **Health Check Interval**: The interval in minutes at which the element will send health check messages to PlayBook.
- **Health Check Status**: The last status of the health check routine. Alarm monitoring is possible for this parameter.
- **Authentication URL**: The full URL used to initiate authentication to obtain a token, so that the element can send health check and update messages to PlayBook.
- **Authentication Client ID and Secret**: The ID and password to initiate the authentication.

The **General** page contains the following configuration parameters:

- **Listen Token:** A string value the element will validate to accept any message from PlayBook. The plain string has to be received in the header token (lower case).
- **Integration Script**: The name of the script that should be executed to update booking requests when a valid message arrives from PlayBook.
- **Show Debugging Page**: Shows or hides the Debug page.
- **Health Check URL**: The partial URL of the endpoint used to send a health check (ping). The full URL is composed by prepending the configured element's HTTP IP address/host to this parameter.
- **Update Booking URL**: The partial URL of the endpoint used to send autonomous update messages to PlayBook. The element's configuration is used to obtain a full URL, like for the Health Check URL
