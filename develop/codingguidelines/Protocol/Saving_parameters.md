---
uid: Saving_parameters
---

# Saving parameters

To make sure your on-premises databases remain in good shape and do not get cluttered with unnecessary data, or to ensure a cost-efficient solution in case you make use of Storage as a Service, it is important to avoid storing unnecessary data. As a consequence, parameters must only be saved when this is really necessary.

Here are some things you can do to make sure no more data is saved than necessary:

- Only add a [save](xref:Protocol.Params.Param-save) attribute to a parameter if it is really necessary.

- If you know a parameter will change frequently, but it definitely needs to be saved, specify a [saveInterval](xref:Protocol.Params.Param-saveInterval) attribute.

- By default, the keys of a table are saved. Avoid fully cleaning and repopulating a table when updating values.

- Consider using a [volatile table](xref:AdvancedDataMinerDataPersistencePersistingTables#volatile-tables). Table that do not contain any monitored parameters could be a good fit for this.
