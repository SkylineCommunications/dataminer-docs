## Engine methods

- [AcknowledgeAlarm](#acknowledgealarm)

- [AddError](#adderror)

- [AddOrUpdateScriptOutput](#addorupdatescriptoutput)

- [AddScriptOutput](#addscriptoutput)

- [ClearScriptOutput](#clearscriptoutput)

- [ClearScriptResult](#clearscriptresult)

- [CreateExtraDummy](#createextradummy)

- [Dispose](#dispose)

- [Dispose (Boolean)](#dispose-boolean)

- [ExitFail](#exitfail)

- [ExitSuccess](#exitsuccess)

- [FindElement](#findelement)

- [FindElementByKey](#findelementbykey)

- [FindElements](#findelements)

- [FindElementsByName](#findelementsbyname)

- [FindElementsByProtocol](#findelementsbyprotocol)

- [FindElementsInView](#findelementsinview)

- [FindInteractiveClient](#findinteractiveclient)

- [FindRedundancyGroup](#findredundancygroup)

- [FindRedundancyGroupByKey](#findredundancygroupbykey)

- [FindRedundancyGroups](#findredundancygroups)

- [FindRedundancyGroupsByName](#findredundancygroupsbyname)

- [FindRedundancyGroupsInView](#findredundancygroupsinview)

- [FindService](#findservice)

- [FindServiceByKey](#findservicebykey)

- [FindServices](#findservices)

- [FindServicesByName](#findservicesbyname)

- [FindServicesInView](#findservicesinview)

- [FindServiceTemplate](#findservicetemplate)

- [FindServiceTemplates](#findservicetemplates)

- [GenerateInformation](#generateinformation)

- [GetAlarmProperty](#getalarmproperty)

- [GetDummy](#getdummy)

- [GetMemory](#getmemory)

- [GetScriptOutput](#getscriptoutput)

- [GetScriptParam](#getscriptparam)

- [GetScriptResult](#getscriptresult)

- [GetUserConnection](#getuserconnection)

- [LoadDoubleValue](#loaddoublevalue)

- [LoadStringValue](#loadstringvalue)

- [LoadValue](#loadvalue)

- [Log](#log)

- [PrepareMailReport](#preparemailreport)

- [PrepareSubScript](#preparesubscript)

- [RunClientProgram](#runclientprogram)

- [SaveValue](#savevalue)

- [SendEmail](#sendemail)

- [SendPager](#sendpager)

- [SendReport](#sendreport)

- [SendSms](#sendsms)

- [SetAlarmProperties](#setalarmproperties)

- [SetAlarmProperty](#setalarmproperty)

- [SetFlag](#setflag)

- [ShowProgress](#showprogress)

- [ShowUI](#showui)

- [Sleep](#sleep)

- [UnSetFlag](#unsetflag)

#### AcknowledgeAlarm

Acknowledges the specified alarm tree using the provided comment message.

If a user launches the script manually or attaches to it interactively, that user will become the owner of the alarm. If the script runs in the background, the alarm owner will become “Administrator”.

```txt
void AcknowledgeAlarm(int dmaId, int alarmId, string comment)                                                
void AcknowledgeAlarm(int dmaId, int elementID, int alarmId, string comment)
```

Examples:

```txt
engine.AcknowledgeAlarm(7,304022,"Alarm acknowledged")
```

```txt
engine.AcknowledgeAlarm(7, 400, 304022, "Alarm acknowledged.");
```

#### AddError

Adds an error message to the Automation script, which will eventually cause the script to fail.

```txt
void AddError(string error)
```

Example:

```txt
engine.AddError("A non-fatal error has occurred.");
```

#### AddOrUpdateScriptOutput

Adds a key to the script output if it has not been added yet. If the key already exists, it will be updated with the specified value. Available from DataMiner 10.0.2 onwards.

```txt
void AddOrUpdateScriptOutput(string key, string value)
```

#### AddScriptOutput

Adds a key and value to the dictionary that will be passed to the parent script. <br>Available from DataMiner 9.6.8 onwards.

```txt
void AddScriptOutput(string key, string value)
```

Exceptions:

| Exception             | Condition                                     |
|-----------------------|-----------------------------------------------|
| ArgumentNullException | *key* is null. |
| ArgumentException     | An element with the same key already exists.  |

#### ClearScriptOutput

Removes the entry with the specified key from the script output.  Available from DataMiner 10.0.2 onwards.

```txt
void ClearScriptOutput(string key)
```

#### ClearScriptResult

Clears the script output.  Available from DataMiner 10.0.2 onwards.

```txt
void ClearScriptResult()
```

#### CreateExtraDummy

Adds an additional dummy to the Automation script.

```txt
ScriptDummy CreateExtraDummy(int dataMinerID, int elementID)                                             
ScriptDummy CreateExtraDummy(int dataMinerID, int elementID, string key)
```

Example:

```txt
ScriptDummy extradummy1 = engine.CreateExtraDummy(366,22);
```

#### Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```txt
void Dispose()
```

Implements: *IDisposable.Dispose*() (see *<https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?redirectedfrom=MSDN&view=netframework-4.7.2#System_IDisposable_Dispose>*)

#### Dispose (Boolean)

Releases the unmanaged resources used by the Engine and optionally releases the managed resources.

```txt
void Dispose(bool A_0)
```

If the boolean is set to *true*, both managed and unmanaged resources are released; otherwise only unmanaged resources are released.

#### ExitFail

Aborts the Automation script, and indicates that it has failed.

```txt
void ExitFail(string reason)
```

> [!NOTE]
> This method throws a *ScriptAbortException*. Make sure you take this into account, so that the script does not keep running endlessly and does not swallow *ScriptAbortException* when calling ExitFail(String).

Example:

```txt
engine.ExitFail("A fatal error has occurred.");
```

#### ExitSuccess

Aborts the Automation script, but does not indicate that it has failed.

```txt
void ExitSuccess(string reason)
```

> [!NOTE]
> This method throws a *ScriptAbortException*. Make sure you take this into account, so that the script does not keep running endlessly and does not swallow *ScriptAbortException* when calling ExitSuccess(String).

Example:

```txt
engine.ExitSuccess("The script has been stopped.");
```

#### FindElement

Retrieves an element

- by name, or

- by ID (DmaID,ElementID).

If no element with the specified name or ID is found, a null reference is returned.

```txt
Element FindElement(string name)                                              
Element FindElement(int dmaId, int elementId)
```

Examples:

```txt
Element myElement = engine.FindElement("myElement");
```

```txt
Element myElement = engine.FindElement(7,32);
```

#### FindElementByKey

Retrieves an element by key (DmaID/ElementID).

If no element with the specified key is found, a null reference is returned.

```txt
Element FindElement(string key)
```

Example:

```txt
Element myElement = engine.FindElementByKey("7/32");
```

#### FindElements

Retrieves all elements matching the specified filter.

```txt
Element[] FindElements(ElementFilter filter)
```

An element filter has the following fields:

- int DataMinerID (default Int32.MaxValue)

- int ElementID (default Int32.MaxValue)

- int ViewID (default Int32.MaxValue)

- string View

- bool ExcludeSubViews (default: false)

- bool IncludeStopped (default true)

- bool IncludeHidden (default true)

- bool IncludePaused (default true)

- string ProtocolVersion

- string ProtocolName

- bool NormalOnly

- bool WarningOnly

- bool MinorOnly

- bool MajorOnly

- bool CriticalOnly

- bool TimeoutOnly

- bool MaskedOnly

- string NameFilter

The NameFilter string can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

> [!NOTE]
> From DataMiner 9.6.11 onwards, you can also use this method to find enhanced services. To do so, add the *IncludeServiceElements* option to the ElementFilter and set it to true.

Examples:

```txt
ElementFilter myElementFilter = new ElementFilter { MajorOnly=true };
Element[] elements = engine.FindElements(myElementFilter);         
```

```txt
ElementFilter filter = new ElementFilter()                                       
{                                                                                
    DataMinerID = serviceReservationInstanceOne.EnhancedServiceElementID.DataMinerID,
    ElementID = serviceReservationInstanceOne.EnhancedServiceElementID.EID,          
    IncludeServiceElements = true                                                    
};                                                                               
                                                                                 
var enhancedServiceElement = engine.FindElements(filter).FirstOrDefault();       
```

 

#### FindElementsByName

Retrieves all elements of which the name matches the specified name mask.

Name masks can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

```txt
Element[] FindElements(string filter)
```

Example:

```txt
Element[] elements = engine.FindElementsByName("Test*");
```

#### FindElementsByProtocol

Retrieves all elements using the specified protocol version.

If you do not specify a version, all elements using any version of the protocol will be retrieved.

```txt
Element[] FindElementsByProtocol(string name)                                                 
Element[] FindElementsByProtocol(string name, string version)
```

Examples:

```txt
Elements[] elements = engine.FindElementsByProtocol("Microsoft Platform");
```

```txt
Elements[] elements = engine.FindElementsByProtocol("Microsoft Platform","1.1.0.48");
```

#### FindElementsInView

Retrieves either all elements in the specified view. or all elements using a specific protocol version in the specified view.

```txt
Element[] FindElementsInView(int id)                                                                                                                    
Element[] FindElementsInView(string name)                                                                                                               
Element[] FindElementsInView(int id, string protocolName, string protocolVersion)     
Element[] FindElementsInView(string name, string protocolName, string protocolVersion)
```

Examples:

```txt
Elements[] elements = engine.FindElementsInView(14);
```

```txt
Elements[] elements = engine.FindElementsInView("MySpecialElements");
```

```txt
Elements[] elements = engine.FindElementsInView(14,"Microsoft Platform","1.1.0.48");
```

```txt
Elements[] elements = engine.FindElementsInView("MySpecialElements","Microsoft Platform","1.1.0.48");
```

#### FindInteractiveClient

In an Automation script executed from e.g. a scheduled background task or as a Correlation action, you can use the *FindInteractiveClient* method to ask for input from a user.

In a message box, the user will be asked to click either *Attach* or *Ignore*.

- If the user clicks *Attach*, the script will start in a pop-up window.

- If the user clicks *Ignore*, the message box will be closed.

The method can take the following arguments:

- A message

- A timeout delay (in seconds)

    When this timeout expires, the script will continue and the *FindInteractiveClient* method will return “False”. The script can then decide how to deal with this result: issue a new request, fail, or execute automatic actions.

- A string indicating which users will receive the request, i.e. a list of DataMiner security group names, separated by semicolons.

    In this list of groups, you can also specify individual users. To do so, specify “user:”, followed by the user name.

- Options in the form of a set of binary flags. See [AutomationScriptAttachOptions enumeration](AutomationScriptAttachOptions_enumeration.md).

The method returns *true* if attaching to the interactive client succeeded; otherwise it returns *false*.

```txt
bool FindInteractiveClient(string message, int timeoutTime)                                                                                                                               
bool FindInteractiveClient(string message, int timeoutTime, string allowedGroups)                                                                        
bool FindInteractiveClient(string message, int timeoutTime, string allowedGroups, AutomationScriptAttachOptions options)
```

Example:

```txt
string allowedGroups = "grpA;grpB";                                  
bool ok = engine.FindInteractiveClient("Hello world",                
            100 , allowedGroups, AutomationScriptAttachOptions.None);            
if (!ok)                                                             
{                                                                    
    engine.GenerateInformation("Could not attach");                      
}                                                                    
else                                                                 
{                                                                    
    engine.GenerateInformation("Attached! As " + engine.UserDisplayName);
    engine.ShowProgress("A message");                                    
    engine.ShowUI("Another message", true);                              
}                                                                    
```

From DataMiner 9.6.9 onwards, it is also possible to find an interactive client by user cookie instead of by user name.

```txt
bool ok = engine.FindInteractiveClient("Some text", 100, "userCookie:" + connection.ConnectionID, AutomationScriptAttachOptions.None);
```

> [!NOTE]
> In DataMiner Cube, you can also use the script action *Find interactive client*, instead of using C#.

#### FindRedundancyGroup

Retrieves a redundancy group

- by name, or

- by ID (DmaID,GroupID).

Name masks can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

If no redundancy group with the specified name or ID is found, a null reference is returned.

```txt
RedundancyGroup FindRedundancyGroup(string name)                                            
RedundancyGroup FindRedundancyGroup(int dmaId, int groupId)
```

Examples:

```txt
RedundancyGroup group = engine.FindRedundancyGroup("MySpecialRedundancyGroup");
```

```txt
RedundancyGroup group = engine.FindRedundancyGroup(7,24);
```

#### FindRedundancyGroupByKey

Retrieves a redundancy group by key (DmaID/GroupID).

If no redundancy group with the specified key is found, a null reference is returned.

```txt
RedundancyGroup FindRedundancyGroupByKey(string key)
```

Example:

```txt
RedundancyGroup group = engine.FindRedundancyGroupByKey("7/24");
```

#### FindRedundancyGroups

Retrieves all redundancy groups matching the specified filter.

```txt
RedundancyGroup[] FindRedundancyGroups(RedundancyGroupFilter filter)
```

A redundancy group filter has the following fields:

- int ViewID (default Int32.MaxValue)

- string View

- bool ExcludeSubViews (default: false)

- int DataMinerID (default Int32.MaxValue)

- int GroupID (default Int32.MaxValue)

- string NameFilter

Example:

```txt
RedundancyGroupFilter myGroupFilter = RedundancyGroupFilter.ByView("MyView");
RedundancyGroup[] groups = engine.FindRedundancyGroups(myGroupFilter);     
```

#### FindRedundancyGroupsByName

Retrieves all redundancy groups of which the name matches the specified name mask.

Name masks can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

```txt
RedundancyGroup[] FindRedundancyGroupsByName(string filter)
```

Example:

```txt
RedundancyGroup[] groups = engine.FindRedundancyGroupsByName("Test*");
```

#### FindRedundancyGroupsInView

Retrieves all redundancy groups in the specified view.

```txt
RedundancyGroup[] FindRedundancyGroupsInView(int id)     
RedundancyGroup[] FindRedundancyGroupsInView(string name)
```

Examples:

```txt
RedundancyGroup[] groups = engine.FindRedundancyGroupsInView(17);
```

```txt
RedundancyGroup[] groups = engine.FindRedundancyGroupsInView("MySpecialView");
```

#### FindService

Retrieves a service

- by name, or

- by ID (DmaID,ServiceID).

If the service with the specified name or ID could not be found, a null reference is returned.

```txt
Service FindService(string name)                                              
Service FindService(int dmaId, int serviceId)
```

Examples:

```txt
Service myService = engine.FindService("MyService");
```

```txt
Service myService = engine.FindService(3, 56);
```

#### FindServiceByKey

Retrieves a service by key (DmaID/ServiceID).

If the service with the specified key could not be found, a null reference is returned.

```txt
Service FindServiceByKey(string key)
```

Example:

```txt
Service myService = engine.FindServiceByKey("3/56");
```

#### FindServices

Retrieves all services matching the specified filter.

```txt
Service[] FindServices(ServiceFilter filter)
```

A service filter has the following fields:

- int ViewID (default Int32.MaxValue)

- int DataMinerID (default Int32.MaxValue)

- int ServiceID (default Int32.MaxValue)

- bool ExcludeSubViews (default: false)

- bool NormalOnly

- bool WarningOnly

- bool MinorOnly

- bool MajorOnly

- bool CriticalOnly

- bool TimeoutOnly

- string NameFilter

The *NameFilter* string can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

Example:

```txt
ServiceFilter myServiceFilter = ServiceFilter.ByView("MyView");
Service[] services = engine.FindServices(myServiceFilter);   
```

#### FindServicesByName

Retrieves all services of which the name matches the specified name mask.

Name masks can contain the following wildcards:

- \* : Any string of characters

- ? : Any single character

```txt
Service[] FindServicesByName(string filter)
```

Example:

```txt
Service[] services = engine.FindServicesByName("Test*");
```

#### FindServicesInView

Retrieves all services in the specified view.

```txt
Service[] FindServicesInView(int id)     
Service[] FindServicesInView(string name)
```

Examples:

```txt
Service[] services = engine.FindServicesInView(19);
```

```txt
Service[] services = engine.FindServicesInView("MySpecialView");
```

#### FindServiceTemplate

Retrieves the service template with the specified DataMiner Agent ID and service template ID.

If the service template is not found, a null reference is returned.

```txt
Service FindServiceTemplate(int dmaId, int serviceTemplateId)
```

Example:

```txt
Service service = engine.FindServiceTemplate(200, 400);
```

#### FindServiceTemplates

Retrieves the service templates matching the specified service filter.

For more information on the service filter, refer to [FindServices](#findservices).

```txt
Service[] FindServiceTemplates(ServiceFilter filter)
```

Example:

```txt
ServiceFilter filter = new ServiceFilter{ CriticalOnly = true};
Service[] services = engine.FindServiceTemplates(filter);    
```

#### GenerateInformation

Generates an information message with the specified text.

```txt
void GenerateInformation(string text)
```

Example:

```txt
engine.GenerateInformation("Hello World!");
```

#### GetAlarmProperty

Retrieves the value of the specified custom alarm property.

```txt
string GetAlarmProperty(int dataMinerID, int alarmID, string propertyName)                                                                                                                                                   
string GetAlarmProperty(int dataMinerID, int elementID, int alarmID, string propertyName)
```

Examples:

```txt
string propertyValue = engine.GetAlarmProperty(200, 59851, "SourceDetail");
```

```txt
string propertyValue = engine.GetAlarmProperty(200, 400, 59851, "SourceDetail");
```

#### GetDummy

Retrieves an object representing one of the script dummies. Through this object, actions like “set parameter” can be executed.

If the specified dummy could not be found, a null reference is returned.

```txt
ScriptDummy GetDummy(int id)     
ScriptDummy GetDummy(string name)
```

Examples:

```txt
ScriptDummy dummyTest = engine.GetDummy(5);
```

```txt
ScriptDummy dummyTest = engine.GetDummy("matrix");
```

#### GetMemory

Retrieves an object representing one of the script’s memory files. Through this object, data can be read from or written into the memory file.

If the specified memory file could not be found, a null reference is returned.

```txt
ScriptMemory GetMemory(int id)     
ScriptMemory GetMemory(string name)
```

Examples:

```txt
ScriptMemory memoryData = engine.GetMemory(3);
```

```txt
ScriptMemory memoryData = engine.GetMemory("name");
```

#### GetScriptOutput

Returns the script output of the specified key. If a subscript fails or throws an exception, its script output will still be filled in.  Available from DataMiner 10.0.2 onwards.

```txt
string GetScriptOutput(string key)
```

#### GetScriptParam

Retrieves an object representing a script parameter. Through this object, its value can be retrieved.

If the specified script parameter could not be found, a null reference is returned.

```txt
ScriptParam GetScriptParam(int id)     
ScriptParam GetScriptParam(string name)
```

Examples:

```txt
ScriptParam param = engine.GetScriptParam(5);
```

```txt
ScriptParam param = engine.GetScriptParam("input");
```

#### GetScriptResult

Returns a copy of the script output of the current script and, if the *InheritScriptOutput* option is set to "true", the child scripts. If a subscript fails or throws an exception, its script output will still be filled in.<br>Available from DataMiner 10.0.2 onwards.

```txt
Dictionary<string, string> GetScriptResult()
```

#### GetUserConnection

Returns a connection that impersonates the user who ran the script based on Engine#UserCookie. If no user cookie is present on the script, the returned IConnection will act as the SLManagedAutomation connection. Available from DataMiner 10.0.10 onwards.

```txt
IConnection GetUserConnection()
```

#### LoadDoubleValue

Retrieves a double value from a global script variable.

```txt
double LoadDoubleValue(string name)
```

Example:

```txt
double myValue = engine.LoadDoubleValue("MyVariable");
```

> [!TIP]
> See also:
> -  [SaveValue](#savevalue)
> -  [LoadValue](#loadvalue)
> -  [LoadStringValue](#loadstringvalue)

#### LoadStringValue

Retrieves a string value from a global script variable.

```txt
string LoadStringValue(string name)
```

Example:

```txt
string myValue = engine.LoadStringValue("MyVariable");
```

> [!TIP]
> See also:
> -  [SaveValue](#savevalue)
> -  [LoadValue](#loadvalue)
> -  [LoadDoubleValue](#loaddoublevalue)

#### LoadValue

Retrieves a value from a global script variable.

```txt
object LoadValue(string name)
```

Example:

```txt
object myValue = engine.LoadValue("MyVariable");
```

> [!TIP]
> See also:
> -  [SaveValue](#savevalue)
> -  [LoadStringValue](#loadstringvalue)
> -  [LoadDoubleValue](#loaddoublevalue)

#### Log

Adds an entry in the SLAutomation.txt log file.

```txt
void Log(string message)                                                                                                                                              
void Log(string message, LogType type, int logLevel)                                                
void Log(string message, LogType type, int logLevel, string method)
```

*LogType* can be set to one of the following values:

- LogType.Information

- LogType.Error

- LogType.Debug

- LogType.Always

> [!TIP]
> See also:
> [LogType enumeration](LogType_enumeration.md)

*method* can be any text. Use it to add an extra comment to the log entry.

Examples:

```txt
engine.Log("My log message");
```

```txt
engine.Log("My log message", LogType.Always, 5);
```

```txt
engine.Log("My log message", LogType.Always, 5, "Initialize");
```

#### PrepareMailReport

Returns a *MailReportOptions* object, which you can use to configure and launch an email report.

```txt
MailReportOptions PrepareMailReport(string template)
```

Example:

```txt
MailReportOptions reportOptions;                             
reportOptions = engine.PrepareMailReport("myReportTemplate");
reportOptions.EmailOptions.SendAsPlainText = true;           
...                                                          
engine.SendReport(reportOptions);                            
```

#### PrepareSubScript

Returns a *SubScriptOptions* object, which you can use to configure and launch a subscript.

```txt
SubScriptOptions PrepareSubScript(string name)
```

Example:

```txt
SubScriptOptions subscriptInfo;                          
subscriptInfo = engine.PrepareSubScript("myOtherScript");
subscriptInfo.Synchronous = true;                        
...                                                      
subscriptInfo.StartScript();                             
```

#### RunClientProgram

Launches an application on the client in an interactive script.

```txt
void RunClientProgram(String applicationPath)                                                                                                            
void RunClientProgram(String applicationPath, bool waitForCompletion)                                                   
void RunClientProgram(String applicationPath, String arguments)                                                         
void RunClientProgram(String applicationPath, String arguments, bool waitForCompletion)
```

If *waitForCompletion* is set to *true*, the script will halt until the client application has completed or has been closed. In the interactive window, users will see the message “Wait for client program to finish”.

Examples:

```txt
engine.RunClientProgram("notepad.exe", @"c:\skyline dataminer\logging\slerrors.txt");
```

```txt
engine.RunClientProgram(@"C:\Skyline DataMiner\Tools\SLTaskbarUtility\SLTaskbarUtility.exe", @"\h", true);
```

#### SaveValue

Saves a value to a global script variable. This value can then be reused elsewhere in the same script.

```txt
void SaveValue(string name, double value)
void SaveValue(string name, string value)
```

Examples:

```txt
engine.SaveValue("MyVariable", 10.8);
```

```txt
engine.SaveValue("MyVariable", "MyValue");
```

#### SendEmail

Sends an email message.

```txt
void SendEmail(EmailOptions options)                                                                                     
void SendEmail(string message, string title, string to)
```

To specify the recipient, use

- an email address,

- *USER:*, followed by the name of a DataMiner user, or

- *GROUP:*, followed by the name of a DataMiner user group.

Example:

```txt
EmailOptions myEmailOptions;                                                                
...                                                                                         
engine.SendEmail(myEmailOptions);                                                           
engine.SendEmail("The message I want to send.","The title of my message","support@gtc.com");
```

#### SendPager

Sends a pager message.

```txt
void SendPager(PagerOptions options)                                      
void SendPager(string message, string to)
```

To specify the recipient, use

- a pager number,

- *USER:*, followed by the name of a DataMiner user, or

- *GROUP:*, followed by the name of a DataMiner user group.

Example:

```txt
PagerOptions myPagerOptions;                                 
...                                                          
engine.SendPager(myPagerOptions);                            
engine.SendPager("The message I want to send.","USER:ADMIN");
```

#### SendReport

Sends an email report.

To create a *MailReportOptions* object, call the *PrepareMailReport* method (see [PrepareMailReport](#preparemailreport)).

```txt
void SendReport(MailReportOptions options)
```

Example:

```txt
MailReportOptions reportOptions;                             
reportOptions = engine.PrepareMailReport("myReportTemplate");
reportOptions.EmailOptions.SendAsPlainText = true;           
...                                                          
engine.SendReport(reportOptions);                            
```

#### SendSms

Sends a text message (SMS).

```txt
void SendSms(SmsOptions options)                                        
void SendSms(string message, string to)
```

To specify the recipient, use

- a mobile number,

- *USER:*, followed by the name of a DataMiner user, or

- *GROUP:*, followed by the name of a DataMiner user group.

Example:

```txt
SmsOptions mySmsOptions;                  
...                                       
engine.SendSms(mySmsOptions);             
engine.SendSms("My Message","USER:ADMIN");
```

#### SetAlarmProperties

Sets the specified custom alarm properties to the specified values.

```txt
void SetAlarmProperties(int dataMinerID, int alarmID, string[] propertyNames, string[] propertyValues)                                                
void SetAlarmProperties(int dataMinerID, int elementID, int alarmID, string[] propertyNames, string[] propertyValues)
```

Examples:

```txt
engine.SetAlarmProperties(200, 521655, new string[]{"Property A", "Property B"}, new string[]{"Value A", "Value B"});
```

```txt
engine.SetAlarmProperties(200, 400, 521655, new string[]{"Property A", "Property B"}, new string[]{"Value A", "Value B"});
```

> [!NOTE]
> -  In DataMiner versions prior to 9.0, this method cannot be used to override alarm property values that are defined in the element protocol.
> -  When an alarm property value has been defined in the element protocol and this method is used to explicitly assign a new value to the property, the new value will only be retained until the severity of the alarm changes. After this, the value from the protocol is used again.

#### SetAlarmProperty

Updates a custom alarm property.

```txt
void SetAlarmProperty(int dataMinerID, int alarmID, string propertyName, string propertyValue)                                                
void SetAlarmProperty(int dataMinerID, int elementID, int alarmID, string propertyName, string propertyValue)
```

Example:

```txt
engine.SetAlarmProperty(200, 521655, "Property A", "Value A");
```

```txt
engine.SetAlarmProperty(200, 400, 521655, "Property A", "Value A");
```

> [!NOTE]
> -  In DataMiner versions prior to 9.0, this method cannot be used to override alarm property values that are defined in the element protocol. 
> -  When an alarm property value has been defined in the element protocol and this method is used to explicitly assign a new value to the property, the new value will only be retained until the severity of the alarm changes. After this, the value from the protocol is used again.

#### SetFlag

Using this method, you can set the following script options at runtime:

- AllowUndef

    By default, C# code used in a DMS Automation script throws an exception when it encounters an undefined or an empty parameter. However, if you add the following line in a DMS Automation script statement of type “CSharp Code”, null will be returned instead:

    ```txt
    engine.SetFlag(RunTimeFlags.AllowUndef);
    ```

- NoCheckingSets

    Available from DataMiner 10.0.8 onwards. Activate this option to disable checking of parameters or properties after these have been changed by the script.

    ```txt
    engine.SetFlag(RunTimeFlags.NoCheckingSets);
    ```

- NoInformationEvents

    Activate this option to prevent information events from being generated by the SET statements in the script:

    ```txt
    engine.SetFlag(RunTimeFlags.NoInformationEvents);
    ```

- NoKeyCaching

    Activate this option to prevent caching of table key mappings.
    By default, within a C# code block, lists of primary key/display key mappings are cached for performance reasons. To prevent caching of table key mappings, add the following statement to your Automation script:

    ```txt
    engine.SetFlag(RunTimeFlags.NoKeyCaching);
    ```

#### ShowProgress

Displays a progress message during the execution of an interactive Automation script.

```txt
void ShowProgress(string message)
```

Example:

```txt
string progress = "Session is successfully booked.";
engine.ShowProgress(progress);                      
```

#### ShowUI

Displays a custom-made dialog box of an interactive Automation script.

```txt
UIResults ShowUI(UIBuilder data)                                                    
UIResults ShowUI(string data)                                                       
UIResults ShowUI(string data, bool requireResponse)
```

Example:

```txt
// Create and configure the dialog box                  
UIBuilder uib = new UIBuilder();                        
...                                                     
// Add dialog box items to the dialog box               
UIBlockDefinition blockButton = new UIBlockDefinition();
blockButton.Type = UIBlockType.Button;                  
...                                                     
uib.AppendBlock(blockButton);                           
// Display the dialog box                               
engine.ShowUI(uib);                                     
```

#### Sleep

Causes the Automation script to pause for the specified amount of time (in milliseconds).

```txt
void Sleep(int timeInMilliseconds)
```

Example:

```txt
engine.Sleep(200);
```

#### UnSetFlag

Available from DataMiner 10.0.0/10.0.2 onwards. This method allows you to clear the specified runtime flag.

```txt
void UnSetFlag (RunTimeFlags flag)
```

This can for instance be used to perform silent parameter sets:

```txt
public void SetParameterSilent(int pid, object value) {                     
   // Set the NoInformationEvents flag to disable information events        
   _engine.SetFlag(RunTimeFlags.NoInformationEvents);                      
   // Perform a silent parameter set without triggering an information event
   element.SetParameter(pid, value);                                        
   // Re-enable information events by clearing the NoInformationEvents flag 
   _engine.UnSetFlag(RunTimeFlags.NoInformationEvents);                    
}                                                                           
```

> [!NOTE]
> This method is available on the *IEngine* interface from DataMiner 10.0.0 CU1/10.0.5 onwards.

> [!TIP]
> See also:
> [SetFlag](#setflag)
