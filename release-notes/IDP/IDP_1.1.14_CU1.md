---
uid: IDP_1.1.14_CU1
---

# IDP 1.1.14 CU1

## Fixes

#### Problem when running IDP setup wizard \[ID_30223\]

When the IDP setup wizard was run, it could occur that an error was returned because interactive mode failed. For example:

```txt
Script Failure (IDP_SetupWizardFrontEnd): Last of 2 errors: (Code: 0x80131500) Skyline.DataMiner.Net.Exceptions.DataMinerException: Show UI Failed: 0x800402F5 (Interactive UI can only be used in interactive mode.)
```

#### Problem when reading SNMPv3 elements \[ID_30286\]

It could occur that IDP could not read SNMPv3 elements correctly, which could cause a problem when provisioning elements.
