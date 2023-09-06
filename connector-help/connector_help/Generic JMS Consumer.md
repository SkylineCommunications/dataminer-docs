---
uid: Connector_help_Generic_JMS_Consumer
---

# Generic JMS Consumer

WebLogic Java Message Service (JMS) is an enterprise-level messaging system. It allows applications to create, send, receive, and read messages. The JMS API defines a common set of interfaces and associated semantics that allow programs written in the Java programming language to communicate with other messaging implementations.

The **Generic JMS Consumer** is the WebLogic JMS .NET client application that subscribes to the JMS API and reads messages (asynchronously) from the queue. The **Generic JMS** **Producer** will publish (i.e. write) events/messages to the JMS AP. The producer and consumerfunction fully independently.

## About

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 12.2                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To connect to the JMS server, on the **Connection** page, specify the Host IP and Port, Factory name, Queue name, Username (optional), and Password (optional).

## How to use

On the **General** page of the element, you can verify if the connection to the JSM server was correctly established. If that is not the case, either the server is not accessible to the connector, or the initial configuration mentioned above is incorrect. In that case, go to the **Connection** page and check if the parameters are correctly filled in.

On the **Connection** page, you can fill in the initial configuration information required to connect to the JMS server. If these parameters have just been filled in or modified, you can reconnect by clicking the **Reconnect** button at the bottom of this page. You can also send the messages that are received by the queue to an external script. For this purpose, enable the parameter **Send to Script** and specify the name of the script. Note that the script should have an **input parameter named "JMS Message"**.

To establish a network connection to the WebLogic Server host, the IP:port information must be specified in the **Host Address** parameter. Multiple addresses can be specified, separated by commas. However, note that you should specify the **host name instead of the IP address**. When multiple addresses are specified, the connector tries each address in turn until one succeeds or they all fail, starting at a random location within the list of addresses, and rotating through all addresses. Starting at a random location facilitates load balancing of multiple clients, as different clients will randomly load balance their network connection to different .NET client host servers.

On the **Consumer** page, you can see the last message that was received from the JMS queue. The **Consumer Action** parameter indicates whether the forwarding of the message to the script (if activated) was correctly executed.
