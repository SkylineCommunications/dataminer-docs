---
uid: SLNetClientTest_triggering_api
---

# Triggering and managing user-defined APIs

> [!NOTE]
> This feature is available from DataMiner 10.3.6/10.4.0 onwards. In DataMiner 10.3.5, it is available in preview.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Triggering a user-defined API

With the SLNetClientTest tool, you can trigger a user-defined API in order to test it. This will bypass the endpoint DxM and go directly to the API manager in SLNet, which can be useful to efficiently test and verify API scripts without the need to send an HTTP request. This is especially handy when you are developing an API, as it allows you to quickly and easily trigger it and get additional information such as the response time along with the result. It can also be used to help detect whether an API script is faulty or if something else is the cause when problems occur with API triggers.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Select *Advanced* > *Apps* > *User-Defined APIs*. <!-- RN 35996 -->

1. Select the *Trigger* tab.

   ![Client Test Tool Trigger Screenshot](~/user-guide/images/UDAPIS_ClientTestToolTrigger.png)

1. In the *Route* box, select the API you want to trigger.

   This will automatically fill in the description in the box below.

1. In the *Request Method* box, select the method you want to use.

1. In the *Secret* box, specify the secret corresponding with the access token (see [Creating an API and tokens in DataMiner Automation](xref:UD_APIs_Define_New_API#creating-an-api-and-tokens-in-dataminer-automation)).

1. Optionally, in the *Request Body* box, fill in a request body.

1. Click the *Trigger* button.

   Your request will be sent, and the response will appear along with some stats and info about your request.

## Managing API tokens and definitions

The SLNetClientTest tool can also provide an overview of all API tokens and definitions, where you can look up specific tokens or definitions and remove them. You can also enable or disable specific tokens.

![Client Test Tool Screenshot](~/user-guide/images/UDAPIS_ClientTestTool.png)

To go to the overview:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Select *Advanced* > *Apps* > *User-Defined APIs*.

1. Go to the *Tokens* or *Definitions* tab, depending on the objects you want to see.

To sort the objects in the list by a specific column, click that column header.

Use the buttons at the top of the tab to do specific actions:

- **View**: Displays a human-readable representation of the selected token or definition.
- **RawView**: Displays the JSON representation of the selected token or definition.
- **Refresh**: Refreshes the list of tokens or definitions.
- **Search**: To use this button, first add text in the *Search* box. When you click the button, the list will be filtered according to the specified text.
- **Delete**: Deletes the selected token or tokens after confirmation.

The *Tokens* tab also allows you to disable or enable an API token by right-clicking the ID field. A context menu will open where you can select whether to disable or enable the token.
