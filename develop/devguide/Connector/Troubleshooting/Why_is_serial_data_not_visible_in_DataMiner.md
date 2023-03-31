---
uid: Why_is_serial_data_not_visible_in_DataMiner
---

# Why is serial data not visible in DataMiner?

Below, you can find how you can determine the reason why info retrieved via serial communication is not shown in DataMiner.

## User skills required

- Basic knowledge of drivers.
- Basic knowledge of how to use DataMiner Cube.

## Symptoms of this issue

All or some parameter values of a DataMiner element using a protocol with serial communication show *Not Initialized* or are no longer updating.

## Investigation

### Check the element communication

The first thing to verify is if there is data traffic between DataMiner and the serial data source. The easiest way to do this is via the built-in Stream Viewer.

- Click the hamburger button in the top-left corner of the element card, and select *View > Stream Viewer*. For more information, see [Connecting to an element using Stream Viewer](xref:Connecting_to_an_element_using_Stream_Viewer).

There are then three possibilities:

- Stream Viewer shows no data.
- Stream Viewer shows a timeout on incoming data.
- Stream Viewer shows incoming data.

#### Stream Viewer shows no data

Stream Viewer remains blank for a long period of time (longer than 1 minute).

In this case, the DataMiner element is not sending any commands. This could be due to the following common causes:

- Another operation in the element is taking a long time. If this takes 7.5 minutes, the DataMiner Watchdog process will indicate a half-open RTE in the watchdog log.
- There is an incorrect definition in the driver. Verify if the driver used by the element should send requests and if the flow to send them is correctly defined.
- The process dealing with serial communication is failing: SLPort is no longer operating correctly. In this case, the DataMiner Watchdog process will indicate this in the watchdog log.

#### Stream Viewer shows a timeout on incoming data

Stream Viewer indicates requests/commands being sent to the data source and the response displays *TIMEOUT*.

In this case, the response could not be retrieved within the defined single command timeout time of the element. This is defined when creating/editing the element. In most cases, this is set to 1500 ms.

A timeout can occur because of various reasons. For example, the serial gateway between DataMiner and the serial data source can be configured incorrectly or the requested info can simply take longer because of network limitations.

#### Stream Viewer shows incoming data

The Stream Viewer indicates responses for each of the requests/commands that are sent to the data source.

In this case, the data source is returning data, but it is not accepted by DataMiner. This can be due to a change in the response format after a firmware update of the data source.

- Validating the format is the best starting point to investigate further.
- After this, check for parsing errors.

These two steps are explained further below.

### Validate the format

The easiest way to know if the incoming data matches what the driver expects is by checking the element log. To do so:

1. Click the hamburger button in the top-left corner of the element card, and select *View > Log*.

1. Open the *Log settings* section at the top of the card and set the following log levels:

    - Info logging level: No logging (0)
    - Debug logging level: Level 2
    - Error logging level: No logging (0)

> [!NOTE]
> When you are done investigating, do not forget to set the log levels back to the previous settings.

Configuring the log levels like this will make sure that the reason for the mismatch is logged. To then quickly find it, search for *CResponse* in the log file. Here is an example of such an error message:

```txt
CResponse::ReadParameterPositions|DBG|2|Could not find NEXT PARAM for parameter [Name of parameter] ([Id of parameter])
```

Note that these cases are not really issues in the driver. It means that the received (new) format is not (yet) supported in the driver. The most common reason for this is a firmware difference. It is always useful to check the driver help to know which versions are supported. You can find the driver help in several places, including on the Help page of an element card.

### Validate data parsing

In many cases, the data that is retrieved will be processed before it gets displayed. It is possible that a problem occurs during this stage. This can be caused by a change in format or an unexpected value.

The logic in a driver should have a safety mechanism to avoid unhandled exceptions abruptly stopping the execution. It should either update the parameter on screen with an exception value, or it should generate a log message in the element log with the required details. When an unhandled exception occurs, an auto-generated error log message will be generated.

Example of a handled exception in QAction 25:

```txt
[Date] [Time]|[Element Name].txt|SLManagedScripting.exe|ManagedInterop|ERR|0|QA25|Run|Error calculating the Local Times, no valid Time is available.
```

Error log messages are also stored in a separate log file: *Errors In Protocol*. This file provides an overview of all the errors logged by any running DataMiner element on the DataMiner Agent.

- To check the *Errors in Protocol* log file in DataMiner Cube, go to *System Center > Logging > DataMiner*, select the DMA and select the file *Errors in Protocol* from the list of log files.

Example of an unhandled exception:

```txt
[Date] [Time]|[Element Name].txt| SLManagedScripting.exe|ManagedInterop|ERR|-1|Exception during execution:
Cookie: 186
Content 1: VT_ARRAY|VT_VARIANT (8) 
0 VT_I4 : [Parameter Id]
1 VT_I4 : [DataMiner Id] 
2 VT_I4 : [Element Id] 
3 VT_BSTR : [Element Name] 
4 VT_BSTR : ...
Content 2: VT_EMPTY .
System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at QAction.Run(SLProtocol protocol, Object oTable)
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at CManagedScript.Run(CManagedScript* , Int32 iCookie, IUnknown* pILog, IUnknown* pProtocol, tagVARIANT* varParameters, tagVARIANT* varRowInfo, tagVARIANT* pvarReturn)
InnerException:
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at QAction.Run(SLProtocol protocol, Object oTable)
[Date] [Time]|[Element Name].txt|SLProtocol - 3256 - Element Name|4072|CQAction::Run|ERR|-1|QAction [QActionId] triggered by [pid=.../idx=.../pk=/user=] failed. (0x800402DA)
	Input: new = <NULL>
	Input: old = <NULL>
	Input: extra = <NULL>
```

### Validate the protocol

Verify that a trigger is present that will execute an action of type read for every response that contains a parameter of LengthType "next param". This action is needed to fill in the response data into a parameter with a variable length, i.e. *LengthType – next param*.

You can configure this with a trigger using the "each" value on the On `id` attribute:

```xml
<Trigger id="1">
   <Name>Read Response</Name>
   <On id="each">response</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>1</Id><!--Read Response-->
   </Content>
</Trigger>
<Action id="1">
   <Name>Read Response Action</Name>
   <On>response</On>
   <Type>read</Type>
</Action>
```

For more information, see [How to use "on each" in a protocol trigger?](xref:How_to_use_on_each_in_a_protocol_trigger) or [Composing responses](xref:ConnectionsSerialCreatingCommandsAndResponses#composing-responses).

> [!NOTE]
> When the communication option `makeCommandByProtocol` is used, you also have to define a `make command` action that triggers before each command.

## Useful links

For more information about using Stream Viewer and checking the logging in DataMiner Cube, see [Logging](xref:logging).
