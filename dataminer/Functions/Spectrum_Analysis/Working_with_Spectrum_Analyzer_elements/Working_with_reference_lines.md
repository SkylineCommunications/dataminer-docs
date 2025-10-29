---
uid: Working_with_reference_lines
---

# Working with reference lines

In the real-time interface, you can add reference lines in order to help you make measurements. These are listed separately in the info pane.

Two types of reference lines are available:

- Amplitude reference lines: horizontal line in the spectrum.

- Frequency reference lines: vertical line in the spectrum.

## Adding reference lines

- To create an amplitude reference line, there are two ways:

  - Go to the *reference lines* tab in the ribbon, and select *Add amplitude reference line*.

  - In the info pane, click the button *Add amplitude line*.

- To create a frequency reference line, there are two ways:

  - Go to the *reference lines* tab in the ribbon, and select *Add frequency reference line*.

  - In the info pane, click the button *Add frequency line*.

## Linking reference lines to measurement points

Reference lines can be linked to measurement points. This way, if you switch to a measurement point, only the reference lines that are linked to it are displayed.

If you create a new reference line, and one or more measurement points are selected in the current preset, the reference line will automatically be linked to these measurement points.

In addition, you can also configure to which measurement points an existing reference line is linked:

1. In the *Reference lines* list of the info panel, click the pencil icon next to the relevant reference line.

1. In the *Edit reference line* dialog box, click *Link to measurement points.*

   > [!NOTE]
   > This option is only displayed if at least one measurement point is available.

1. In the *Link to measurement points* dialog box, select *Measurement point selection*, and select the measurement points to which you want to link the reference line.

1. Click *OK* to confirm your changes and close the dialog box.

> [!NOTE]
> In case a measurement point is removed, any reference lines linked to it will not be removed from presets they have been stored in. However, they will no longer be displayed in the spectrum graph or info pane.

## Reference line options

The following options are available for spectrum reference lines:

- **Showing or hiding reference lines**:

  Go to the *reference lines* tab in the ribbon, and select *Show reference lines*. Clear the selection to hide reference lines.

- **Adding or changing a reference line label**:

  To add a label to a reference line or to change an existing label, click the pencil icon next to the reference line coordinates in the info pane, enter a new *Name* in the pop-up window, and click *OK*.

- **Moving reference lines**:

  There are two ways to move a reference line:

  - Click and drag the line to its new position.

  - Click the pencil icon next to the reference line coordinates in the info pane, enter a new frequency or amplitude in the pop-up window, and click *OK*.

- **Deleting reference lines**:

  To delete a single reference line, click the *x* next to its coordinates in the info pane. To delete all reference lines at once, go to the *reference line* tab of the ribbon and select *Delete all reference lines*.

- **Changing reference line colors**:

  To change the color of reference lines or their labels, go to the *reference lines* tab in the ribbon and select a different color in the appropriate dropdown list.

- **Linking reference lines to measurement points:**

  See [Linking reference lines to measurement points](#linking-reference-lines-to-measurement-points).
