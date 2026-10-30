---
uid: PA_User_DOM_Instance
description: "Explore how a user DOM instance uses a fixed behavior definition, supports gateway decisions, and requires completion before the next activity."
---

# User DOM instance

A [user task](xref:PA_Activities#supported-activities) will always generate a user DOM instance. The Process Automation framework will then wait for the user to complete the user DOM instance before going to the next activity of a process instance.

User DOM instances have a fixed behavior definition that cannot be changed.

Similarly to process DOM instances, fields in the container of data from a user DOM instance can also be used as decision criteria for [gateways](xref:PA_Process_Definition#gateway).
