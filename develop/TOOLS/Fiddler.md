---
uid: Fiddler
---

# Fiddler

Fiddler is a free web debugging tool that logs all HTTP(S) traffic between your computer and the Internet. Fiddler can be very useful to develop protocols that implement HTTP connections.

> [!TIP]
>
> - For more information, see [How to create an HTTP connector](xref:How_to_create_an_HTTP_connector_CoinMarketCap_use_case).
> - You can download this tool from the [Telerik website](http://www.telerik.com/fiddler).

## Configuration

1. Go to *Tools > Fiddler Options* and select the *Connections* tab.

   ![Fiddler Options Window](~/develop/images/Fiddler_Options_Window.png)<br>*Fiddler Connections Options window*

1. Set the port that Fiddler needs to listen on. This should be the same port as the DataMiner element.

   Fiddler will now capture all HTTP requests that are sent to this port (including the HTTP requests issued by the DataMiner element).

1. Now, in the main window in Fiddler, select the *AutoResponder* tab

   ![Fiddler Main Window](~/develop/images/Fiddler_Main_Window.png)<br>*Fiddler main window*

   - Select the check boxes *Enable Rules* and *Unmatched requests passthrough*.

   - You can make sure a response for a captured HTTP request is provided by dragging the HTTP request from the request overview on the left to the *AutoResponder* overview on the right.

   - The rule editor at the bottom of the *AutoResponder* tab allows you to configure the response. Typically, a device that communicates via HTTP will send XML data back. When the XML responses of a device are saved, these can be used so Fiddler will return the file content as response to the HTTP request.

   > [!TIP]
   > There are a lot of options available related to the *AutoResponder*. For more details, see [Getting Started with Fiddler Classic](http://docs.telerik.com/fiddler/configure-fiddler/tasks/configurefiddler).

In case Fiddler needs to run for a long time (or process many requests), make sure to select the *Hide All* option and limit the number of sessions to keep.

![Hide All](~/develop/images/Hide_All.png)<br>*Fiddler Hide All option*

![FiddlerKeep](~/develop/images/FiddlerKeep.png)<br>*Fiddler sessions to keep configuration*
