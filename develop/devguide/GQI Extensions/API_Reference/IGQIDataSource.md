---
uid: GQI_IGQIDataSource
---

# IGQIDataSource interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Implementing this interface marks the class as a GQI data source.

> [!NOTE]
> The *IGQIDataSource* interface is the only required interface to identify a class as a GQI data source.

## Methods

### GQIColumn[] GetColumns()

Defines the columns of the data source.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle#getcolumns).

#### Returns

The columns available in the data source.

### GQIPage GetNextPage(GetNextPageInputArgs args)

Retrieves the next page of data from the data source.

> [!TIP]
> Learn more about when this method is called within an [ad hoc data source](xref:Ad_hoc_Life_cycle#getnextpage).

#### Returns

A [GQIPage](xref:GQI_GQIPage) with the data.

> [!TIP]
> In numerous scenarios, not all data is required immediately to generate a query result. Therefore, partitioning rows into separate pages proves beneficial, allowing individual pages to be requested and processed as needed. This approach enhances both speed and memory efficiency.

#### Examples

##### Paged data retrieval

The following example illustrates how the `HasNextPage` property can be used to indicate that there are additional pages. If `HasNextPage` is set to `true`, GQI may call `GetNextPage` again when more data is needed.

```csharp
private int pageCounter = 0;
private int pageSize = 100;

public GQIPage GetNextPage(GetNextPageInputArgs args)
{
    var rows = FetchPagedData(pageCounter);
    pageCounter++;

    // If a full page is retrieved, we assume there is more data
    var hasNextPage = rows.Length == pageSize;
    return new GQIPage(rows)
    {
        HasNextPage = hasNextPage,
    };
}

private GQIRow[] FetchPagedData(int pageNumber)
{
    // Fetch page 'pageNumber' containing at most 'pageSize' rows
}
```
