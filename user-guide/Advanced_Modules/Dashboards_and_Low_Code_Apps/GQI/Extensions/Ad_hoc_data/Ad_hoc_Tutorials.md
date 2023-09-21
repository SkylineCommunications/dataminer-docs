---
uid: Ad_hoc_Tutorials
---

# Tutorials

## Example of forwarding dummy data to the GQI

Below you can find an example script that forwards dummy data to the GQI. The name of the data source, as defined in the *GQIMetaData* attribute, will be “People”.

First the *IGQIDataSource* interface is implemented, then *GetColumns* is used to define the custom columns for the data source. In this case, there are 5 columns. The *GetNextPage* method then returns the actual data to the GQI. In this case these are 3 rows, defined as an array of cells. For each cell, a display value can also be defined. In this case, this is done for the cells within the *Height* column to indicate the unit of measure. The *HasNextPage* property is set to *False* to indicate that no additional pages need to be fetched.

The optional *IGQIInputArguments* interface is also implemented in the example, in this case to allow the user to add an input argument indicating the minimum age for the records that will be retrieved. The argument is indicated as required, so the user will have to specify it to be able to configure the query. The argument value is retrieved with *OnArgumentsProcessedInputArgs* and used to filter the returned data.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "People")]
public class MyDataSource : IGQIDataSource, IGQIInputArguments
{
    private GQIDoubleArgument _argument = new GQIDoubleArgument("Age") { IsRequired = true };
    private double _minimumAge;

    public GQIColumn[] GetColumns()
    {
        return new GQIColumn[]
        {
            new GQIStringColumn("Name"),
            new GQIIntColumn("Age"),
            new GQIDoubleColumn("Height (m)"),
            new GQIDateTimeColumn("Birthday"),
            new GQIBooleanColumn("Likes apples")
        };
    }

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _argument };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _minimumAge = args.GetArgumentValue(_argument);
        return new OnArgumentsProcessedOutputArgs();
    }

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = new List<GQIRow>() {
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Alice" },
                        new GQICell() { Value = 32 },
                        new GQICell() { Value = 1.74, DisplayValue = "1.74 m" },
                        new GQICell() { Value = new DateTime(1990, 5, 12) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Bob" },
                        new GQICell() { Value = 22 },
                        new GQICell() { Value = 1.85, DisplayValue = "1.85 m" },
                        new GQICell() { Value = new DateTime(2000, 1, 22) },
                        new GQICell() { Value = true }
                    }),
            new GQIRow(
                new GQICell[]
                    {
                        new GQICell() { Value = "Carol" },
                        new GQICell() { Value = 27 },
                        new GQICell() { Value = 1.67, DisplayValue = "1.67 m" },
                        new GQICell() { Value = new DateTime(1995, 10, 3) },
                        new GQICell() { Value = false }
                    })
            };

        var filteredRows = rows.Where(row => (int)row.Cells[1].Value > _minimumAge).ToArray();

        return new GQIPage(filteredRows)
        {
            HasNextPage = false
        };
    }
}
```
