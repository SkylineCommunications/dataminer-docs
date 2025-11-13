---
uid: Service_card_pages
---

# Service card pages

The navigation pane on the left side of a service card contains a tree view with the items mentioned below.

> [!NOTE]
> For an enhanced service, depending on which service protocol is used, additional pages may be available.

### VISUAL

Under the *VISUAL* node, one or more pages are displayed that contain a graphic representation of the service. These can be completely customized in Visio.

> [!NOTE]
> For more information on how to change the Visio file linked to a particular service, see [Switching between different Visio files](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files).

### DATA

The data pages of a service represent the different service children, i.e. the elements or partial elements included in the service.

A service child can have one of the following statuses:

- **In use**: Either no condition is defined, or the device is included based on a condition.

- **Not in use**: The device is included based on a condition, but does not influence the service based on a service influence condition.

- **Excluded**: The device is excluded based on a condition.

Service children are displayed in a different way depending on their status:

- At the top of the list, service children are displayed that are both included and in use. Below them, you will find the service children that are not in use, and below those the service children that are excluded.

- Service children that are not in use are grayed out.

- For service children that are not in use or excluded, the status is added in parentheses to the name of the element within the service.

> [!TIP]
> See also: [Conditionally including an element in a service](xref:Conditionally_including_an_element_in_a_service)

> [!NOTE]
>
> - For services that were created with a service protocol, additional *Summary* pages are available, such as the *General parameters* page, which is similar to the General parameters page of an element.
> - In the Cube user settings, you can select to show or hide excluded devices and/or the General parameters page. See [Card settings](xref:User_settings#card-settings).

### ALARMS

This page displays all alarms related to the service, in the default Alarm Console layout.

> [!TIP]
> See also: [Working with the Alarm Console](xref:Working_with_the_Alarm_Console)

### SLA

This page is only available for services that are monitored by an SLA element. It displays general information, performance indicators and compliance information of the SLA.

### REPORTS

A graphic representation of the alarm distribution, alarm events, alarm states, and a timeline. You can set the period for which data are shown to the last 24 hours, one week to date, or one month to date.

> [!TIP]
> See also: [Viewing the reports page on a card](xref:Viewing_the_reports_page_on_a_card)

### DASHBOARDS

This page links to the DMS Dashboards module.

> [!NOTE]
> The legacy Dashboards module is by default disabled from DataMiner 10.4.0/10.4.1 onwards.<!-- RN 37786 --> If you want to keep using this module, you need to enable it with the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards). Prior to this, starting from DataMiner 10.2.0/10.1.12, the legacy Dashboards module can optionally be disabled with this soft-launch option.

### DOCUMENTS

On this page, you can find documents that have been made available either on the DMS in general or for a particular protocol used in the service. You can also add, edit or delete documents here.

### NOTES

On this page, you can add short notes to the service. For more information, see [Card navigation pane](xref:Working_with_cards_in_DataMiner_Cube#card-navigation-pane).

### ANNOTATIONS (deprecated)

In older DataMiner versions (prior to DataMiner 10.6.0), this page allows you to add, view, and edit extensive annotations for the service. With the pencil icon on this page, you can open an HTML editor that allows you to add text, hyperlinks, pictures, etc. to the annotations. There is also an icon that can be used to print the annotations, and an icon to refresh the annotations page.

> [!NOTE]
> The Annotations module is no longer available from DataMiner 10.6.0 onwards. Prior to this, starting from DataMiner 10.4.0/10.4.1<!-- RN 37786 -->, it is disabled by default, but it can be enabled with the [*LegacyAnnotations* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyannotations). In even older DataMiner versions, this feature is enabled by default, but you can optionally disable it with the soft-launch option.
