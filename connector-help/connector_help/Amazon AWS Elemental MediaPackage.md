---
uid: Connector_help_Amazon_AWS_Elemental_MediaPackage
---

# Amazon AWS Elemental MediaPackage

AWS Elemental MediaPackage is a just-in-time packaging and origination service that lets you deliver highly secure and reliable live outputs and video-on-demand assets for a variety of devices.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x [Obsolete]</td>
<td><p>Lists following components from the AWS Elemental MediaPackage API:</p>
<ul>
<li>Channels</li>
<li>Origin Endpoints</li>
<li>Channel Operational Metrics</li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.0.1.x [SLC Main]</td>
<td>SNS subscription and message processing support.</td>
<td>1.0.0.2</td>
<td>A new IP connection has been added, requiring element configuration.</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware**                 |
|-----------|----------------------------------------|
| 1.0.0.x   | AWS Service - Production service 2021. |
| 1.0.1.x   | AWS Service - Production service 2021  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

This connector communicates with 2 AWS APIs, namely the Amazon MediaPackage and the Amazon CloudWatch API. It will also process CloudWatch SNS subscription messages that are sent from AWS.

The connector is intended to only work for a single region at a time, so each element created with this connector will only support one region.

To monitor multiple regions, create an element for each region.

To configure the connections, refer to the region information on the page <https://docs.aws.amazon.com/general/latest/gr/rande.html>. Collect the region code of your choice and use it ro replace **\#REGION#** within each URL as described below.

### Connections

#### HTTP Main Connection

This connector uses an HTTPS connection to communicate with the Amazon MediaPackage API to collect configuration data.

Each region should be interpreted as one Amazon AWS Elemental MediaPackage element.

HTTP CONNECTION:

- **IP address/host**: [https://mediapackage.**\#REGION#**.amazonaws.com](https://mediapackage./#REGION%23.amazonaws.com)
  For example, for Europe (Frankfurt): *https://mediapackage.****eu-central-1****.amazonaws.com*
- **IP port**: The IP port of the destination (default: *443).*

#### HTTP Connection - Monitoring Connection

This connector uses an HTTPS connection to communicate with the Amazon CloudWatch service to collect alarm data and metrics.

HTTP CONNECTION:

- **IP address/host**: [https://monitoring.**\#REGION#**.amazonaws.com](https://monitoring./#REGION%23.amazonaws.com)
  For example, for Europe (Frankfurt): [https://monitoring.**eu-central-1**.amazonaws.com](https://monitoring.eu-central-1.amazonaws.com/).
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### IP Connection - SNS Listener Connection

This connector listens on the specified port for CloudWatch SNS subscription messages

IP connection:

- **IP address/host**: The IP address of the DMS
- **IP port**: The IP port to listen on (default: *2000*).

### Initialization

In order to securely interact with AWS APIs, go to the General page and fill in the **Access Key ID** and the **Secret Access Key**. It is also advised that you create an IAM account specifically for DataMiner usage. To do so:

1.  Log in to your Amazon AWS Account and go to the IAM Management Console.
2.  Go to *Users* and click *Add User*.
3.  Create a user with a name of your choosing (we recommend "DataminerMediaPackageProtocol") and make sure to grant *Programmatic Access* to this account.
4.  Make sure to grant policies for accessing the MediaPackage and CloudWatch APIs (ReadOnly).
5.  Copy the **Access Key ID** and the **Secret Key** and paste them on the **General page** of the DataMiner element.
    Note that these **keys are only generated once**, so you will not be able to recover these if you lose them. Make sure to store them in a safe location as neither Skyline nor Amazon will be able to trace them back.

## How to Use

### General page

On the General page, you can specify the Access Key and the Secret Key, as detailed under "Initialization" above.

### Channels page

The Channels page displays the channels configured in the MediaPackage configured region.

Note: If no channels have any tags configured, the Channel Tags table will be empty.

### Origin Endpoints page

The Origin Endpoints page displays the origin endpoints configured in the MediaPackage configured region.

Note: If no origin endpoints have any tags configured, the Origin Endpoints Tags table will be empty.

### Channels Operational Metrics page

The Channels Operational Metrics page relies on the CloudWatch API and will only display values when the endpoint is actually getting metrics.

### SNS Messages page

The SNS Messages page displays the processed SNS messages (alarms) and information related to the SNS subscription.

Setting up SNS messages will allow the MediaPackage connector to receive real-time notifications raised by the AWS MediaPackage service, so that DataMiner does not have to wait for the polling interval to elapse to update the status information.

For this feature to work, SNS needs to be configured to send notifications to DataMiner. Typically, AWS SNS uses a public IP and DataMiner uses an internal network, and all the necessary network settings have to be applied to allow traffic in both directions between AWS SNS and DataMiner. Contact your IT department for support to implement this.

## Notes

The connector will only work as expected if **both connections are configured in the same region**. Configuring different regions in both connections is not supported.

The AWS API provides an interface for each region, so for multiple region representation of this service, please create a dedicated element for each region.

Multiple elements can also be created to monitor the same regions in order to apply different alarm/trend/information templates.
