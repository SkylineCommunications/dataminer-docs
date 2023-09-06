---
uid: Connector_help_Amazon_AWS_S3_File_Upload
---

# Amazon AWS S3 File Upload

This driver allows you to automatically upload files from a specific source directory to the Amazon Simple Storage Service (Amazon S3) cloud platform.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                     |
|-----------|----------------------------------------------------------------------------|
| 1.0.0.x   | Amazon S3 API 2006-03-01<https://docs.aws.amazon.com/AmazonS3/latest/dev/> |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Format: "*\<bucket name\>.s3.\<region\>.amazonaws.com*", e.g. "mybucket*.s3.eu-west-2.amazonaws.com*".
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

HTTP GET/POST/PUT/DELETE messages are used to communicate with the Amazon S3 API.

### Initialization

After creating a new element, you need to configure the following parameters:

- **Access Key** and **Secret Key**
- **Source Path**: The directory where the source files can be found.
- **Processing State**: Enable this parameter to start uploading the files.

### Redundancy

There is no redundancy defined.

## How to use

The purpose of this driver is to be able to upload files (specifically DataMiner backup files) towards the Amazon S3 cloud service using a DataMiner element.

At a configurable interval (by default every hour), files that are added to the configured source directory are automatically processed and uploaded if they match the filter. This filter is defined as a regular expression. When the name of the file matches the filter, the file will be uploaded; otherwise, it will be ignored. This can for example be used to only upload \*.dmbackup files that do not start with "\_current" (filter='^(?!current\_)(.\*\\dmbackup)\$').

To be able to identify each DMA backup package and the DMA that generated it, you can configure automatic conversion of the file name using placeholders, with the **Change Filename** parameter. If this parameter is empty, the original filename will be used. The following placeholders can be used:

- \<dmaId\>: ID of this DMA
- \<elementId\>: ID of this element
- \<createTime\>: Time when the file was created, format: *yyyyMMddHHmmss*
- \<filename\>: File name of the original file, without extension
- \<extension\>: The extension of the original file

The driver will automatically restart the copy process in case of a failure during the copy action, so that it can automatically recover from a temporary network outage.

Information events are created whenever a copy action starts, finishes or fails (error, connection error, etc.), to make sure that this information is available for long-term storage on the DMA. The last x (configurable) events are also available in the **Events Table**.

Successful file uploads are displayed in the **Upload History Table**, including the source file path, file size, start upload datetime, end upload datetime and average upload speed.
