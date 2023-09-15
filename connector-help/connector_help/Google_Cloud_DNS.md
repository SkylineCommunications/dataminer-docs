---
uid: Connector_help_Google_Cloud_DNS
---

# Google Cloud DNS

This connector manages Google Cloud DNS, which is a high-performance, resilient, global Domain Name System (DNS) service.

## About

Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP Connection - Auth

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created:

1. On the **General** page, specify the Project ID, Client ID, Client Secret, Scope, and Redirect URI.
1. Click **Get access code**. This will set the Access Code URL.
1. Navigate to the URL. You will first need to go through permission steps, and then you will be able to copy the required code.
1. Paste the code into the **Authorization Code** parameter. The Access Token will now be set, allowing you to poll data.

## How to use

The DNS Zones page shows each of the managed zones, while each of the **Records** pages show the zones' corresponding records (A, SOA, CNAME, and NS). You can configure the polling cycles on the **Polling Configuration** page.
