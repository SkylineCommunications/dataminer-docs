---
uid: Connecting_to_an_element_using_Stream_Viewer
---

# Connecting to an element using Stream Viewer

To open Stream Viewer for a particular element:

1. Right-click the element in the Surveyor, or open the element card’s hamburger menu.

1. In the context menu or header menu, select *View* > *Stream Viewer*.

The Stream Viewer window consists of two panes:

- On the left is a tree view that can be used to filter the stream per connection, group or pair.

  > [!NOTE]
  > From DataMiner 10.1.0 [CU22]/10.2.0 [CU10]/10.3.1 onwards, the Stream Viewer tree view supports more levels in case of HTTP communication.

- On the right, the communication stream is displayed for the selected item in the tree view.

At the bottom of the Stream Viewer window, there are five buttons:

| Button    | Functionality                                                                           |
|-----------|-----------------------------------------------------------------------------------------|
| Sniffer   | Opens the Stream Sniffer, which allows the capture of a stream for diagnostic purposes. |
| Save as   | Saves the communication stream as a TXT file.                                           |
| Freeze    | Freezes the communication stream. Click again to unfreeze the stream.                   |
| Clear     | Clears the buffer for the item currently selected in the tree view pane.                |
| Clear All | Clears the buffer for all items and resets Stream Viewer.                               |

To search for a particular item in the communication stream, use the *Find* box in the top-right corner of the window. Navigate between search results using the arrow buttons next to the *Find* box.
