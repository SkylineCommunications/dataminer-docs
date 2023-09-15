---
uid: Connector_help_Amazon_AWS_EC2
---

# Amazon AWS EC2

Amazon Elastic Compute Cloud (Amazon EC2) is a web service that provides secure, resizable compute capacity in the cloud. It is designed to make web-scale cloud computing easier for developers.

Amazon EC2's simple web service allows you to easily obtain and configure capacity.

## About

### Version Info

| **Range**            | **Key Features**                         | **Based on** | **System Impact**        |
|----------------------|------------------------------------------|--------------|--------------------------|
| 1.0.0.x              | Initial version.                         | \-           | \-                       |
| 1.0.1.x \[SLC Main\] | Support for starting/stopping instances. | 1.0.0.3      | Removed HTTP connection. |

### Product Info

| **Range** | **Supported Firmware**                 |
|-----------|----------------------------------------|
| 1.0.0.x   | AWS Service - Production service 2021. |
| 1.0.1.x   | AWSSDK.EC2 3.7.113.5                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

This connector communicates with the AWS EC2 API.

The connector is intended to only work for a single region at a time, so each element created with this connector will only support one region. If you want to use the connector for multiple regions, create a different element for each region.

### Connections

#### HTTP Main Connection (range 1.0.0.x only)

This connector uses an HTTPS connection to communicate with the Amazon EC2 API to collect data. Each region should be interpreted as one Amazon AWS EC2 element.

More region information is available at <https://docs.aws.amazon.com/general/latest/gr/rande.html>. Select a region code and use it instead of **\#REGION#** in the URL mentioned below.

HTTP CONNECTION:

- **IP address/host**: *https://ec2.**\#REGION#**.amazonaws.com*

  For example, for Europe (Frankfurt): *https://ec2.**eu-central-1**.amazonaws.com*

- **IP port**: The IP port of the destination (default: *443*).

#### Virtual connection (range 1.0.1.x)

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

To securely interact with AWS APIs, go to the **General** page and fill in the **Access Key ID** and the **Secret Access Key**. If you are using range 1.0.1.x, also fill in the **Region Endpoint**.

We recommend that you create a dedicated IAM account user to use with DataMiner. To do so, follow these steps in your Amazon account:

1. Log in to your Amazon AWS account and access the IAM Management Console.
1. Go to Users and click Add User.
1. Create a user with a name of your choosing. We recommend the name *DataminerEc2Protocol*.
1. Make sure to grant Programmatic Access to the user account.
1. Make sure to grant policies for accessing the EC2 API.
1. Copy the **Access Key** and the **Secret Key** and paste them on the **General page** of the element.

   Note that these keys are only **generated once**, so you will not be able to recover them if you lose them. Make sure to store them in a safe location, as Skyline or Amazon cannot trace them back.

## How to Use

The **General** page features the Account ID, Access Key ID, and Secret Key. Apart from the Account ID, all keys are securely stored in DataMiner.

This **Instances** page provides an overview of all EC2 instances available for the specified region. In range **1.0.1.x**, the possibility to **start or stop instances** is also introduced.

The **Debug** page (available in range 1.0.1.x) contains a table with records of all interactions with AWS.
