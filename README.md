# WordFinderChallenge

A console-based word search challenge built in C#. The application dynamically generates a letter matrix and searches for a list of words both horizontally and vertically. This project is designed following clean architecture principles, making it modular, testable, and easy to maintain.

## Features

- Dynamically generates a customizable 64 x 64 matrix filled with words and random characters.
- Searches for a list of predefined words (case-insensitive).
- Reports the number of occurrences of each word found.
- Designed with clean architecture: separation of concerns between domain, application, infrastructure, and presentation layers.
- Includes unit tests using xUnit.

## Project Structure

/WordFinderChallenge
/WordFinderChallenge.Console // Console application (entry point)
/WordFinderChallenge.Application // Core application logic and interfaces
/WordFinderChallenge.Domain // Domain models and business contracts
/WordFinderChallenge.Infrastructure // Matrix generation and service implementations
/WordFinderChallenge.Tests // Unit tests using xUnit

### Layer Responsibilities

- **Domain**: Contains business entities and contracts (e.g., interfaces, models).
- **Application**: Implements core use cases and application-level logic (e.g., word searching).
- **Infrastructure**: Provides external functionalities such as matrix generation or data services.
- **Console**: Acts as the presentation layer (CLI).
- **Tests**: Contains automated unit tests for the application.

## How It Works

1. A predefined list of words is used to generate a random matrix using `MatrixGeneratorHelper`.
2. The matrix is injected into `WordSearchService`, which implements the `IWordSearchService` interface from the Application layer.
3. The service searches for the words horizontally and vertically.
4. Results with counts and the elapsed search time are displayed in the console.

## Example Output

Found words in 3 ms:
COLD: 1
WIND: 1
HEAT: 1
SNOW: 1

## How to Run

dotnet build
dotnet run --project WordFinderChallenge.Console
