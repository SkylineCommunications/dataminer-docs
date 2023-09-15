---
uid: Connector_help_Ziggo_IPVPN_Provisioning
---

# Ziggo IPVPN Provisioning

The **Ziggo IPVPN Provisioning** connector can be used to create, update and delete modem info on the Ziggo IPVPN CPE setup through HTTP POST JSON messages. It can also update the modem info through automatic provisioning via CSV files.

## About

The Ziggo IPVPN Provisioning connector will launch a self-hosted web service and will listen for incoming HTTP POST JSON messages. It will also periodically check for files to ingest.

It will then create IAM DSL files and will call the **Skyline IAM DB** element to load the DSL file into the IAM DB. After this, it will call the provisioning on the CPE setup.

With this element, the configuration for the classifier names will be done, which the **Ziggo IPVPN Collector** elements need. Only one **Ziggo IPVPN Provisioning** element is needed for the entire CPE setup.

This is a virtual connector, so no data traffic will be displayed in the Stream Viewer.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the web service

On the **General** page, the following parameters need to be configured:

- **Web Service Port**: The TCP port on which the web service will be listening for incoming requests. As soon as a value is filled in here, the web service will be launched. The **Web Service State** will show whether it is active or not.
- **DSL Folder Location**: The directory where the created DSL files will be placed.
- **IAM DmaId/ElID**: The ID of the **Skyline IAM DB** element. This element will be responsible for picking up the DSL files and uploading them into the IAM DB.
- **User Name** and **Password**: The credentials that an HTTP POST needs to contain to be valid.

### Configuration of the classifier names

On the **QoS Classifier Name** page, for every vendor, the voice, video, and default-class classifier names can be configured in the **QoS Classifier Config** table. These values will be distributed to be used by every **Ziggo IPVPN Collector** element. You can add or remove vendors in the table via the table right-click menu. You can modify the values for every type of classifier name directly by using the write parameter of the table cell.

### Configuration of the Feeds table

In the **Feeds** table on the **General** page, the **Delivery Folder** and **History Folder** columns need to be configured for each feed. The folders must be created beforehand.

## Usage

For more information on the usage of the connector, refer to the sections above.

## Notes

### Automatic provisioning via CSV

#### General

The purpose of the automatic provisioning is to update enrichment data of already provisioned CPEs.

There are four different sources that can provide CSV files to DataMiner, which are displayed in the **Feeds** table of the **General** page:

- **CRM feed**: This will update the **Customer Relation ID** and the **Customer Relation Name** for a given **Service ID**. The **Service ID** in the CSV will identify the CPE or CPEs that need to be updated. All fields are mandatory.

- CSV header: service_id, customer_relation_id and customer_name.

- **CPE status feed**: This will update the **CPE status**. The **Hostname** in the CSV will identify the CPE that has to be updated. All fields are mandatory.

- CSV header: hostname and cpe_status.

- **TP feed**: This will update the **HFC technical path**. The **Hostname** in the CSV will identify the CPE that has to be updated. All fields are mandatory.

- CSV header: hostname and technical_path_cpe

- **IM feed**: This will update the inventory information and contains among others the same information as the CPE status feed and the TP feed. You can configure to omit the CPE Status field from the IM feed by disabling **CPE Status From IM Feed** parameter.

- More information is available in the IM FEED section below.

#### Feeds table

The **Feeds** table is displayed on the **General** page. It contains 4 entries (for each feed type) and contains the following configuration/information:

- **Source**: The type of feed.

- **State**: Whether the feed has to be processed or not.

- **Clean**: Whether the files in the **Delivery Folder** will be removed when a feed is enabled.

- **Delivery Folder**: The directory where the connector will periodically search for files to ingest.

- **History Folder**: The directory where the files will be moved after they have been processed (successfully or not).

- **Frequency**: The frequency at which the folder has to be checked.

- **Number of Files**: The number of files in the **Delivery Folder**.

- **Status**: The status of the last ingest. Possible values are:

- *File(s) ingested:* CSV files were found and zero or more entries were processed.
  - *No file(s) found:* No CSV files were found on the specified directory
  - *Ingest Error:* An error occurred while trying to find, open or process the CSV files.

- **Error Message**: This will contain an error message related to the last ingest in case the **Status** is *Ingest Error*.

- **Timestamp**: The most recent timestamp when files were last ingested.

- **Successful Entries**: The number of entries in all files that were successfully processed, when files were last ingested.

- **Discarded Entries**: The number of entries in all files that were discarded, when files were last ingested.

- **Move**: A button that moves the files from the **Delivery Folder** to the **History Folder**.

- **Ingest**: A button that starts the process of ingesting the CSV files in the **Delivery folder**.

#### IM feed

The CSV header of the IM feed should contain the following fields: **hostname**, **service_type**, **service_id**, **accesses_access_type**, **accesses_access_name**, cpe_status, location_city, location_street, accesses_technical_path_cpe and accesses_modem_mac.

The fields above in **bold** are mandatory fields that serve as a reference to identify the CPE that needs to be updated. The **service_id** field is adapted to just acknowledge the last 3 octets. The entries with **accesses_access_type** equal to *Coax* are interpreted as *HFC.*

The IM feed can be used to update the following CPE information:

- **CPE Status**: When the **CPE Status From IM Feed** parameter is enabled and when this field contains a value, it will be updated.
- **Location City**
- **Location Street**
- **Technical Path**: This field will only be updated when the **Access Type** for this entry in the CSV file equals *HFC* or *Coax.*
- **Modem MAC**: This field will only be updated when the **Access Type** for this entry in the CSV file equals *HFC* or *Coax.*

Since the content of the **IM feed** contains enrichment data that is also supplied by the **TP** and **CPE Status feed**, the following mechanism is set to prevent any conflict between feeds:

- When the **IM Feed** is *enabled*:

- The **TP feed** will be *disabled.*
  - The **CPE Status From IM Feed** parameter will be *disabled*.

- The **CPE Status From IM Feed** parameter can only be *enabled* when the **IM feed** is *disabled.*

- When the **CPE Status From IM Feed** parameter is *enabled*:

- The **CPE Status feed** will be *disabled.*

- The **TP feed** and **CPE Status feed** cannot be *enabled* if the **IM feed** is also *enabled.*

### HTTP POST / JSON

#### TCP Port

- Only one entity can listen to a TCP port. This means that no more than one element can be created to listen to the same TCP port on the same DMA.
- Do not forget to modify the firewall to allow incoming traffic on the configured TCP port.

#### Result codes

Based on whether or not the HTTP POST succeeds or fails, the following result codes will return. Only when result code 100 returns, can the action be considered to have succeeded. In all other cases, something went wrong.

| **Result Code** | **Result Message**                                                            |
|-----------------|-------------------------------------------------------------------------------|
| 100             | Successful action                                                             |
| 201             | *xxx* is a mandatory field and is not provided                                |
| 202             | *xxx* does not contain a valid IPv4 format                                    |
| 203             | *xxx* is a mandatory field and is empty                                       |
| 204             | *xxx* does not contain a valid value *yyy*, allowed values are *zzz*          |
| 205             | Timeout when sending request to element                                       |
| 206             | Error when trying to read out element                                         |
| 207             | Exception encountered: *xxx*                                                  |
| 208             | IAM parameters not correctly configured                                       |
| 301             | SQL error when trying to upload DSL file                                      |
| 302             | Unknown action in DSL file: only 'create', 'update', and 'delete' are allowed |
| 303             | Trying to create an item that already exists                                  |
| 304             | Trying to update an item that does not exist                                  |
| 305             | Trying to delete an item that does not exist                                  |
| 306             | SQL result unknown                                                            |
| 401             | Unauthorized                                                                  |

#### JSON Example

Items below in **bold** are mandatory for creation. A hostname is the identifier and must always be specified and an operation must also always be included.
Possible values for "operation" are: *create*, *update*, and *delete*. To delete an item, only the operation and hostname need to be specified.

    {
       "operation" : "create",
       "hostname" : "BDH-1171GX-21-AR001",
       "model_name" : "AR169FGW-L",
       "mgmt_ip" : "198.18.0.88",
       "cpe_status" : "planned",
       "customer" : {
          "customer_relation_id" : "EXT117117",
          "customer_name" : "HFC UPC met VDSL backup"
       },
       "location" : {
          "location_house_nr_extension" : "",
          "location_street" : "Uiverstraat",
          "location_zip_code" : "1171GX",
          "location_city" : "Badhoevedorp",
          "location_house_nr" : "21"
       },
       "services" : [
          {
             "service_type" : "IP VPN Premium",
             "service_id" : "IP VPN-135.598.747",
             "qos_profile" : "VO2-MM-BC"
          }
       ],
       "accesses" : [
          {
             "access_name" : "Access-135.598.748",
             "modem_mac" : "",
             "technical_path_cpe" : "",
             "access_type" : "HFC"
          },
          {
             "access_name" : "Access-135.598.748",
             "access_type" : "DSL",
             "technical_path_cpe" : "",
             "modem_mac" : ""
          }
       ],
       "cpe_interfaces" : [
          {
             "if_name" : "GigabitEthernet0/0/2",
             "function" : "Customer|IP VPN-135.598.747"
          },
          {
             "function" : "Customer|IP VPN-135.598.747",
             "if_name" : "GigabitEthernet0/0/3"
          },
          {
             "if_name" : "GigabitEthernet0/0/0",
             "function" : "Customer|IP VPN-135.598.747"
          },
          {
             "if_name" : "GigabitEthernet0/0/1",
             "function" : "Customer|IP VPN-135.598.747"
          },
          {
             "if_name" : "GigabitEthernet0/0/4",
             "function" : "Main Uplink|Access-135.598.748"
          },
          {
             "if_name" : "GigabitEthernet0/0/4.100",
             "function" : "Main Prod Uplink|IP VPN-135.598.747",
             "ip_address" : "217.105.224.6",
             "ip_prefix" : "29"
          },
          {
             "if_name" : "GigabitEthernet0/0/4.99",
             "function" : "Main Uplink Management"
          },
          {
             "if_name" : "Ethernet0/0/0",
             "function" : "Backup Uplink|Access-135.598.748"
          },
          {
             "ip_prefix" : "29",
             "ip_address" : "217.105.224.14",
             "function" : "Backup Prod Uplink|IP VPN-135.598.747",
             "if_name" : "Ethernet0/0/0.100"
          },
          {
             "function" : "Backup Uplink management",
             "if_name" : "Ethernet0/0/0.99"
          }
       ]
    }
