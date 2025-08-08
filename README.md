# Chess Engine - Pawn Movement

This project implements chess logic focused on Pawn movement in C#, based on an inherited interface.

## Features

- Standard pawn movement (1 or 2 squares)
- Diagonal capturing
- Move validation with boundaries
- Unit tests using xUnit

## Test Coverage

All tests are under /Chess.Tests and include:

- Valid 1-square and 2-square forward moves for initial position
- Invalid backward and horizontal moves
- Diagonal capturing only if enemy present
- Prevents moving off the board

## How to Run

- Clone the project
- Ensure .NET 8 SDK is installed
- dotnet test
