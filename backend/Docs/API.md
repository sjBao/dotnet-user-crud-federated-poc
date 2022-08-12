## User CRUD API

### Create User
```
POST localhost:7236/users
```

**Body**
```ts
{
    username: string;
    firstName: string;
    lastName: string;
}
```
**RESPONSE**
```ts
{
    id: GUID;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: UTC;
}
```

### GET USERS
```
GET localhost:7236/users
```
**RESPONSE**
```ts
Array<{
    id: GUID;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: UTC;
}>
```

### GET USER
```
POST localhost:7236/users/:id
```
**RESPONSE**
```ts
{
    id: GUID;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: UTC;
}
```

### UPDATE USER
```
PUT localhost:7236/users/:id
```

**Body**
```ts
{
    username: string;
    firstName: string;
    lastName: string;
}
```
**RESPONSE**
```ts
{
    id: GUID;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: UTC;
}
```

### DELETE USER
```
DELETE localhost:7236/users
```
**RESPONSE**
```ts
{
    id: GUID;
    username: string;
    firstName: string;
    lastName: string;
    dateCreated: UTC;
}
```
