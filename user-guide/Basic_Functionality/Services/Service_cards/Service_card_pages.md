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

Up to DataMiner 9.0.0, The *DATA* node contains subnodes indicating the status of service children. Expand one of these subnodes to view all service children with this particular status. Each service child node can in turn be expanded to display its data pages.

From DataMiner 9.0.5 onwards, service children are displayed in a different way depending on their status:

- Devices that are both included and in use are displayed at the top of the list, respectively followed by devices that are not in use and by excluded devices.

- Devices that are not in use are grayed out.

- For devices that are not in use or excluded, the status of the device is added in parentheses to the device name.

A service child can have one of the following statuses:

- **In use**: Either no condition is defined, or the device is included based on a condition.

- **Not in use**: The device is included based on a condition, but does not influence the service based on a service influence condition.

- **Excluded**: The device is excluded based on a condition.

> [!TIP]
> See also:
> [Conditionally including an element in a service](xref:Conditionally_including_an_element_in_a_service)

> [!NOTE]
> - For services that were created with a service protocol, additional *Summary* pages are available, such as the *General parameters* page, which is similar to the General parameters page of an element.
> - In the Cube user settings, you can select to show or hide excluded devices and/or the General parameters page. See [Card settings](xref:User_settings#card-settings).

### ALARMS

This page displays all alarms related to the service, in the default Alarm Console layout.

> [!TIP]
> See also:
> [Working with the Alarm Console](xref:Working_with_the_Alarm_Console)

### SLA

This page is only available for services that are monitored by an SLA element. It displays general information, performance indicators and compliance information of the SLA.

### REPORTS

A graphic representation of the alarm distribution, alarm events, alarm states, and a timeline. You can set the period for which data are shown to the last 24 hours, one week to date, or one month to date.

> [!TIP]
> See also:
> [Viewing the reports page on a card](xref:Viewing_the_reports_page_on_a_card)

### DASHBOARDS

This page links to the DMS Dashboards app.

> [!NOTE]
> From DataMiner 10.2.0/10.1.12 onwards, the legacy Dashboards app can be disabled using the soft-launch option *LegacyReportsAndDashboards*. See [Soft-launch options](xref:SoftLaunchOptions).

### DOCUMENTS

On this page, you can find documents that have been made available either on the DMS in general or for a particular protocol used in the service. You can also add, edit or delete documents here.

### NOTES

On this page, you can add short notes to the service. For more information, see [Card navigation pane](xref:Working_with_cards_in_DataMiner_Cube#card-navigation-pane).

### ANNOTATIONS

On this page, you can add, view and edit extensive annotations to the service. With the pencil icon on this page, you can open an HTML editor that allows you to add text, hyperlinks, pictures, etc. to the annotations. There is also an icon that can be used to print the annotations, and an icon to refresh the annotations page.

> [!NOTE]
> From DataMiner 10.2.0/10.1.12 onwards, annotations can be disabled using the soft-launch option *LegacyAnnotations*. See [Soft-launch options](xref:SoftLaunchOptions).
