# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

This is a Smart Store sample application implementing a retail reference architecture with the following microservices:

- **Item Service** (`/src/item-service`): Integrated product master service
- **Stock Service** (`/src/stock-service`): Inventory management with CQRS pattern
- **Box Service** (`/src/box-service`): Smart box management service
- **POS Service** (`/src/pos-service`): Point of sale transaction service
- **Client App** (`/src/client-app`): Xamarin mobile client application
- **Client Service** (`/src/client-service`): Box admin BFF service

## Architecture

The system uses:
- **Azure Functions** for microservice APIs (C#, .NET Core 2.1)
- **Azure Cosmos DB** for document storage (NoSQL)
- **Azure SQL Database** for relational data (stock queries)
- **Xamarin.Forms** for cross-platform mobile client
- **CQRS pattern** in stock service (separate command/query sides)
- **ARM templates** for infrastructure as code

## Development Commands

### Build and Deploy
```bash
# Deploy Azure infrastructure
./src/arm-template/provision.ps1  # Windows
./src/arm-template/provision.sh   # Linux

# Build Azure Functions projects
dotnet build src/box-service/BoxManagementService.sln
dotnet build src/pos-service/PosService.sln
dotnet build src/item-service/ItemService.sln
dotnet build src/stock-service/StockService.sln
```

### Testing
Use Swagger UI for API testing with the following definition files:
- Item Master API: `/docs/api/item-master-api.yaml`
- Stock Command API: `/docs/api/stock-command-api.yaml`
- Stock Query API: `/docs/api/stock-query-api.yaml`
- POS Service API: `/docs/api/pos-service-api.yaml`
- Box Service API: `/docs/api/box-service-api.yaml`

### Mobile App Development
```bash
# Build Xamarin solution
cd src/client-app/SmartRetailApp
# Use Visual Studio or Visual Studio for Mac for Xamarin development
```

## Key Implementation Details

### Stock Service CQRS Pattern
- **StockCommand**: Handles write operations to Cosmos DB
- **StockProcessor**: Uses Cosmos DB Change Feed to sync data to SQL DB
- **StockQuery**: Handles read operations from SQL DB

### Authentication
Azure Functions use API keys for authentication. Keys are configured per function app and shared across the microservices.

### Configuration
Each service has `local.settings.example.json` showing required configuration. Production settings are managed through Azure Function App Settings.

### Data Flow
1. Mobile client scans QR codes and interacts with Box Service
2. Box Service communicates with POS Service for transactions
3. POS Service updates inventory through Stock Service
4. Item Service provides product master data
5. All services use Cosmos DB for persistence (except stock queries use SQL DB)

## Common Issues

- Ensure Azure CLI IoT extension is installed: `az extension add --name azure-cli-iot-ext`
- Data migration tool (`dt` command) is Windows-only for Cosmos DB data loading
- Mobile app requires App Center configuration for push notifications
- Function apps need cross-service API keys configured in Application Settings

## File Structure Notes

- ARM templates in `/src/arm-template/` with sample data in `sample-data/`
- Each service has its own solution file (`.sln`)
- API documentation in `/docs/api/` with OpenAPI YAML definitions
- Service-specific documentation in `/docs/` directory