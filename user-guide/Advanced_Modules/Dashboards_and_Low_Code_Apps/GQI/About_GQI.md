---
uid: About_GQI
---

# About Generic Query Interface

The Generic Query Interface offers a versatile query language designed to retrieve and manipulate data from both within and beyond your DataMiner system. Its output is presented in a tabular format and is independent of the underlying data structure, effectively functioning as a flexible abstraction layer.

This abstraction layer fulfills several key functions:

- Operators enable the transformation of the retrieved data, providing flexibility in shaping the output according to specific requirements.
- Visualizations can be effortlessly generated to represent the retrieved data, facilitating a clearer understanding of the information at hand.
- Various analytical tools are available for in-depth examination and scrutiny of the retrieved data set, empowering users to extract valuable insights and make informed decisions.

![GQI concept](~/user-guide/images/gqi_concept.png)

## What are queries?

A query defines the data to be accessed and the transformations to be applied.

It comprises:

- A single data source, specifying the data to retrieve. This can originate from within your DataMiner system, such as parameters, DOM instances, bookings, or alarms, or from external sources like API endpoints, databases, or local file storage formats such as CSV, JSON, or XML.
- Any number of operators, linked together to create intricate transformations. These operators can be sequenced to perform tasks like filtering datasets followed by computing average values grouped by specific criteria.

Queries can be constructed using a conversational API accessible within Dashboards or Low-Code Apps. This interface facilitates a dialogue between the user and GQI, where users dictate the data selection or operators, and GQI responds with available options. For instance, filtering numeric columns might offer choices like 'Greater than' or 'Lower than', while text column filtering might include options such as 'Contains' or 'Matches regex'.

> [!TIP]
> See also: [Creating a GQI query](xref:Creating_GQI_query)

## Architecture

GQI operates as a server-side process housed within the SLHelper process. This process is activated only upon usage. Once activated, it remains operational for a duration of 30 minutes before automatically shutting down, thereby releasing any utilized resources.

Queries are executed within the security context of the DataMiner user, ensuring that DataMiner's security measures are enforced during data retrieval. Consequently, the results obtained may vary significantly for users belonging to different security groups.
