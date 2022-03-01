---
uid: GetElementNameByPollingIp
---

# GetElementNameByPollingIp

Use this method to request a list of all the elements that poll a specific IP address (element names only).

## Input

| Item       | Format | Description                                   |
|------------|--------|-----------------------------------------------|
| Connection | String | The connection ID. See [Connect](xref:Connect). |
| IP         | String | The IP address                                |

## Output

| Item                             | Format          | Description                                              |
|----------------------------------|-----------------|----------------------------------------------------------|
| GetElementNameByPolling­IpResult | Array of String | The list of elements that poll the specified IP address. |

