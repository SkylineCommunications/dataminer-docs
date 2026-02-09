---
uid: Dynamically_Referencing_Data_in_Text
---

# Dynamically referencing data in text

From DataMiner 10.3.11/10.4.0 onwards<!-- RN 37229 -->, some Dashboards and Low-Code Apps features allow you to link to data by dynamically referencing data values from the dashboard or low-code app in specific text fields.

You can for example use this to [navigate to a URL](xref:LowCodeApps_event_config#navigating-to-a-url) that is dynamically adjusted based on a data value.

> [!NOTE]
> To know whether a specific Dashboards or Low-Code Apps feature supports this syntax, refer to the documentation for this feature.

## Syntax

### [From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 41141-->](#tab/tabid-1)

#### Components

To create component references inside textual settings, use the following syntax:

```txt
{COMPONENT.Source name.Component name.Category name.Data type.Property name}
```

- **COMPONENT**: A fixed keyword to indicate that the variable represents a component link.

- **Source name**: The name of the low-code app page or panel, e.g. "Page 1".

  > [!NOTE]
  > When you link to a [web](xref:DashboardWeb) or [text](xref:DashboardText) component in a dashboard, omit the source name.<!--RN 38993-->

- **Component name**: The name of the component, e.g. "Table 3".

- **Category name**: The part of the component that will contain the data, e.g. "Selected rows".

- **Data type**: The type of data, e.g. "Elements" or "Tables".

  > [!NOTE]
  > Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075-->, the data types "Texts" and "Tables" are called "Strings" and "Query rows" instead.

- **Property name**: The property of the data that should be used, e.g. "Protocol Name".

> [!TIP]
> You can find the name of each part in the *Components* data source of the edit panel's *Data* pane.

> [!NOTE]
>
> - Any parts of this syntax that contain spaces should be enclosed in double quotation marks.
> - All parts of this syntax are case-sensitive.

Examples:

- If the linked component provided the element name "Localhost" and the protocol name "Microsoft Platform", the following example would result in the text "*The element Localhost uses the protocol Microsoft Platform*":

  ```txt
  The element `{COMPONENT."Page 1"."Dropdown 3"."Selected item".Elements.Name}` uses the protocol `{COMPONENT."Page 1"."Dropdown 3"."Selected item".Elements."Protocol Name"}`.
  ```

- If the linked component represents a toggle switch, where "Toggle 1" is either enabled (`true`) or disabled (`false`), the following example would result in the text "*Toggle state: true*" when Toggle 1 is enabled and "*Toggle state: false*" when Toggle 1 is disabled:

  ```txt
  Toggle state: {COMPONENT."Current view"."Toggle 1".Value.Booleans.Value}.
  ```

  > [!NOTE]
  > Dynamically referencing boolean values is supported from DataMiner 10.4.0 [CU12]/10.5.3 onwards<!--RN 41845-->.

#### URLs

In the URL section, you have the ability to either select [URL data](#url-data), previously known as query parameters, or the [static value `DMAIP`](#dmaip).

##### URL data

To create references to URL data inside textual settings, use the following syntax:

- From DataMiner 10.5.0 [CU12]/10.6.3 onwards<!--RN 44015-->:

  ```txt
  {URL.Data.type.Value}
  ```

  - **URL**: A fixed keyword to indicate that the variable represents a URL.

  - **Data**: Indicates that the data originates from the URL data section.

  - **Type**: The type of data, e.g. "Numbers" or "Texts".

  - **Value**: The property of the data that should be used in the URL.

- Prior to DataMiner 10.5.0 [CU12]/10.6.3:

  ```txt
  {URL."Query parameters".type.Value}
  ```

  - **URL**: A fixed keyword to indicate that the variable represents a URL.

  - **"Query parameters"**: Indicates that the data originates from the URL query parameters section.

  - **Type**: The type of data, e.g. "Numbers" or "Texts".

    > [!NOTE]
    > Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41075-->, the data types "Texts" and "Tables" are called "Strings" and "Query rows" instead.

  - **Value**: The property of the data that should be used in the URL.

> [!NOTE]
>
> - URL query parameter references are only supported in the Dashboards app, not in Low-Code Apps.
> - Any parts of this syntax that contain spaces should be enclosed in double quotation marks.
> - All parts of this syntax are case-sensitive.

Example: If you want to pass a number as a query parameter to a URL, you could use the following syntax:

```txt
{URL.Data.Numbers.Value}
```

##### DMAIP

From DataMiner 10.4.0 [CU11]/10.5.2 onwards<!--RN 41561-->, the static value `DMAIP` is available in Dashboards and Low-Code Apps. It represents both the hostname and the IP port. You can access it using the following syntax:

```txt
{URL.DMAIP.Value}
```

#### Flows

Flows are available starting from DataMiner web 10.4.12. The minimum required server version is 10.4.0 or 10.3.9.

> [!TIP]
> See also: [Flows](xref:Using_flows)

To create a flow reference inside textual settings, use the following syntax:

```txt
{FLOW.Flow name.Property name}
```

- **FLOW**: A fixed keyword to indicate that the variable represents a flow.

- **Flow name**: The name of the flow you want to reference.

- **Property name**: The property of the provided data that should be used, e.g. "Protocol Name".

> [!NOTE]
>
> - Any parts of this syntax that contain spaces should be enclosed in double quotation marks.
> - All parts of this syntax are case-sensitive.

For example, if you want to use the ID output of the "Selected Items Flow" flow:

```txt
The selected item is `{FLOW."Selected Items Flow".ID}`.
```

### [Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12](#tab/tabid-2)

To create feed references inside textual settings, use the following syntax:

```txt
{FEED.Source name.Feed name.Category name.Data type.Property name}
```

- **FEED**: A fixed keyword to indicate that the variable represents a feed link.

- **Source name**: The name of the low-code app page or panel, e.g. "Page 1".

  > [!NOTE]
  > When you link a feed to a [Web](xref:DashboardWeb) or [Text](xref:DashboardText) component in a dashboard, omit the source name.<!--RN 38993-->

- **Feed name**: The name of the feed, e.g. "Table 3".

- **Category name**: The part of the feed that will contain the data, e.g. "Selected rows".

- **Data type**: The type of data, e.g. "Elements".

- **Property name**: The property of the fed data that should be used, e.g. "Protocol Name".

> [!TIP]
> You can find the name of each part in the *FEEDS* data source of the edit panel's *Data* pane.

> [!NOTE]
>
> - Any parts of this syntax that contain spaces should be enclosed in double quotation marks.
> - All parts of this syntax are case-sensitive.

Example: If the linked feed provided the element name "Localhost" and the protocol name "Microsoft Platform", the following example would result in the text "*The element Localhost uses the protocol Microsoft Platform*":

```txt
The element `{FEED."Page 1"."Dropdown 3"."Selected item".Elements.Name}` uses the protocol `{FEED."Page 1"."Dropdown 3"."Selected item".Elements."Protocol Name"}`.
```

***
