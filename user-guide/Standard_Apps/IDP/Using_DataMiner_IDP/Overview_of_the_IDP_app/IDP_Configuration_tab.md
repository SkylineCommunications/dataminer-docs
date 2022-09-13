---
uid: IDP_Configuration_tab
---

# Configuration tab

This tab consists of several subtabs, as detailed below.

## Summary

This tab provides an overview of the elements of which the CI Type has *Take Backup* and/or *Configuration Update* enabled (via *Processes* > *Automation*). The overview includes the CI Type, element name and IP address for each element, as well as the update progress of the last backup that was copied to the configuration archive, and the date and time when the last configuration change was detected.

Above the overview, the following buttons are available:

- *Backup*: Creates a configuration backup of the selected elements.

- *Default*: Applies the default configuration to the selected elements.

- *Compare*: Starts a configuration comparison with the selected file as one of the files to be compared.

- *Show Backups*: Displays all available configuration backups from the last 30 days for the selected element in the *Backups* tab.

## Backups

On this tab, you can view a list of configuration backups, either based on a selection in the *Summary* tab as mentioned above, or based on specific search criteria. The list mentions the element name, the timestamp of the backup, the backup type, the backup size and whether a change was detected compared to the previous backup.

Clicking the *Search* icon opens a wizard where you can specify these search criteria. Searching is possible by CI Type, by element name or by time range (UTC), or a combination of these. When you select a configuration backup in the table, you can also use the following buttons above the table:

- *Show content*: Displays the content of the selected configuration backup to the right of the list. Above the content, a drop-down box allows you to select whether the *Full Configuration Backup* should be displayed or the *Core Configuration Only*. This last option allows you to focus on the information that is most important for the configuration.

- *Compare*: Starts a configuration comparison with the selected file as one of the files to be compared.

## Update

This tab allows you to apply a configuration backup file to one or more elements. To do so, select the configuration backup file in the table on the left, and the elements in the table on the right (keep the Ctrl key pressed to select several elements at a time). Then click the *Update* button above the table.

> [!NOTE]
> When a configuration backup is applied, the backup file is first copied from the DataMiner Configuration Archive to the working directory on the DMAs hosting the selected elements. This means that a working directory must be configured for each DMA in the DMS. You can do so via *Admin* > *Configuration* > *Network Shares*. See [Configuration](xref:Configuration).

## Compare

This tab allows you to compare two configuration files. To do so:

1. Start a search to get a list of configuration files matching specific search criteria.

1. Use the buttons above the table to select the configuration files to show on the left side and on the right side of the comparison, and click the *Compare* button to start comparing them.

With the drop-down box in the top-right corner, you can select whether you want to compare the *Full Configuration Backup* or the *Core Configuration Only*. This last option allows you to focus on the information that is most relevant for comparison.

If you started a comparison from the *Summary* or *Backups* subtab, the file you selected there will automatically be selected as the left file in the comparison.

To clear the current file selection, click *Clear*.

  > [!NOTE]
  > Files can only be compared if they have an extension listed under *Admin* > *Configuration* > *Backup*. See [Configuration](xref:Configuration).
