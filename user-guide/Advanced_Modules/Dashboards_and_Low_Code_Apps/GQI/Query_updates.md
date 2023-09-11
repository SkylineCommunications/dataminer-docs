---
uid: Query_updates
---

# Query updates

When executing a query, you have the option to keep your query result up to date by enabling query updates.
These updates may add, remove or update rows from the initial result returned by your query.

> [!TIP]
> Take a look at [query update support](#query-update-support) to see which updates your query can support.

## How to enable updates

GQI allows you to enable or disable updates for each query individually.

In the UI however, you control updates per component under *Settings* > *Data retrieval* > *Update data*.
This setting will enable updates for all queries executed by that component.

## Query update support

A GQI query can offer various levels of support for updates:

1. It can support updates through [real-time events](#real-time-events)
1. It can support updates through [notify events](#notification-events)
1. It might not provide any support for updates.

> [!IMPORTANT]
> The update support of your query is determined by the **lowest** level of support among the data sources and operators in your query.
> See [supported data sources](#supported-data-sources) and [supported operators](#supported-operators) for an overview.

### Real-time events

As the name suggests, real-time events occur as soon as a change is detected.
These events contain incremental updates in the form of added, removed or updated rows and cells.

### Notification events

Notification events serve as a simplified variant of real-time events, allowing data sources and operators to notify the client that there *may* have been a change, without detailing *what* changed.

In practice, GQI will keep track of these notifications and relays them to the client every 30 seconds.
When the client receives such an event, it will re-execute the query to show the most recent data.

## Supported data sources

> [!NOTE]
> The overview below lists all data sources that have any update support. If a data source is not listed here, it means there is no update support for it yet.

| Data source | Supports |
| ----------- | -------- |
| [Get parameter table by ID](xref:Get_parameter_table_by_ID) | real-time updates\* |
| [Get views](xref:Get_views) | real-time updates\* |

\* These updates have specific limitations. Check the data source documentation for more details.

## Supported operators

> [!NOTE]
> The overview below lists all operators that can handle [real-time events](#real-time-events). If an operator is not listed here, it means that it can only handle [notification events](#notification-events).

| Operator |
| -------- |
| [Select](xref:GQI_Select) |

> [!NOTE]
> Some operators not listed here may still support real-time updates in combination with other data sources.
> You can check this for each data source individually.
