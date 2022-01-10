## Working with frequency masks

> [!NOTE]
> This feature is only included in the legacy Element Display application, and is no longer available from DataMiner 9.6.0 onwards.

As a visual aid for carrier alignment, it is possible to use frequency masks. However, at this point, this functionality is only available in the legacy Element Display client application.

To access a spectrum element in Element Display, go to *http://**\[MyDMA\]**/DataDisplay.htm?id=\[ElementID\]*, where MyDMA is the hostname or IP of your DMA and ElementID is the element ID of the spectrum element, in the format DMA ID/element ID.

> [!TIP]
> See also:
> [How can I open the legacy System Display and Element Display applications?](../../part_6/faq/DataMiner_client_applications.md#how-can-i-open-the-legacy-system-display-and-element-display-applications)

### Showing/hiding frequency masks

To show frequency masks in Element Display:

- Go to the *Tools* menu, and select *Frequency Mask \> View Frequency Mask*.

To hide frequency masks in Element Display:

- Go to *Tools \> Frequency Mask* and clear the selection from *View Frequency Mask*.

### Defining frequency masks

To define a frequency mask in Element Display:

1. Go to *Tools \> Frequency Mask \> Create/Edit*.

    The *Settings* window will open on the tab *Freq Mask*.

2. Next to *Ref. Amplitude*, enter a reference amplitude for the mask.

3. Next to *Symbol Rate (R)*, enter a symbol rate.

4. Next to *Ref. Freq. Center*, enter the reference center frequency.

    Alternatively, you can also select *Use current* to apply the same center frequency as in the current spectrum display.

5. Double-click the fields in the upper bound and lower bound area to add new points of the frequency mask.

    While you do this:

    - If you select a point in the upper bound or lower bound editor, those points will be highlighted in the actual frequency mask.

    - When you edit points, the frequency mask will immediately be adapted in the background to reflect the changes.

6. Click *Exit* when ready.

> [!NOTE]
> When the trace breaches the upper or lower bound, FAIL will be displayed instead of PASS, and the shading of the associated area will be color-coded. To customize the colors in question, go to *Options \> Preferences* and select different colors for *Failed Freq Mask Shading*, *Freq Mask Upper Bound* and/or *Freq Mask Lower Bound*.

### Importing and exporting frequency masks

To import a frequency mask in Element Display:

1. Go to *Tools \> Frequency Mask \> Create/Edit*.

2. Click the *Import* button at the bottom of the *Settings* window.

3. Browse to the .csv file you wish to import, and click *Open*.

To export a frequency mask in Element Display:

1. Go to *Tools \> Frequency Mask \> Create/Edit*.

2. Click the *Export* button at the bottom of the *Settings* window.

3. Browse to the location where you wish to save the .csv file, and click *Save*.
