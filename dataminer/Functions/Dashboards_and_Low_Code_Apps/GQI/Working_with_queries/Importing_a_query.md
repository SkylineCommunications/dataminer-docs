---
uid: Importing_a_query
keywords: import query, query JSON, GQI query, reuse query
description: Import a GQI query from exported JSON or another dashboard to reuse exiting query configurations without rebuilding them.
---

# Importing a query

## Importing a query from JSON

From DataMiner 10.5.0 [CU17]/10.6.0 [CU5]/10.6.8 onwards<!--RN 45630-->, you can import a query from raw JSON previously exported using the [*Dashboards / Apps* export option](xref:Exporting_a_query):

1. In the *Data* pane, select *Queries* and click the ![import](~/dataminer/images/Import_icon.png) icon.

1. In the *Import query* pop-up window, paste the JSON into the *Query JSON* box.

1. In the *Name* box, enter a name for the imported query.

1. Click *Import* in the lower-right corner of the window.

The query will now be available for use in the *Data* pane.

## Importing a query from a dashboard

> [!NOTE]
> This option is only available in dashboards.

You can import a query from another dashboard in the DMS. To do so:

1. In the *Data* pane, select *Queries* and click the ![import](~/dataminer/images/Import_icon.png) icon (to the right of the + icon).

   The *Import query* pop-up window will appear.

1. From DataMiner 10.5.0 [CU17]/10.6.0 [CU5]/10.6.8 onwards<!--RN 45630-->, set *From* to *Dashboard*.

1. Select the dashboard from which you want to import the query.

1. Select the query itself from the *Query* dropdown list.

1. In the *Name* box, enter a name for the imported query.

1. Click *Import* in the lower-right corner of the window.

The query will now be available for use in the *Data* pane.
