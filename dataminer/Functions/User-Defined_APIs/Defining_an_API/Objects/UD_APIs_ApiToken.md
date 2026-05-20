---
uid: UD_APIs_Objects_ApiToken
---
# ApiToken object

An `ApiToken` is an object that defines which secret string can be used to access an API.

## Properties

The table below lists the properties of the `ApiToken` object. For each property, it also indicates whether the property can be used for filtering using the `ApiTokenExposers`.

|Property       |Type       |Filterable |Description|
|---------------|-----------|-----------|-----------|
|ID             |ApiTokenId |Yes        |The ID of the `ApiToken`.|
|Name           |string     |Yes        |A name that makes the token recognizable. Must be filled in.|
|Secret         |string     |No         |The secret string that will be linked to the token. See [Secret](#secret).|
|IsDisabled     |bool       |Yes        |You can set this property to true to revoke the token and disable the access. Setting this back to false will re-enable the token.|
|CreatedBy      |string     |Yes        |The name of the user who created the token.|
|CreatedAt      |DateTime   |Yes        |The UTC date and time when the token was created.|
|LastModifiedBy |string     |Yes        |The name of the last user who modified the token.|
|LastModified   |DateTime   |Yes        |The UTC date and time when the token was last modified.|
|RateLimit      |RateLimit  |No         |Optional rate limit that controls how frequently the token can be used to trigger APIs on a per-endpoint basis. See [RateLimit](#ratelimit). Available from DataMiner 10.6.7/10.7.0 onwards.<!-- RN 44848 -->|

### Secret

When a user wants to call an API, they need to pass a secret string in the header of their request to authenticate. This secret string should be set on a token that is authorized to use that API.

The `Secret` property of an `ApiToken` is **only used to set the secret** for the token. This is done when the token is created, or to update the secret. In all **other cases**, the property should be **empty**.

The secret string is used by API users when they call an API. It has to meet the following requirements:

- It must consist of **at least 32 characters**.
- It must **not be used by any other token**.
- It must not contain any characters other than the following:
  - Lowercase letters: `abcdefghijklmnopqrstuvwxyz`
  - Uppercase letters: `ABCDEFGHIJKLMNOPQRSTUVWXYZ`
  - Digits: `0123456789`
  - The following special characters:
    - Underscore: `_`
    - Hyphen: `-`
    - Period: `.`
    - Equals sign: `=`
    - Plus: `+`
    - Forward slash: `/`

If you do not want to define your own format for the secrets, you can use the built-in secret generator. This will return a 32-character random string that meets all the requirements:

```csharp
var secret = ApiTokenSecretGenerator.GenerateSecret(); 
```

> [!WARNING]
> Once a token has been created with a specific secret, **it is not possible to retrieve that secret again**. The value is stored securely in the database with a non-reversible hashing function. Make sure to save it somewhere secure or pass it to the API user in a secure way.

### RateLimit

From DataMiner 10.6.7/10.7.0 onwards<!-- RN 44848 -->, an `ApiToken` can be configured with a rate limit to control how frequently it can be used to trigger user-defined APIs. This rate is evaluated on a per-endpoint basis.

A rate limit consists of the following properties:

| Property | Type     | Description |
|----------|----------|-------------|
| Limit    | int      | The maximum number of requests allowed within the configured time window. Supported range: 1 to 100. |
| Window   | TimeSpan | The time span during which the configured number of requests are allowed. Supported range: 1 second to 1 day. |

> [!IMPORTANT]
> Currently, rate limits cannot be configured in the UI and must be configured via the C# API. If an API token with a configured rate limit is updated through the UI, the rate limit will be cleared.

#### Behavior when the limit is exceeded

When the rate limit is exceeded, the *UserDefinableApiEndpoint* DxM returns an HTTP 429 *Too Many Requests* response. In this case, the API trigger is not forwarded to SLNet, and the API script is therefore not executed. The response message indicates that the rate limit was exceeded and includes internal error code 1014. See [Errors](xref:UD_APIs_Triggering_an_API#errors).

Every request that can be linked to a token counts toward that token's rate limit, regardless of whether the request results in a successful API script trigger.

#### Sliding window behavior

Rate limiting uses a sliding window. When a request is received, the system checks how many requests were made with the same token during the preceding configured window. If the configured limit has already been reached within that period, the request is blocked.

For example, with a limit of 5 requests per minute, a client using the token can trigger the API up to 5 times within any rolling 1-minute period.

Keep in mind that different limit/window combinations can result in different behavior, even when they allow the same average number of requests. For example:

- If *Limit* is 10 and *Window* 60 seconds, bursts of up to 10 requests are allowed in a short time, after which the client must wait until requests fall outside the 60-second window.
- If *Limit* is 1 and *Window* 6 seconds, requests are spread more evenly, as one new request is allowed every 6 seconds.

> [!NOTE]
>
> - Configuring a high rate limit, such as 100 requests per second, does not guarantee that DataMiner can process that number of API triggers. The actual throughput depends on factors such as API script runtime, server hardware, current system load, the number of Agents in the cluster, and other system-specific conditions.
> - When an existing rate limit is changed, the updated limit is only applied after a next trigger both starts and finishes after the update has been applied. If a long window was configured and the limit has already been reached, the client may need to wait until the window has passed before another trigger can be executed and the updated limit can take effect.

## Requirements

- **Create**: The `Secret` property must contain a secret that meets the requirements mentioned under [Secret](#secret).
- **Update**: When the `Secret` property is updated (non-empty value), the secret must meet the requirements mentioned under [Secret](#secret).
- **Create & Update**: The `Name` property must contain a name (which must not be null or whitespace).
- **Delete**: The `ApiToken` must not be in use by an `ApiDefinition`. This means that there must be no `ApiDefinition` that has the ID of the token that is to be deleted in the `AllowedTokens` property. Before you delete a token, make sure it has been removed from all definitions. If you want to quickly block access, disable the token instead.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `ApiTokenErrors`. Below is a list of all possible `ErrorReasons`. The `Id` property of the `ApiTokenError` object will always contain the ID of the API token that could not be created, updated or deleted.

|Reason            |Description|
|------------------|-----------|
|InvalidName       |The specified name was null or whitespace.|
|InvalidSecret     |The specified secret did not meet the requirements or is already used by another token.|
|TokenInUse        |The token is in use by one or multiple `ApiDefinitions`. The *ApiDefinitionIdLinks* property will contain a list of IDs of the definitions using the token.|
|InvalidRateLimit  |The configured `RateLimit` is invalid. The `Message` property contains an English description of the invalid configuration. Available from DataMiner 10.6.7/10.7.0 onwards.<!-- RN 44848 -->|

## Security

To create, read, update, or delete API tokens, specific user permissions are needed:

- To read or count tokens, you need the user permission [Modules > User-Defined APIs > Tokens > UI available](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--ui-available).
- To create or update tokens, you need the user permission [Modules > User-Defined APIs > Tokens > Add/Edit](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--addedit).
- To delete tokens, you need the user permission [Modules > User-Defined APIs > Tokens > Delete](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--delete).
