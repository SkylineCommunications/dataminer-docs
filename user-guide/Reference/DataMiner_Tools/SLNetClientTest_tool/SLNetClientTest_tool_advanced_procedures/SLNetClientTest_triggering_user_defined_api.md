---
uid: SLNetClientTest_triggering_api
---

# Triggering a User-defined API through the client test tool

It is possible to trigger an API through the User Definable API UI in the Client Test Tool. It can be found under `Advanced > Apps > User Definable APIs...` on the `Trigger` tab.

![Client Test Tool Trigger Screenshot](~/user-guide/images/UDAPIS_ClientTestToolTrigger.jpg)

To trigger an API, simply select the API Definition in the dropdown. This will automatically fill in the route in the textbox below. Choose the `RequestMethod` from the dropdown and enter your secret in the Secret textbox. Optionally, you can fill in a request body in the large textbox on the bottom. When clicking 'Trigger', your request is sent and the response will appear along with some stats and info about your request. This is a great way to test your API while developing it, as it is easy to trigger.

There also is a UI available in the client test tool that makes it possible to easily see all the tokens and definitions.

![Client Test Tool Screenshot](~/user-guide/images/UDAPIS_ClientTestTool.jpg)

By selecting an object and clicking the 'View' or 'RawView' buttons, you can see all the properties of that object. It is possible to sort on values by clicking on the column headers.

In the Tokens tab, you can disable or enable an `ApiToken` by right-clicking on the ID field of an `ApiToken`. A context menu will open with a button to 'Disable' or 'Enable' the token.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.