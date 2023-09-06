---
uid: Connector_help_Dalet_Ooyala_Flex_Platform
---

# Dalet Ooyala Flex Platform

This driver integrates with the Ooyala Flex platform. It uses the REST API to retrieve information from the platform. It is capable of acting as a simple server listening for messages and sending basic replies.

## About

### range.

| **Range**            | **Key Features**                                                             | **Based on** | **System Impact**   |
|----------------------|------------------------------------------------------------------------------|--------------|---------------------|
| 1.0.0.x              | Initial version                                                              | \-           | \-                  |
| 1.0.1.x \[SLC Main\] | Add smart-serial connection to listen for messages from the Ooyala platform. | 1.0.0.1      | Adds new connection |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | Ooyala Flex 7.1 REST API |
| 1.0.1.x   | Ooyala Flex 7.1 REST API |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart Serial IP Connection

This driver uses a smart serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

- Interface connection:

<!-- -->

- **IP address/host**: any
- **IP port**: Default: *3000*.

#### HTTP Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: Ooyala endpoint HTTPS.
- **IP port**: Default: *443*.
- **Bus address**: *Bypassproxy*

### Initialization

Specify the **Username** and **Password** on the **General** page. These credentials are used to retrieve the information via the REST API.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

The element created with this driver consists of the following data pages:

- **General**: Allows you to configure the **Username** and **Password** credentials to authenticate with the API.
- **Resources/Actions/Profiles**: These pages each contain a table with information on resources, actions and profiles, respectively.
- **Workflows**: Contains the Workflows table, as well as a toggle button that allows you to enable or disable the polling of the workflows, as this is a large table.
- **Messages**: Displays the **Ooyala Flex Messages** table, as well as the message and response. You can define the maximum number of messages that can be kept in the table.
