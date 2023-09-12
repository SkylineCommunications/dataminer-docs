---
uid: Searching_in_DataMiner_Cube
---

# Searching in DataMiner Cube

## Using the Cube Search box

### From DataMiner 10.0.0/10.0.2 onwards

From DataMiner 10.0.0/10.0.2 onwards, to search for an item in the DataMiner System, you can use the search box in the middle of the Cube header bar.

As soon as you click the search box, a list of suggestions is shown below. Initially, this list shows recent items (with any pinned items at the top), but it is updated with search results as soon as you type anything in the box.

Click a suggestion to immediately open the corresponding card, or click *Advanced search* at the bottom of the list to open a complete list of search results in a side panel. You can also right-click a suggestion in the list to open the same right-click menu as in the Surveyor (see [Surveyor right-click menu](xref:DataMiner_Cube_sidebar#surveyor-right-click-menu)).

From DataMiner 10.1.11/10.2.0 onwards, you can also search directly in the advanced search pane using the search box at the top. If the pane is pinned to the sidebar, it is always displayed, even if you have not done a search using the search box in the header bar. (see [Sidebar](xref:DataMiner_Cube_sidebar)).

Please note the following

- For a quick search, only the following objects can be displayed in the results: elements, services, service children with alias, redundancy groups, SLAs, views and apps, as well as objects of which the ID matches the search string. Hidden elements are not included.

- If the text you enter in the box consists of less than three characters, an advanced search will only return exact matches.

- Starting from DataMiner 10.2.12/10.3.0, you can search for a number (e.g "12345") in strings. In previous versions, if you search for a number only, this is always interpreted as a view ID, so that only the view with matching ID is returned.

- In an advanced search, you can use specific keywords to only search for certain DataMiner items. See [Special search options](#special-search-options).

    > [!NOTE]
    > If you want to do an advanced search on a piece of text that is the same as a keyword, place it between double quotation marks. For example, if you search only for the word “Element”, no results will be returned in the advanced search unless this word is placed between quotation marks.

- By default, both a client-side and a server-side search are done. If you do an advanced search, it can occur that additional results become available from the server-side search after the initial results are displayed in the search pane. You can then view these additional results by clicking the *Show more* button.

    > [!NOTE]
    > In the Cube system settings, it is possible to disable the client-side search. To do so:
    >
    > - In a system with a MySQL database, go to *System Center* > *System Settings* > *Search*, clear the checkbox next to *Enable search indexing on the client* and click the *Apply* button.
    > - In a system with a Cassandra database, go to *System Center* > *Search & Indexing*, clear the checkbox next to *Enable search indexing on the client* and click the *Apply* button.
    >
    > The setting will take effect as soon as you log off in Cube and then log on again.
    >
    > Note that this is a system-wide setting, so it will be applied for all users.

- In a DataMiner search, you can use any alphanumeric characters as well as the following characters:

    ```txt
    _ - ( ) [ ] { } # & .
    ```

    > [!NOTE]
    > In an advanced search, “\*” and “?” will be interpreted as wildcard characters. See [Searching with wildcard characters](#searching-with-wildcard-characters).

- For more information on which search terms you can enter to find specific DataMiner items, see [Searching for specific DataMiner items](#searching-for-specific-dataminer-items).

- Hidden elements are not included in the search results.

### Prior to DataMiner 10.0.0/10.0.2

To search for an item in the DataMiner System using a DataMiner version prior to DataMiner 10.0.0/10.0.2, enter a search term in the Search box at the top of the Cube navigation pane. With every character you type, any available results will appear in the navigation pane.

- Up to DataMiner 9.5.10, a search must always contain a term of at least 3 characters. From DataMiner 9.5.11 onwards, a search that includes only search terms of less than three characters can yield results, in case there are exact matches with the specified terms.

- In a DataMiner search, you can use any alphanumeric characters as well as the following characters:

    ```txt
    _ - ( ) [ ] { } # & .
    ```

    > [!NOTE]
    > If you enter “\*” or “?”, these will be interpreted as wildcard characters. See [Searching with wildcard characters](#searching-with-wildcard-characters).

- For more information on which search terms you can enter to find specific DataMiner items, see [Searching for specific DataMiner items](#searching-for-specific-dataminer-items).

- To find items more quickly, you can use special options or keywords. See [Special search options](#special-search-options).

- First a client-side search will be done, then a server-side search. The results of the client-side search are displayed immediately. When more results return from the server, a button will be added in the top corner of the results pane, listing the number of results found. Click this button to view these additional results as well.

    > [!NOTE]
    > In the Cube system settings, it is possible to disable the client-side search. To do so, in a system with a MySQL database, go to *System Center* > *System Settings* > *Search*. In a system with at least DataMiner 9.6.4 and a Cassandra database, go to *System Center* > *Search & Indexing*. Clear the checkbox next to *Enable search indexing on the client* and click the *Apply* button. The setting will take effect as soon as you log off in Cube and then log on again.
    >
    > However, note the following:
    >
    > - This is a system-wide setting, so it will be applied for all users.
    > - If this setting is disabled, up to DataMiner 9.5.0 CU7/9.5.10, no settings will be included in the search results.

- Browse through the results either by scrolling, or using the *UP* and *DOWN* keys. When you select an item in the list, basic information about the item is displayed at the bottom of the navigation pane.

    > [!NOTE]
    > If you browse through the results using the *UP* and *DOWN* keys, the cursor stays in the Search box. This allows you to quickly refine or change the text to be searched without using your mouse.

- Select an item and press *ENTER*, or click an item to open it in a card. Click with the middle mouse button to open the item in a new card, next to any existing cards.

- To clear the Search box and erase the list of search results, click the X on the right.

## Search type filter

If an advanced search returns several kinds of items, it is possible to filter which categories are displayed. To do so, click the *All types* button in the top-left corner, and select the type you wish to display. For some of these types, an additional filter is displayed when you have selected the type filter.

> [!NOTE]
> When server-side results are loaded, the list will be updated when you select a search type from the search type selection box.

| Search type | Description |
|--|--|
| Application      | DataMiner applications, including custom applications and DataMiner tools, such as the Query Executer. |
| Document         | DataMiner documents. See [Documents](xref:About_the_Documents_module). |
| Element          | All elements. An additional filter allows you to limit the search to elements that are monitored, in alarm, masked, or in a particular alarm state. |
| Matrix           | Matrix elements. An additional filter allows you to limit the search to elements that are monitored, in alarm, masked, or in a particular alarm state. |
| Parameter        | All parameters. An additional filter allows you to limit the search to parameters that are or are not trended, or to monitored parameters. |
| Protocol         | DataMiner protocols. See [Protocols](xref:Protocols1). |
| Redundancy group | DataMiner redundancy groups and redundancy group templates. See [About redundancy groups](xref:About_redundancy_groups). |
| Script           | Automation scripts. See [Automation](xref:automation). |
| Service          | DataMiner Services and Spectrum Analysis measurement points. An additional filter allows you to limit the search to services that are monitored, in alarm, masked, or in a particular alarm state. |
| Service template | DataMiner service templates. See [Service templates](xref:Service_templates). |
| Settings         | Cube settings. See [User settings](xref:User_settings) |
| SLA              | SLA elements. See [Business Intelligence](xref:sla). |
| User             | User accounts of the DMS. See [About DataMiner Security](xref:About_DMS_Security). |
| User group       | User groups configured in the DMS. See[User groups](xref:User_groups). |
| View             | DataMiner views. |
| Workspaces       | DataMiner workspaces. See[Working with workspaces](xref:Working_with_workspaces). |

## Searching for specific DataMiner items

To search for an **element**, enter (part of):

- an element name

- a protocol name

- a protocol version

- an alarm template name

- a trend template name

- an element description

- an alarm severity (e.g. critical, etc.)

- an element property displayed in Surveyor

- an element ID, in the format DmaID/ElementID

    > [!NOTE]
    > Searches on ID only work with exact matches. If client-side search indexing is disabled in System Center, searching by ID is not supported.

To search for a **service**, enter (part of):

- a service name

- a service description

- a name of a child element or a child service

- an alarm severity (e.g. critical, etc.)

- a service property displayed in Surveyor

- a service ID, in the format DmaID/ServiceID

    > [!NOTE]
    > Searches on ID only work with exact matches. If client-side search indexing is disabled in System Center, searching by ID is not supported.

To search for a **redundancy group**, enter (part of):

- a redundancy group name

- a redundancy group description

- a redundancy group ID, in the format DmaID/RedundancyGroupID

    > [!NOTE]
    > Searches on ID only work with exact matches. If client-side search indexing is disabled in System Center, searching by ID is not supported.

To search for an element **parameter** (or a matrix label), enter (part of):

- a display name

- an element name

- a protocol name

- a protocol version

- a row display key (for columns, only if one of other criteria matches a column parameter)

- a matrix label

To search for a **user**, enter (part of):

- a logon name

- a full name

To search for a **user group**, enter (part of):

- a group name

To search for a **view**, enter (part of):

- a view name

- a view property displayed in Surveyor

To search for a **video source**, enter (part of):

- a video source name

To search for a **protocol**, enter (part of):

- a protocol name

- a protocol version

To search for a **document**, enter (part of):

- a document title

- a document description

- a file name

## Special search options

For advanced searches, a number of special search options are available:

- To do a negative search, i.e. to look for items that do not match a particular search term, put an exclamation mark in front of the search term.

    E.g. *!redundancy*

- To look for an exact phrase of several words, surround the phrase by double quotes.

    E.g. *“MS Server”*

- The following special keywords can be used in conjunction with a search term, separated from the term with a space.

    | If you enter:  | the search results will contain:                                                        |
    |------------------|-----------------------------------------------------------------------------------------|
    | trend            | elements that have been assigned trend templates as well as trended parameters          |
    | trending         | “                                                                                       |
    | trended          | “                                                                                       |
    | monitored        | only elements and parameters that are being monitored                                   |
    | alarm            | “                                                                                       |
    | inalarm          | only elements and parameters of which the state is not equal to “normal” or “undefined” |
    | online           | only users who are currently logged in                                                  |
    | dma              | only DataMiner Agents                                                                   |
    | element          | only elements                                                                           |
    | elements         | “                                                                                       |
    | view             | only views                                                                              |
    | views            | “                                                                                       |
    | service          | only services                                                                           |
    | services         | “                                                                                       |
    | servicetemplate  | only service templates, listed in the search results under “Services”                   |
    | servicetemplates | “                                                                                       |
    | settings         | Cube user settings                                                                      |
    | SLA              | SLA elements                                                                            |
    | parameter        | only parameters                                                                         |
    | parameters       | “                                                                                       |
    | redundancy       | only redundancy groups                                                                  |
    | user             | only users                                                                              |
    | users            | “                                                                                       |
    | usergroup        | only user groups                                                                        |
    | usergroups       | “                                                                                       |
    | protocol         | only protocols                                                                          |
    | protocols        | “                                                                                       |
    | document         | only documents                                                                          |
    | documents        | “                                                                                       |
    | critical         | only elements, services and parameters with the specified alarm severity.               |
    | major            | “                                                                                       |
    | minor            | “                                                                                       |
    | warning          | “                                                                                       |
    | timeout          | “                                                                                       |
    | normal           | “                                                                                       |
    | masked           | “                                                                                       |

## Searching with wildcard characters

You can use the following two wildcard characters:

- \*, which represents 0 or more characters.

- ?, which represents a single character.

> [!NOTE]
>
> - The expression must always match the entire string (e.g. “a\*” will not match “bar”).
> - The checks are executed using the invariant culture and ignoring case.
> - These characters are not supported for the quick search from the Cube search box, only for the advanced search.

### Examples

```txt
London*
```

- Matches ...

  - London-Amplifier-1

  - London-Amplifier-2

- Does not match ...

  - NewYork-Amplifier-1

  - East-London-Amplifier

```txt
London-Amplifier-?
```

- Matches ...

  - London-Amplifier-1

- Does not match ...

  - London-Amplifier-22

```txt
*-Amplifier-?
```

- Matches ...

  - London-Amplifier-1

  - NewYork-Amplifier-1
