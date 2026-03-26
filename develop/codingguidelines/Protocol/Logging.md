---
uid: Logging
---

# Logging

- When logging messages are generated, the QAction ID and method name should be included:

	```txt
	protocol.Log("QA" + protocol.QActionID + "|Method Name|Message", LogType.Error, LogLevel.NoLogging);
	```

- Logging messages that should only be generated when debugging a protocol can be surrounded by preprocessor directives as follows:

	```txt
	#if debug
	protocol.Log("QA" + protocol.QActionID + "|Method Name|Message", LogType.Error, LogLevel.NoLogging);
	#endif
	```

- Only implement logging when required, e.g., logging exceptions.
