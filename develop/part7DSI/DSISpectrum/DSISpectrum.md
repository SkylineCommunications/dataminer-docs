---
uid: DSISpectrum
---

# Spectrum analyzer

DataMiner allows the monitoring and controlling of spectrum analyzer devices.

To obtain a spectrum analyzer UI, specify *type="Spectrum Analyzer"* in the *Display* tag.

```xml
<Display defaultPage="Main View" type="Spectrum Analyzer"/>
```

Internal parameters, starting from ID 64000, are used to control specific spectrum analyzer functions like number of trace points, video bandwidth filter and resolution bandwidth filter.

> [!NOTE]
> Monitors allow you to generate parameters from scripts. These use 50000 as starting parameter ID. You should avoid using the 50000 range for your parameters in a protocol.

In this section:

- [Internal spectrum parameters](xref:Internal_spectrum_parameters)

- [RBW and VBW units](xref:RBW_and_VBW_units)

- [Implementation routine](xref:Implementation_routine)

> [!TIP]
> See also:
> DataMiner Protocol Markup Language:<br> -  Protocol.Display [type](xref:MARProtocolDisplay#type)
>
