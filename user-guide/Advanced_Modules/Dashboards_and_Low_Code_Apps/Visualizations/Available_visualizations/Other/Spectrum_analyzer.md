---
uid: DashboardSpectrumAnalyzer
---

# Spectrum analyzer

This component can be used to display a spectrum graph. Available from DataMiner 10.0.10 onwards.

To configure the component:

1. Add a spectrum element feed or (from DataMiner 10.0.11 onwards) a spectrum buffer feed. You can also link to a feed component where a user can select the element feed or buffer feed.

1. Optionally, you can also add a spectrum preset as a filter. If no preset filter is specified, the component will display the graph for the most recently closed spectrum session of the current user for the selected spectrum element.

Please note the following regarding this component.

- The displayed trace colors and grid colors depend on the preset and cannot be changed in the component configuration. The same goes for the background color and text color of the spectrum graph, and for the show/hide settings for the grid and for axis labels.

- You can let the user select the spectrum preset by adding a drop-down feed component as a data source for the spectrum analyzer component. Use the *Spectrum presets* group as a data source for the feed component and then add a protocol filter to configure it.

- To add a spectrum buffer to a feed component, you can either add an individual spectrum buffer, or add the spectrum buffers group and then add a spectrum element filter.

- If a spectrum analyzer component uses a spectrum buffer feed, it is possible to color the threshold lines from the preset based on the state of a spectrum monitor parameter. For this purpose, the spectrum monitor must use a script containing variables that refer to the threshold lines. Each threshold line has a threshold ID, which is an index ranging from 1 to the total number of thresholds in the preset. To refer to the first threshold, the script variable should be *$threshold1*, for the second threshold, it should be *$threshold2*, etc. This format is case-sensitive. When you configure the spectrum monitor parameters, you can then select these variables to create a parameter with alarm monitoring (see [Configuring spectrum monitors](xref:Working_with_spectrum_monitors#configuring-spectrum-monitors)).

- To allow users to visualize and switch between measurement points for a spectrum session (supported from DataMiner 10.0.11 onwards):

  1. Ad a spectrum analyzer component and use a spectrum analyzer element as its data input.

  1. Optionally, add a spectrum preset filter.

  1. Add a list feed component (see [List](xref:DashboardListFeed)) and add the spectrum session feed from your spectrum analyzer as its input.

  A list of all the available measurement points will then be shown, with a colored LED. This LED will be a filled circle for the active measurement point and an empty circle for other measurement points. If measurement points are selected in the list, this will update the spectrum session, so that the spectrum analyzer visualization shows those measurement points.

- In DataMiner 10.0.10 only, it was possible to configure a trigger action on a spectrum analyzer component, so that clicking the component opened another dashboard. However, this feature is no longer available from DataMiner 10.0.11 onwards.
