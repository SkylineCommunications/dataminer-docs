---
uid: AutomationActionLog
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
