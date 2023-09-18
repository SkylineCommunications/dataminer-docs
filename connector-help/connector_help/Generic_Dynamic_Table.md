---
uid: Connector_help_Generic_Dynamic_Table
---

# Generic Dynamic Table

This connector keeps a list of entries with a unique key and text and/or numeric value.

## About

This generic connector allows you to keep a list of data entries defined by a unique key name. Each entry can have a text value (on which alarm monitoring can be activated) and a numeric value (on which both alarm monitoring and trending can be activated). Each entry contains a column with the time when it was last updated. By default, 1000 entries will be saved. An automatic cleanup mechanism will check to remove expired entries when a maximum age is defined.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Entries

To avoid an endlessly growing list of entries, a maximum number of entries is defined. You can adjust this maximum using the **Entries Maximum Entries** parameter on the **Maintenance** subpage of the **General** page.

The default limit is 1000 rows, but this can be increased up to 100,000 rows.

## Usage

### General

This page contains a list of entries, a button to add an entry and a page button that provides access to the **Maintenance** page.

The **Add** button will add an entry with an empty text value, a numeric value of 0 and a numeric incrementing key name prefixed with *Entry.*

Each entry in the **Entries** list contains:

- A unique **Key Name**. This is the displayed index of this table.

- A **Text Value**. Alarm monitoring can be activated on this value.

- A **Numeric Value**, which is saved as a double and limited to 3 decimals. Alarm monitoring and trending can be activated on this value.

- The **Last Update** time (displayed in the time zone of the element's DMA), which indicates when the entry was last updated. This time will also be used by the automatic cleanup mechanism.

- A button to **Delete** the entry.

- The context menu allows you to:

- **Add** **Entry**: Add an entry, with the provided key name, text value and numeric value.
  - **Cleanup**: Perform a forced cleanup of the table, considering **Entries Maximum Entries** and **Entries Maximum Age**.
  - **Delete Entry/Delete Entries**: Remove the selected entries from the list. After you confirm this action, the entries cannot be restored.
  - **Clear**: Remove all entries. After you confirm this action, the entries cannot be restored.

### General/Maintenance

On the **Maintenance** subpage, the maximum number of entries in the list can be defined with the parameter **Entries Maximum Entries**. This parameter will be checked whenever entries are added or cleaned up. When there are more entries than the defined maximum, the oldest entries (based on *Last Update*) will be removed. You can set expired entries to be removed automatically upon every cleanup by setting **Entries Maximum Age**. An automatic cleanup will be performed every hour, but can be forced using the **Cleanup** button.

The **Clear** button will remove all entries. After you confirm this clear action, the entries cannot be restored.

### Automation

On this page, you can perform particular actions using a single command:

- **Automation Command Delimiter**: Allows you to define the delimiter that will be used to split up the commands.
- **Automation Add Entries**: Allows you to add a series of new entries with the specified key names, delimited by the command delimiter.
- **Automation Add or Update Text Value**: Allows you to add or update the text value of the entry with the specified key. The command must contain the key and text value, delimited by the command delimiter.
- **Automation Add or Update Numeric Value**: Allows you to add or update the numeric value of the entry with the specified key. The command must contain the key and numeric value, delimited by the command delimiter. Numeric values will be interpreted as a double.
- **Automation Change Key**: Allows you to change the entry key. The command must contain the current key and the new key, delimited by the command delimiter.
- **Automation Delete Entries**: Allows you to delete a series of entries with the specified keys, delimited by the command delimiter.
