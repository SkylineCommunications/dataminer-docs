---
uid: Connector_help_Masternaut_Connect
---

# Masternaut Connect

This connector is used to monitor the Masternaut Connect device. The Masternaut Connect is a GPS system that communicates vital data from assets.

All device information is retrieved via HTTP.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v1.0                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- Interface connection:

  - **IP address/host**: The polling URL. e.g. <https://api.masternautconnect.com/connect-webservices/services/public/v1/customer/>.
  - **IP port**: The IP port of the device. e.g. *80*, *443*.
  - **Bus address**: Not required.

### Initialization

To allow full polling of the device, specify the **Customer ID** and **Password** on the General page of the element.

These parameters must be filled in to be able to make the API call to the device for information retrieval. In the background, these will be concatenated with the URL defined in the element configuration when making the connection with the device.

If necessary, you can also use the proxy server option on the General page.

### Redundancy

There is no redundancy defined.

## How to Use

Once the Customer ID and Password are filled in as detailed above, the data from the device will be displayed in the element.

You can fine-tune the polling state and polling frequency to your preference with the Polling State and Polling Frequency parameters.

On the Asset Information page, you can find asset information from the device.
