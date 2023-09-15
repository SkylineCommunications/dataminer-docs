---
uid: Connector_help_Route_Mobile_SmsPlus
---

# Route Mobile SmsPlus

The **Route Mobile SmsPlus** is used to send text messages using an HTTP request. The connector is mainly used with an Automation script to send certain messages to customer mobile phones.

## About

The connector needs to be configured with the right username and password so that it can be authorized to deliver text messages. To be able to send a message, you also need to configure the sender ID and message type in the connector options. The receiver mobile number and message need to be combined with a pipe character ("\|") in the Automation text box. The connector will process all this information (username, password, sender ID, message type, recipient number and message) and make a HTTP request to deliver the message.

On the General page, all the message information, such as the recipient mobile number, the message and the time stamp of the message are displayed. This page also includes basic statistics such as the logging status, HTTP status code, total SMS messages, number of succeeded SMS messages and number of failed SMS messages.

The History page displays the history table, which includes messages that were sent from the device. It is possible to configure how many messages are displayed in this table.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.0.0                       |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy* (by default).

## Usage

### General

This section contains the following information:

- **Username**: The account username of Route Mobile.
- **Password**: The account password of Route Mobile.
- **Sender ID**: The sender ID of the message sender.
- **Message Type:** The type of message that needs to be sent.
- **Delivery Report:** Whether a delivery report is required or not.
- **Automation:** Combination of the recipient mobile number and message, separated by a pipe character ("\|").
- **Mobile Number:** The mobile number that will be processed by Automation.
- **Message:** The message that will be processed by Automation.
- **Date Time**: The date and time when the message is sent.
- **Logging**: The status of the sent message.
- **HTTP Status Code:** The status of the HTTP code.
- **HTTP Response:** The HTTP response when the message is processed correctly.
- **SMS Total Requests Sent:** The number of SMS requests sent.
- **SMS Succeeded**: The number of SMS requests that were successful.
- **SMS Failed:** The number of SMS requests that failed.

### History

This page contains the **History Table**, which shows the history of the sent messages, detailing whether they were sent successfully or failed to be delivered.

The **Maximum Number of Messages** parameter allows you to set how many messages are shown in the history table.

## Notes

Special characters like '\[', '\]', '{', '}', 'æ', etc. can cause problems in the message if an incorrect message type is chosen. It is best to check if the API of Route Mobile supports the special characters you want to use.
