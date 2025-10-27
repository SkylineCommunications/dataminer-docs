---
uid: Skyline_DataMiner_DataSources_OpenConfig_1.0.2
---

# Skyline DataMiner DataSources OpenConfig 1.0.2

## New features

#### Support for setting additional value types [ID 37017]

Up to now, in the Skyline.DataMiner.DataSources.OpenConfig.Gnmi, the GnmiClient was only able to perform a set with a string value type. Now new *Set* methods have been added that accept the value types bool, double, long, and ulong.

In addition, another *Set* method has been added that accepts a string value type as well as a *StringValueContentType* enumeration identifying what the string value represents: *AsciiString*, *JsonUtf8*, *JsonIetfUtf8*, or *StringValue* (which is equal to omitting the *StringValueContentType* when passing a string value).

Finally, the parsing of the string as path has also been improved. The key value can contain a slash or backslash. When the key value contains a single quotation mark, this can be indicated by adding two single quotation marks. For example, a string path with value "Ether'net1/2" for the "name" key can be written as `interfaces/interface[name='Ether''net/1/2']/config/enabled`.

#### Ability to verify previous rate value [ID 37021]

In the Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol library, the following new members have been added to the DataMinerConnectorRateArgs of the DataMapper:

- *PreviousRateValue*
- *PreviousRateTimestampUtc*

These allow you to verify what the previous result was when using the rate calculator.

When the rate calculator is called for the first time, *PreviousRateValue* will be null, and *PreviousRateTimestampUtc* will be *DateTime.MinValue*.
