---
uid: Get_parameters_for_elements_where
---

# Get parameters for elements where

The *Get parameters for elements where* data source retrieves parameters across elements. You can use it to compare metrics across devices and as input for further aggregation.

To ensure consistent parameter mapping across devices, elements must either share the same [protocol version](#by-protocol-version) or be linked to a [profile definition](#by-profile-definition).

From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44553-->, this data source can also query indexed logger tables stored in an Elasticsearch or OpenSearch database.

## By protocol version

Selecting a protocol and version retrieves parameters for all active elements that use the specified protocol version.

You can select both table parameters and standalone parameters during query creation. If you select a table parameter, all columns in that table become available for further query operators.

It is not possible to select multiple table parameters or combine a table parameter with standalone parameters.

> [!WARNING]
> Retrieving table parameters from a mediated protocol is not supported. <!--RN 45539-->

## By profile definition

Selecting a profile definition retrieves parameters for all active elements of a specific protocol version that are linked to a profile parameter. You can use converters to align parameters across different protocol versions.
