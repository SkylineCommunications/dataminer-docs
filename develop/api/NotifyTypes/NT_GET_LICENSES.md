---
uid: NT_GET_LICENSES
---

# NT_GET_LICENSES (154)

Retrieves license information.

```csharp
string[] licenses = (string[]) protocol.NotifyDataMiner(154, null, null);

foreach (string item in licenses)
{
   ////...
}
```

## Return Value

- (string[]) License information.

Example output:

```
DATAMINER
AUTOMATION
CORRELATION
REPORTS
SPECTRUM
MAPS
ASSETMANAGER
MOBILE GATEWAY
MOBILE
MOBILEEXT
RESOURCEMANAGER
SERVICEMANAGER
TICKETING
ELEMENTS1000
SCHEDULER
COBRANDING1
PROVIDER|NAME|Skyline - DataMiner
PROVIDER|COMPANY|NAME|Skyline Communications N.V.
PROVIDER|PRODUCT|NAME|DataMiner
PROVIDER|WWW|www.skyline.be
PROVIDER|COMPANY|EMAIL|info@skyline.be
PROVIDER|TECHSUPPORTNAME|DataMiner Technical Support
PROVIDER|TECHSUPPORTADDRESSLINE1|Ambachtenstraat 33
PROVIDER|TECHSUPPORTADDRESSLINE2|B-8870 Izegem
PROVIDER|TECHSUPPORTADDRESSLINE3|Belgium
PROVIDER|TECHSUPPORTWWW|www.skyline.be/Contact/TechnicalSupport.htm
PROVIDER|TECHSUPPORTEMAIL|support@dataminer.services
PROVIDER|EXTRANETWWW|dataminer.services
PROVIDER|ONLINECOLLABORATIONWWW|www.skyline.be/meeting.exe
PROVIDER|LICENSINGEMAIL|dataminer.licensing@skyline.be
PROVIDER|POWEREDBYVISIBLE|True
PROVIDER|POWEREDBYABOUTVISIBLE|True
PROVIDER|DATAMINERLOGOVISIBLE|True
MAC1:F8-BC-12-94-3D-B0
LastLicenseCheck:16_11_2017_11_04_29
VerificationMethod:DataMiner.lic
ExpirationData: UNLIMITED
```

## Remarks

- The number of licensed elements mentioned in the license info is the number of active elements.
