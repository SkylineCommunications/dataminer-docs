---
uid: Alarming1
---

# Alarming

- By default, all parameters must support alarming, except for parameters used for internal logic, table definition parameters, index parameters, foreign key parameters, etc.

- Make sure no redundant alarms can be set on parameters.

- If applicable, default values should be provided for the different severity levels.

- Do not implement parameters used for the configuration of alarm thresholds just because the user interface of the device provides these. DataMiner can create those values by itself by means of an alarm template.
