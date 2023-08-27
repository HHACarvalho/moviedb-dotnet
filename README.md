# MovieDB ASP.NET Core API

REST API built with ASP.NET Core

# Routes

## Movie

### Create movie - http://localhost:4000/movie - POST

Adds a new movie to the database.

**Body:**

```json
{
    "title": "The Lord of the Rings: The Fellowship of the Ring",
    "director": "Peter Jackson",
    "year": 2001
}
```

### Find one movie - http://localhost:4000/movie - GET

Retrieves a single movie.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| id        | 9eea2d93-ff5c-4439-a2c8-9cccf10323f9 |

### Find movies - http://localhost:4000/movie - GET

Retrieves a list of movies whose names include the value of the 'title' parameter.

**Parameters:**

| Parameter    | Value |
|:-------------|:------|
| title        | Rings |

### Find all movies - http://localhost:4000/movie/all - GET

Retrieves a list of all movies, or a sublist if both parameters are provided.

**Parameters:**

| Parameter  | Value |
|:-----------|:------|
| pageNumber | 1     |
| pageSize   | 20    |

### Update movie - http://localhost:4000/movie - PUT

Updates an existing movie.

**Body:**

```json
{
    "title": "The Lord of the Rings: The Return of the King",
    "director": "Peter Jackson",
    "year": 2003
}
```

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| id        | 9eea2d93-ff5c-4439-a2c8-9cccf10323f9 |

### Delete movie - http://localhost:4000/movie - DELETE

Deletes a movie from the database.

**Parameters:**

| Parameter | Value                                |
|:----------|:-------------------------------------|
| id        | 9eea2d93-ff5c-4439-a2c8-9cccf10323f9 |

---
