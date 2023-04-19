---
uid: SLNetClientTest_triggering_api
---

# Triggering a user-defined API

> [!WARNING]
> This feature is in preview and is not fully released yet. For now, it should only be used on a staging platform. It should not be used in a production environment.

With the SLNetClientTest tool, you can trigger a user-defined API in order to test it. This especially handy when you are developing an API, as it allows you to quickly and easily trigger it and get additional information such as the response time along with the result.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Select *Advanced* > *Apps* > *User-defined APIs*. <!-- RN 35996 -->

1. Select the *Trigger* tab.

   ![Client Test Tool Trigger Screenshot](~/user-guide/images/UDAPIS_ClientTestToolTrigger.png)

1. In the *API Definition* box, select the API you want to trigger.

   This will automatically fill in the route in the box below.

1. In the *Request Method* box, select the method you want to use.

1. In the *Secret* box, specify the secret corresponding with the access token (see [Creating an API definition and token(s)](xref:UD_APIs_Define_New_API#creating-an-api-and-tokens-in-dataminer-automation)).

1. Optionally, in the *Request Body* box, fill in a request body.

1. Click the *Trigger* button.

   Your request will be sent, and the response will appear along with some stats and info about your request.

> [!NOTE]
> On the *Tokens* tab of the *User-defined APIs* window, you can see an overview of all the tokens and definitions.
>
> ![Client Test Tool Screenshot](~/user-guide/images/UDAPIS_ClientTestTool.jpg)
>
> If you select an object, you can use the *View* and *RawView* buttons to see its properties. You can also sort on values by clicking the column headers.
>
> You can also disable or enable an API token here, by right-clicking its ID field and selecting *Disable* or *Enable*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
