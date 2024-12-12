---
uid: Protocol.Chains.Chain-options
---

# options attribute

Specifies a number of options separated by semicolons.

> [!TIP]
> See also: [EPM chains and fields configuration](xref:EPMManagerChainsAndFields)

## Content Type

string

## Parent

[Chain](xref:Protocol.Chains.Chain)

## Remarks

The following sections provide more information on the options for this tag.

### GroupingColumnPids

<!-- RN 5987 -->

(Service Overview Manager only)

Additional columns by which to group.

Example:

```xml
<Chain name="Services" topology="HardwareTopology" options="ServiceFilter:12402; HideFields;VisioTabName:Kingdom;GroupingColumnPids:12401,12402,12403"></Chain>
```

For each column ID you specify, an extra tab will be added to the tab control. The services in this new tab will be grouped by that column. Inside the groups, the services will then be sorted by severity and name.

### HideFields

(Service Overview Manager + EPM)

Use this option to hide the field filters for a chain, for example to display only a Visio file with configuration parameters.

### Level=X

<!-- RN 7478 -->

The security level of the chain.

If, for example, you specify "Level=1", then the chain will be visible for users with level 0 or 1.

### OpenFromAlarmConsoleForParameter

<!-- RN 8085/8374/8653 -->

This option allows you to specify the chain to be selected as well as the filter to be used when a CPE alarm is opened in a card.

To do so, add the *OpenFromAlarmConsoleForParameter* chain option in the protocol, and specify a parameter and a filter.

- If several parameters use the same chain, you can separate those using commas.
- If you want the same chain to be used for all parameters, you can use the ‘*’ wildcard.
- If you only want to specify a chain and no filter, then simply put a dash (‘-‘).

Example: Table 1600 is a table linked to table 1500 (Customer). It does not have to be part of the topology, a foreign key relationship is all that is needed. If a user opens an alarm on one of the parameters of table 1600, the "Internet" chain will automatically be filled in, and the Customer field will be set as filter:

```xml
<Chain name="Internet" options="OpenFromAlarmconsoleForParameter:1600-Customer">
    <Field name="Customer" options="ShowCPEChilds;details:1500-KPI|1600;displayInFilter; ShowBubbleupAndInstanceAlarmLevel;ShowSiblings" pid="1502"/>
</Chain>
```

It is also possible to specify this per column parameter. Suppose that table 1600 has two columns: 1602 (Modem state) and 1603 (Set-top box state).

If users open an alarm on column 1602, the "Internet" chain will automatically be selected. If they open an alarm on column 1603, the "Television" chain will automatically be selected:

```xml
<Chain name="Internet" options="OpenFromAlarmconsoleForParameter:1602-Customer"></Chain>
<Chain name="Television" options="OpenFromAlarmconsoleForParameter:1603-Customer">
```

> [!NOTE]
> This feature also works with view tables.

### ServiceFilter

(Service Overview Manager only)

Use this attribute to specify the column that contains the service for filtering in a Service Overview Manager.

Example:

```xml
<Chain name="Services" topology="HardwareTopology" options="ServiceFilter:1033;HideFields;VisioTabName:overview//sweden;GroupingColumnPids:1004,1005"/>
```

### showVisioPagesAsTabs

<!-- RN 14811 -->

Use this option to have the Visio tabs shown next to the other tabs instead of under a separate Visio tab.

### VisioTabName

(Service Overview Manager)

Use this attribute to specify the default Visio page that needs to be loaded when the Service Overview Manager element is opened.
