---
uid: Working_with_markers
---

# Working with markers

Markers can be used to help you make measurements, by identifying points of traces. There is no limit to the number of markers you can place.

Different modes are available:

- In normal mode, the exact amplitude and frequency of each marker are displayed in the information pane.

- In delta mode, the information pane shows the exact amplitude and frequency of the reference marker, and for all other markers it shows the difference with the reference marker.

The following sections provide more information on working with markers in Cube:

- [Adding a marker](#adding-a-marker)

- [Moving a marker](#moving-a-marker)

- [Marker options](#marker-options)

## Adding a marker

1. In the info pane, to the right of the real-time display on the spectrum analyzer card, click the *Add marker* button.

    The marker is automatically added at the center frequency, and takes the color of the trace. If you move the marker to a different trace, the color will be adapted accordingly.

2. Click the pencil icon to the right of the marker to specify its settings.

3. Optionally, in the pop-up window, add a name in the *Name* field.

4. In the *Frequency* field, you can enter a different frequency for the marker.

    Alternatively, a marker can also be dragged to a different frequency on the real-time display or moved through the right-click menu. See [Moving a marker](#moving-a-marker).

5. To create a special type of marker, select the appropriate checkboxes:

    - **Reference marker**: A marker used as the reference to compare other markers with in delta mode. In contrast to normal maskers, which are displayed as triangles, reference markers are diamond-shaped.

    - **Noise marker**: A marker used to measure the noise floor. Whereas the triangles marking normal markers are fully colored, for noise marker only the outline of the triangles is shown.

    - **Lock to peak**: Locks the marker to a peak of the trace.

    - **Lock to trace**: Locks the marker to the trace.

    > [!NOTE]
    > You can also quickly change an existing marker into a reference marker or noise marker by right-clicking the marker and selecting *Reference marker* or *Noise marker* respectively.

6. Click *OK* to save your changes and close the pop-up window.

> [!NOTE]
> From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards<!--RN 37705-->, if you have entered a different frequency for the marker, you can set the marker back at the center frequency by clicking the ![center frequency](~/user-guide/images/Center_Frequency.png) button to the right of the marker.

## Moving a marker

To move a marker in Cube, you can:

- Click the pencil icon next to the marker in the info pane, and enter a new marker frequency.

- Click the ![center frequency](~/user-guide/images/Center_Frequency.png) button next to the marker in the info pane to move the marker to the center frequency (available from DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards<!--RN 37705-->).

- Drag the marker to a different position on the real-time display.

- Right-click the marker and select one of the following options in the *Move marker* submenu:

    | Option         | Description                                        |
    |------------------|----------------------------------------------------|
    | Peak high        | Moves the marker to the highest peak.              |
    | Peak high left   | Moves the marker to the highest peak to the left.  |
    | Peak high right  | Moves the marker to the highest peak to the right. |
    | Peak low         | Moves the marker to the lowest peak.               |
    | Peak low left    | Moves the marker to the lowest peak to the left.   |
    | Peak low right   | Moves the marker to the lowest peak to the right.  |
    | Center frequency | Moves the marker to the center frequency.          |
    | Start frequency  | Moves the marker to the start frequency.           |
    | Stop frequency   | Moves the marker to the stop frequency.            |

    > [!NOTE]
    > These options are also available in the *markers* menu in the ribbon.

## Marker options

In the ribbon of a spectrum analyzer card, the *markers* tab provides several additional options:

- **Show markers**:

    Select this option to show the markers; clear the selection to hide them.

- **Delete all markers**:

    Select this option to permanently remove all markers from the trace.

- **Delta mode**:

    Select this option to enter delta mode, so that the values for normal markers are shown relative to the reference marker.

- **Link markers**:

    Select this option to link the markers together, so that if you move one marker, the other markers moves accordingly.

- **Float noise markers**:

    Select this option to ensure the noise markers remain in the visible field.

- **Lock all markers to trace**:

    Locks all markers to the trace they are currently on, so that they cannot be dragged to another trace.

- **Reference marker**:

    Changes the selected marker into a reference marker, or if it already is a reference marker, into a regular marker.

- **Noise marker**:

    Changes the selected marker into a noise marker, or if it already is a noise marker, into a regular marker.

- **Lock to peak**:

    Locks the selected marker to a peak of the trace.

- **Lock to trace**:

    Locks the selected marker to the trace, so that it cannot be dragged to another trace.

- **Move trace \> Center frequency to marker frequency**:

    Sets the center frequency to the frequency of the marker.

- **Move trace \> Reference level to marker level**:

    Sets the reference level to the amplitude of the marker.

> [!NOTE]
> - Several of these options are also available through the marker right-click menu.
> - If one or more markers have been locked to the trace, and you close and then re-open the spectrum card, it will again be possible to move the markers freely.
>
