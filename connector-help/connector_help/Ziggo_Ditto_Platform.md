---
uid: Connector_help_Ziggo_Ditto_Platform
---

# Ziggo Ditto Platform

The **Ziggo Ditto Platform** is a VOD Server.

## About

HTTP connector for the **Ziggo Ditto Platform** connector, which serves as an intermediary in request/response communication between VoD Workflow Manager/SmartRec elements and the Ditto Environment.

### Ranges of the connector

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Creation

### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION (Connection to Ditto Server):

- IP address/host: The polling IP or URL of the destination.
- IP port: The IP port of the destination, *default 80*.
- Bus address: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

General Page

The **General** page displays parameters such as:

- **Server Hostname,** Ditto server hostname
- **VoD Workflow Manager DMA ID**
- **VoD Workflow Manager Element ID**
- **VoD Workflow Manager Rejected Assets Parameter ID**
- **VoD Workflow Manager Asset Status Parameter ID**

Communication

Communication between all elements and the Ditto server is done through the exchange of JSON messages.

#### Get Ditto Content Platforms

##### JSON query message on ParamID = 1003

{"RequestID":"123","CRID":"bds.tv/6152569","DmaID":"24453","ElementID":"110","ParamID":"1000"}

##### JSON response message with Ditto results

{"CRID":"bds.tv/6152569","platforms":\["CMDC","TRAXIS","MSS","RENG","SMARTREC","OESP"\],"RequestID":"123"}

#### Get Rejected Assets

##### JSON query message on ParamID = 1004

{"RequestID":"456","StartTime":"2015-05-27T13:30:08.793Z","EndTime":"2016-05-27T14:30:08.793Z"}

##### JSON query message sent to VoD Worfklow Manager

{"RequestID":"456","StartTime":"2015-05-27T13:30:08.793Z","EndTime":"2016-05-27T14:30:08.793Z","DmaID":"24453","ElementID":"109","ParamID":"2001"}

##### Suggested VoD Worfklow Manager JSON response to receive in ParamID sent in previous query (ParamID = 2001)

{

"RequestID": "1234",

"Assets": \[

{

"ProviderID": "45",

"AssetID": "67",

"RejectionReason": "Error"

},

{

"ProviderID": "89",

"AssetID": "01",

"RejectionReason": "Error n2"

}

\]

}

#### Get Asset Status

##### JSON query message on ParamID = 1005

{"RequestID":"456","CRID":"bds.tv/6152569"}

##### JSON query message sent to VoD Worfklow Manager

{"CRID":"bds.tv/6152569","DmaID":"24453","ElementID":"109","ParamID":"2002","RequestID":"456"}

##### Suggested VoD Worfklow Manager JSON response to receive in ParamID sent in previous query (ParamID = 2002)

{

"RequestID": "1234",

"ProviderID": "45",

"AssetID": "67",

"AssetStatus": " Active"

}
