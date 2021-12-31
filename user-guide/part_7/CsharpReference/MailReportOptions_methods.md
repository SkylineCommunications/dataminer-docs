## MailReportOptions methods

- [IncludeElement](#includeelement)

- [IncludeFilteredView](#includefilteredview)

- [IncludeView](#includeview)

- [SetMailOptions](#setmailoptions)

#### IncludeElement

Adds an element to be included in the report.

```txt
void IncludeElement(ScriptDummy dummy, string param1, string param2, string param3, ...)                                                                         
void IncludeElement(ScriptDummy dummy, MailReportParameter param1, MailReportParameter param2, MailReportParameter param3, ...)                                  
void IncludeElement(int dmaid, int eid, MailReportParameter param1, MailReportParameter param2, MailReportParameter param3, ...)
void IncludeElement(Element dummy, string param1, string param2, string param3, ...)                                                                             
void IncludeElement(Element dummy, MailReportParameter param1, MailReportParameter param2, MailReportParameter param3, ...)                                      
```

In the example above, you can see how single-value parameters are passed to a report by means of string values containing parameter names. To add table cells to a report, create a MailReportParameter object for every table cell that has to be added, and then pass those objects instead of parameter names. These are the possible constructors for the MailReportParameter class:

```txt
MailReportParameter(int pid, string displayIndex)                                                                                                                           
MailReportParameter(int pid, string displayIndex, MailReportParameterFlags options)                                                        
MailReportParameter(ScriptDummy dummy, string name)                                                                                                                         
MailReportParameter(Element dummy, string name)                                                                                                                             
MailReportParameter(ScriptDummy dummy, string name, string displayIndex)                                                                   
MailReportParameter(Element dummy, string name, string displayIndex)                                                                       
MailReportParameter(ScriptDummy dummy, string name, string displayIndex, MailReportParameterFlags options)
MailReportParameter(Element dummy, string name, string displayIndex, MailReportParameterFlags options)    
```

For an example showing how to pass single-value parameters as well as table cells to a report, see below.

```txt
Element dummy1 = engine.FindElement("My Element");                                            
MailReportOptions reportOptions = engine.PrepareMailReport("Report Name");                    
//Add single-value parameter                                                                  
reportOptions.IncludeElement(dummy1, new MailReportParameter(dummy1, "Total Processor Load"));
//Add table cell                                                                              
reportOptions.IncludeElement(dummy1, new MailReportParameter(dummy1, "Bandwidth", "Eth0"));   
```

> [!NOTE]
> In the example above, the index argument has to contain the display key. If necessary, use the FindDisplayKey method on the element or the dummy to retrieve that key. See [FindDisplayKey](Element_methods.md#finddisplaykey).

#### IncludeFilteredView

Adds all elements of a given protocol from a given view.

```txt
void IncludeFilteredView(string viewName, string protocolName, string protocolVersion, string param1, string param2, string param3, ...)                                  
void IncludeFilteredView(string viewName, string protocolName, string protocolVersion, MailReportParameter param1, MailReportParameter param2, MailReportParameter param3)
```

#### IncludeView

Adds a view to be included in the report.

```txt
void IncludeView(string viewName)
```

#### SetMailOptions

Configures the following email options:

- Body text

- Subject text

- Destination address(es)

```txt
void SetMailOptions(string message, string title, string to)
void SetMailOptions(EmailOptions options)                                                                                     
```

> [!NOTE]
> To copy the report as a PDF to a remote location, the following syntax can be used:<br>*reportOptions.SetMailOptions("message", "title", string.Format("copypdf:{0}:{1}:::", filename, location));*
>
