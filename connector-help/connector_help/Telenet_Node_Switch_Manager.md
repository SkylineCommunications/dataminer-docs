---
uid: Connector_help_Telenet_Node_Switch_Manager
---

# Telenet Node Switch Manager

The **Telenet Node Switch Manager** is a DataMiner Application that is used to schedule node switching jobs. Each of these jobs can contain multiple nodes that need to be switched.

## About

This connector makes it possible to plan jobs containing nodes that need to be switched. Once a task has been planned, a **scheduled** **task** is created. The different nodes that can be switched are retrieved via SOAP messages to a specific headend DMA. The scheduled tasks will execute an **Interactive** **Automation Script,** which in turn will execute another **Automation Script** that takes care of the actual switching of the nodes. Once a job has been completed, another **Automation Script** is activated which creates and emails a **Report** of the job that has been completed.

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an **HTTP** connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination e.g. *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

### Automation scripts

This connector uses three **Automation Scripts**. These must be added before you can start using the connector:

- CreateReport.xml
- Switching Nodes AS.xml
- Switching Nodes IAS.xml

There are two ways to add these Automation Scripts:

1. In **System Display**, go to Advanced \> Automation, then select "Insert File" and select the Automation Scripts one by one.

1. Paste the three **Automation Scripts** into *C:\Skyline DataMiner\Scripts* and then perform a force synchronization as follows:

   - In **System Display**, right-click the top banner and select Admin Tools \> Force Synchronization \> File... In the "Force Synchronization" window, paste *C:\Skyline DataMiner\Scripts* and click OK.

In addition, you must also add the report template. To do so, place the file *Node Switch Report.asp* in the folder *C:\Skyline DataMiner\Webpages\Reports\templates*, and then perform a force synchronization of this folder (in the same way as described above).

Finally, you then need to fill in the settings on the **Settings** page of the element, as described below in the section "Settings Page."

## Usage

### Jobs Page

The **Jobs** **Page** displays two tables.

The **Job List** table displays all the jobs that are planned, are being executed, or have been executed. It is possible to change the execution time of a job by modifying the **Start** **Time** parameter. This time will only be changed if it occurs in the interval specified on the **Settings** page and if the job has not yet started.

Below, the **Node** **Table** is displayed, which shows all the nodes that are planned, are being executed, or have been executed. Each node is part of a job. A job can have multiple nodes, but a node can only have one job. The **Required** **Switch** **Position** parameter should be filled in. If this cell is left blank, then the inverse of the current **Switch** **Position** will be used.

In addition, three page buttons are available:

- **Alarm Table .** : Leads to a page displaying clearable alarms generated when something goes wrong when the nodes are switched, along with extra information.

- **New Job .** : Leads to a page where you can select different nodes that need to be switched.

- Selecting the nodes can be done either by selecting each node in turn via the **Nodes Available** box, or by filling in the names of the nodes, separated by a space, in the **Import CSV** field.
  - You also have to fill in the **Start** **Time** **Job** parameter with an appropriate start time that lies in the interval defined on the **Settings** page.
  - The **Duration** **Job** parameter also needs to be filled in.
  - The **Status Information** parameter will display an error message if the provided input data is not as expected.
  - Once all the nodes have been added and all the parameters are filled in, you can add the job by pressing the **Add Job** button. The job will then be added to the **Job List** and the selected nodes will be added to the **Node Table**.

### Settings Page

On this page, the settings for the Node Switch Manager can be filled in. These parameters are:

- **Headend DMA**: The IP address of the headend DMA that is currently in use.
- **User Name**: The username to log in to the specified headend DMA.
- **DMA Group Authorized**: The DMA group that is authorized to decide if a Node Switching Job can be started or not.

In addition, you can also configure the settings for the tasks:

- **Number of Parallel Nodes**: The number of nodes that are allowed to be processed at once.
- **Time Frame Start**: The time from which the nodes can be started.
- **Time Frame End**: The time from which no new nodes can be started.
- **Allowed Deviation**: The deviation that is allowed between the optical parameters before and after the node switch.
- **Waiting Time After Set**: The delay after the node has been switched before the optical parameters of the node are rechecked.

There are three page buttons available on this page that can be used to fill in the master data. Each of these will open a pop-up page where the different settings can be filled in for the **Major Outage tickets** or the **Planned Maintenance tickets**. When these parameters are left blank, a standard value will be filled in.

There is also one button available, **Default Masterdata,** which can be used to reset the initial values of the master data.

Below this, there are two additional page buttons:

- **Email**: Leads to a page where you can add email addresses to a table. All these email addresses will receive the report once a job is finished. You can either add an email address manually, or add all the users in a group from the DMA.
- **Headend**: Leads to a page where additional headend DMAs can be added. If the connection to the current DMA is lost, the element will then automatically select another headend DMA to connect to. You can force the application to use a certain connection by pressing the **Select** button in the row of the DMA that you want to connect to.
