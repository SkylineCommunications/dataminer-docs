---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_4.0.0
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi 4.0.0

#### Support for gNMI notifications of which the value is of type BytesVal, ProtoBytes, DecimalVal, FloatVal, or LeaflistVal [ID_38649]

Previously, when the middleware received gNMI notifications with values of type *BytesVal* or *ProtoBytes*, these were flagged as unsupported. Now these will get processed and handed over to consumers of the middleware through a `byte[]`. It is then up to the consumer to process these in the expected way.

In addition, the middleware did not yet support data sent out as *decimalVal*, as *DecimalVal* in combination with *FloatVal* is considered obsolete. However, as it is a consumer library and it is not in control over which data are sent out, support has been added for both *DecimalVal* and *FloatVal*.

Finally, *LeaflistVal* was also not yet supported. This will now be converted into a JSON string representation of the values, similar to how this is done when data is polled and enters as JSON.
