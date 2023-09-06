# MovieDB ASP.NET Core API

REST API built with ASP.NET Core

# Commands

### Build the application

```
dotnet build
```

### Run the application

```
dotnet run
```

### Run the tests

```
dotnet test
```

# Routes

Default API url - http://localhost:4000

# Movie

### Create movie - POST /movie

Adds a new movie to the database.

**Requires:** A successful login and a role with sufficient permissions.

**Body:**

```json
{
    "title": "The Lord of the Rings: The Fellowship of the Ring",
    "director": "Peter Jackson",
    "year": 2001
}
```

**Returns:** If successful, the code 201 and a copy of the created movie. Otherwise, the code 400 and an error message.

---

### Find all movies - GET /movie/all?pageNumber&pageSize

Retrieves a list of the lastest 20 movies, or another custom list if both parameters are provided. Default values for *pageNumber* and *pageSize* are 1 and 20, respectively.

**Parameters:**

| Parameter  | Value |
|:-----------|:------|
| pageNumber | 1     |
| pageSize   | 20    |

**Returns:** If successful, the code 200 and a list of movies. Otherwise, the code 404 and an error message.

---

### Find movies - GET /movie/search?movieTitle

Retrieves a list of movies whose names include the value of the 'movieTitle' parameter.

**Parameters:**

| Parameter    | Value |
|:-------------|:------|
| movieTitle   | Rings |

**Return:** If successful, the code 200 and a list of movies. Otherwise, the code 404 and an error message.

---

### Find one movie - GET /movie?movieId

Retrieves a single movie by its ID.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| movieId   | f0000000-b444-b444-b444-f00000000000 |

**Returns:** If successful, the code 200 and a single movie. Otherwise, the code 404 and an error message.

---

### Update movie -  PUT /movie?movieId

Updates an existing movie.

**Requires:** A successful login and a role with sufficient permissions.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| movieId   | f0000000-b444-b444-b444-f00000000000 |

**Body:**

```json
{
    "title": "The Lord of the Rings: The Return of the King",
    "director": "Peter Jackson",
    "year": 2003
}
```

**Returns:** If successful, the code 200 and a copy of the updated movie. Otherwise, the code 404 and an error message.

---

### Delete movie - DELETE /movie?movieId

Deletes a movie from the database.

**Requires:** A successful login and a role with sufficient permissions.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| movieId   | f0000000-b444-b444-b444-f00000000000 |

**Returns:** If successful, the code 200 and a copy of the deleted movie. Otherwise, the code 404 and an error message.

---