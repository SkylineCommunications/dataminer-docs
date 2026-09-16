---
uid: Get_parameters_for_elements_where
---

# Get parameters for elements where

The *Get parameters for elements where* data source retrieves parameters across elements. You can use it to compare metrics across devices and as input for further aggregation.

To ensure consistent parameter mapping across devices, elements must either share the same [protocol version](#by-protocol-version) or be linked to a [profile definition](#by-profile-definition).

From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44553-->, this data source can also query indexed logger tables stored in an Elasticsearch or OpenSearch database.

## By protocol version

Selecting a protocol and version retrieves parameters for all active elements that use the specified protocol version.

You can select either a table parameter or standalone parameters during query creation. If you select a table parameter, all columns from that table become available for query operators and the first 10 visible table columns will be included in the query result. From DataMiner 10.5.0 [CU18]/10.6.0 [CU6]/10.6.9 onwards<!--RN 45692-->, you can also choose to select a subset of table columns. In that case, only the selected columns will become available and they will automatically be included in the query result.

It is not possible to select multiple table parameters, combine a table parameter with standalone parameters, or mix columns from different tables.

> [!IMPORTANT]
> Retrieving table parameters from a mediated protocol is not supported. <!--RN 45539-->

## By profile definition

Selecting a profile definition retrieves parameters for all active elements of a specific protocol version that are linked to a profile parameter. You can use converters to align parameters across different protocol versions.
