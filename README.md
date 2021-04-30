# DotNetBaseSample
Template to get started with a simple .NET 5 API including CQRS and event-based models.

Src has been split into several projects:
 - **Api**: Api entry point containing controllers and configurations.
 - **Components**: Business logic implementations.
 - **Events**: Event models.
 - **DataModel**: Database context containing all data models.
 - **Infrastructure**: Infrastructure to be used in the application.

## Api
Api is the entry point of the application.
All endpoints for the API can be found here as well as the configurations of the application.

API uses mediator to send commands and queries to their handlers.

It might also publish events to one or more handlers.

## Components
Components contain the business logic. These have been split into handlers like query handlers (for getting data), command handlers (for changing data), and event handlers (for handling events).

Handlers expect a request and return a result. Where requests are verified via a validator.

Query- and command handlers are async and return a result. A query and command can only be handled by one handler.

Event handlers are async as well but don't return a result. The reason for the no result is that an event can be handled in multiple places (without knowing the order).

## Events
All event models to be used in event handlers. All events are immutable and often only the reference is used in the model.
The naming of the models is in past tense because an event usually defines something that has happened or has been triggered.

The reason this is abstracted into its project is that it might be needed for other projects that don't need to know about the business logic or anything else (e.g. notification service, logging service, etc.).

## DataModel
DataModel contains all the database models with data migrations. In case a model changes or a new model is introduced a new migration must be generated and later applied to a database.

Some helper functions as `BaseModel.cs` and `BaseModelContextExtensions.cs` have been added to generalize tables with UUID id as primary key and Datetime created date in UTC.

Other helper functions as `BaseModelEnum.cs` and `BaseModelEnumContextExtensions.cs` have been added to generalize reference tables containing only int id and string name. Where id is the enum value and name is the string representation of the enum.
Also, it makes sure to populate the enum values into the table once created.

`DatabaseContext.cs` contain all the models and makes sure that an event is published once executing `SaveChangesAsync`.

## Infrastructure
Infrastructure contains configuration and helper functions to from the API implementations.
It makes it way easier to read `Startup.cs` when every addition is referred to as a function. Also it makes it a lot easier to set up multiple projects within the solution.

The reason this is a project in the solution and not a Nuget dependency is that it becomes a lot more transparent and possible to change in case it's needed.
