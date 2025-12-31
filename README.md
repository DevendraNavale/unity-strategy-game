# unity-strategy-game
Unity strategy game project with unit, base, and combat systems.
# Unity RTS Game Project

# Overview
This project is a simple RTS-style game developed using Unity.  
The player controls units that defend their base while enemy units spawn and attack.  
The goal is to destroy the enemy base while protecting the player base.

# Features
- Player and enemy bases with health system
- Unit movement, enemy detection, and attack logic
- Enemy wave spawning system
- Match flow: Start → Play → Win / Lose
- Simple resource and unit spawning logic

# Tools & Technologies
- Unity 3D
- C#
- Visual Studio
- Git & GitHub

# Project Structure
- `Scripts/Units` – Unit movement and combat logic
- `Scripts/Buildings` – Base health and damage system
- `Scripts/Core` – MatchManager and game state handling
- `Prefabs` – Units, bases, and spawn points

# How to Run
1. Open the project in Unity Hub
2. Load the main scene
3. Press Play
4. Click Start Game to begin the match

# Challenges Faced
- Managing enemy wave spawning timing
- Handling unit and base damage correctly
- Implementing a proper match state system

# Learnings
- Unity game state management
- Script organization and modular design
- Basic RTS-style AI behavior

# Future Improvements
- Add UI for health bars and resources
- Improve unit AI and animations
- Add more unit types and levels
