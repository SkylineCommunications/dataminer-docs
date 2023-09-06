---
uid: Connector_help_Camunda_BPMN
---

# Camunda BPMN

Camunda Platform is a complete process automation tech stack with powerful execution engines for BPMN workflows and DMN decisions paired with essential applications for modeling, operations and analytics.
The driver fetches and locks external tasks that can either be completed manually or with a script.

## About

### Version Info

| **Range**            | **Key Features**         | **Based on** | **System Impact** |
|----------------------|--------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | External task completion | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.15.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8080*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

For the external tasks, the topic name and lock duration should be set on the **General** page or on the **External Tasks** \> **Configuration** page.

### Redundancy

There is no redundancy defined.

## How to use

External tasks, with the topic defined with the **External Tasks Topic Name** parameter, will be fetched and locked every minute. They will be requested for locking for the duration defined with the **External Tasks Lock Duration** parameter, for the specified **Worker ID**.

When external tasks are locked, the Automation script defined with the **External Tasks Handler Automation Script** parameter will be launched with their IDs (the key of the external task). Unless the script confirms the handling of the external task, it will be launched again when the time defined in the **External Tasks Relaunch Handler Timeout** parameter has passed since the last launch.

## Notes

### External Tasks Handler Automation Script

The Automation script specified with the **External Tasks Handler Automation Script** parameter requires the following parameters:

- **Worker Element Name**: The name of the Camunda BPMN element that started the script.
- **External Task IDs**: The IDs (table keys) of the external tasks that need handling, separated by semicolons (";").

Example:



       using


       System;
    using


       System.Collections.Generic;

    using


       Newtonsoft.Json;
    using


       Skyline.DataMiner.Automation;

    public


       class


       Script
    {
        public


       static





          void


       Run(Engine engine)
        {
            var workerElement


       = engine.FindElement(engine.GetScriptParam("Worker Element Name").Value);
            var tasksIdsString


       = engine.GetScriptParam("External Task IDs").Value;
            engine.GenerateInformation($"{workerElement?.ElementName} -





             {tasksIdsString}");

            if


       (workerElement


       ==


       null


       || tasksIdsString


       ==


       null)
            {
                engine.ExitFail("Arguments are missing");
                return;
            }

            var externalTaskIds


       = tasksIdsString.Split(';');
            var r


       =


       new


       Random();
            foreach


       (var externalTaskId


       in externalTaskIds)
            {
                var priority


       = r.Next(1,


       8);
                if


       (priority


       <=


       2)
                {
                    // Inform that the external task can't be handled now
                    workerElement.SetParameterByPrimaryKey(107, externalTaskId,


       "/Fail");
                    continue;
                }

                // Confirm that the task will be handled now
                workerElement.SetParameterByPrimaryKey(107, externalTaskId,


       "/Confirm");

                // Complete Task without variables
                // workerElement.SetParameterByPrimaryKey(105, externalTaskId, "/Complete");

                // Complete Task and pass variable `priority`
                var completeCommand


       =


       new


       Dictionary<string,


          object>
                {
                    {


       "action",


       "complete"


       },
                    {


       "variables",


       new


       Dictionary<string,


          object>


       {


       {


       "priority", priority


       }


       }


       }
                };

                workerElement.SetParameterByPrimaryKey(105, externalTaskId, JsonConvert.SerializeObject(completeCommand));
            }
        }
    }
