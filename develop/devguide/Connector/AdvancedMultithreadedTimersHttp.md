---
uid: AdvancedMultiThreadedTimersHttp
---

# HTTP

To set up multithreaded HTTP communication in a QAction, perform the following steps:<!-- RN 9290 -->

1. [Build the request](#step-1-build-the-request)
1. [Process the responses](#step-2-process-the-responses)
1. [Run the QAction after the response](#step-3-run-the-qaction-after-the-response)

## Step 1: Build the request

Assume the following multithreaded timer is defined:

```xml
<Timer id="1" options="ip:1000,1;each:5000;pollingrate:30,10,10;threadPool:20,5,221,222,223,224,225,15000;dynamicthreadpool:220;qactionBefore:1010;qactionAfter:1012">
  <Name>Poll timer CMTS SSH</Name>
  <Time>1000</Time>
  <Interval>0</Interval>
  <Content>
    <Group>1011</Group>
  </Content>
</Timer>
```

Group 1011 is a group of type `poll`, with an empty `content` tag, e.g., as defined below.

```xml
    <Group id="1011">
       <Name>Multithread Group 1011</Name>
    <Description>Multithread Group 1011</Description>
       <Type>poll</Type>
       <Content>
       </Content>
    </Group>
```

To build the request, create a QAction triggered by a multithreaded timer (using the qactionBefore option), which creates the request object and returns this.

```xml
<QAction id="1010" name="Create HTTP Request" encoding="csharp" row="true">
```

This QAction is used to create the request as illustrated in the following example:

```csharp
/// <summary>
/// Example HTTP before.
/// </summary>
public class QAction
{
    /// <summary>
    /// Example HTTP Before.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    /// <returns>The HTTP request.</returns>
    public static object[] Run(SLProtocolExt protocol)
    {
        try
        {
            string rowkey = protocol.RowKey();
            
            // Note: In this QAction you will typically set the status of the current row to, for example, "Sending".
            string verb = "GET";
            string url = Convert.ToString(protocol.GetParameterIndexByKey(1000, rowkey, 2)) + "/";
            string userName = Convert.ToString(protocol.HttpUsername);
            string password = Convert.ToString(protocol.HttpPassword);
            string requestHeaders = "Accept-Encoding|gzip, deflate";    // Use pipe character ('|') to separate the header from the header value. Use semicolon to provide multiple request headers.
            
            int timeout = 100; // Timeout in ms.
            
            string[] requestSettings = new string[6];
            
            requestSettings[0] = verb;
            requestSettings[1] = url;
            requestSettings[2] = userName;
            requestSettings[3] = password;
            requestSettings[4] = requestHeaders;
            requestSettings[5] = timeout.ToString();
            
            string[] resourcePaths = new string[3];
            
            resourcePaths[0] = "resourceA.htm";
            resourcePaths[1] = "resourceB.htm";
            resourcePaths[2] = "resourceC.htm";
            
            object[] httpRequestInfo = new object[3] { "http", requestSettings, resourcePaths };
            
            return httpRequestInfo;
        }
        catch (Exception e)
        {
            protocol.Log("An exception occurred: " + e.ToString());
        
            return null;
        }
    }
}
```

Format of the request: httpRequestInfo (object[]):

- httpRequestInfo[0] (string): Set to "http".
- httpRequestInfo[1] (string[]): Request settings.
  - requestSettings[0]: Verb (e.g., "GET").
  - requestSettings[1]: URL.
  - requestSettings[2]: Username.
  - requestSettings[3]: Password.
  - requestSettings[4]: Request headers. Use the pipe character ('|') to separate the header from the header value. Use a semicolon (';') to specify multiple request headers.
  - requestSettings[5]: Timeout (ms).
  - requestSettings[6]: Specifies whether to skip the SSL/TLS certificate verification. Default: true. Feature introduced in DataMiner 10.4.12 (RN 40877, RN 41285).
- httpRequestInfo[2] (string[]): The resource path(s).

  From DataMiner 10.0.12 (RN 27438) onwards, it is possible to add a message body for the HTTP request (e.g., for a POST request).
- httpRequestInfo[2] (object[]): The resource paths and request bodies.
  - requestPathAndBody (string[]): A resource path and request body entry.
    - requestPathAndBody[0] (string): resource path
    - requestPathAndBody[1] (string): request body

> [!NOTE]
>
> - The original syntax where httpRequestInfo[2] is a string array can still be used. If you use the old syntax, no message bodies will be sent. If you use the new syntax for a single resource, no message body needs to be added. In that case, you should define an empty string instead.
> - By adding the message bodies to the last array in the request, the new syntax allows you to send a different message body to each of the different subpages.
> - DataMiner does not format the message body in any way. It is forwarded as received from within the QAction. It is up to the user to correctly format the message body.

**Example**

```csharp
string[] firstResourcePathAndBody = new string[2] { "resourceA.htm", "//request body A goes here" };
string[] secondResourcePathAndBody = new string[2] { "resourceB.htm", "//request body B goes here" };
string[] thirdResourcePathAndBody = new string[2] { "resourceC.htm", "//request body C goes here" };

object[] resourcePathsAndBodies = new object[3] { firstResourcePathAndBody, secondResourcePathAndBody, thirdResourcePathAndBody };
object[] httpRequestInfo = new object[3] { "http", requestSettings, resourcePathsAndBodies };
```

> [!NOTE]
> The Run method of the QAction now has a return type of object[].

In this QAction, typically you will also set the state of the corresponding row to, for example, "Sending".

## Step 2: Process the responses

To process the responses, create a QAction that triggers on the group of the multithreaded timer.

> [!NOTE]
> Whereas typically you provide a parameter ID in the triggers attribute, here you need to specify the ID of the group of the multithreaded timer.

```xml
<QAction id="1011" name="Process HTTP Responses" encoding="csharp" options="group" triggers="1011" row="true">
```

Note the "group" option, which allows the use of the OldRow method (SLProtocol) to retrieve the result data.

Format of the result data:

- result (object[]): Result object. This object array has two entries, which are in turn object arrays. The size of these arrays corresponds with the number of resource paths specified in the request (httpRequestInfo[2]).
  - result[0] (object[]): Status lines.
  - result[1] (object[]): Message bodies.

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example HTTP data..
/// </summary>
public class QAction
{
    /// <summary>
    /// QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public void Run(SLProtocolExt protocol)
    {
        try
        {
            string rowKey = protocol.RowKey();
            object result = protocol.OldRow();
            
            if (result != null)
            {
                string communicationState = Convert.ToString(result);
                
                if (communicationState != "TIMEOUT" && communicationState != "NO POLLING OCCURED")
                {
                    object[] responses = (object[])result;
                
                    if(responses.Length > 1)
                    {
                        object[] statusLines = (object[]) responses[0];
                        object[] messageBodies = (object[])responses[1];
                
                        for (int i = 0; i < statusLines.Length; i++)
                        {
                            string statusLine = Convert.ToString(statusLines[i]);
                            string response = Convert.ToString(messageBodies[i]);
                
                            if (statusLine == "HTTP/1.1 200 OK")
                            {
                                // Process response (e.g., process data and update status column to OK).
                            }
                            else
                            {
                                // Process unexpected response (e.g., update status column to Error).
                            }
                        }
                    }
                }
                else
                {
                    protocol.Log("Result: " + Convert.ToString(result));
                }
            }
            else
            {
                protocol.Log("Result is null.");
            }
        }
        catch (Exception e)
        {
            protocol.Log("QA" + protocol.QActionID + "|Run|An exception occurred: " + e.ToString(), LogType.Error, LogLevel.NoLogging);
        }
    }
}
```

In this QAction, you will typically also update the state column of the corresponding row.

## Step 3: Run the QAction after the response

The last step runs the QAction specified in the qactionAfter option of the multithreaded timer.

```xml
<QAction id="1012" name="HTTP After" encoding="csharp" row="true">
```

In this QAction, you can check if a timeout occurred and set the status of the corresponding row accordingly.

```csharp
public class QAction
{
    /// <summary>
    /// After Processing Multithreaded Group.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        string rowKey = protocol.RowKey();

        // Check if state is still "Sending". If this is the case, a timeout occurred and the state should be set accordingly.
    }
}
```
