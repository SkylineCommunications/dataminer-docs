---
uid: GQI_Ad_hoc_data_sources
description: For an ad hoc data source, add a correctly configured script in the Automation app and select 'Get ad hoc data' and your source in the query config.
---

# Ad hoc data sources

Each ad hoc data source for GQI is defined in an **Automation script library** by a **C# class** that implements specific [interfaces](xref:Ad_hoc_Building_blocks). Every time GQI requires information from the ad hoc data source, it will create a new instance of that class and call the relevant [life cycle](xref:Ad_hoc_Life_cycle) methods.

> [!TIP]
> To learn more about what you can do with ad hoc data sources, we highly recommend watching [Empower Replay: Create your own GQI data source](https://www.youtube.com/watch?v=rapRdkIRSHQ). ![Video](~/dataminer/images/video_Duo.png)

> [!IMPORTANT]
> To reduce complexity and maintainability, only create an ad hoc data source if it is not possible to use the built-in data sources and operators for the purpose you have in mind.
