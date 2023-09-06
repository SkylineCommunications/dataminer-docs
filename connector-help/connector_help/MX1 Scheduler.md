---
uid: Connector_help_MX1_Scheduler
---

# MX1 Scheduler

This driver exposes a REST API that can be used to manage tasks in the Scheduler app.

The following methods are currently supported by the API:

- /createScheduledTask

- POST: Creates a new scheduled task.

- /deleteScheduledTask/{taskId}

- DELETE: Deletes a scheduled task by ID.

- /getAutomationScripts

- GET: Lists all available Automation scripts.

- /getSchedulerTasks

- GET: Lists all scheduler tasks.

- /updateScheduledTask

- PATCH: Updates an existing scheduled task.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

## How to use

### General

This page displays the current **status** of the API service, together with the current **endpoint URI** on which the service can be reached.

### Tasks

This page contains a table with information for each scheduled task present in the Scheduler app.

The **Delete Task** parameter allows you to delete a specific task by ID.

### Configuration

The **address** and **port** of the web service endpoint can be configured on this page. After the address or port have been changed, the web service will restart. Make sure that incoming traffic is allowed by the (Windows) firewall for the configured port.

### API Help

This page displays the default WCF help page that describes the available methods and expected input/output of the REST web service.

## Notes

Specific information about every request or response is displayed on the API Help page of the driver.To create or update a task, specific guidelines for the request body must be followed. Below, you can find these guidelines, as well as two examples (in JSON and XML).

### Guidelines

- **Name**: String with unique task name.

- **StartDate** and **EndDate**: String in the format "yyyy-MM-dd".

- **StartTime** and **EndTime**: String in the format "HH:mm:ss".

- **RepeatType**: One of the following strings: "Once", "Daily", "Weekly", "Monthly".

- **RepeatInterval:**

- If **RepeatType =** "**Once**": This field can be omitted.
  - If **RepeatType =** "**Daily**": This field can be omitted and the interval can be defined in the **RepeatIntervalInMin** field.
  - If **RepeatType =** "**Weekly**": String containing the days of the week, separated by commas. For example, if "1,2,7" is specified, the task will be repeated every Monday, Tuesday and Sunday.
  - If **RepeatType =** "**Monthly**": String containing the days of the month and the code of the months to repeat, separated by commas. The code for January is 101, for February it is 102, etc. with the code for December being 112. For example, if "1,2,7,101,105,112" is specified, the task will be repeated on days 1, 2 and 7 of January, May and December.

- **Enabled**: "True" or "False".

- **DmaId**: String containing the ID of the DMA where the task will be scheduled. This field can be omitted, in which case the default DMA ID will be used (i.e. the DMA ID of the driver).

- **Script:**

- **Name**: String containing the Automation Script name.

  - **Dummies**:

  - - **Dummy:**

    - - **ID**: String containing the ID of the script dummy.
      - **ElementName**: Name of the element to assign to the dummy.

  - **Params**:

  - - **Param**:

    - - **ID**: String containing the ID of the script parameter.
      - **Value**: String containing the value for the parameter ID.

### Example of /createScheduledTask Request Body in JSON

{"Task":{"Name":"Example1","Description":"Sts","StartDate":"2020-05-07","StartTime":"10:00:00","RepeatType":"Monthly","RepeatInterval":"1,2,102,107","RepeatIntervalInMin":"50","Enabled":"True","DmaId":"512","Script":{"Name":"ExampleScriptName1", "Dummies":\[{"ID":"1","ElementName":"Example Element Name"}\],"Params":\[{"ID":"1","Value":"param1_value"}\] }}}

### Example of /createScheduledTask Request Body in XML

\<CreateTaskRequest\> \<Task\> \<Name\>Example2\</Name\> \<StartDate\>2020-05-08\</StartDate\> \<StartTime\>10:00:00\</StartTime\> \<Enabled\>True\</Enabled\> \<RepeatType\>Weekly\</RepeatType\> \<RepeatInterval\>1,2,3\</RepeatInterval\> \<Script\> \<Name\>ExampleScriptName2\</Name\> \<Dummies\> \<Dummy\> \<ID\>1\</ID\> \<ElementName\>Example Element Name\</ElementName\> \</Dummy\> \</Dummies\> \<Params\> \<Param\> \<ID\>2\</ID\> \<Value\>param2_value\</Value\> \</Param\> \<Param\> \<ID\>3\</ID\> \<Value\>param3_value\</Value\> \</Param\> \</Params\> \</Script\> \</Task\>\</CreateTaskRequest\>
