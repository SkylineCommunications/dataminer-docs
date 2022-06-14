---
uid: QuestionsAndAnswers
---

# Questions & Answers

1. *What are the different methods of retrieving an SNMP table? List the different names, their internal
working and summarize the implementation method.*
  
    **GetNext**
  
    Driver Implementation: Define an SNMP tag on the table parameter but not on the column parameters.
    The table parameter uses “1.3.6.1.2.1.2.2” as OID.

    Capture observation: the initial request is an SNMP getNext request with the OID of the Entry (1.3.6.1.2.1.2.2.1).
  
    The result of this is the content of 1.3.6.1.2.1.2.2.1.1, the first row, first column. GetNext requests are performed until the OID in the response exceeds the range of table OID.

    **GetNext + MultipleGet**

    Driver Implementation: Define an SNMP tag on the table parameter and on the column parameters

    Capture observation: getNext requests are performed to obtain the number of rows using the instance, starting with the OID of the Entry (1.3.6.1.2.1.2.2.1). Once this is known, one SNMP Get request is performed to obtain all the rows of the table. By default, 50 cells can be retrieved at a time; it can be overridden with the bulk: option.

    A problem that can occur is that when a row disappears during the retrieval, the result can be mixed up because the data is retrieved block by block, e.g. first block still has data of 5 rows, while for the next block it is 4 rows. A second problem is that when a column is "Not Available", a shift of data will occur in DataMiner. The content of columns will be shifted, the "Not Available" column will contain the data of the next column, and so on.

    **MultipleGetNext**

    Driver implementation: Define an SNMP tag on the table parameter and on the column parameters. The use of options=”multipleGetNext” is needed on the table parameter.

    Capture observation: getNext requests are performed for all columns at the same time until all rows are retrieved.

    **MultipleGetBulk**

    Driver implementation: Define an SNMP tag on the table parameter and on the column parameters. The use of options=”multipleGetBulk” is needed on the table parameter.

    Capture observation: getBulk requests are performed until all data is retrieved. The max-repetitions field indicates for how many rows this is done in one request; in DataMiner this field is defined by specifying a number after the multipleGetBulk option. For example: multipleGetBulk:5. The standard value is 10 iterations.

1. *What is the meaning of the instance of an SNMP parameter? What is it used for?*

    To retrieve an SNMP parameter, we need the OID and its instance. For standalone parameters, this is usually “.0”, while for rows in a table, it is something like .1, .2, and 3. The instance uniquely identifies the row.

    When options=”instance” is used, DataMiner will automatically copy the instances to the first specified column. Typically, the first column of a table contains the primary key, which is the same as the instance. In that case, we can just retrieve that column without the use of options=”instance”.

1. *What is the best way to search data spread over multiple tables? From the tables below, I need all elementary streams related to transport stream "TS02".*



1. *Which steps would you perform to investigate an SNMP communication issue with a device? I.e. the device is not responding to the requests you send.*
    1. Perform a ping to the device.
    1. Use another tool (e.g. MibBrowser) to test the connection.
    1. Check the community strings.

1. *What is the meaning of the actions "Execute", "Execute Next", "Execute One", "Add to Execute" and "Force Execute" on a group?*

    Groups added by a timer or an "add to execute" actions are added to the end of the queue. There is no check if the group is already present in the queue. When the action "execute one" is used, there will first be a check whether the group is already present.

    "execute" actions will add the group to the queue just before the groups that have been added by a timer or by "add to execute" actions. "execute one now" will only add this group if it is not already present in the queue.

    "execute next" will add the group just after the group that is currently being executed. "execute one top" will insert it only if the group is not present in the queue.

    "force execute" is used with a trigger before/after command/response to execute the force execute group with, for example, with new settings before continuing the execution of the current group. The group executed "by force" will interrupt the current group being executed between two pairs.

1. *What is the meaning of this piece of code taken from a parameter with ID 200? Is there something missing in order for this code to work? If so, what is missing?*

    ```xml
    <ColumnOption idx="9" pid="210" type="custom" value="" options=";foreignKey=100"/>
    ```

    The use of the option "foreignKey=100" puts an integrity constraint on the values of this column. It states that the values of this column refer to values from the primary key column of table with ID 100.

    When the foreignKey option is used, a relation also needs to be definition. For example:

    ```xml
    <Relation path="200,100"/>
    ```

1. *What is the similarity and difference between the “Others” and “Exceptions” tags?*

    The Others and Exceptions tags are used to indicate an exceptional state of a parameter. Others is used when the incoming exceptional value is from a different type than described in the Interprete tag of the parameter. The Exceptions tag is used when the type is the same.

    It is not possible to fill in Others from within a QAction. Choose your value used as exception wisely so that a good trend graph is obtained. It is recommended to choose a value that falls just out of the normal range of the parameter.

1. *What can you say about the time it takes for a command to receive its response?*

    In the following cases, DataMiner will take in the matching response as quickly as possible:

    - The response has a header and trailer defined
    - All parameters of the response have a fixed length defined
    - The response has a field indicating the length which is accounted for using a parameter of type "length"

    In other cases, DataMiner will wait for a timeout to check if the response matches

1. *When you use a state column, do you need to take this column into account when using fill table at once (number of columns)? When can you use a state column?*

    You do not need to take into account the state column in the number of columns of the array that will fill the table at once if the state column is at the end of the table. You can use the state column on SNMP tables and when Fill Table at once is used with a NotifyProtocol type 193 method call.

1. *What is the purpose of DVEs? Point out the key functionality that is needed to implement a DVE protocol.*

    DVE stands for Dynamic Virtual Element. This technology allows DataMiner to create new elements dynamically. This is for example done for a device that contains a controller card and several optical receivers and other cards in its slots. Different elements are used to monitor the different cards.

    In the past, different protocols would be created for each type of card/element. With DVEs, one driver is created that automatically creates new virtual elements/protocols.

    To implement DVE functionality, the following must be defined in a protocol.

    - On the Protocol.Type tag, specify `exportProtocol:[protocol name]:[tableID]"` in the options tag. Multiple exportProtocols can be separated with semicolons. The "noElementPrefix" option can be used to leave out the parent element name in the virtual element name.

       ```xml
      <Type options="exportProtocol:Workflow Server:100">snmp</Type>
      <Type options="exportProtocol:Workflow Server:100:noElementPrefix">snmp</Type>
      <Type options="exportProtocol:Workflow Server:100;exportProtocol:Workflow Server2:200">snmp</Type>
      ```

    - An additional column needs to be created that has the option "element". This column will contain the global element ID ("DMA ID/element ID") values of the virtual elements that will be created. On the ColumnOption tag of the table, you define the option "element".

      ```xml
      <ColumnOption idx="11" pid="112" type="custom" value="" options=";element"/>
      ```

    - On the parameters you want to export to the DVE, define the attribute `export="true"` or `export="table id"` for a specific export when using multiple exports. When working with a referenced table, do not forget to use the foreignKey option and define relations. If you put the export attribute only on the columns, they will be exported as standalone parameters (possible in 1-1 relation).

1. *Is there a mistake in the code below?*

   ```xml
    <ColumnOption idx="1" pid="305" type="retrieved" value="" options="save"/>
    ```

    There should be a semicolon (“;”) before the save.

1. *How can you verify if traps arrive in DataMiner without using a protocol?*

    The SLSNMPManager log file can be verified. The minimum log levels are “Log Everything” in order to see the trap information in the file.

1. *When do you need the “Read Response” action?*

    When the response contains a parameter with LengthType set to "next param", the action "Read Response" needs to be executed by a "Trigger Before Each Response".

    ```xml
    <Trigger id="12">
        <Name>Before Response</Name>
        <On id="each">response</On>
        <Time>before</Time>
        <Type>action</Type>
        <Content>
          <Id>12</Id>
        </Content>
    </Trigger>
    ```

    ```xml
    <Action id="12">
        <Name>Read Response Action</Name>
        <On>response</On>
        <Type>read</Type>
    </Action>
    ```

1. *What can explain the following behavior in a serial protocol implementing HTTP? Good responses and timeout follow up on each other.*

    A serial protocol that uses HTTP commands in SLProtocol requires the definition of `"options:closeConnectionOnResponse"`. If not, the communication will suffer from the described issue.

1. *Can you explain the “Set with wait” action? What is important regarding the implementation of this action? Does this also count for “Set and get with wait”?*

    A “Set with wait” will:

    - Perform a set request
    - Wait until the set succeeded (when the SNMP Manager receives an “OK” from the device)

    A “Set and get with wait” will:

    - perform a set request
    - wait until the set succeeded (when the SNMP Manager receives an “OK” from the device)
    - perform a get request
    - wait until the get succeeded (when the result of the get is known)

    There is no verification of the get/set value. It is important that both the actions are executed from the protocol thread. This can be achieved by putting the action into a group and letting that group execute.

1. *Can you name one or more reasons for the problem “Too many groups on the protocol stacks”? How can this be solved?*

    This occurs when the last group in a timer is of type "Action" or "Trigger" or when a trigger executes a group of those two types. This is because the system does not wait for "Action" or "Trigger" groups to be finished before continuing. It can be solved by using type "poll action" or "poll trigger", or by putting a poll group after the group.

1. *What is the difference between starting a Trigger -> Action with a SetParameter and a CheckTrigger?*

    A protocol.CheckTrigger makes sure that the action is not started from the protocol thread but from a new thread created by the QAction. It is therefore not possible to start e.g. “Set with wait” from a QAction unless you put a group in the queue where the “Set with wait” is.

1. *When the protocol has a table on which settings will be done from an Automation script, what do you need to look out for and how can it be solved?*

    An Automation script performs settings very fast, which can mean that a parameter that is used in a command or in an SNMP set can already be changed again before it has actually been sent to the device. This can be solved by implementing a buffer for serial sets; for SNMP sets it is now possible to perform SNMP sets/gets from within a QAction.

1. *What is the meaning of “15236” in the following line taken from an element log file?*

    ```bash
    SLProtocol - 15236 - |7652|CProtocol::InitFunc|CRU|0|ReadSettings
    ```

    This is the SLProtocol process ID.

1. *Does the display key need to be unique?*

    It needs to be unique. The index column needs to be unique as well.

1. *Is it correct that the measurement type of a primary key must be “string”?*

    No, the measurement type can be something else, but the “interprete” type has to be a string.

1. *What is the best way to check if a cell from an SNMP table has changed?*

    You should use `row=”true”` in combination with the NewRow method defined in the SLProtocol interface.

1. *The Transfer-Encoding header of an HTTP message can sometimes be set to “chunked”. What is the meaning of this type and how do we process this in DataMiner?*

    The chunked encoding modifies the body of a message in order to transfer it as a series of chunks, each with its own size indicator, followed by an OPTIONAL trailer containing entity-header fields. This allows dynamically produced content to be transferred along with the information necessary for the recipient to verify that it has received the full message. It can be processed in DataMiner using the attribute `communicationOptions="ChunkedHTML"` on the Protocol.Type tag.

    Note that this is no longer needed with the using the connection type "HTTP".

1. *What is the best way to retrieve the time between two executions of the same SNMP poll group?*

    SNMP communication from SLProtocol towards SLSNMPManager is initiated by triggering a group. Per group, SLSNMPManager tracks a number of counters and then forwards all counter information to SLProtocol.

    To retrieve the delta between two consecutive group executions (in ms) from within a QAction:

    ```csharp
    int delta = Convert.ToInt32(protocol.NotifyProtocol(269/*NT_GET_BITRATE_DELTA*/, 1500, null));
    protocol.Log("QA" + protocol.QActionID + "|" + string.Format("Delta on group 1500:{0}", delta), LogType.Error, LogLevel.NoLogging);
    ```

1. *What is the purpose of “name resolution”? What else can you say about it?*

    Name resolution has the same purpose as a DisplayColumn: to give a more user-friendly description to alarm and trend records. It was originally intended to be used when the desired description consisted of values coming from different tables. It was then not needed to write a QAction and manually compose the description. It can also be used to avoid the problem with SNMP tables and DisplayColumns using row="true".

1. *What might be the reason/explanation for the following problem: the value of an SNMP displayColumn remains equal to the index while it should contain a customized value. After restart of the element, the correct value is used. What is a safe way to create a custom display column for an SNMP table?*

    By default, the display column will have the same value as the index column when its value has not been overwritten yet. The index and display column values are always stored in the database; after startup all stored values are retrieved from the database. This indicates that the correct value for the display column was available but not shown on the screen. This happens in the following situation:

    SNMP table with custom DisplayColumn that is filled in with row=true. In your QAction, the desired value is filled in but it will be overwritten in the display with the default index values the moment the entire SNMP table has been retrieved.

    Safe way:

    - Keep row=true but use naming on custom column.
    - Fill in the display column in a QAction but after the SNMP table group. To avoid too many unnecessary sets, you should make use of a flag to indicate whether it should be overwritten again.

1. *Can you provide some comments on the following code fragment?*

    ```csharp
    for (int j = 1; j <= rowCountProgram; j++)
    {
        string key = Convert.ToString(protocol.GetParameterIndex(50, j, 1));
        int rowIndex = protocol.GetKeyPosition(50, key);
    
        if (rowIndex != 0)
        {
            int parameterID = Convert.ToInt32(protocol.GetParameterIndex(50, j, 2));
    ```

    First the key is retrieved from a row, then there is a check if the key actually exist in the table before a cell is retrieved. This is unnecessary code.

1. *What is the main difference between a serial and a smart serial driver?*

    The principle of a serial driver is that a command needs to be sent in order for the device to send some data back (responses), while in a smart-serial driver, the device can send data on its own initiative.

1. *A driver contains two different trap receiver parameters. Someone complains that alarms coming from these two parameters are linked to each other while in fact they should not be. The meaning of the traps is different; they also have different OIDs. What do you think is the reason and what can be done to fix it?*

    By default, trap parameters will be linked together if they have similar linking conditions. In order to overwrite this, you should specify a group ID number before the linking, e.g. |Link:-1,2,5.

1. *Is it possible to use different severities on trap alarms with the exact same protocol? If so, how can this be achieved?*

    It is possible because when trap receivers are created with TrapMappings and discrete severities, the user needs to configure an alarm template on the element in order for alarms to be generated. The user specifies the alarm severity per trap.

1. *You have a big table and for some reason you need all the keys. How would you retrieve them in your protocol?*

    Using the function NotifyProtocol (168, tableId, null) we get an array with 2 cells that each contain an array. The first array contains all the primary keys, the second array contains the display keys.

1. *In a serial protocol, you encounter the problem that a value of a parameter is not updated while you see in the stream that a new value is given in the response. No errors are generated, everything runs well. What issue in a protocol can cause this?*

    A command can have multiple responses defined. It first checks the first response and if it fails, it will try the second. When the second matches, the first one should be cleared. Otherwise, DataMiner will never try to match the first response again unless a restart of the element is done.

1. *A protocol uses naming to obtain a meaningful alarm description. You saw that two alarms were generated on a parameter before the description as specified by the naming was used. What do you think is the reason?*

    The reason is most likely that the values used for naming are filled in after that the value on which alarming is done is filled in.

1. *A QAction contains the following lines of code. The set on parameter 21 will trigger the execution of a second QAction. What will happen? Will parameter 14 be set to 3 after or before the execution of the second QAction? In other words, will QAction 1 be interrupted for the execution of the second QAction?*

    ```csharp
    if (triggerValue == 1)
    {
        protocol.SetParameter(21, "True");
        protocol.SetParameter(14, 3);
    }
    ```

    QAction 1 will be interrupted; the set on parameter 14 will be done after execution of QAction 2.

1. *Which Microsoft .NET framework is supported for scripting in protocols?*

    .NET version 2.0 and .NET 4.0 (since DataMiner version 7.0.2)

1. *If you execute a SetParameter method call with a fixed value, will the change go off the second time as well?*

    Yes, it will go off. A set through a QAction always goes off.

1. *What will the following fragment from a protocol do?*

    ```xml
    <Group id="1">
        <Name>Perform Copy</Name>
        <Description>Perform Copy</Description>
        <Content>
            <Action>1</Action>
        </Content>
    </Group>
    ...
    <Action id="1">
        <On id="20">parameter</On>
        <Type id="10">copy</Type>
    </Action>
    ...
    <Timer id="1">
        <Time>3000</Time>
        <Interval>75</Interval>
        <Content>
            <Group>1</Group>
        </Content>
    </Timer>
    ```

    The intention is that group 1 will be executed every three seconds and perform a copy. However, this will fail because it is a poll group (this is the default type) and not an "action" or "poll action" group (i.e. the following line should be added to the group: `<Type>poll action</Type>)`.

1. *Under which circumstances can `row=true` work and when not?*

    `row=true` will work when the QAction triggers on a table parameter. It is useless on a QAction that does not trigger on a table.

1. *Is it OK to have an “After Startup” trigger to run a “Run Actions” action?*

    It is not OK. It is very likely to cause issues on the DMA. There are two possible approaches for this and the second one is the best:

    - Using a timer and stopping it after its first execution
    - Using an “After Startup” trigger that will trigger an “execute group” action that will execute a “poll action” group that will execute a “Run Actions” action that will trigger the QAction.

1. *Can you describe the buffer technology sometimes used for sets in serial protocols?*

    When a set is done on the write parameter, the crosspoint values that need to be set are stored into a buffer as a “|”-separated string. For example: param 50. Values will be taken from that buffer one by one and a flag is used to indicate if a set is being performed.

    So when a set is done by the write parameter and the flag indicates that there is no setting busy, the code used to take one crosspoint from the buffer needs to be triggered by adjusting the flag.

    When taking a crosspoint from the buffer, the buffer needs to be adjusted and a command needs to be composed. Once the command is executed, the flag needs to be changed again so that the next crosspoint can be taken again from the buffer.

    Summary:

    - QAction 1: Triggers on write of matrix, process the data to put it into a buffer parameter in a certain format. Set flag to true if it is not false. (false=set is being executed)
    - QAction 2: Triggers on flag parameter if true, to take 1 crosspoint from the buffer and send it to a command; set flag to false.
    - Group is executed with command to perform the setting.
    - Trigger after group to put the flag back to True (back to step 2 until buffer is empty).

1. *When will a QAction go off that triggers on a polled SNMP parameter?*

    It will only go off when there is a change in the parameter value.
