---
uid: Managing_Visio_files_linked_to_protocols
---

# Managing Visio files linked to protocols

In DataMiner, each protocol has one or more Visio files linked to it. It is possible to change the Visio files linked to a protocol, so that each element based on that particular protocol displays the Visual Overview you have determined.

> [!NOTE]
> For elements that have been created by a parent element, it may not be possible to change what Visio file is used, except with an Administrator account or via the parent element.

## Switching between different Visio files

### Switching between Visio files for elements

In the Protocols & Templates module, for each protocol, any Visio files linked to it are displayed under *Visio files* in the second column. There can be several different Visio files listed in this section:

- Default Visio files shipped with the DataMiner software, called *General default*.

- Protocol-specific Visio files included in certain protocol packages, called *Protocol default*.

- Custom Visio files assigned to a protocol by a user, called *Custom*.

In the Protocols & Templates module, the currently used Visio file for the protocol is marked with a check icon.

To set a different Visio file as the active file for a particular protocol:

1. Right-click the Visual Overview.

1. In the context menu, select *Set as active \[protocol name\] protocol Visio file* and then select *Custom*, *Protocol Default* or *General Default*, depending on which of the configured Visio files you wish to use.

> [!NOTE]
> From DataMiner 10.0.11 onwards, it is also possible to assign a Visio file to one element only, without affecting the Visio files available for the protocol. For more information, see [Set as active Visio file](xref:Editing_a_visual_overview_in_DataMiner_Cube#set-as-active-visio-file).

### Switching between Visio files for services or views

To set a different Visio file as the active file for a particular service or view:

1. Right-click the Visual Overview and select *Set as active Visio file* > *Existing*.

1. Select the Visio file that should be used as the active file. If the file is not displayed in the dialog box, click *Other file* to browse to its location.

1. Next to *Page*, select which page should be displayed by default.

1. Optionally, select *Force default page selection* to always show this page by default.

   > [!TIP]
   > See also: [Visual overview page priority](xref:Visual_overview_page_priority)

1. Click OK to close the dialog box.

> [!NOTE]
> The option to switch to a different Visio file is also available from an element, service or view card’s header bar menu. See [Card header bar menu](xref:Working_with_cards_in_DataMiner_Cube#card-header-bar-menu).

## Assigning a custom Visio file to a protocol

In the Protocols & Templates module, you can upload a custom-made Visio file to assign it to a protocol.

1. Go to *Apps* > *Protocols & Templates*.

1. Select the protocol to which you want to assign a Visio file under *Protocols*.

1. Under *Visio Files*, right-click *General default* and select *Upload custom Visio file*.

1. In the *Open* dialog box, select the desired Visio file (extension: .vdx or .vsdx), and click *Open*.

> [!NOTE]
>
> - It is not possible to upload Visio files of which the file name contains more than one “%” sign.
> - Under *Protocols*, protocols to which a Visio file has been assigned are marked by a small Visio icon.

> [!TIP]
> You can also upload a Visio file to a specific element instead of to a protocol. See [Set as active Visio file](xref:Editing_a_visual_overview_in_DataMiner_Cube#set-as-active-visio-file).

## Removing a Microsoft Visio file assigned to a protocol

If you no longer want a custom Visio file to be linked to a protocol, you can sever the link between the protocol and the Visio file.

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, right-click the protocol and select *Remove Visio file*.

1. In the confirmation box, click *Yes*.
