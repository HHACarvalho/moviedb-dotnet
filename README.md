# MovieDB ASP.NET Core API

REST API built with ASP.NET Core

# Routes

# Movie

### Create movie - http://localhost:4000/movie - POST

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

### Find all movies - http://localhost:4000/movie/all?pageNumber=VALUE&pageSize=VALUE - GET

Retrieves a list of the lastest 20 movies, or another custom list if both parameters are provided. Default values for *pageNumber* and *pageSize* are 1 and 20, respectively.

**Parameters:**

| Parameter  | Value |
|:-----------|:------|
| pageNumber | 1     |
| pageSize   | 20    |

**Returns:** If successful, the code 200 and a list of movies. Otherwise, the code 404 and an error message.

### Find movies - http://localhost:4000/movie?movieTitle=VALUE - GET

Retrieves a list of movies whose names include the value of the 'movieTitle' parameter.

**Parameters:**

| Parameter    | Value |
|:-------------|:------|
| movieTitle   | Rings |

**Return:** If successful, the code 200 and a list of movies. Otherwise, the code 404 and an error message.

### Find one movie - http://localhost:4000/movie?movieId=VALUE - GET

Retrieves a single movie by its ID.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| movieId   | f0000000-b444-b444-b444-f00000000000 |

**Returns:** If successful, the code 200 and a single movie. Otherwise, the code 404 and an error message.

### Update movie - http://localhost:4000/movie?movieId=VALUE - PUT

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

### Delete movie - http://localhost:4000/movie?movieId=VALUE - DELETE

Deletes a movie from the database.

**Requires:** A successful login and a role with sufficient permissions.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| movieId   | f0000000-b444-b444-b444-f00000000000 |

**Returns:** If successful, the code 200 and a copy of the deleted movie. Otherwise, the code 404 and an error message.

---