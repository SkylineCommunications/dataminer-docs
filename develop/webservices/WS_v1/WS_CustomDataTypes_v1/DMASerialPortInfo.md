---
uid: DMASerialPortInfo
---

# DMASerialPortInfo

| Item | Format | Description |
|------|--------|-------------|
| Baudrate    | Integer | The baud rate for the serial port. |
| BusAddress  | String  | The bus address for the serial port. |
| Databits    | Integer | The data bits setting of the serial port. |
| FlowControl | String  | The flow control setting of the serial port: "No", "CTS_RTS", "CTS_DTR", "DSR_RTS", "DSR_DTR", or "XON_XOFF". |
| IPAddress   | String  | The polling IP of the device. |
| IPPort      | Integer | The IP port of the device. |
| LocalIPPort | Integer | The local IP port of the device. |
| Network     | String  | Determines whether the device is accessible through the first or second network interface of the DMA, or if this is automatically selected. |
| Parity      | String  | The parity setting of the serial port: "No", "Even", "Odd", "Mark", or "Space" |
| SerialPort  | String  | The name/number of the serial port. |
| Stopbits    | Double  | The stop bits setting of the serial port. |
| Type        | String  | "Serial", "TCP" or "UDP". |
