# Rewind Protocol

> Work with your past self to escape a collapsing temporal simulation.

A 2D puzzle-platformer built in Unity where players solve environmental puzzles by collaborating with time-replayed versions of themselves.

---

## Overview

Rewind Protocol is a minimalist sci-fi puzzle platformer centered around a temporal replay mechanic. Players record their actions, create replayed versions of themselves, and cooperate with their past selves to overcome obstacles and solve environmental puzzles.

The game gradually introduces new challenges and combines them into increasingly complex scenarios, encouraging strategic planning, timing, and coordination between the player and their temporal echoes.

---

## Features

- Time replay puzzle mechanics
- Ghost-player cooperation
- Timed ghost persistence system
- Platforming challenges
- Multi-condition button and door puzzles
- Automatic level reset system
- Progressive puzzle difficulty
- Minimalist pixel-art sci-fi aesthetic

---

## Gameplay

The core mechanic of Rewind Protocol revolves around recording and replaying actions.

At the beginning of an attempt, the player's actions are automatically recorded.

After ending a recording:

1. A ghost is created.
2. The ghost replays the recorded movement.
3. The player returns to the starting position.
4. The player and ghost must work together to solve the puzzle.

As the game progresses, additional constraints are introduced, including limited ghost lifetimes and multi-step puzzle interactions.

---

## Level Progression

### Level 1 — Introduction

Introduces the replay mechanic.

Objectives:

- Record movement
- Create a ghost
- Use the ghost to hold a button
- Open a door and reach the exit

Introduced Mechanics:

- Ghost recording
- Ghost replay
- Pressure buttons
- Basic door puzzle

---

### Level 2 — Platforming Challenge

Introduces environmental hazards.

Objectives:

- Jump across gaps
- Avoid falling
- Reach the exit

Introduced Mechanics:

- Platforming
- Respawn system
- Gap traversal

---

### Level 3 — Timed Ghost

Introduces time pressure.

Objectives:

- Complete puzzles before the ghost expires
- Manage limited ghost lifetime

Introduced Mechanics:

- Timed ghost persistence
- Automatic puzzle reset
- Countdown system

---

### Level 4 — Dual-Button Cooperation

Introduces cooperative puzzle solving.

Objectives:

- Use a ghost to hold a pressure button
- Activate a second button as the player
- Open a door requiring two conditions

Introduced Mechanics:

- Dual-button puzzles
- Simultaneous activation requirements
- Ghost-player cooperation

---

### Level 5 — Final Challenge

Combines all previously introduced mechanics.

Objectives:

- Coordinate with a ghost
- Manage time constraints
- Traverse platforming challenges
- Complete a multi-step puzzle sequence

Introduced Mechanics:

- Combined puzzle systems
- Advanced planning and execution
- Final mastery challenge

---

## Controls

| Key | Action |
|-------|--------|
| A / D | Move Left / Right |
| Space | Jump |
| E | End Recording |

Recording begins automatically when a level starts.

---

## Visual Style

Rewind Protocol uses a minimalist sci-fi pixel-art aesthetic.

### Design Goals

- Clean visual readability
- Strong puzzle clarity
- Cold technological atmosphere
- Minimal visual noise

### Color Palette

| Purpose | Color |
|----------|----------|
| Background | #0B1517 |
| Dark Panels | #102328 |
| Interactive Elements | #52B2CD |
| Secondary Highlights | #16749D |
| UI Elements | #CDDCDE |
| Neutral Accents | #8C8C8E |

---

## Technical Details

### Engine

- Unity
- Universal Render Pipeline (URP)

### Programming

- C#

### Tools

- TextMeshPro
- Unity 2D Physics
- Pixel Perfect Camera

### Systems Implemented

- Replay Recording System
- Ghost Playback System
- Timed Ghost Expiration
- Door and Button Interactions
- Level Reset Logic
- Respawn System
- Camera Follow System
- Pixel Perfect Rendering

---

## Development Status

### Current Status

Playable Vertical Slice Complete

### Implemented

- Five playable levels
- Complete puzzle progression
- Ghost replay system
- Timed ghost mechanic
- Cooperative puzzle mechanics
- Platforming challenges
- Pixel-art visual prototype

### Planned Improvements

- Main menu
- Intro story sequence
- Ending sequence
- Sound effects
- Background music
- Visual polish
- Additional bug fixing and balancing

---

## Project Structure

```text
Level 1 → Replay Introduction
        ↓
Level 2 → Platforming Challenge
        ↓
Level 3 → Timed Ghost
        ↓
Level 4 → Dual-Button Cooperation
        ↓
Level 5 → Final Combined Challenge
```

---

## Screenshots

Add gameplay screenshots here.

<img width="1512" height="949" alt="image" src="https://github.com/user-attachments/assets/2cad290d-c791-443e-ba6e-ba2048953140" />

---

## Author

Yixuan Liu

University Game Development Project

2026
