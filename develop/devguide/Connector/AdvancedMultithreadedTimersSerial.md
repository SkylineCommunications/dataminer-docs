---
uid: AdvancedMultiThreadedTimersSerial
---

# Serial

To set up multithreaded serial communication in a QAction, perform the following steps:<!-- RN 9290 -->

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

To build the request, create a QAction triggered by a multithreaded timer (using the qactionBefore option), which creates the request object and returns this.

```xml
<QAction id="1010" name="Serial Before" encoding="csharp" row="true">
```

This QAction is used to create the request as illustrated in the following example:

```csharp
public class QAction
{
    /// <summary>
    /// Example HTTP Before.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    /// <returns>The serial request.</returns>
    public static object[] Run(SLProtocolExt protocol)
    {
        protocol.Log("Ran QActionBefore");
        
        try
        {
            int timeout = 1500; // Timeout in ms.
            
            string[] commands = new string[2];
            commands[0] = "MyCommand";
            commands[1] = "MyCommand2";
            
            string[] requestSettings = new string[2];
            requestSettings[0] = timeout.ToString();
            requestSettings[1] = "1,2";    // Comma-separated list of response IDs.
            
            object[] requestInfo = new object[3] { "serial", requestSettings, commands };
            
            return requestInfo;
        }
        catch (Exception e)
        {
            protocol.Log("An exception occurred: " + e.ToString());
            return null;
        }
    }
}
```

Format of the request: requestInfo (object[]):

- requestInfo[0] (string): Set to "serial".
- requestInfo[1] (string[]): Request settings.
- requestSettings[0]: Timeout (ms).
- requestSettings[1]: Comma-separated list of response IDs.
- requestInfo[2] (string[]): The commands to send.

In this QAction, typically you will also set the state of the corresponding row to e.g., "Sending".

> [!NOTE]
> The Run method of the QAction now has a return type of object[].

## Step 2: Process the responses

To process the responses, create a QAction that triggers on the group of the multithreaded timer.

> [!NOTE]
> Whereas typically you provide a parameter ID in the triggers attribute, here you need to specify the ID of the group of the multithreaded timer.

```xml
<QAction id="1011" name="Serial Data" encoding="csharp" options="group" triggers="1011" row="true">
```

Note the "group" option, which allows the use of the OldRow method (SLProtocol) to retrieve the result data.

Format of the result data:

- responses (object[]): Result object. The number of entries in this object array equals the number of commands sent (See commands array in the request).

Each response contains two entries:

- response[0] (Int32): The ID of the matching response or -1 in case no match is found.
- response[1] (byte[] or String): If there was a match, this entry contains the response data as a byte array. If there was no match, this entry contains a string message (e.g., "TIMEOUT").
- response[2] (byte[]): Only present if result[0] is -1 (i.e., no response matches). This makes it possible to inspect the received response that does not match any of the specified expected responses.<!-- RN 13052 -->

Suppose parameters 1023 and 33 are defined as follows:

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example serial data.
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
            
                if (communicationState != "TIMEOUT" && communicationState != "NO POLLING OCCURRED")
                {
                    object[] responses = (object[])result;
            
                    if (responses.Length > 0)
                    {                    
                        for (int i = 0; i < responses.Length; i++)
                        {
                            if (responses[i] != null)
                            {
                                object[] response = (object[])responses[i];
            
                                int responseResponseId = Convert.ToInt32(response[0]);
                
                                if (responseResponseId != -1)
                                {
                                    byte[] responseData = (byte[])response[1];    
            
                                    // Process data...                            
                                }
                                else
                                {
                                    string responseData = (string)response[1]; // E.g. "TIMEOUT".
            
                                    // Process feedback...
                                    if (response.Length > 2)
                                    {
                                        byte[] responseBytes = (byte[])response[2]; // The received response.
                                    }
                                }
                            }
                            else
                            {
                                protocol.Log("QA" + protocol.QActionID + "|Response data is null.", LogType.Error, LogLevel.NoLogging);
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

The last step runs the QAction specified in the *qactionAfter* option of the multithreaded timer.

```xml
<QAction id="1012" name="Serial After" encoding="csharp" row="true">
```

In this QAction, you can check if a timeout occurred and set the status of the corresponding row accordingly.

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example serial after.
/// </summary>
public class QAction
{
    /// <summary>
    /// QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocol protocol)
    {
        string rowKey = protocol.RowKey();
    
        // Check if state is still "Sending". If this is the case, a timeout occurred and the state should be set accordingly.
    }
}
```
