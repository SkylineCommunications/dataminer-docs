---
uid: Connector_help_Generic_SMPP_SMS_Sender
---

# Generic SMPP SMS Sender

This driver can be used to set up a (TCP/IP) connection with an SMS Center using the open, industry-standard Short Message Peer to Peer Protocol (**SMPP v3.4**). In this setup, DataMiner acts as the **ESME** (External Short Message Entity). It initiates an application layer connection with an SMSC over a TCP/IP and may then **send short messages (SMS)** to the SMSC, which will then forward the SMS to the final destination.

As such, this driver can be used to interface with any SMS Center that supports and is based on the standard SMPP specification v3.4.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.4                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

### Initialization

On the Configuration page you can find all configuration parameters that affect the initialization of the connection to the SMSC and the communication between DataMiner (as "ESME") and the "SMSC".

Make sure that at least **System ID** (= username) and **Password** are correct and match with the credentials needed to set up the connection with the SMSC. If no authentication is necessary, you can leave them blank. The same applies for the **Source Phone Number**.
The rest of the configuration parameters have default values which should be a good start when initiating a new element. In case default values do not work, you may need to get advice from people familiar with the SMSC for specific settings.

### Redundancy

There is no redundancy defined.

## How to use

Make sure all the parameters on the Configuration page are filled in. For some options, a time can be specified. To disable these options, fill in 0 seconds.

Once all parameters are configured and applied, it should be possible to send an SMS to a destination number from the General page. Fill in the text to be sent in the Message field and apply this change. Fill in the destination phone number (the mobile phone number to which the message needs to be sent) and apply this change. Make sure you start with the country code when filling in the destination phone number. For example, if a message needs to be sent to the number "+32 471 123456", fill in "32471123456". When all this has been filled in, click the **Send Message** button to send the message. A status message will show whether the message was sent successfully.

## Notes

This driver can be used in combination with an Automation script that fills in the message and phone number to initiate SMS notifications.
