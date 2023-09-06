---
uid: Connector_help_Google_Cloud_Compute_Engine
---

# Google Cloud Compute Engine

The Google Cloud Compute Engine is the Infrastructure-as-a-Service component of the Google Cloud Platform, which is built on the global infrastructure that runs Google's search engine, Gmail, YouTube, and other services. Google Cloud Compute Engine enables users to launch virtual machines on demand.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: *https://compute.googleapis.com*
- **IP port**: *443*

HTTP CONNECTION - Auth:

- **IP address/host**: *https://oauth2.googleapis.com*
- **IP port**: *443*

HTTP CONNECTION - Monitoring:

- **IP address/host**: *https://monitoring.googleapis.com*
- **IP port**: *443*

### Initialization

When the element has been created:

1.  On the General page, specify the Project ID, Client ID, Client Secret, Scope, and Redirect URI.
2.  Click **Get access code**. This will set the Access Code URL.
3.  Navigate to the URL. You will first need to go through permission steps, and then you will be able to copy the required code.
4.  Paste the code into the **Authorization Code** parameter. The Access Token will now be set, allowing you to poll data.

## How to use

The element created using this connector has the following data pages:

- **General**: This page display general information like the Project ID, Client ID, Client Secret, Scope, Redirect URI, and more.
- **Instances**: This page displays the **Instances and Instance Groups** tables.
- **CPU**: This page displays the **CPU Statistics** table.
- **Disk**: This page displays the **Disk** **Statistics** table.
- **Memory**: This page displays the **Memory** **Statistics** table.
- **Network**: This page displays the **Network Statistics** table.
- **Polling Configuration**: This page displays the **Polling Configuration** table, which you can use to set how often groups are polled.
