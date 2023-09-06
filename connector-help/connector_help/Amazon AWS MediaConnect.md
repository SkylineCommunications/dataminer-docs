---
uid: Connector_help_Amazon_AWS_MediaConnect
---

# Amazon AWS MediaConnect

This connector implements part of the communication with the AWS Elemental MediaConnect REST API, AWS CloudWatch REST API, and AWS SNS REST API. Its goal is to retrieve information related to AWS MediaConnect flows and their related metrics. The connector is capable of receiving unsolicited messages from SNS topics related to MediaConnect Flow Alarms. These will be used to poll the related flow metrics.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                              |
|----------------------|------------------|--------------|------------------------------------------------|
| 1.0.0.x              | Initial version  | \-           | \-                                             |
| 1.0.1.x \[SLC Main\] | Initial version  | 1.0.0.9      | Supports new flow types. Changes in discreets. |

### Product Info

| **Range** | **Supported Firmware**                                         |
|-----------|----------------------------------------------------------------|
| 1.0.0.x   | AWS Elemental MediaConnectAWS CloudWatchAWS SNS                |
| 1.0.1.x   | AWS Elemental MediaConnectAWS CloudWatchAWS SNSAWS EventBridge |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP MediaConnect connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP Connection - MediaConnect:

- **IP address/host**: https://mediaconnect.\[region\].amazonaws.com
- **IP port**: Default 433
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### HTTP Monitoring connection

The connector uses an additional HTTP connection for monitoring, for which it requires the following input during element creation:

HTTP Connection - Monitoring:

- **IP address/host**: https://monitoring.\[region\].amazonaws.com
- **IP port**: Default 443
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### IP connection

This is a smart-serial connection acting as a server to receive HTTP notifications from SNS.

- **IP address/host**: any
- **IP port**: Default 2000
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

In order to communicate with the AWS REST APIs, on the **General** page, the **Account**, **Access Key ID**, and **Secret Access Key** must be filled in.

## How to Use

The element created with this connector consists of the following data pages:

- **General**: Contains the parameters **Account**, **Access Key ID**, and **Secret Access Key**, which are used for authentication and verification. The parameters SNS URL and SNS Topic ARN contain the information related to the SNS subscription topic from which the connector received unsolicited messages.
- **SNS Debug**: The parameter **SNS Message** contains the last received SNS message. This can be used for debug purposes to determine which information was received.
- **Flow Tree**: Contains a tree control that shows the current flows. For each flow, there is a tab with **Sources**, **Outputs**, and **Metrics**.
- **Flows Page:** Contains the **Flows** table, with the information for the list flows operation. The table only contains the flows present in the AWS Availability Zone specified in the connection. It is possible to start or stop a flow. The **Polling Status** parameter allows you to configure if additional information about the flow should be retrieved. If this parameter is enabled, the connector will schedule a request to retrieve the flow description with information about **Sources** and **Outputs**, and it will also schedule to retrieve **Flow** and **Source** **Metrics.** The parameter **Polling Frequency** allows you to determine how often this operation should be scheduled per flow. The parameter **Last Polled** shows when additional information was last requested for a flow.
- **Sources**: Contains the **Sources** table, which is linked to the **Flows** table. It contains source-related information such as the **Protocol**, **Ingest Port**, **Max Bitrate**, **Max Latency**, **Whitelist CIDR**, and **Ingest IP**.
- **Outputs**: Contains the **Outputs** table, which is linked to the **Flows** table. It contains output-related information such as the **Destination**, **Port**,and **Protocol**.
- **Entitlements**: Contains the **Entitlements** table, which displays the **Data Subscriber Fee Percent**.
- **Flow Metric**: Contains the **Flow Metrics** table, which is linked to the **Flows** table. It contains 53 metrics related to a flow. This information is retrieved from CloudWatch. In case a notification is received via **SNS** for a flow, the related metrics will be polled again.
- **Source Metric**: Contains the **Source Metrics** table, which is linked to the **Sources** table. It contains 26 metrics related to a source. This information is retrieved from CloudWatch.
