---
uid: Connector_help_Ziggo_Arris_Alarm_Central_Simulator
---

# Ziggo Arris Alarm Central Simulator

This connector is used to simulate specific use case scenarios, on Ziggo systems, and test if functionalities work as expected.

## About

The **Ziggo Arris Alarm Central Simulator** connector sends custom events, as HTTP posts, to a predefined destination.

A list of **events** can be orderly saved as a **Scenario**, so, multiple **events** can be sent automatically in one go.

**AlarmId** placeholders are available that, when used, generate a random GUID ending with "aacsim" to be easily tracked. These placeholders can be used by setting '\[' and '\]' in the beginning and end of the *\<AlarmId\>* tag value. This means that, within the same scenario run, alarm IDs with the same placeholder will have the same value.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector requires a HTTP connection to send events, and, by default, asks for an **IP address/host** upon element creation. This parameter is mandatory but irrelevant, because all the addresses are set on the **Scenario** table in the element. Therefore, "localhost" is enough.

## Usage

### General

This page displays a tree view with all stored **scenarios** and associated **events**. Clicking on a **scenario** of the tree view shows a table with all events associated to it, and all relevant information regarding that scenario:

- **Name**: Name of the scenario.

- **Description**: Description of the scenario.

- **Destination**: The IP address and port the events should be forwarded to.

- **Delay**: Time delay, in milliseconds, between each event of a scenario.

- **State**

  - *Idle*: Scenario is not sending any events at the time.

  - *Running*: Events of the scenario are scheduled to be forwarded.

- **Current** **step**: The position, in the scenario, of the last event to be sent.

  - E.g.: "1/5" means the first event of the scenario (with 5 events) was sent.

  - On the tree view, the last event sent has an arrow icon.

Every **scenario** has 5 buttons/actions available:

- **Next**: Send next **event** in line

  - E.g.: If the **Current Step** is "1/5", by clicking on **Next**, the second event will be sent immediately, and the cell becomes "2/5".

  - **Next** actions do not take **Delay** values into account.

- **Reset**: Resets **scenario** to default values and restarts **Current Steps** back to default (*Not started*).

- **Run**: Initiates a **scenario** run. All **events** of the **scenario** will automatically, and sequentially, be forwarded with a predefined **delay** between each others. The run starts on the position displayed in **Current Step**.

  - E.g.: If **scenario's delay** is set to *500 ms* and the **Current Step** is "2/5", by clicking on **Run**, all the last 3 events are scheduled to be sent with *500 ms* apart.

- **Stop**: Stops a running **scenario**. The **Current Step** is not reset, it remains on the same step when the action **Stop** was performed.

  - Analogously, **Run/Stop** can be used as **Resume/Pause**.

- **Delete**: Deletes the scenario.

The table listing all **events** of the **scenario** contains useful information for tracking and debugging:

- **Event Idx**: Name of the **event**.

- **Order**: Order of the **event** in the scenario.

- **Breakpoint**: The user can set an **event** with a **breakpoint**. If so, when the **scenario** is *running*, it will automatically **stop** before the specified **event** is sent.

  - In the tree view, the **breakpoint event** that stopped the run of the **scenario** has a special "i" icon.

- **Alarm ID**: The *\<AlarmId\>* tag value of the **event** that was forwarded.

  - Useful when using placeholders.

The **New Scenario** page allows the user to configure **scenarios**. This page will be explained on the Scenarios section below.

### Scenarios

This page displays all the **scenarios** stored in the element, in the **Scenarios Table**. This table contains all the information and actions available in the tree view of the General page, except the list events. The **Scenarios table** allows the use of context menu, where the user can *delete* and *duplicate* **scenarios**.

By clicking the **New Scenario** page button the user can **create** and **edit** **scenarios**.

**Creating a new scenario**:

1. On the **Scenario Settings** section, fill scenario's general information:

   - **Name**
   - **Description**
   - **Destination**
   - **Delay**

1. Select an **event** from the **Scenario Event Name** drop down box and click *Add Event*;

   - The **event** is added to the bottom of the **CreateScenarios table**.

1. The **CreateScenarios table** lists the **events** and allows the user to order them within the **scenario**, via **Order column**.

1. When the scenario is configured, click *Add* on the **Scenario Settings** section.

**Editing an existing scenario**:

1. On the **Load Scenario** section, select the **scenario** from the **Scenario List** drop down box and click *Load;*

   - The general information is filled and the sequence of **events** of that specific **scenario** is imported to the **CreateScenarios** *table*

1. Edit any information or the list of **events**

   - Do not change the Name of the scenario, otherwise the scenario is interpreted as a new one

1. Click *Replace* on the **Scenario Settings** section

The **Import/Export** page allows the user to export/import scenarios into/from a file.

- Exporting a **scenario** saves all scenarios and **events** information, meaning that, when importing, all the **event** files need to be available at the same location, otherwise the import operation is canceled.

  - The user is notified of the *names* and *locations* of the missing files.

### Events

This page shows a list of all **events** that can be sent, in the **Events Table**.

To import an event:

1. Set the location of the .xml file(s) on the **Import Event Filepath** parameter.

1. Select one of the files in the drop down box **Import Event Filename** parameter.

1. Click on the *Import XML* button

   - A new event is added to the **Events table**

   - The name of the event will be the name of the file, and it is unchangeable.

The content of the xml file is not loaded into the element, only the file location is stored. When an event is ready to be sent, the connector reads the xml content using the filepath value set on the **Events Table** upon "*event import*".

- Therefore, the user can change the content of the **event** without the need to import it again.

However, the xml file needs to be available, so the event can be sent. To change the file location of an **event**, import the event again, with the same name, and the **Filepath** will be updated.
