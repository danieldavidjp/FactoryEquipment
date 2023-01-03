# Lego Red Yellow Green Test

This Repository contains the solution for the Red Yellow Green Case Study for Lego

## Dependencies

-  Net 6.0
-  PostgreSQL

## Migrations

For the migration of the DB schema go to the API directory at Services/FactoryEquipmentsAPI and run the following command:

```
dotnet ef database update --context FactoryEquipmentContext
```

## Running the Solution

Run Both the API and Client, if there is a change on the Port where the API is running, this need to be configure on the appsettings.json of the Client.
