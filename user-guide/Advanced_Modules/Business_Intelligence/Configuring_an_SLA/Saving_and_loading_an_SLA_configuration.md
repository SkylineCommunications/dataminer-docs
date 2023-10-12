---
uid: Saving_and_loading_an_SLA_configuration
---

# Saving and loading an SLA configuration

It is possible to save the configuration of an SLA element in DataMiner Cube. This can be done from any of the following pages: the *SLA Configuration* page, the *Compliance Configuration* page, and the *Violation Configuration* page.

> [!NOTE]
>
> - The saved configuration includes all parameters on the “Configuration” pages, except the manual reset. Other pages, e.g. *Offline Window*, are not included.
> - The parameter *Maximum Single Violations Percentage* is only included from versions 2.0.0.26 and 3.0.0.1 of the *Skyline SLA Definition Basic* protocol onwards.

## Saving the SLA configuration

1. At the top of an SLA configuration page, click the *Save/Load Config* button.

1. In the *Save/Load Configuration* window, specify the config file:

   - If you wish to save the configuration to a new file, enter the file name in the *Configuration Name* box and click the green check mark.

   - If you wish to save the configuration to an existing file, select the file in the drop-down list next to *Configuration Name*, and click the green check mark.

   > [!NOTE]
   > The configuration files are saved in the folder *C:\\Skyline DataMiner\\Documents\\SLA Configurations*. If you want to save the configuration to a file that is already in this folder, but this file does not appear in the drop-down list, click the *Load Configurations* button to refresh the list first.

1. Click the *Save* button.

## Loading settings that have been saved for a particular configuration page

1. At the top of an SLA configuration page, click the *Save/Load Config* button.

1. Select the configuration file in the *Configuration Name* drop-down list and click the green check mark.

   If an existing configuration file is not displayed in the drop-down list, click the *Load Configurations* button to refresh the list.

1. Click the *Load* button.

## Removing existing configuration files

Existing configuration files can either be removed in the *Documents* module, or via the *Save/Load Config* button of the SLA element:

- In the *Documents* module, go to the *SLA Configurations* folder, right-click the relevant configuration file and select *Delete*.

- In the *Save/Load Configuration* window, select the relevant configuration file, in the same way as when you select a file to save or load a configuration, but then click the *Delete* button instead.
