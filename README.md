# Mini-Tower-Defence-Prototype
A Mini Tower Defense game prototype made in Unity. Built with a focus on data-driven design using Scriptable Objects and clean, modular code.
Of course. Here is a complete, professional README.md file that covers everything we've built. You can copy this text, paste it into a file named README.md in your project's main folder, and it will be ready for submission.

Markdown

# Gritstorm - Tower Defense Prototype

This project is a small tower defense game prototype created for a technical assessment. The focus is on demonstrating a clean, scalable, and data-driven code architecture within the Unity engine.

## Key Features
* **Dynamic Wave Spawning:** A robust system that spawns enemies in waves, with the ability to define waves as either sequential or a random mix of units.
* **Data-Driven Enemies & Towers:** Multiple enemy and tower types with unique stats (health, speed, damage, cost, etc.), all defined through data assets.
* **Player Building System:** A complete gameplay loop where players earn currency by defeating enemies and spend it to build new towers on predefined spots.
* **Functional UI:** A complete user interface including a Main Menu, an in-game shop, real-time display of currency, wave count, and base health, and clear win/loss screens.
* **Complete Game Loop:** The game features a multi-wave progression system, a clear win condition (surviving all waves), a lose condition (base destroyed), and a restart function.

## Architecture and Design Patterns

The project was built with a strong emphasis on creating a clean, modular, and extensible codebase.

### Data-Driven Design with Scriptable Objects
The core of the architecture relies on Scriptable Objects. All defining characteristics of game entities—such as `TowerData`, `EnemyData`, and `WaveData`—are stored as assets in the project. This decouples the game's balance and content from its core logic, allowing designers to create, modify, and balance new units without writing any new code.

### Manager Singletons
Global systems are managed by a few key singleton classes:
* **`GameManager`:** Acts as the central brain for the game loop, controlling wave progression, tracking game state (win/loss, currency), and managing the economy.
* **`UIManager`:** Handles all UI updates and interactions, such as displaying currency, showing/hiding panels, and updating health bars.
* **`BuildManager`:** Manages the logic of purchasing and placing towers, acting as the bridge between the UI Shop and the in-game `TowerSpot`s.

### Event-Driven Communication
To maintain low coupling between systems, communication is handled primarily through C# `event`s and `Action`s.
* The `GameManager` broadcasts an `OnCurrencyChanged` event, which the `UIManager` subscribes to. This means the `GameManager` doesn't need a direct reference to the `UIManager`, making the systems highly modular.
* Similarly, the `PlayerBase` broadcasts an `OnHealthChanged` event.

### Component-Based Architecture (Single Responsibility Principle)
Following Unity's philosophy, logic is broken down into small, focused components. For example:
* **`EnemyMovement`:** Is only responsible for moving an enemy along a path.
* **`Tower`:** Is only responsible for its own targeting and firing logic.
* **`Shop`:** Is only responsible for handling UI button clicks for purchases.

## How to Run the Project
1. Clone or download the repository.
2. Open the project in Unity Hub using **Unity version 6000.2.1f1**.
3. Open the `MainMenu` scene located in `Assets/_Project/Scenes`.
4. Press the Play button.

## How to Add New Content

### Adding a New Tower
1. Create a 3D model and save it as a prefab. Attach the `Tower.cs` script and an `AudioSource` component to its root.
2. In the Project, right-click and go to `Create -> Data -> Tower`. This creates a new `TowerData` asset.
3. Configure the new `TowerData` asset with its `Name`, `Cost`, `Damage`, etc., and link the new prefab to the `Tower Prefab` slot.
4. Open the `Shop.cs` script. Add a new `[SerializeField]` for the new `TowerData` and a new public method `BuyNewTower()`.
5. In the UI, add a new button to the `ShopPanel` and connect its `OnClick()` event to the new `Shop.BuyNewTower()` method.

### Adding a New Enemy
1. Create an enemy model, rig it, animate it, and save it as a prefab. Attach the `Enemy.cs` and `EnemyMovement.cs` scripts.
2. In the Project, right-click and go to `Create -> Data -> Enemy`. This creates a new `EnemyData` asset.
3. Configure the new `EnemyData` asset with its `Health`, `Speed`, `Kill Reward`, etc.
4. On the new enemy prefab, link the new `EnemyData` asset to the `Enemy (Script)` component.
5. To add it to a wave, select a `WaveData` asset, add a new `Wave Step`, and link the new enemy prefab.

## Known Limitations
* The UI is functional but visually basic.
* Enemy pathfinding is limited to a single, predefined path.
* There is no system for selling or upgrading existing towers.
* Tower targeting AI is simple ("first enemy in range") and could be expanded.
