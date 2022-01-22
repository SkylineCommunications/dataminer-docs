---
uid: Restricting_the_number_of_client_sessions_of_a_spectrum_element
---

## Restricting the number of client sessions of a spectrum element

The maximum number of concurrent client sessions of a spectrum analyzer element can be restricted by means of the *Spectrum.MaxRealTimeClients* element property.

> [!NOTE]
> By default, the maximum number of concurrent client sessions is 100. However, when a client starts watching buffers, goes into standby, plays a recording file, etc., the device access is released for other clients to take.

### Adding the Spectrum.MaxRealTimeClients property to a spectrum analyzer element

1. Right-click the spectrum element in the Surveyor and select *Properties*.

2. In the *Custom* tab, click the settings button in the lower left corner and select *Add*.

3. In the *Edit* window, specify the name “Spectrum.MaxRealTimeClients”, and then click *OK*.

4. In the *Custom* tab of the *Properties* window, set the value of the new property to the number of concurrent client sessions allowed for the spectrum element.

5. Click *OK* to close the window.

6. Right-click the spectrum analyzer element in the Surveyor and select *Status \> Restart*.

### Taking over a session from another client

> [!NOTE]
> This feature is only included in the legacy Element Display application, and is no longer available from DataMiner 9.6.0 onwards.

If you try to access a Spectrum Analyzer element and the maximum number of concurrent client sessions has been reached, a warning message will appear that indicates that the maximum number of clients has been reached.

However, in Element Display, users who have been granted the *Spectrum: Take Device From Other Client* permission can disregard that message and take over one of the current sessions.

To do so:

1. In Element Display, in the top-right corner of the graph window, click *x clients*.

    A message box will appear, containing the following message:

    ```txt
    You currently don't have device access. Would you like to take access away from one of the other users that are connected?
    ```

2. Click *Yes* to take over one of the current sessions.

> [!NOTE]
> To access a spectrum element in Element Display, go to *http://**\[MyDMA\]**/DataDisplay.htm?id=**\[ElementID\]*, where MyDMA is the hostname or IP of your DMA and ElementID is the element ID of the spectrum element, in the format DMA ID/element ID.

> [!TIP]
> See also:
> [How can I open the legacy System Display and Element Display applications?](xref:DataMiner_client_applications#how-can-i-open-the-legacy-system-display-and-element-display-applications)
