# Rewind Protocol - Presentation Plan

## Duration
5 Minutes

---

## 1. Introduction (30 seconds)

- Introduce the game title: Rewind Protocol
- Briefly explain the genre
- Present the core concept:
  - A 2D puzzle-platformer
  - Players cooperate with replayed versions of themselves
  - Inspired by time manipulation and simulation themes

---

## 2. Gameplay Overview (1 minute)

### Core Mechanic

- Player movements are automatically recorded
- Press E to stop recording
- A ghost replays the recorded actions
- The player must cooperate with the ghost to solve puzzles

### Objective

- Reach the exit portal
- Complete all five levels
- Escape the simulation

---

## 3. Level Design Progression (1 minute)

### Level 1
Introduction to recording and replay mechanics.

### Level 2
Introduces platforming and gap traversal.

### Level 3
Introduces timed ghost persistence.

### Level 4
Requires cooperation between player and ghost using dual-button puzzles.

### Level 5
Final challenge combining all previous mechanics.

---

## 4. Design Decisions (45 seconds)

### Visual Design

- Minimalist pixel-art style
- Sci-fi technology theme
- Consistent cyan and dark-blue color palette

### Narrative Design

- Story delivered through system messages
- Intro sequence
- Mid-game warning sequence
- Ending sequence

This approach reinforces the simulation atmosphere while keeping development scope manageable.

---

## 5. Technical Implementation (1 minute)

### Replay System

- Player positions are recorded during gameplay
- Ghosts replay recorded movement paths

### Ghost Management

- Timed ghost persistence
- Automatic expiration and reset logic

### Scene Management

- Main Menu
- Story scenes
- Level transitions
- Ending sequence

### Audio System

- Persistent AudioManager
- Separate Menu, Gameplay, and Ending music

---

## 6. Challenges and Reflection (30 seconds)

### Challenges

- Designing reliable ghost replay behavior
- Managing scene transitions
- Handling level reset logic
- Synchronizing gameplay systems

### Lessons Learned

- Unity scene management
- UI systems
- Audio management
- Puzzle design iteration

---

## 7. Conclusion (15 seconds)

- Rewind Protocol is a complete playable prototype.
- Successfully demonstrates a time-replay puzzle mechanic.
- Future improvements could include additional levels, visual effects, and more complex puzzles.
