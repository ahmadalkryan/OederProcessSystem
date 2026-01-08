# OederProcessSystem
## Tests: One single piece of code (like a function or a class)
##
 integration tests verify the complete vertical slice of the application:
Ensures business rule enforcement
Scope: Small and isolated

Mocks: Uses fake dependencies


Integration Test
Tests: Multiple components working together

Scope: Larger, includes real dependencies

Mocks: Uses real dependencies (database, files, APIs)

Speed: Slower

Validates exception throwing for invalid input

OrderService (business logic layer)

FileOrderRepository (data access layer)

File System (persistence mechanism)
Test Data: Uses realistic but minimal test data

Error Messages: Validates exception messages

Validates business rules (quantity > 0)

Verifies persistence to file system

Confirms data integrity after retrieval

