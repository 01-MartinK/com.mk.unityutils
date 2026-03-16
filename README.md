# Unity Starter Scripts

This repository is a collection of common starter scripts and tools I use across multiple of my Unity projects. It contains various systems, controllers, and utilities designed to speed up prototyping and development.

## Modules

The repository is organized into several folders based on functionality:

*   **3DGridSystem**: A custom grid system that includes A* pathfinding (`AStarPathfinding.cs`), a grid representation (`GridXZ.cs`), and a basic navigation agent (`NavAgent.cs`).
*   **FirstPerson**: First-person player controller scripts, including camera management (`FPSCamera.cs`, `HeadBobController.cs`), character movement (`FirstPersonController.cs`), and basic interaction (`IInteractable.cs`, `Interactor.cs`).
*   **QuickInput**: A simple wrapper around Unity's Input System (`InputManager.cs`) along with predefined input actions (`PlayerControls.inputactions`).
*   **QuickProjectInit**: A highly useful Editor script (`QuickProjectInit.cs`) available under `Tools > Quick Init Project` to quickly generate standard folder structures (Art, Scripts, Prefabs, Audio, etc.) for new projects.
*   **Shaders**: A collection of Shader Graph shaders (e.g., `BuildingGridShader`, `OutlineShader`, `ToonShader`) and related scripts like `Wobble.cs`.
*   **ThirdPerson**: Third-person player controller scripts, including camera management (`CameraController.cs`) and character movement (`ThirdPersonController.cs`).
*   **Topdown**: Top-down or RTS style camera controller (`RTSCamera.cs`).
*   **UI**: Various UI utilities, including a flexible grid layout system (`FlexibleGridLayout.cs`) and modal/modeless window handlers (`ModalHandler.cs`, `ModalWindowPanel.cs`, `ModelessWindow.cs`).

## Miscellaneous Utilities

The root of the repository also contains several standalone utility scripts:

*   **CharacterRandomizer.cs**: A script for randomizing character models and their blend shapes, useful for generating varied NPCs or crowds.
*   **FunctionTimer.cs**: A utility for easily executing a function after a delay.
*   **Mouse3D.cs**: A helper script for dealing with 3D mouse input, such as finding the world position of the mouse cursor.
*   **TimeManager.cs / TimeTickRate.cs**: Scripts to manage in-game time, supporting minute, hour, and day ticks using C# events.

## Usage

You can copy the specific folders or scripts you need into your Unity project's `Assets` folder.
The `QuickProjectInit` tool is especially useful when starting a brand new project to instantly set up a clean folder hierarchy.