---
uid: DMAPP_Legacy_tab
---

# DMAPP (Legacy) tab

The *DMAPP (Legacy)* tab allows you to configure and build the DMAPP package, in the legacy format from before DataMiner 10.0.11.

- The *Description* text box allows you to provide a description for the package. This description will be used to build the *Description.txt* file.

- The *Files to Delete* and *Files to Leave* list boxes allow you to specify the files to be removed or kept, respectively.

- The *Startup Actions* list box allows you to specify startup actions that have to be performed and the order in which these need to be performed. Based on the actions defined here, a *StartUpActions.txt* file will be generated in the folder *Upgrades\\StartUpActions* in the Update.zip file.

    > [!NOTE]
    > For an overview and explanation of the different startup actions that are available, see [StartUpActions.txt](xref:Actions_that_can_be_performed_during_an_upgrade_operation#startupactionstxt).

- The *Update Content* list box allows you to specify the actions that must be performed during an upgrade operation (e.g. update entries for each selected folder).

    > [!NOTE]
    > For an overview and explanation of the different actions that are available, see [UpdateContent.txt](xref:Actions_that_can_be_performed_during_an_upgrade_operation#updatecontenttxt).
    >
