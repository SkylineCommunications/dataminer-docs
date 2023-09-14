---
uid: Connector_help_EventIS_TraxIS
---

# EventIS TraxIS

This connector is an interface towards the TraxIS platform.

## About

This connector will query the TraxIS platform to retrieve the Package ID or Product ID of resources.

XML over HTTP calls are used to query resources on the TraxIS Platform.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: default 80
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### HTTP Backup connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: default 80
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Usage

### General

Setting **Query Asset** (pid 101) with a correct JSON request will query the TraxIS platfrom for the Package or Product ID. If no result is found, the backup connection is used for a new attempt.

example: {"ResourceType":"Title","ADIs":\[{"ResultID":null,"ProviderID":"35300","AssetID":"HBO_M_141020_M74899","PK":"35300.HBO_M_141020_M74899"}\],"DmaID":"24453","ElementID":"2","ParamID":"98","RequestID":null}
