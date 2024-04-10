---
uid: GQI_GQIPage
---

# GQIPage class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Represents a single page of rows. Every query result consists of one or more such pages.

## Properties

| Property | Type | Required | Description |
| -------- | ---- | -------- | ----------- |
| Rows | [GQIRow](xref:GQI_GQIRow)[] | Yes | Rows of the page. |
| HasNextPage | boolean  | No | `True` if GQI can fetch additional pages, `False` if the current page is the last page. |

> [!TIP]
> To enhance performance and efficiency, consider restricting the data returned by using the `HasNextPage` boolean of a `GQIPage`. Often, not all data from an ad hoc data source is essential for the visualization. Utilizing paged data retrieval makes sure the implementation only retrieves the necessary pages until GQI accumulates sufficient data. This approach offers several benefits:
> - Speed: Fetching all data immediately in your implementation can be inefficient. By retrieving only the required pages, you optimize processing speed.
> - Memory Efficiency: Limiting the data retrieved helps conserve memory resources. Unnecessary data won't burden the system, allowing it to operate more efficiently.

### Examples

#### Paged data retrieval

The following example illustrates how the `HasNextPage` boolean can be manipulated to indicate that there are additional pages. If `HasNextPage` is set to `False`, GQI might call `GetNextPage` once more, until it has enough data.

```csharp
private int pageCounter = 0;
private int pageSize = 100;

public GQIPage GetNextPage(GetNextPageInputArgs args)
{
    var rows = FetchData(pageCounter, pageSize);
    var hasNextPage = rows.Length == pageSize;
    return new GQIPage(rows)
    {
        HasNextPage = hasNextPage;
    };
}

private GQIRow[] FetchData(int page, int pageSize){
    // Retrieve the data starting from 'page'
}
```

> [!NOTE]
> The example is purely to demonstrate how `HasNextPage` could potentially be manipulated. Depending on the data retrieval method, it may be advisable to incorporate additional information into the class.