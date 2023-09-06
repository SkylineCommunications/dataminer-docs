---
uid: Connector_help_OneWeb_Incident_Manager
---

# OneWeb Incident Manager

This connector allows you to create and update incidents on the OneWeb environment.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Go to the **Settings** page and set the **Username** and **Password** for the HTTP connection (parameters 100 and 102).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The parameter with ID **11** can be used to **send new incidents or incident updates** to the OneWeb environment. When you have set this parameter, a request will be sent to the system. In the Examples section below, you can find examples of such requests.

On the **General** page of the element, you can check the **incidents** that were reported as well as information about failed requests.

### Examples

New request:

       {

           "requestBody": {

               "shortDescription": "DataMiner Test",

               "description": "From 2pm yesterday, Sintra_SNP has been faulting",

               "impact": "Significant",

               "urgency": "High",

               "locationDescription": "Sintra",

               "configurationItemName": "Sintra_SNP",

               "categoryName": "Ground",

               "subCategoryName": "CGI",

               "comment": {

                   "commentary": "Please, update me on the status",

                   "raisedBy": "Test"

               },

               "externalReference": "TG09L8",

               "workforceIdentityId": "test@tester.com",

               "timeOccurred": "2021-07-05T18:09:11.604Z"

           }

       }

Update request:

       {

           "id": "INC0065422",

           "action" : "update",

           "requestBody": {

               "shortDescription": "DataMiner Test2",

               "description": "From 2pm yesterday, Sintra_SNP has been faulting",

               "impact": "Significant",

               "urgency": "High",

               "locationDescription": "Sintra",

               "configurationItemName": "Sintra_SNP",

               "categoryName": "Ground",

               "subCategoryName": "CGI",

               "comment": {

                   "commentary": "Please, update me on the status",

                   "raisedBy": "Test"

               },

               "externalReference": "TG09L8",

               "workforceIdentityId": "test@tester.com",

               "timeOccurred": "2021-07-05T18:09:11.604Z"

           }

       }

New request with an example of alarm information:

          {

              "alarm": {

                  "id": "151598/695/1471",

                  "properties": [{

                          "name": "ServiceHUB ID",

                          "value": "ID123"

                      }, {

                          "name": "ServiceHUB URL",

                          "value": "An url information"

                      }

                  ]

              },

              "requestBody": {

                  "shortDescription": "DataMiner Test",

                  "description": "From 2pm yesterday, Sintra_SNP has been faulting",

                  "impact": "Significant",

                  "urgency": "High",

                  "locationDescription": "Sintra",

                  "configurationItemName": "Sintra_SNP",

                  "categoryName": "Ground",

                  "subCategoryName": "CGI",

                  "comment": {

                      "commentary": "Please, update me on the status",

                      "raisedBy": "Test"

                  },

                  "externalReference": "TG09L8",

                  "workforceIdentityId": "test@tester.com",

                  "timeOccurred": "2021-07-05T18:09:11.604Z"

              }

          }
