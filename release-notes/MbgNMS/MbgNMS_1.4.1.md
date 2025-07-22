---
uid: MbgNMS_1.4.1
---

# MbgNMS 1.4.1

## New features

#### Configuration rules bulk actions [ID 43363]

It is now possible to include, exclude, and delete configuration rules in bulk. You can do so via the context menu of the configuration rules table.

## Enhancements

#### "Running" backup option now retrieves complete configuration [ID 43275]

The mbgNMS backup option "Running" will now fetch the complete running configuration, which contains the same information as a manual backup configuration via the web interface of a device. Previously, some information, such as user information and certificates, was not included in the backup. You can view this "running" backup and restore it to a device. The data is retrieved and sent through an SSH connection.

#### Meinberg Element Manager app improvements [ID 43276]

A number of improvements have been implemented in the Meinberg Element Manager app:

- To avoid confusion, double-clicking an entry in the *Inventory Summary* table no longer opens the details page.
- The *Configuration* page has been renamed to *Backups*.
- The *Inventory*, *Backups*, and *Software* tabs have been shifted one level up and the Equipment tab has been removed.
- The *Summary*, *Backups*, and *Update* pages under *Equipment* > *Configuration* have been combined into one page, named *Overview*.
- The *Update* button has been renamed to *Restore*.
- A *Device Type* filter has been added to the *Backups* > *Rules* page.
