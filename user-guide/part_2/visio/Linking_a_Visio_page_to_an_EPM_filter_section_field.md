## Linking a Visio page to an EPM filter section field

If you have linked a page of a Visio drawing to a chain (i.e. tab page) of an EPM element (formerly known as CPE Manager) using a shape data field of type **Chain**, you can use a shape data field of type **Field** to link that page to one specific filter section field of that chain (e.g. “Headends”, “Customer”, “STB”, etc.). That way, the page in question will only appear when you select a value for that specific filter section field.

If, for example, you set **Field** to “*Headends*”, the page will appear when you select a headend in the *Filter* section of the EPM interface.

> [!TIP]
> See also:
> [Linking a Visio page to an EPM chain](Linking_a_Visio_page_to_an_EPM_chain.md)

### Configuring the shape data field

Add a shape data field of type **Field** to the shape, and set its value to the name of a field in the *Filter* section of the EPM interface.

From DataMiner 9.6.8 onwards, you can specify more than one field, using a pipe character (“\|”) as separator between the field names. This can be combined with one or more chains, so that for each combination of a chain and field value from the shape data, the page will be displayed.

For example, if the following shape data is specified, the page will be visible for the *OLT* and *CMC* field, while the user navigates in the *OLT (limited)*, *CMTS topology* or *maps* chain:

| Shape data field | Value                              |
|------------------|------------------------------------|
| Chain            | olt (limited)\|cmts topology\|maps |
| Field            | OLT\|CMC                           |

> [!NOTE]
> -  If you do not specify a shape data field of type **Field** or if you leave its value blank, then the page will appear when nothing is selected in the *Filter* section. In case multiple field values are specified, but these are followed by a pipe character, the page will also be displayed when nothing is selected.
> -  The behavior of these shape data fields changes in DataMiner 10.0.12. Prior to this DataMiner version, visual pages are displayed if there is a matching Field property, regardless of the Chain property. From DataMiner 10.0.12 onwards, the pages are only displayed if the Chain property is set to a valid chain or to the wildcard "\*".
>
