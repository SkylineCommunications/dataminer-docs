---
uid: View_Cards
---

# View cards

On the left side of a view card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the view.

- *Below this view*: Contains pages listing the different elements and services in the view and its subviews.

- *Alarms*: Displays the active alarms for the view.

- *Reports*: Displays the DataMiner reports related to the view.

- *Histogram*: Available from DataMiner 10.0.3 onwards. Allows you to display a histogram of a protocol parameter for all elements of this protocol in the view. The parameter can be selected in the sidebar on the right. Once a valid parameter has been selected, you can click *Show histogram* to show or refresh the histogram. The side panel also has a settings tab where you can apply the following options:

  - *Include subviews*: Only displayed in case the view contains other views. Determines whether those subviews should also be taken into account.

  - *Use relative frequency*: Determines whether the frequency on the Y-axis should be shown in percent.

  - *Use custom intervals*: Allows you to specify a custom number of intervals and interval range.

- *Notes*: Allows you to add and view notes for the view.

View cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to a view using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/view/*\<view ID>*/*\<view page>

The view page in this URL is optional; if it is not specified, the default page is displayed. To go to a visual page, specify *visual/*\<view page>. For example: *http://*\<DMA IP>*/monitoring/view/103/visual/0*
