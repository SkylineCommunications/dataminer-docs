---
uid: Get_resource_usages
---

# Get resource usages

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available in soft launch from DataMiner 10.3.9/10.4.0 onwards<!--RN 36231-->, the *Get resource usages* data source retrieves resource usage records in the DataMiner System. Each record includes the resource ID, booking ID, booking start, booking end.

When configuring this data source, you must first specify whether resource usages should be retrieved for resources of a **booking** or a **resource pool**.

- **Booking**: Retrieves all resources included in the specified booking and returns their usage records. If any of these resources are also used in other bookings, usage records for those bookings will be included as well.
- **Resource pool**: Retrieves all resources in the specified resource pool and returns the usage records for those resources.

> [!NOTE]
>
> - If a booking uses multiple resources, the query returns a separate record for each resource.
> - The *Get resource usages* data source is only available on DataMiner Systems with the appropriate license.
