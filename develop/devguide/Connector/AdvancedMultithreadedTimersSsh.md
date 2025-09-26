---
uid: AdvancedMultiThreadedTimersSsh
---

# SSH

To implement a multithreaded timer with SSH, perform the following steps:

1. Building the request
1. Processing the responses
1. Running the QAction after the response

## Step 1: Building the request

Assume the following multithreaded timer is defined:

```xml
<Timer id="1" options="ip:1000,1;each:60000;pollingrate:30,10,10;threadPool:20,5,221,222,223,224,225,15000;dynamicthreadpool:220;qactionBefore:1010;qactionAfter:1012">
  <Name>Poll Timer SSH</Name>
  <Time>1000</Time>
  <Interval>0</Interval>
  <Content>
    <Group>1011</Group>
  </Content>
</Timer>
```

To build the request, create a QAction triggered by a multithreaded timer (using the qactionBefore option), which creates the request object and returns this.

```xml
<QAction id="1010" name="SSH Before" encoding="csharp" row="true">
```

This QAction is used to create the request as illustrated in the following example:

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example of SSH before QAction.
/// </summary>
public class QAction
{
    /// <summary>
    /// QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    /// <returns>The SSH request.</returns>
    public static object[] Run(SLProtocolExt protocol)
    {
        try
        {
            string rowkey = protocol.RowKey();
            
            protocol.SetParameterIndexByKey(1000, rowkey, 7, 3); // Put status of this row to busy.
            
            string userName = Convert.ToString(protocol.SshUsername);
            string password = Convert.ToString(protocol.SshPassword);
            string sshOptions = "";
            int timeout = 5000;
            string responseTrailer = "<<EOT>>";
            int trailerResponseOccurrenceCount = 2;
            
            if (!String.IsNullOrWhiteSpace(userName) && !String.IsNullOrWhiteSpace(password))
            {
                string[] sshSettings = new string[6];
                sshSettings[0] = userName;
                sshSettings[1] = password;
                sshSettings[2] = sshOptions;
                sshSettings[3] = Convert.ToString(timeout);
                sshSettings[4] = responseTrailer;
                sshSettings[5] = Convert.ToString(trailerResponseOccurrenceCount);
                
                string sshCommand = "show cable modems\r\n";
                string[] sshCommands = new string[] { sshCommand };
                
                object[] requestInfo = new object[2];
                requestInfo[0] = sshSettings;
                requestInfo[1] = sshCommands;
                
                return requestInfo;
            }
            else
            {
                protocol.Log("No SSH user name or password filled in.");
            
                return null;
            }
        }
        catch (Exception e)
        {
            protocol.Log("QA" + protocol.QActionID + "|Run|An exception occurred: " + e.ToString(), LogType.Error, LogLevel.NoLogging);
        
            return null;
        }
    }
}
```

Format of the request: requestInfo (object[]):

- requestInfo[0] (string[]): SSH settings, where:<!-- RN 18538 -->

  - sshSettings[0]: Username.
  - sshSettings[1]: Password.
  - sshSettings[2]: SSH options.
  - sshSettings[3]: Timeout (ms).
  - sshSettings[4]: Response trailer.
  - sshSettings[5]: Number of times the trailer needs to occur in the response.
  - sshSettings[6]: Connection setup timeout (ms).

  If this value is not provided, the connection setup timeout defaults to the general (response) timeout.

- requestInfo[1] (string[]): SSH commands.

- requestInfo[2] (string[]): Key exchange algorithms.<!-- RN 13897 -->

  Refer to Secure Shell (SSH) for an overview of the supported key exchange algorithms.

  E.g. requestInfo[2] = new string[2] {"diffie-hellman-group1-sha1","diffie-hellman-group-exchange-sha1" }

  In the example above, DataMiner will first try to connect through diffie-hellman-group1-sha1, if that one is not supported by the server we will continue with diffie-hellman-group-exchange-sha1.

> [!NOTE]
> Note that the Run method of the QAction now has a return type of object[].

## Step 2: Processing the responses

To process the responses, create a QAction that triggers on the group of the multithreaded timer.

> [!NOTE]
> Whereas typically you provide a parameter ID in the triggers attribute, here you need to specify the ID of the group of the multithreaded timer.

```xml
<QAction id="1011" name="SSH Data" encoding="csharp" options="group" triggers="1011" row="true">
```

Note the "group" option, which allows the use of the OldRow method (SLProtocol) to retrieve the result data.

Format of the result data:

- responses (object[]): Result object. The number of entries in this object array equals the number of commands sent (See sshCommands array in the request). Each response in this array is a string.

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example SSH data.
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
            string rowkey = protocol.RowKey();      
            object responseData = protocol.OldRow();
        
            if (responseData == null)
            {
                protocol.Log("Response data is null.");
            }
            else if ((Convert.ToString(responseData) == "TIMEOUT") || (Convert.ToString(responseData) == "NO POLLING OCCURRED"))
            {
                protocol.Log("Response data is " + Convert.ToString(responseData));
            }
            else
            {
                object[] responses = (object[])responseData;
            
                protocol.Log("QA" + protocol.QActionID + "|Number of lines ins response: " + responses.Length, LogType.Error, LogLevel.NoLogging);
            
                for(int i=0; i<responses.Length; i++)
                {
                    string response = Convert.ToString(responses[i]);
            
                    // Process response...
                }
            }
        }
        catch (Exception e)
        {
            protocol.Log("QA" + protocol.QActionID + "Run|An exception occurred: " + e.ToString(), LogType.Error, LogLevel.NoLogging);
        }
    }
}
```

In this QAction, you will typically also update the state column of the corresponding row.

## Step 3: Running the QAction after the response

The last step runs the QAction specified in the *qactionAfter* option of the multithreaded timer.

```xml
<QAction id="1012" name="SSH After" encoding="csharp" row="true">
```

In this QAction, you can check if a timeout occurred and set the status of the corresponding row accordingly.

```csharp
using System;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Example SSH after.
/// </summary>
public class QAction
{
    /// <summary>
    /// QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    public static void Run(SLProtocolExt protocol)
    {
        try
        {
            string rowKey = protocol.RowKey();
            
            // Check if state is still "Sending". If this is the case, a timeout occurred and the state should be set accordingly.
        }
        catch (Exception e)
        {
            protocol.Log("QA" + protocol.QActionID + "Run|An exception occurred: " + e.ToString(), LogType.Error, LogLevel.NoLogging);
        }
    }
}
```
