---
uid: SLNetClientTest_tool_UI
---

# Overview of the SLNetClientTest tool UI

The most important features of the SLNetClientTest tool user interface are the menu at the top and the three tabs at the bottom. In the menu, a host of different diagnostic and troubleshooting commands are available. Depending on the selected tab at the bottom, a different UI is shown.

Most functionality is only available after you [connect to a DMA](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Properties tab

The *Properties* tab shows an overview of the different messages have been sent, with the time they were sent and the time it took to get a response.

When you select a message in the list, the pane on the right shows more detailed information. With the *Grid* and *Text* tabs at the top of that pane, you can switch between two different ways of viewing this information.

At the bottom of the tab, three filter boxes are available. The leftmost box will highlight messages in yellow, the middle box highlights them in cyan, and the box on the right allows you to filter based on a regular expression. Note that the box on the right is only available from DataMiner 10.5.11/10.6.0 onwards<!-- RN 43540 -->, and it should only be used when no new messages are expected to arrive.

![SLNetClientTest tool Properties tab](~/dataminer/images/SLNetClientTest_UI.png)<br>*SLNetClientTest tool Properties tab in DataMiner 10.5.11*

## Output tab

The *Output* tab displays detailed results from commands sent with the tool.

A filter box is available at the bottom. Any text you enter in the box will be highlighted in the pane above. If the *Filter Lines* box is selected, only the lines containing text that matches the filter will be shown.

With the two buttons next to the filter box, you can decrease and increase the font size of the text.

![SLNetClientTest tool Output tab](~/dataminer/images/SLNetClientTest_UI_Output.png)<br>*SLNetClientTest tool Output tab in DataMiner 10.5.11*

## Build Message tab

In the *Build Message* tab, you can send a message to the DataMiner Agent you are currently connected to, by selecting the message in the box at the top, configuring the necessary parameters in the main pane below, and then clicking *Send Message*.

If you enter text in the filter box below the *Message Type* box, only the messages matching that filter will be shown. This is a quick and easy way to find the message you are looking for in the box.

For more details about specific messages, refer to [diagnostic procedures](xref:SLNetClientTest_tool_diagnostic_procedures) and [advanced procedures](xref:SLNetClientTest_tool_advanced_procedures) in this documentation.

![SLNetClientTest tool Output tab](~/dataminer/images/SLNetClientTest_UI_Build_Message.png)<br>*SLNetClientTest tool Build Message tab in DataMiner 10.5.11*
