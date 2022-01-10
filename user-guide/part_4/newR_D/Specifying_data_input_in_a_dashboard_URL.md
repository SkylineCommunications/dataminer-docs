## Specifying data input in a dashboard URL

If a dashboard has been configured with one or more feed components, it is possible to specify data input for these feeds in a dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened.

Within the dashboard URL, the following objects can be specified:

- Elements (using the argument *elements*): By specifying the DMA ID and element ID.

- Services (using the argument *services*): By specifying the DMA ID and service ID.

- Redundancy groups (using the argument *redundancy groups*): By specifying the DMA ID and redundancy group ID.

- Parameters (using the argument *parameters*):

    - By protocol: By specifying the protocol name, protocol version and protocol ID.

    - By element: By specifying the DMA ID, the element ID, the parameter ID and optionally the parameter index.

- Views (using the argument *views*): By specifying the view ID.

- SLAs (using the argument *slas*): By specifying the DMA ID and element ID.

- DataMiner Agents (using the argument *agents*): By specifying the DMA ID.

- Protocols (using the argument *protocols*): By specifying the protocol name and protocol version.

- Data Display pages:

    - By protocol (using the argument *protocol pages*): By specifying the protocol name, protocol version and page name.

    - By element (using the argument *parameter pages*): By specifying the DMA ID, the element ID and the page name.

- Indices (using the argument *indices*): By specifying the index.

- Time spans (using the argument *time spans*): By specifying the start and end time stamp.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.1 onwards, for a predefined time span in a time range component, the URL contains the name of that time span (e.g. today, yesterday, etc.) instead of the start time and end time of the time span.

- Bookings (using the argument *bookings*): By specifying the booking ID. Supported from DataMiner 10.0.3 onwards.

- Service definitions (using the argument *service definitions*): By specifying the service definition ID(s). Supported from DataMiner 10.0.5 onwards.

- An EPM filter (using the argument *cpes*): By specifying the DMA ID, the element ID, the field PID, the table PID and the value. From DataMiner 10.0.5 onwards, you should instead specify the DMA ID, the element ID, the field PID, the field value, the table index PID and the index value.

    > [!NOTE]
    > -  If, in the time spans argument, you specify “/1531814522191” (i.e. leaving out the first time stamp), this will be interpreted as “from midnight to X”.
    > -  If, in the time spans argument, you specify “1531810522191” (i.e. leaving out the second time stamp), this will be interpreted as “from X to now”.

Within one object, use a slash (“/”) as the separator between its components. If different objects of the same type are specified, use “%1D” as the separator between the objects.

For example:

- http://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=<br>1/1/1%1D1/1/2/myIndex

    This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- http://myDma/Dashboard/#/myDashboard?time%20spans=1549753200000/1549835265007

    This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

> [!NOTE]
> -  Additional URL options are possible from DataMiner 10.0.2 onwards. To only display a dashboard, without the rest of the app, add the argument “*embed=true*”. To display the *Clear all* button for an embedded dashboard, add “*subheader=true*” as well.<br>For example: *http://**\[DMA IP\]**/dashboard/#/MyDashboards/dashboard.dmadb?embed=true&subheader=true*
> -  The *showAdvancedSettings=true* URL option can be used with some components in order to make additional functionality available.
>
