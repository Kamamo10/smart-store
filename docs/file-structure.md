# Smart Store プロジェクト ファイル構成とファイルの役割

## プロジェクト概要

Smart Store は Azure ベースのマイクロサービス アーキテクチャを採用した小売店舗向けサンプル アプリケーションです。以下の主要コンポーネントで構成されています。

## ルートディレクトリ構成

```
smart-store/
├── LICENSE                    # MITライセンス
├── README.md                  # プロジェクト概要とセットアップガイド
├── CLAUDE.md                  # Claude Code 用の開発ガイダンス
├── docs/                      # プロジェクトドキュメント
└── src/                       # ソースコード
```

## docs/ ディレクトリ

### API定義ファイル (`docs/api/`)
- `README.md` - API定義ファイルの利用方法
- `box-service-api.yaml` - Box管理サービス OpenAPI定義
- `item-master-api.yaml` - 商品マスタサービス OpenAPI定義  
- `pos-service-api.yaml` - POSサービス OpenAPI定義
- `stock-command-api.yaml` - 在庫更新API OpenAPI定義
- `stock-query-api.yaml` - 在庫照会API OpenAPI定義

### サービス別ドキュメント
- `appcenter.md` - App Centerでのプッシュ通知環境構築手順
- `box-service.md` - Box管理サービスの概要
- `client-app.md` - クライアントアプリの概要
- `item-master.md` - 統合商品マスタの概要
- `operation-check.md` - 動作確認手順
- `pos-service.md` - POSサービスの概要
- `stock-service.md` - 在庫管理サービスの概要

### 画像ファイル (`docs/images/`)
システム構成図、シーケンス図、App Center設定画面のスクリーンショットなど

## src/ ディレクトリ

### ARM Template (`src/arm-template/`)

#### デプロイメント設定
- `template.json` - Azure リソースのARMテンプレート（主設定）
- `parameters.json` - ARMテンプレートのパラメータ設定
- `provision.ps1` - Windows用プロビジョニングスクリプト
- `provision.sh` - Linux用プロビジョニングスクリプト
- `README.md` - デプロイメント手順詳細

#### サービス別ARMテンプレート
- `common-template.json` - 共通リソース定義
- `box-service-template.json` - Box管理サービス用リソース
- `item-service-template.json` - 商品マスタサービス用リソース
- `pos-service-template.json` - POSサービス用リソース
- `stock-service-template.json` - 在庫管理サービス用リソース

#### サンプルデータ (`src/arm-template/sample-data/public/`)
- `box-service/` - Box管理用マスタデータ（SKU、端末情報）
- `item-service/` - 商品マスタサンプルデータとテスト画像 
- `pos-service/` - POSマスタデータ

#### SQL初期化
- `createStocksInStockBackend.sql` - 在庫管理用SQLデータベース初期化スクリプト

### Box管理サービス (`src/box-service/`)

#### プロジェクト構成
- `BoxManagementService.sln` - Visual Studio ソリューションファイル
- `README.md` - Box管理サービスの概要とAPI一覧

#### Azure Functions プロジェクト (`BoxManagementService/`)
- `BoxManagementService.csproj` - プロジェクトファイル（.NET Core 2.1）
- `host.json` - Azure Functions ホスト設定
- `local.settings.example.json` - ローカル開発用設定例

#### 主要ソースファイル
- `BoxManagementServiceFunctions.cs` - Box管理API実装
- `DeviceFunctions.cs` - デバイス管理機能
- `ActionResultFactory.cs` - API レスポンス生成
- `BoxResponseFactory.cs` - Box用レスポンス生成

#### データアクセス層 (`Models/`)
- `Repositories/CosmosDB/` - Cosmos DB アクセスクラス
  - `BoxRepository.cs` - Boxデータアクセス
  - `SkuRepository.cs` - SKUデータアクセス
  - `StockRepository.cs` - 在庫データアクセス
  - `TerminalRepository.cs` - 端末データアクセス
- `Repositories/Http/` - HTTP API アクセスクラス
  - `CartRepository.cs` - カートAPI呼び出し
  - `UserRepository.cs` - ユーザー情報取得

#### ユーティリティ (`Utilities/`)
- `Settings.cs` - 設定値管理
- `HttpRequestUtility.cs` - HTTP リクエスト処理
- `NotificationUtility.cs` - プッシュ通知処理
- `BoxUtility.cs` - Box関連ユーティリティ
- `StaticHttpClient.cs` - HTTPクライアント管理

### POS サービス (`src/pos-service/`)

#### プロジェクト構成  
- `PosService.sln` - Visual Studio ソリューションファイル
- `README.md` - POSサービスの概要とAPI一覧

#### Azure Functions プロジェクト (`PosService/`)
- `POSService.csproj` - プロジェクトファイル（.NET Core 2.1）
- `host.json` - Azure Functions ホスト設定
- `local.settings.example.json` - ローカル開発用設定例

#### 主要ソースファイル
- `Functions.cs` - POS API実装
- `PosLogic.cs` - POSビジネスロジック実装
- `IPosLogic.cs` - POSロジックインターフェース
- `Errors.cs` - エラー定義

#### データ契約 (`DataContracts/`)
- `Pos/Parameters/` - POS API リクエストパラメータ
- `Pos/Responses/` - POS API レスポンス
- `Items/` - 商品関連データ契約
- `Stocks/` - 在庫関連データ契約

#### データアクセス層 (`Models/`)
- `Documents/` - Cosmos DB ドキュメントクラス
- `Repositories/CosmosDB/` - Cosmos DB アクセス
- `Repositories/Http/` - 外部API アクセス

#### 定数定義 (`Constants/`)
- `CartStatus.cs` - カート状態定数
- `CounterType.cs` - カウンター種別
- `StockAllocationType.cs` - 在庫割当種別
- `TaxType.cs` - 税種別
- `TransactionType.cs` - 取引種別

### 商品マスタサービス (`src/item-service/`)

#### プロジェクト構成
- `ItemService.sln` - Visual Studio ソリューションファイル  
- `README.md` - 商品マスタサービスの概要

#### Azure Functions プロジェクト (`ItemService.ItemMaster/`)
- `ItemService.ItemMaster.csproj` - プロジェクトファイル
- `host.json` - Azure Functions ホスト設定
- `local.settings.example.json` - ローカル開発用設定例
- `ItemFunction.cs` - 商品情報取得API実装

#### データモデル (`Models/`)
- `ItemDocument.cs` - 商品ドキュメント
- `MdHierarchy.cs` - 商品階層情報
- `Tax.cs` - 税情報

### 在庫管理サービス (`src/stock-service/`)

#### プロジェクト構成
- `StockService.sln` - Visual Studio ソリューションファイル
- `README.md` - 在庫管理サービス概要（CQRS パターン説明）

#### 共通ライブラリ (`StockService.Core/`)
- `StockService.Core.csproj` - コアライブラリプロジェクト
- `StockDbContext.cs` - Entity Framework DB コンテキスト
- `TransactionType.cs` - 取引種別定義
- `Documents/StockDocument.cs` - Cosmos DB 在庫ドキュメント
- `Entities/StockEntity.cs` - SQL DB 在庫エンティティ

#### 在庫更新API (`StockService.StockCommand/`)
- `StockService.StockCommand.csproj` - プロジェクトファイル
- `CommandFunction.cs` - 在庫更新API実装（CQRS Command側）
- `host.json` - Azure Functions ホスト設定
- `local.settings.example.json` - 設定例

#### 在庫同期処理 (`StockService.StockProcessor/`)
- `StockService.StockProcessor.csproj` - プロジェクトファイル
- `ChangeFeedFunction.cs` - Cosmos DB Change Feed処理
- Cosmos DB から SQL DB への準リアルタイム同期

#### 在庫照会API (`StockService.StockQuery/`)
- `StockService.StockQuery.csproj` - プロジェクトファイル  
- `QueryFunction.cs` - 在庫照会API実装（CQRS Query側）
- SQL DBから高速な在庫照会を提供

### クライアント サービス (`src/client-service/`)

#### BFF (Backend for Frontend) (`ClientService.BoxAdminBff/`)
- `ClientService.sln` - Visual Studio ソリューションファイル
- `ClientService.BoxAdminBff.csproj` - プロジェクトファイル
- `SignalRFunction.cs` - リアルタイム通信機能
- `StockFunction.cs` - 在庫管理機能
- `host.json` - Azure Functions ホスト設定
- `local.settings.example.json` - 設定例

### モバイル クライアント アプリ (`src/client-app/`)

#### プロジェクト構成
- `README.md` - クライアントアプリ詳細（ビルド手順、App Center設定）

#### Xamarin.Forms ソリューション (`SmartRetailApp/`)
- `SmartRetailApp.sln` - Visual Studio ソリューションファイル

#### 共通ライブラリ (`SmartRetailApp/SmartRetailApp/`)
- `SmartRetailApp.csproj` - 共通ライブラリプロジェクト（.NET Standard 2.0）
- `App.xaml` / `App.xaml.cs` - アプリケーション エントリポイント

#### XAML ページ (`Views/`)
- `LoginPage.xaml` - ログイン画面
- `RegisterPage.xaml` - 登録画面
- `ThankPage.xaml` - 完了画面

#### データモデル (`Models/`)
- `Constant.cs` - API エンドポイント、App Center キー設定
- `CartStart.cs` - カート開始データ
- `CartStartResult.cs` - カート開始結果
- `CartStatus.cs` - カート状態

#### サービス (`Services/`)
- `CartApiService.cs` - カートAPI呼び出し
- `IQrScanningService.cs` - QRコードスキャンインターフェース

#### Android プロジェクト (`SmartRetailApp.Android/`)
- `SmartRetailApp.Android.csproj` - Androidプロジェクト
- `MainActivity.cs` - メインアクティビティ
- `google-services.json` - Firebase設定（プッシュ通知用）
- `appcenter-pre-build.sh` - App Center ビルド前処理
- `Services/QrScanningService.cs` - Android用QRスキャン実装

#### iOS プロジェクト (`SmartRetailApp.iOS/`)
- `SmartRetailApp.iOS.csproj` - iOSプロジェクト
- `AppDelegate.cs` - アプリケーション デリゲート
- `Services/QrScanningService.cs` - iOS用QRスキャン実装

## 設定ファイルの役割

### Azure Functions 設定
- `host.json` - Functions ランタイム設定（バージョン、拡張機能など）
- `local.settings.example.json` - ローカル開発用環境変数設定例
  - Cosmos DB接続文字列
  - IoT Hub接続文字列  
  - 外部API認証キー
  - 通知サービス設定

### Azure リソース設定
- ARM テンプレートによるInfrastructure as Code
- パラメータファイルでの環境別設定分離
- プロビジョニングスクリプトによる自動構築

### モバイルアプリ設定  
- `Constant.cs` - API エンドポイントとキー管理
- `google-services.json` - Firebase プッシュ通知設定
- App Center による継続的インテグレーション設定

## 開発フロー

1. **インフラ構築**: ARM テンプレートでAzureリソース展開
2. **データ準備**: プロビジョニングスクリプトでマスタデータ投入
3. **API開発**: Visual Studio で各サービス開発・デプロイ
4. **アプリ開発**: Xamarin で モバイルアプリ開発
5. **テスト**: Swagger UI でAPI動作確認
6. **配信**: App Center でアプリ配信

このファイル構成により、マイクロサービス アーキテクチャの各コンポーネントが疎結合で開発・運用できる構造となっています。