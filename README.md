# BookStore WebApi

## Endpoints
GET api/authors  --> shows lists of authors
GET api/authors/{author}/books --> list of books per author
GET api/authors/{author}/books/{book}/{key} --> book details for book {key}

POST api/authors --> creates an author
POST api/authors/{author}/books --> creates a book for an author

DELETE api/authors/{author} --> deletes an author
DELETE api/authors/{author}/books/{key} --> delete a book for an author

### Structure
Domain > domain models for the project
Repositories > only works with the domain models only
Application Services > handling of the business logics. e.g creating authors, get authors - api controllers are invoking application services. App services works with Repositories
DTO - services works with DTO only. Application services don't work with domain models directly. Services returns DTOs to users not the models.
