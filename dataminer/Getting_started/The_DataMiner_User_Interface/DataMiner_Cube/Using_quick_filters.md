---
uid: Using_quick_filters
---

# Using quick filters

You will often find filter boxes in DataMiner Cube that you can use to filter the displayed data. This can for instance be at the top of a card side panel, above a table or in the Alarm Console.

> [!TIP]
> See also:
>
> - [Using the Alarm Console quick filter box](xref:ApplyingAlarmFiltersInTheAlarmConsole#using-the-alarm-console-quick-filter-box)

## Tips on the use of quick filters

- The filter box is a combo box, which means you can type in it or click the magnifying glass icon on the right side of the box to choose from a list of suggestions. Depending on where you are using the filter box, it could be that you first have to type a few characters before suggestions appear.

    > [!NOTE]
    > A filter box keeps a history of past searches, which is listed underneath the suggestions. By default, 10 items are kept in the history, but this number can be changed in the user settings. See also [Data Display settings](xref:User_settings#data-display-settings).

- To filter more effectively, you can use wildcards or regular expressions in filters.

    > [!TIP]
    > See also:
    > - [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters)
    > - [Using regular expressions in quick filters](#using-regular-expressions-in-quick-filters)

- The following comparison operators can be used in quick filters: = or ==, *!=*, *\>*, *\>=*, *\<* and *\<=*. To use these operators, first mention the column name (between double quotation marks in case it contains a space), then the operator, and then the value, which can be a number, a string or an alarm severity.

    For example:

    ```txt
    "process id">1000
    "process id"!=1001
    severity>major
    "service impact">5
    cpu>2
    ```

    > [!NOTE]
    > - Alarm severities are ordered as follows: Undefined, initial, Information, Notice, Normal, Masked, Warning, Minor, Major, Critical, Timeout, Error
    > - Strings use the .Net string order of the current culture.
    > - From DataMiner 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0/10.4.3 onwards<!--RN 38367-->, the following operators are supported in filters for numeric columns of partial tables: `<`, `<=`, `>`, `>=`, `==`, and `!=`. Prior to DataMiner 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0/10.4.3, when any of these operators is used in a numeric column filter, it results in an exact match (`==`).

- To filter on an exact combination of characters, put the characters between double quotation marks.

- To filter on a column containing a specific value, enter the name of the column followed by a colon, and then specify the value (*column:value*). Similarly, to filter on a column that does not contain a specific value, enter the name of the column, followed by an exclamation mark and a colon, and then specify the value (*column!:value*).

    > [!NOTE]
    > To filter on a value containing a colon, put the filter item between double quotation marks.

- To deactivate the filter, click the X in the filter box.

- When you apply a quick filter on a paged table, all pages of the table are considered for the filter, but some restrictions apply:

  - As in this case filtering is applied server-side instead of client-side, prefixes like “regex:”, “trending”, or “severity:” cannot be used. In addition, to launch a search, you have to explicitly press the Enter key or click an arrow button.

  - In this case, it is not possible to filter on column parameters of type *discreet*, *button* or *togglebutton*.

> [!NOTE]
>
> - When you use the Alarm Console quick filter to filter the alarms shown in an alarm tab, the total number of alarms will still be displayed in the alarm bar, with the filtered number of alarms added in parentheses.
> - In the Alarm Console quick filter, to search for exact matches in alarm properties, square brackets can be used. For example, if there are two alarms, one with property "bbc1", the other with property "bbc", using the search term "bbc" will return both alarms. However, using the search term "\[bbc\]" will only return the latter.

## Using filters in drop-down lists

In several places in DataMiner Cube, drop-down lists feature a filter box that can be used to find an item in the list more quickly.

Such drop-down list controls can for example be found in the element, service, redundancy group template and service template editor, as well as in the Automation, Correlation, Aggregation, Element Connections, Trending and Scheduler apps.

By default, DataMiner will simply look for the text you enter in the filter. However, it is also possible to use regular expressions, if you add the prefix *regex:* in front of your filter entry.

## Using regular expressions in quick filters

In quick filters on element, service and view cards, regular expressions can be used, with the following syntax:

```txt
[columnname:]regex:REGEX
```

In the above syntax, replace REGEX with the regular expression. If it contains spaces, then enclose the entire expression in double quotes. For example:

| Filter                                      | Description                                                                                                                               |
|---------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| regex:part\[0-9\]                           | Search for rows containing “part” followed by a number from 0 to 9.                                                                       |
| "rack name":regex:"part\[0-9\] part\[0-9\]" | Search for rows of which the column named “Rack Name” contains a value that matches the regular expression <br>“part\[0-9\] part\[0-9\]”. |
