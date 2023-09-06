---
uid: Connector_help_Amazon_AWS_CloudWatch
---

# Amazon AWS CloudWatch

Amazon CloudWatch is a **monitoring and management service** built for developers, system operators, site reliability engineers (SRE), and IT managers.

CloudWatch provides you with data and actionable insights to monitor your applications, understand and respond to system-wide performance changes, optimize resource utilization, and get a unified view of operational health. CloudWatch collects monitoring and operational data in the form of logs, metrics and events, providing you with a unified view of AWS resources, applications and services that run on AWS, and on-premises servers. You can use CloudWatch to set high-resolution alarms, visualize logs and metrics side by side, take automated actions, troubleshoot issues, and discover insights to optimize your applications and ensure they are running smoothly.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                  |
|----------------------|------------------|--------------|----------------------------------------------------|
| 1.0.0.x              | Initial version  | \-           | \-                                                 |
| 1.0.1.x \[SLC Main\] | Initial version  | 1.0.0.7      | Adds connection to receive SNS HTTP notifications. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 20100801               |
| 1.0.1.x   | 20100801               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | Amazon AWS CloudWatch - API Gateway Amazon AWS CloudWatch - Direct Connect Amazon AWS CloudWatch - EC2 Amazon AWS CloudWatch - EC2 Spot Fleet Amazon AWS CloudWatch - MediaPackage Amazon AWS CloudWatch - S3 Amazon AWS CloudWatch - Transit Gateway Amazon AWS CloudWatch - Kinesis Data Streams Amazon AWS CloudWatch - Lambda Amazon AWS CloudWatch - Media Connect Amazon AWS CloudWatch - Simple Notification Service Amazon AWS CloudWatch - VPC NAT Gateway Amazon AWS CloudWatch - VPC VPN Amazon AWS CloudWatch - Route 53 Amazon AWS CloudWatch - Cognito Amazon AWS CloudWatch - Network ELB |
| 1.0.1.x   | No                  | Yes                     | \-                    | Amazon AWS CloudWatch - API Gateway Amazon AWS CloudWatch - Direct Connect Amazon AWS CloudWatch - EC2 Amazon AWS CloudWatch - EC2 Spot Fleet Amazon AWS CloudWatch - MediaPackage Amazon AWS CloudWatch - S3 Amazon AWS CloudWatch - Transit Gateway Amazon AWS CloudWatch - Kinesis Data Streams Amazon AWS CloudWatch - Lambda Amazon AWS CloudWatch - Media Connect Amazon AWS CloudWatch - Simple Notification Service Amazon AWS CloudWatch - VPC NAT Gateway Amazon AWS CloudWatch - VPC VPN Amazon AWS CloudWatch - Route 53 Amazon AWS CloudWatch - Cognito Amazon AWS CloudWatch - Network ELB |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The monitoring AWS URL from the desired region. The URL should have the following structure: *monitoring.\<region\>.amazonaws.com*.
- **IP port**: The IP port of the device.
- **Bus address**: Specify *bypassproxy* if the proxy server has to be bypassed.

IP Connection

This driver uses a smart-serial connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** Any.
- **IP port**: The IP port on which the driver will listen for SNS HTTP notifications.
- **Bus address**: Specify *bypassproxy* if the proxy server has to be bypassed.

### Initialization

Before polling can start, you first need to enter the credentials on the **General** page. The **Access Key** and **Secret Key** must always be filled in. **Session Token** only has to be filled in if credentials for a temporary user are being used.

## Usage

HTTP POST messages are used to communicate with the Amazon AWS CloudWatch. This driver will export different drivers based on the retrieved data. A list can be found in the section "Exported Drivers".

### General

This page contains **Login** options, as well as information on which services should be polled with this element. To make sure that the driver can work properly, you **must** **first provide login information**.

First specify the **Default Polling Interval** and **Default Poll All Metrics** column values of the Amazon Services table. These are the values that will be applied when a new service entry has been added. Changing these values will have no impact on existing **Service Entries**. If **Default Polling Interval** has a value other than *Disabled*, a DVE element will be created and the enabled metrics will be polled at the specified polling interval. If **Default Poll All Metrics** is *Enabled*, all available metrics will be polled by the DVE at the configured polling interval.

**Warning**: Amazon may charge when metrics are polled. Enabling the polling of all metrics by default could come with an additional cost.

Specify which services should be polled with the **Poll** column of the **Amazon Services** table by setting the appropriate service row to *Enabled*. **Warning**: Setting this to *Disabled* will remove existing DVE elements of this service.
Discovered entries will be added to the **Service Entries** table.

### SNS Debug

This page contains **Account** information. If a received message does not match the account, it will not be processed. The page also contains information about the topic that is currently subscribed and the SNS service that is sending the notifications.

It also displays information on the last received notification.

### Service Entries

On this page, you can control DVE creation. With the **Automatic Delete Service Entries** parameter, you can set entries to be automatically removed. With the **Get Service Entries** button, you can refresh the **Service Entries** table.

With the **Name** column of the **Service Entries** table, you can change a DVE element name. You can create a DVE element by setting the **Polling Interval** to a different value than *Disabled.* Setting **Poll All Metrics** allows you to enable or disable the polling of all metrics of the DVE. You can remove a DVE element by clicking the **Delete** button; however, this can only be done when the **Polling Interval** is *Disabled* or the **Status** has the *Fail* value.

### Other Pages

The driver provides a page per supported service type. These pages contain the table that is used to export DVE elements and a table that allows you to configure the polling of each metric. The polling is spread so that not all DVE elements poll at the same interval. To immediately poll the enabled metrics of a DVE, click the **Force Polling** column button. Use the context menus of the tables for a quicker configuration, to set the **Polling Interval** or to **Poll All Metrics** for multiple selected DVE rows.

## Notes

It is not possible to set the Poll parameter to *Enabled* for metric parameters that have the *N/A* value. These *N/A* metrics are not present in the provided metrics list for this instance and hence their Poll parameter will remain *Disabled*.
