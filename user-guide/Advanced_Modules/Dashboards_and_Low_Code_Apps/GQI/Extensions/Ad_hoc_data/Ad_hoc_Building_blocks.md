---
uid: Ad_hoc_Building_blocks
---

# Building blocks of queries with ad hoc data

An ad hoc data source implements predefined interfaces that can be considered building blocks as they add the desired functionality to the data source.

The [*IGQIDataSource* interface](xref:GQI_IGQIDataSource) is the only required interface. It must be implemented for the class to be detected by GQI as a data source.

All other interfaces add additional functionality.

## Interfaces in the ad hoc data script

The available interfaces are:

- [IGQIDataSource](xref:GQI_IGQIDataSource): Be able to provide rows and columns.

  > [!IMPORTANT]
  > This is the only required interface. See also: [Configuring an ad hoc data source in a query](xref:Configuring_an_ad_hoc_data_source_in_a_query)

- [IGQIInputArguments](xref:GQI_IGQIInputArguments): Retrieve input from the user through input arguments.

- [IGQIOnDestroy](xref:GQI_IGQIOnDestroy): Can be implemented to clean up resources after it has been used.

- [IGQIOnInit](xref:GQI_IGQIOnInit): Can be implemented to get notified when the custom operator is created.

- [IGQIOnPrepareFetch](xref:GQI_IGQIOnPrepareFetch): Used to implement optimizations when data is retrieved.

- [IGQIUpdateable](xref:GQI_IGQIUpdateable): Be able to provide real-time updates. (available from DataMiner 10.4.4/10.5.0 onwards<!-- RN 38643 -->)