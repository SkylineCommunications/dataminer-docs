---
uid: Importing_and_exporting_elements
---

# Importing and exporting elements

> [!NOTE]
> For more information on importing and exporting elements, services, etc. using .dmimport packages, see [Exporting and importing packages on a DMA](xref:Exporting_and_importing_packages_on_a_DMA).

## Importing elements from a CSV file

1. Either open the card of the view where you want to import the elements and click the hamburger button in the top-left corner, or right-click the view in the Surveyor.

1. In the menu, select *Actions \> Import*.

   > [!NOTE]
   > If you do not have the *Config* permission for a particular view, export and import actions will not be available for this view.

1. In the lower-left corner of the *Import* window, select *Import comma-separated file*.

1. In the *Import file* dialog box, select the CSV file you want to import, and click *Open*.

> [!NOTE]
>
> - If DataMiner detects invalid data when elements are imported, a notice will be generated. This can for instance be the case when you import a new element and data is missing, or when something is wrong with the formatting.
> - Only import CSV files that have been created by DataMiner during a previous export. See [Exporting elements to a CSV file](#exporting-elements-to-a-csv-file).
> - For more information on how you can modify an exported CSV file for later import, see [Altering an exported CSV file in a third-party application](#altering-an-exported-csv-file-in-a-third-party-application).
> - For more information on how DataMiner checks for duplicate names, see [Duplicate name check](#duplicate-name-check).
> - For elements communicating via SNMPv3, some fields in the CSV file have a different meaning. See [Altering an exported CSV file in a third-party application](#altering-an-exported-csv-file-in-a-third-party-application).

### Duplicate name check

When you import elements via a CSV file, DataMiner checks for duplicate names.

Name checks are case-insensitive. This means that for instance "element1" is considered identical to "ELEMENT1".

- **Check for duplicate element names in the CSV file**: If several lines in the CSV file contain the same element name, none of the lines sharing that same name will be imported. For each of those lines, an error message like the following one will be generated:

  ```txt
  Import elements failed. Line 7 contains existing element name (in import file).(MyElementName)
  ```

- **Check for duplicate names in the DataMiner System**: If a line in the CSV file contains an element name that already exists within the DataMiner System, that line will not be imported and an error message like the following one will be generated:

  ```txt
  Import elements failed. Line 1 contains existing element name (DMS). (MyElementName)
  ```

## Exporting elements to a CSV file

> [!NOTE]
> To export element information to a printer or to the clipboard, you can also follow this procedure.

1. Either open the card of the view from which you want to export the elements and click the hamburger button in the top-left corner, or right-click the view in the Surveyor.

   > [!NOTE]
   >
   > - To export all elements in a DMS, use the root view.
   > - To export several elements at the same time, select them in the list on a view card (using Shift or Ctrl) and then right-click them.
   > - If you do not have the *Config* permission for a particular view, export and import actions will not be available for this view.

1. In the menu, select *Actions \> Export*.

1. In the lower-left corner of the *Export* window, select *Export to comma-separated file (\*.csv), clipboard or print*.

1. In the *WHAT* section of the *Export* window, select what is to be included in the export:

   - All data (suitable for CSV import),

   - The data displayed in the element list of a view card,

   - *Only IDs*, with or without view IDs, or

   - *Only IP addresses with hostnames*, with or without DMA IP addresses and polling IP addresses/Serial Gateways.

1. In the *HOW* section of the *Export* window, select what kind of export you want to make:

   - *export to CSV:* exports the element information to a CSV file, which can be used for an import in DataMiner.

   - *copy to clipboard*: makes a copy of the element information to the clipboard.

   - *print*: exports the element information to a printer.

   > [!NOTE]
   > Private information, such as SNMPv3 authentication and encryption passwords, will not be exported for security reasons.

1. Click *Export*.

1. Depending on the type of export you selected, you will still need to:

   - Indicate where the file is to be saved and optionally specify a custom file name, for an export to CSV;

   - Click *OK* in a confirmation message, for a copy to clipboard; or

   - Determine the printing settings, for an export to a printer.

## Altering an exported CSV file in a third-party application

When altering an exported CSV file in a third-party application like Microsoft Excel, in order to import the altered file into a DMS afterwards, take the following into account:

- After an import operation, an element will be **restarted** if relevant information related to that element has been changed.

- When changing existing elements, **do not change the DataMiner ID or the element ID**.

- A row with no element ID will **create a new element** instead of altering an existing one.

- You **cannot delete** existing elements by importing a CSV file.

- When you import a CSV file into MS **Excel**, remember that **tabs will be automatically removed**. MS Excel does not support the use of tabs inside cell values. If you want tabs to survive an import operation, replace each tab by *\\t*.

- For elements communicating via SNMPv3, some fields in the CSV file have a different meaning:

  | Field name    | SNMPv3 parameter                                                             |
  |---------------|------------------------------------------------------------------------------|
  | Parity        | Authentication algorithm (MD5, SHA-1, SHA-224, SHA-256, SHA-384, or SHA-512) |
  | Data Bits     | Username                                                                     |
  | Stop Bits     | Security level and protocol (noAuthNoPriv, authNoPriv, or authPriv)          |
  | Flow Control  | Encryption algorithm (DES, AES-128, AES-192, or AES-256)                     |
  | Get Community | Authentication password                                                      |
  | Set Community | Encryption password                                                          |

- Import operations are **asynchronous**. The DataMiner client will send the imported file to the DMA to which it is connected. That DMA will then process the file when appropriate. To check the progress of an import operation, consult the list of information events.

- The **ProtocolType** column in the CSV file contains a numeric value that corresponds to the communication type that is defined in the protocol XML. When there are multiple connections defined in the protocol, the values are separated by a comma. This is the mapping:

  | Protocol Type | Description                        |
  |---------------|------------------------------------|
  | 0             | Undefined                          |
  | 1             | SNMP                               |
  | 2             | Serial                             |
  | 3             | Smart-serial                       |
  | 4             | Virtual                            |
  | 5             | GPIB                               |
  | 6             | OPC                                |
  | 7             | SLA                                |
  | 8             | SNMPv2                             |
  | 9             | SNMPv3                             |
  | 10            | HTTP                               |
  | 11            | Service                            |
  | 12            | Serial-single                      |
  | 13            | Smart-serial-single                |
  | 14            | Smart-serial-raw                   |
  | 15            | Smart-serial-raw-single            |
  | 16            | Websocket                          |
  | 17            | Virtual-function                   |
  | 18            | Auto-generated                     |
