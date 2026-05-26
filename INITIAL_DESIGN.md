# Rewind Protocol — Initial Game Design Document

## 1. Overview

Rewind Protocol is a 2D puzzle platformer built in Unity, centered around a time-replay mechanic. Players must solve environmental puzzles by cooperating with recorded versions of their past actions.

The game explores themes of time, causality, and self-cooperation, where progress depends not on individual skill alone, but on planning across multiple time loops.

---

## 2. Core Concept

> You cannot solve the puzzle alone — only by trusting your past actions can you move forward.

The player performs actions within a fixed time window. Once the time expires, the level resets, and a "ghost" version of the player replays the recorded actions. The player must use these past actions to assist their current self in solving puzzles.

---

## 3. Core Mechanics

### 3.1 Time Loop System
- Each level operates in repeated time loops (default: 8 seconds per loop)
- At the end of each loop:
  - The environment resets
  - A ghost replay is created from the player's previous actions
  - The player restarts from the initial position

---

### 3.2 Ghost Replay System
- Ghosts replicate previously recorded player actions
- Ghosts are not controllable
- Maximum number of active ghosts: 2–3 (to limit complexity)
- Ghosts can interact with certain objects (e.g., pressure buttons)

---

### 3.3 State Reset System
At the start of each loop:
- All environmental elements reset (doors, buttons, hazards)
- Player returns to the starting position
- Previously recorded ghosts remain active

---

### 3.4 Interaction Rules
- Ghosts can:
  - Activate pressure buttons
- Ghosts cannot:
  - Trigger one-time events
  - Permanently alter level states

This ensures predictable and manageable puzzle logic.

---

## 4. Gameplay Elements

### 4.1 Player Abilities
- Move left/right
- Jump
- Interact with environment (via collision/triggers)

---

### 4.2 Interactive Objects

#### Pressure Buttons
- Must be held down to activate
- Used to open doors

#### Doors
- Closed by default
- Open only when linked conditions are met

#### Hazards
- Examples: lasers, spikes
- Cause immediate failure/reset of current loop

#### Exit Gate
- The level goal
- Activated when all puzzle conditions are satisfied

---

## 5. Level Design Principles

- Each level introduces one new concept
- Complexity increases gradually
- Solutions require coordination across multiple loops

---

### Example Level Progression

| Level | Concept Introduced |
|------|------------------|
| 1 | Basic time replay |
| 2 | Spatial separation (button + door) |
| 3 | Time optimization |
| 4 | Multiple buttons |
| 5 | Hazards |
| 6 | Combined mechanics |

---

## 6. Visual & Art Direction

### Style
- Pixel art
- Minimalist sci-fi laboratory environment

### Color Palette
- Dark blue/black background #0B1517
- Cyan/blue highlights for interactive elements #CDDCDE #52B2CD #16749D #8C8C8E
- Red/orange for hazards #B3262A 

### Ghost Representation
- Semi-transparent
- Light blue glow
- Visual distinction from the player

---

## 7. User Interface (UI)

### HUD Elements
- Time remaining bar
- Loop counter (e.g., "Loop 2")
- Status messages (e.g., "Recording...", "Replay Active")

---

### Menus
- Main menu
- Pause menu
- Level complete screen
- Failure/reset feedback

---

## 8. Technical Architecture (High-Level)

### Core Systems
- Player Controller
- Time Manager
- Recorder (stores player actions)
- Ghost System (replays recorded actions)
- Level Manager
- UI Manager

---

## 9. Scope & Constraints

### Target Scope
- 6–8 levels
- 1 core mechanic (time replay)
- 3–4 interactive object types
- Fully playable prototype with UI

---

### Constraints
- Single-player only
- No complex AI systems
- Limited number of ghosts to maintain performance and clarity

---

## 10. Development Timeline (10 Weeks)

| Phase | Focus |
|------|------|
| Weeks 1–2 | Unity basics + player movement |
| Weeks 3–4 | Recording & replay system |
| Week 5 | Time loop system |
| Week 6 | Core interactions (buttons, doors) |
| Weeks 7–8 | Level design |
| Week 9 | UI & polish |
| Week 10 | Testing & final presentation |

---

## 11. Learning Objectives

- Implement a time-based state recording and replay system
- Design puzzle mechanics around temporal interaction
- Develop structured game architecture in Unity
- Create a polished, small-scale game experience

---

## 12. Future Extensions (Optional)

- Additional mechanics (moving platforms, dynamic hazards)
- More complex time interactions (delayed triggers, selective memory)
- Expanded level set

---

## 13. Summary

Rewind Protocol is a focused, mechanic-driven puzzle game that emphasizes clarity, design, and technical implementation. By limiting scope and refining a single core system, the project aims to deliver a polished and conceptually strong gameplay experience suitable for both academic evaluation and portfolio presentation.

---
