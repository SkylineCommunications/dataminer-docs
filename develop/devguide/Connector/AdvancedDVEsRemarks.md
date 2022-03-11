---
uid: AdvancedDVEsRemarks
---

# Remarks

- A table from which you want to export everything should also contain a link.
- By default, the elements that are created are stored under the same view as the main element.
- The name of the element consists of the parent element name.Displaykey of the table. It is also possible to leave out the parent name.
- The positions of the parameters are defined by specifying positions on the column parameters. When there is an alarm on the virtual element, the parent element will not go into alarm.
- Alarm templates and trend templates can be defined on the main element but also on the virtual elements.
- The display column of a table exported to DVEs needs to be unique in the main element, otherwise duplicate alarms can be generated when the element is restarted.
- In case you want to export a table as standalone parameters, the table needs to contain an FK column pointing to the corresponding entry in the main table. (Note that the PK column cannot be reused as FK column.)
- When a column value is exported as a single parameter in a DVE, the alarm on the DVE will be displayed as a standalone parameter.
