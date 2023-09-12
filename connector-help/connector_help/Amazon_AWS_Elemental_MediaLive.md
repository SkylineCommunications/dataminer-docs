---
uid: Connector_help_Amazon_AWS_Elemental_MediaLive
---

# Amazon AWS Elemental MediaLive

AWS Elemental MediaLive is a video service that allows easy creation of live outputs for broadcast and streaming delivery.

This driver communicates with 2 AWS APIs, i.e. Amazon MediaLive and Amazon CloudWatch. It is intended to only work for **a single region at a time**. This means that each element created with this driver will only support one region. For multiple regions, you will have to create multiple elements using this driver.

## About

### Version Info

| **Range**            | **Key Features**                                                                 | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version containing Inputs Table, Channel Table and Channel Health Table. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                 |
|-----------|----------------------------------------|
| 1.0.0.x   | AWS Service - Production service 2021. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This driver communicates with 2 AWS APIs, i.e. Amazon MediaLive and Amazon CloudWatch. Both connections must be configured for the same region.

The region is specified in the IP address/host field of each connection, as described below.

#### HTTP Main Connection

This driver uses an HTTPS connection to communicate with the Amazon MediaLive API to collect configuration data.

HTTP CONNECTION:

- **IP address/host**: *https://medialive.****\#REGION#****.amazonaws.com*. \#REGION# is the Amazon AWS region code. For more information, see <https://docs.aws.amazon.com/general/latest/gr/rande.html>.
  For example, for Europe (Frankfurt), specify *https://medialive.**eu-central-1**.amazonaws.com*.
- **IP port**: The IP port of the destination (default: *443*).

#### HTTP Connection - Monitoring Connection

This driver uses an additional HTTPS connection to communicate with the Amazon CloudWatch service to collect alarm information and metrics.

HTTP CONNECTION:

- **IP address/host**: *https://monitoring.****\#REGION#****.amazonaws.com*. \#REGION# is the Amazon AWS region code. For more information, see <https://docs.aws.amazon.com/general/latest/gr/rande.html>.
  For example, for Europe (Frankfurt), specify *[https://monitoring.**eu-central-1**.amazonaws.com](https://monitoring.eu-central-1.amazonaws.com/)*.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To securely interact with the AWS APIs, go to the General page and fill in the **Access Key ID** and the **Secret Access Key.**

It is advised to create a dedicated IAM account user to use with DataMiner. To do so, follow these steps in your Amazon account:

1.  Log in to your Amazon AWS account and access the IAM Management Console.
2.  Go to Users and click Add User.
3.  Create a user with a name of your choosing. We recommend the name *DataminerMediaLiveProtocol*.
4.  Make sure to grant Programmatic Access to the user account.
5.  Make sure to grant policies for accessing the MediaLive and CloudWatch APIs.
6.  Copy the **Access Key** and the **Secret Key** and paste them on the **General page** of the element.
    Note that these keys are only **generated once**, so you will not be able to recover them if you lose them. Make sure to store them in a safe location, as Skyline or Amazon cannot trace them back.

## How to Use

The element consists of the following data pages:

- **General**: Features the Account ID, Access Key ID and Secret Key. Apart from the Account ID, all keys are securely stored in DataMiner.
- **Inputs**: Displays the inputs available in the configured MediaLive region.
- **Channels**: Displays the channels available in the configured MediaLive region.
- **Channels Health**: Relies on the CloudWatch API and will only display values when a channel is in a running state. Note that it can take up to 59 seconds to retrieve the data on this page.

## Notes

The driver will only work as expected if both connections are configured in the same region. Configuring different regions for the two connections is not supported. To monitor multiple regions, create a different element for each region using this same driver. You can also create multiple elements to monitor the same regions but apply different alarm, trend or information templates.
