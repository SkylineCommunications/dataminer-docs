---
uid: Ad_hoc_Building_blocks
---

# Building blocks of an ad hoc data source

An ad hoc data source implements predefined interfaces that act as building blocks that each add a desired functionality and that can be combined together to form the data source.

The [*IGQIDataSource* interface](xref:GQI_IGQIDataSource) is the only required interface. It must be implemented for the class to be detected by GQI as a data source.

All other interfaces add additional functionality.

## Interfaces

The available interfaces are:

- [IGQIDataSource](xref:GQI_IGQIDataSource): Makes it possible to provide rows and columns.

  > [!IMPORTANT]
  > This is the only required interface. See also: [Ad hoc data sources](xref:GQI_Ad_hoc_data_sources)

- [IGQIInputArguments](xref:GQI_IGQIInputArguments): Retrieves input from the user through input arguments.

- [IGQIOnDestroy](xref:GQI_IGQIOnDestroy): Can be implemented to clean up resources after it has been used.

- [IGQIOnInit](xref:GQI_IGQIOnInit): Provides a way to initialize the data source with access to dependencies like the DMS.

- [IGQIOnPrepareFetch](xref:GQI_IGQIOnPrepareFetch): Used in order to implement optimizations when data is retrieved.

- [IGQIUpdateable](xref:GQI_IGQIUpdateable): Makes it possible to provide real-time updates (available from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->).

- [IGQIOptimizableDataSource](xref:GQI_IGQIOptimizableDataSource): Can be used to optimize an ad hoc data source based on operators added to the query (available from DataMiner 10.5.0 [CU2]/10.5.5 onwards when using the [GQI DxM](xref:GQI_DxM)<!-- RN42528 -->).
