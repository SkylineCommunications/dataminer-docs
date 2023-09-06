---
uid: Connector_help_Generic_Profile_Log_Manager
---

# Generic Profile Log Manager

This driver can be used as an extension to any SRM solution. It is capable of storing the history related to profile instances applied to resources. It allows you to track results from each profile application, as well as to easily consult all the profile applications and validations related to a specific booking.

## About

The profile instances application history is made using a serialized string of the ProfileInstanceData class.

The booking history records are made using a serialized string of the BookingData Class.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This driver uses a virtual connection and does not require any input during element creation.

## How to Use

The **Profile Instance History Data** page contains all the **Profile Instances Application** records. With the parameter **Max Number of Profile Instance History Records**, you can limit the number of records (from 1 to 10,000, with a default value of 1000).

The **Booking History Data** page contains all the **Profile Instances History** records associated with a resource from a booking. With the parameter **Max. Number of Booking History Records Table**, you can limit the number of records (from 1 to 10,000, with a default value of 1000).If the maximum number of rows is reached and a new record needs to be added, the oldest records will be discarded until the maximum number of allowed records is reached.

A script or driver can write to **parameter 11** of this driver with a serialized string of the **ProfileInstanceData** class:

For example:\[{ "Timestamp": "2019-02-28T21:18:26.972533+09:00", "ResourceGuid": "2024d578-ea4c-413f-b82e-f61f49ba60e9", "ResourceName": "LSM.1", "FunctionType": "LSM.1", "FunctionDVEName": "Sony LSM PWS-110NM1.LSM.1", "FunctionDVEID": "120302/1709", "ParentElementName": "Sony LSM PWS-110NM1", "ParentElementID": "120302/1708", "ProfileInstanceGuid": "8b1ed2f6-6568-4cca-a774-760981bf1ad9", "ProfileInstanceName": "MyLSM2", "ProfileMetadata": "", "Type": "Manual", "BookingGuid": "-1", "BookingName": "-1", "UserName": "Administrator", "State": "OK", "Custom": "False" }\]

| **Field** | **Description**                                                                                                              |
|-----------|------------------------------------------------------------------------------------------------------------------------------|
| Type      | Can be *Manual* or *Booking,* depending on whether the profile was applied manually or applied from a booking configuration. |
| State     | Can be *OK* or *Failed*, depending on whether the profile was correctly applied.                                             |
| Custom    | Indicates if the applied profile was customized by a user (which can be done in the wizard of the solution).                 |

A script or driver can write to **parameter 13** of this driver with a serialized string of the **BookingData** class:

For example:\[{ "BookingGuid": "9605b35a-deea-489c-8e01-7a55830fb67f", "BookingName": "Book6", "ResourceGuid": "60963486-1dec-4eeb-b58b-4583307475b4", "ResourceName": "ResourceName3", "FunctionType": "PWS4500", "ResourceDropped": "Yes", "Status":"Failed", "ApplyTimestamp":"4/5/2019 3:26:30 PM", "ValidateTimestamp":"4/5/2019 3:26:30 PM", }\]
