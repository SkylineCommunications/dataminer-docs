---
uid: Restricting_the_number_of_client_sessions_of_a_spectrum_element
---

# Restricting the number of client sessions of a spectrum element

The maximum number of concurrent client sessions of a spectrum analyzer element can be restricted by means of the *Spectrum.MaxRealTimeClients* element property.

> [!NOTE]
> By default, the maximum number of concurrent client sessions is 100. However, when a client starts watching buffers, goes into standby, plays a recording file, etc., the device access is released for other clients to take.

1. Right-click the spectrum element in the Surveyor and select *Properties*.

1. In the *Custom* tab, click the settings button in the lower left corner and select *Add*.

1. In the *Edit* window, specify the name “Spectrum.MaxRealTimeClients”, and then click *OK*.

1. In the *Custom* tab of the *Properties* window, set the value of the new property to the number of concurrent client sessions allowed for the spectrum element.

1. Click *OK* to close the window.

1. Right-click the spectrum analyzer element in the Surveyor and select *Status \> Restart*.
