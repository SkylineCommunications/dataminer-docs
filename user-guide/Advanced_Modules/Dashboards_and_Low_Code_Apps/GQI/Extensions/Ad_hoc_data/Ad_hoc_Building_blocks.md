---
uid: Ad_hoc_Building_blocks
---

# Building blocks of queries with ad hoc data

An ad hoc data source implements predefined interfaces that can be considered building blocks as they add the desired functionality to the data source.

The [*IGQIDataSource* interface](xref:IGQIDataSource) is the only required interface. It must be implemented for the class to be detected by GQI as a data source.

All other interfaces add additional functionality.

## Interfaces in the ad hoc data script

The available interfaces are:

- [IGQIDataSource](xref:IGQIDataSource)

  > [!IMPORTANT]
  > This is the only required interface. See also: [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query)

- [IGQIInputArguments](xref:IGQIInputArguments)

- [IGQIOnDestroy](xref:IGQIOnDestroy)

- [IGQIOnInit](xref:IGQIOnInit)

- [IGQIOnPrepareFetch](xref:IGQIOnPrepareFetch)

## Objects in the ad hoc data script

To build the ad hoc data source, you can use the following objects:

- [GQIArgument](xref:GQIArgument)

- [GQICell](xref:GQICell)

- [GQIColumn](xref:GQIColumn)

- [GQIDMS](xref:GQIDMS)

- [GQIPage](xref:GQIPage)

- [GQIRow](xref:GQIRow)
