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

## Requirements

- **Create**: The `Secret` property must contain a secret that meets the requirements mentioned under [Secret](#secret).
- **Update**: When the `Secret` property is updated (non-empty value), the secret must meet the requirements mentioned under [Secret](#secret).
- **Create & Update**: The `Name` property must contain a name (which must not be null or whitespace).
- **Delete**: The `ApiToken` must not be in use by an `ApiDefinition`. This means that there must be no `ApiDefinition` that has the ID of the token that is to be deleted in the `AllowedTokens` property. Before you delete a token, make sure it has been removed from all definitions. If you want to quickly block access, disable the token instead.

## Errors

When something goes wrong during the CRUD actions, the `TraceData` can contain one or more `ApiTokenErrors`. Below is a list of all possible `ErrorReasons`. The `Id` property of the `ApiTokenError` object will always contain the ID of the API token that could not be created, updated or deleted.

|Reason        |Description|
|--------------|-----------|
|InvalidName   |The specified name was null or whitespace.|
|InvalidSecret |The specified secret did not meet the requirements or is already used by another token.|
|TokenInUse    |The token is in use by one or multiple `ApiDefinitions`. The *ApiDefinitionIdLinks* property will contain a list of IDs of the definitions using the token.|

## Security

To create, read, update, or delete API tokens, specific user permissions are needed:

- To read or count tokens, you need the user permission [Modules > User-Defined APIs > Tokens > UI available](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--ui-available).
- To create or update tokens, you need the user permission [Modules > User-Defined APIs > Tokens > Add/Edit](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--addedit).
- To delete tokens, you need the user permission [Modules > User-Defined APIs > Tokens > Delete](xref:DataMiner_user_permissions#modules--user-defined-apis--tokens--delete).
