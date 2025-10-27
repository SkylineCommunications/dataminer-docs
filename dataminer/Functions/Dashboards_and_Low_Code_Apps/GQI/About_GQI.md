---
uid: About_GQI
---

# About the Generic Query Interface

The Generic Query Interface is designed to retrieve and manipulate data from both inside and outside a DataMiner System. Its output is presented in a tabular format and is independent of the underlying data structure, effectively functioning as a flexible abstraction layer.

With operators, the retrieved data can be transformed, so that you can shape the output according to specific requirements. To display the retrieved data, you can use visualizations in dashboards and low-code apps, making it easy for users to access and understand the information.

Various analytical tools are also available for in-depth examination of the retrieved dataset, empowering users to extract valuable insights and make informed decisions.

![GQI concept](~/dataminer/images/gqi_concept.png)

> [!TIP]
> You can also schedule GQI queries to run periodically at fixed times, dates, or intervals using the [Data Aggregator module](xref:Data_Aggregator_DxM).

## What are queries?

A query defines the data to be accessed and the transformations to be applied.

It comprises:

- A single **data source**, specifying the data to retrieve.

  This can be a source from **inside** your DataMiner System, such as parameters, DOM instances, bookings, or alarms, or from **outside** the system, such as API endpoints, databases, or local files in formats such as CSV, JSON, or XML.

- Any number of **operators**, linked together to create transformations.

  These operators can be sequenced to perform tasks like filtering datasets followed by computing average values grouped by specific criteria.

To construct queries, you can use the Dashboards or Low-Code Apps modules, where you can assemble the queries with a user-friendly UI. When you select a data source or operator in the UI, the options that are available next are automatically adjusted based on your selection. For example, if you filter numeric columns, you may get choices like "Greater than" or "Lower than", while text column filtering might include options such as "Contains" or "Matches regex".

> [!TIP]
> See also: [Creating a GQI query](xref:Creating_GQI_query)

## Architecture

The GQI engine can run in two different ways:

- As an extension module. See [GQI DxM](xref:GQI_DxM).
- Within the SLHelper process. In this case, it is only activated when it is used. Once the process has been activated, it remains operational for a duration of 30 minutes before automatically shutting down and releasing any utilized resources.

When queries are executed, the rights and permissions of the current DataMiner user are taken into account. This way, DataMiner's security measures are enforced during data retrieval. This means that the obtained results may vary significantly for users belonging to different security groups.
