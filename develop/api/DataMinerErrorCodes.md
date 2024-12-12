---
uid: DataMinerErrorCodes
---

# DataMiner error codes

Values are 32-bit values structured as follows:

![DataMiner error code structure](~/develop/images/errorCodeStructure.svg)

- **Sev**: Severity code
  - 00 (0x0) - STATUS_SEVERITY_SUCCESS
  - 01 (0x1) - STATUS_SEVERITY_INFORMATIONAL
  - 10 (0x2) - STATUS_SEVERITY_WARNING
  - 11 (0x3) - STATUS_SEVERITY_ERROR
- **C**: Customer code flag
- **R**: A reserved bit
- **Facility**: Facility code
- **Code**: Facility status code
