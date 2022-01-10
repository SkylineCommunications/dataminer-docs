## Configuring a spectrum element to follow the device settings

From DataMiner 9.6.11 onwards, a spectrum element can be configured to initially load the settings from the device instead of from a cached preset stored per client. This makes it possible to fine-tune the device directly, so that any changes are reflected in the DataMiner element.

To configure a spectrum element to follow the device settings:

1. Either create a new spectrum element or edit an existing spectrum element. (See [Adding an element](../../part_2/elements/Adding_and_deleting_elements.md#adding-an-element) or [Updating elements](../../part_2/elements/Updating_elements.md), respectively.)

2. In the *Advanced element settings* section, select *Follow device settings*.

3. To make sure that traces are also shared between clients, select *Shared session mode*. See [Enabling shared session mode](Viewing_spectrum_analyzer_traces.md#enabling-shared-session-mode). Though you do not have to select this option, it is highly recommended.

4. Click *Apply*.
