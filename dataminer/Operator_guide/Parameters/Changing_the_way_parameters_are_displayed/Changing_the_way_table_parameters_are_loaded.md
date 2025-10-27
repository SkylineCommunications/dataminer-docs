---
uid: Changing_the_way_table_parameters_are_loaded
---

# Changing the way table parameters are loaded

By default, lazy loading is activated for table parameters in Cube. This means that table parameters are only loaded when the page containing the table parameter is opened.

In the system settings, a setting is available that allows you to specify whether lazy loading should be applied or not. Disabling this option will cause all table parameters of an element to be loaded as soon as you open the element card. This may improve responsiveness when switching between pages of an element, but it can cause a longer initial load time.

To enable or disable lazy loading of table parameters:

1. In DataMiner Cube, go to *Apps* > *System Center* > *System settings* > *data display*.

1. Toggle the option *Enable lazy loading for tables* and click the *Apply* button in the lower-right corner.
