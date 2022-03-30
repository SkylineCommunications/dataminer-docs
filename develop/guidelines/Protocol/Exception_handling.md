---
uid: Exception_handling
---

# Exception handling

- In case a call is performed that could throw an exception, exception handling must be provided.

- In case a *try* block allocates resources, resource cleanup must be provided in a *finally* block.

    > [!NOTE]
    > The usage of a using clause is preferred.

- When an IDisposable object is used, the object should be declared and instantiated in a using statement. The using statement ensures that the Dispose method is called (whether an exception occurred or not).

    > [!NOTE]
    > The object is read-only and cannot be modified or reassigned.

- Every method serving as an entry point in a QAction should contain exception handling, so that it cannot throw exceptions. This is because otherwise a memory leak can occur in the SLScripting process.

- The ToString method of the exception object should be used when exception-related information is logged (instead of the Message property).

	```txt
	protocol.Log("QA" + protocol.QActionID + "|Method Name|" + e.ToString(), LogType.Error, LogLevel.NoLogging);
	```
