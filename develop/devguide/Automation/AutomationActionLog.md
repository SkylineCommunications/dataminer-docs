---
metadata_version: 1
uid: AutomationActionLog
description: "Configure the Log action to write either a predefined message or an automation script variable value to the SLAutomation.txt log file."
---

# Log

Creates a log message that will be saved in the SLAutomation.txt log file.

- To log a predefined message:

    ```xml
    <Exe id="2" type="logmessage">
       <Message>MyLogMessage</Message>
    </Exe>
    ```

- To log the value of a script variable:

    ```xml
    <Exe id="2" type="logmessage">
        <Message ref="param1"></Message>
    </Exe>
    ```
