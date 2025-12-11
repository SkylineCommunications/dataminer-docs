---
uid: Options_for_opening_DataMiner_Cube
---

# Arguments for DataMiner Cube

It is possible to [connect to a DMS using URL arguments](xref:Cube_start_window#connecting-to-a-dms-using-arguments). Below you can find an [overview of the different arguments](#overview-of-the-arguments), as well as some [examples](#examples) of how you can use these.

To combine different options, use a **space as separator**.

> [!NOTE]
>
> - In the legacy **browser app**, you can pass these arguments by adding them to the URL. To combine different arguments in the browser app, use an "&" instead of a space. Note that the URL must be encoded according to the W3C guidelines. For more information, see [http://www.w3schools.com/tags/ref_urlencode.asp](http://www.w3schools.com/tags/ref_urlencode.asp).
> - If the Cube desktop app is installed, you can also [use a cube:// URL to connect to a specific host](#using-a-cube-url-to-connect-to-a-specific-host).

## Examples

Examples for the desktop application:

```txt
view="My special view" element=MyElement
view=View2 element=365 app=help
```

Examples for the legacy browser application:

```txt
http://MyDMA1/DataminerCube/dataminercube.xbap?element=MyElement&view=MyView
http://MyDMA1/Dataminercube/dataminercube.xbap?app=Protocols%20%26%20Templates
DataMinerCube.exe host=MyDMA view="My special view" element=MyElement
DataMinerCube.exe host=MyOtherDMA view=View2 element=365 app=help
```

## Overview of the arguments

### Opening a card on a particular page

If you use the *element=*, *service=* or *view=* option to open an element, service, or view card at startup, you can have this card opened on a particular page.

To do so, add the following:

- A colon, followed by "*data*" or "*d*" for a data page, or followed by "*visual*" or "*v*" for a visual page.

  If the page is not grouped under the data or visual pages, only add a colon.

- A second colon, followed by the name of the page.

- A forward slash and the name of a subpage, in case you want to open a particular subpage.

For example:

- To open the subpage "ping" of the data page "performance" of the element with ID 48/70:

  ```txt
  element=48/70:data:performance/ping
  ```

- To open the page "help" of the element with ID 48/70:

  ```txt
  element=48/70::help
  ```

- To open the data page "Australia service" of the service with ID 48/105:

  ```txt
  service=48/105:d:Australia Service
  ```

- To open the page "aggregation" of the view "SLC":

  ```txt
  view=SLC::aggregation
  ```

### alarm=

Use this option to immediately display a specific alarm card. Different formats are supported, depending on the DataMiner version:

- DMA ID / root alarm ID

  Example:

  ```txt
  alarm=48/6713
  ```

- DMA ID / element ID / root alarm ID (supported from DataMiner 10.3.0 [CU14]/10.4.0 [CU2]/10.4.5 onwards).<!-- RN 39126 -->

  Example:

  ```txt
  alarm=48/123/6713
  ```

- Root alarm ID only

  Example:

  ```txt
  alarm=6713
  ```

> [!NOTE]
> To quickly find the root alarm ID, right-click the alarm in the Alarm Console and select *Properties*. The root alarm ID will be displayed below the regular ID in the top-right corner of the properties window.

### app=

Use this option to immediately open a specific module in a card.

If you want to open several modules, separate the module names by means of pipe characters.

Examples:

```txt
app=about
app="Protocols & Templates"|"Asset Manager"
```

### autoslide=

Use this option if you want DataMiner Cube to automatically move to the next workspace every X seconds.

Examples:

```txt
autoslide=30
```

To disable the autoslide mode, reconnect without the autoslide option.

### buffer=

Use this option along with the *element=* option to immediately show the buffer of a Spectrum Analyzer element.

The buffer should be specified in one of the following three ways:

- Monitor trace variable:

  ```txt
  buffer=monitorID:traceVariable
  ```

- Monitor trace variable with monitor script using measurement point:

  ```txt
  buffer=monitorID:traceVariable:measurementpointID
  ```

- Monitor trace variable with monitor script using measurement point and input preset:

  ```txt
  buffer=monitorID:traceVariable:measurementpointID:presetName
  ```

Example:

```txt
element=34/105&buffer=3:trace1
```

### chain=

Use this option to open an EPM Manager element to a particular chain.

Example:

- To open the element with ID 169/2 and open the chain with name "Physical":

    ```txt
    element=169/2 chain=physical
    ```

> [!NOTE]
>
> - We recommend that you also pass the element ID. If no element ID is specified, the first element of type "element manager" will be used.
> - The chain name is not case-sensitive.

### debug=true

This option allows you to view functionality that can be useful for debugging, but which is otherwise hidden in the UI.

For example, the GUID of service definitions is only shown in the Services app if you use the *debug=true* argument.

### dte_filtername=filtervalue

Use this option to open an EPM Manager element with a particular filter.

- "filtername" is the name of the filter without spaces. The name is not case sensitive.

- "filtervalue" is the value of the filter.

Example:

- To open the element with ID 169/2, open the first chain with a "Node" filter, and load node "DBL900":

  ```txt
  element=169/2 dte_Node=DLB900
  ```

- To open the element with ID 169/2, open the first chain with a "Node" filter and an "MTA" filter, and if there is only one MTA that matches the filter then load the MTA that contains the string "ABCD987":

  ```txt
  element=169/2 dte_Node=DLB900 dte_MTA=*ABCD987*
  ```

> [!NOTE]
>
> - We recommend that you also pass the element ID and chain. If no element ID is specified, the first element of type "element manager" will be used. If no chain is specified, the first chain containing the specified filter will be used.
> - When multiple filters are specified, only the lowest filter in the selected chain will be used. However, if no chain is specified, all filters are used to find the correct chain.
> - If only one row matches the filter, an object will be loaded.
> - If the filter value is a key prefix, add an asterisk ("\*") to the filter value.
> - If you want to use this argument for the browser app, the URL must be encoded according to the W3C guidelines. For more information, see [http://www.w3schools.com/tags/ref_urlencode.asp](http://www.w3schools.com/tags/ref_urlencode.asp).

> [!TIP]
> See also: [Experience and Performance Management](xref:EPM)

### element=

Use this option to specify an element to be opened in a card right after startup. You can specify the element by:

- Element ID,
- DMA ID/Element ID, or
- Element name

If you want to open several elements, separate them by means of pipe characters.

Examples:

```txt
element=154
element=231/154
element=MyElement|MyOtherElement
element="My element|My other element"
```

> [!NOTE]
> To open an SLA element, also use the *element=* option.

### host=

Use this option to specify the IP address or hostname of the DMA to which you want to connect.

Examples:

```txt
host=MyDMA2
```

### measpt=

Use this option when opening a Spectrum Analyzer element right after startup, in order to immediately open the *Measurement points* tab of the settings pane and select the indicated measurement point.

Always combine this option with *element=*.

To open several measurement points, separate them by means of pipe characters.

Examples:

```txt
element=34/105 measpt=1
```

> [!NOTE]
> This option can be combined with the *preset=* option.

### options=

Use this option along with *preset=*, in order to load a spectrum preset in the Spectrum Analyzer element(s) opened right after startup.*options=* is used in order to specify the preset options.

Spectrum preset options have to be specified as the sum of the following hexadecimal values:

| Value | Option                                             |
|-------|----------------------------------------------------|
| 0x1   | Load reference trace                               |
| 0x2   | Do not load settings like start and stop frequency |
| 0x4   | Load threshold                                     |
| 0x8   | Load display settings like colors                  |
| 0x10  | Load markers                                       |
| 0x20  | Load reference lines                               |
| 0x80  | Load frequency mask                                |
| 0x200 | Load measurement point cycle                       |

Example:

```txt
element=34/105 preset=abc options=0x208
```

### preset=

Use this option to specify the name of the spectrum preset to be loaded in the Spectrum Analyzer element(s) opened right after startup.

Unlike the inline preset option (see below), the regular preset option must always be combined with both *element=* and *options=*.

Examples:

```txt
element=34/105 preset="mypreset (public)" options=0x208
element=34/105|34/106|34/107 preset="mypreset (public)" options=0x00
```

> [!NOTE]
>
> - If you specify more than one element, like in the second example above, all elements will be opened with their own card, but if only the first one is a Spectrum Analyzer element, only that element will load the specified preset.
> - Only public presets can be used, and their *(public)* suffix must be mentioned.

### preset=inline

The *preset=* option can also be used for inline presets. This works differently from the regular *preset=* option, but it should also always be combined with *element=*.

Example:

```txt
element=35/105 measpt=-1 preset=inline:freqstart:450000;freqstop:500000000
```

Syntax:

```txt
inline:property1:value1;property2:value2;...
```

Property names:

- amountPoints
- detectMode
- firstMixerInput
- freqCenter (Hz)
- freqSpan (Hz)
- freqStart (Hz)
- freqStop (Hz)
- inputAtten
- preamp
- scaleType
- sweep (default: auto)
- rbw (default: auto)
- refLevel (default: 0 dBm)
- refScale (default: 10)
- vbw (default: auto)

> [!NOTE]
> When you specify an inline preset definition, you have to define at least the following properties:
>
> - freqStart and freqStop, or
> - freqCenter and freqSpan.

### service=

Use this option to specify the service to be opened in a card right after startup. You can specify the service by:

- ServiceID,
- DmaID/ServiceID, or
- Service name

If you want to open several services, separate them by means of pipe characters.

Examples:

```txt
service=MyService
service="My service"
service=MyService|MyOtherService
```

> [!NOTE]
> To open an SLA element, use the *element=* option.

### UseInitialArgumentsAfterDisconnect=true

This argument will make sure that all other specified arguments will be applied again when Cube has to reconnect for some reason.

Available from DataMiner 10.2.0 [CU22], 10.3.0 [CU10], and 10.4.1 onwards.<!-- RN 37888 -->

### view=

Use this option to specify the view to be opened in a card right after startup. You can specify the view by **view ID** or by **view name**.

If you want to open several views, separate them by means of pipe characters.

Examples:

```txt
view=MyView
view="My view"
view=MyView|MyOtherView
```

### workspace=

Use this option to specify the name of the workspace to be opened right after startup.

Examples:

```txt
workspace=Classic
```

> [!NOTE]
> If you want an empty workspace to be opened, use the argument *workspace=Clean*.

## Using a cube:// URL to connect to a specific host

If the Cube desktop app is installed, you can also use **cube:// protocol** to connect to a specific host. For example:

- cube://mydma?element=MyElement

- cube://10.11.12.13?view=12

From DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards<!--RN 40795-->, you can add or update the following arguments in a *cube://* URL of a Cube instance that is already running:

- `alarm=`

- `app=`

- `element=`

- `service=`

- `view=`

> [!NOTE]
> If you want to open a new Cube instance instead of updating the arguments of an open Cube instance, add the following argument to the URL: `forcenewsession=true`.
