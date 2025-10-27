---
uid: Configuring_a_spectrum_element_to_follow_the_device_settings
---

# Configuring a spectrum element to follow the device settings

A spectrum element can be configured to initially load the settings from the device instead of from a cached preset stored per client. This makes it possible to fine-tune the device directly, so that any changes are reflected in the DataMiner element.

To configure a spectrum element to follow the device settings:

1. Either create a new spectrum element or edit an existing spectrum element. (See [Adding elements](xref:Adding_elements) or [Updating elements](xref:Updating_elements), respectively.)

1. In the *Advanced element settings* section, select *Follow device settings*.

1. To make sure that traces are also shared between clients, select *Shared session mode*. See [Enabling shared session mode](xref:Viewing_spectrum_analyzer_traces#enabling-shared-session-mode). Though you do not have to select this option, it is highly recommended.

1. Click *Apply*.
