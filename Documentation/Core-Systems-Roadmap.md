# Darkthorn Quest Core Systems Roadmap

This roadmap breaks down core gameplay and engine systems into small, focused phases to build a solid foundation before adding complex roguelike features.

## Phase 1: Engine Foundation

### 1.1 Game State Management
- Create GameState enum (Menu, Playing, Paused, GameOver)
- Implement StateManager service to handle state transitions
- Add state change events for systems to react to
- Wire state manager into GameLifecycle injector pattern

### 1.2 Scene/World Management
- Create Scene interface and base Scene class
- Implement SceneManager to switch between scenes (Menu, Town, Dungeon)
- Add scene lifecycle methods (Load, Unload, Update, Draw)
- Integrate with existing WorldManager

### 1.3 Time Management
- Create TimeService for delta time, game time, paused time
- Add time scaling support (slow motion, fast forward)
- Replace gameTime parameters with TimeService where appropriate

## Phase 2: Core Systems

### 2.1 Audio System
- Create AudioService with SoundEffect and Music support
- Implement audio asset loading and management
- Add volume controls (master, music, SFX)
- Create audio injector for game lifecycle
- Add basic sound effects (footsteps, UI clicks)

### 2.2 Save/Load System
- Design save data structure (player state, world state, settings)
- Implement SaveService using JSON serialization
- Create save file management (slots, auto-save, quick-save)
- Add save/load UI triggers
- Implement settings persistence

### 2.3 Input System Enhancement
- Extend InputSystem to support gamepad
- Create InputAction system for rebinding
- Add input context switching (menu vs gameplay)
- Implement input buffering for combat timing

## Phase 3: Graphics Enhancements

### 3.1 Camera System
- Create Camera2D component with follow target
- Implement camera bounds and clamping
- Add camera effects (shake, zoom, smooth follow)
- Integrate camera into RenderSystem

### 3.2 Animation System
- Create AnimationComponent (spritesheet, frame data)
- Implement AnimationSystem for frame updates
- Add animation states (idle, walk, attack, hurt)
- Support animation blending and transitions

### 3.3 Particle System
- Create ParticleEmitter component
- Implement basic particle physics
- Add particle effects for gameplay feedback
- Integrate with existing ECS

## Phase 4: Basic Gameplay

### 4.1 Collision System
- Create ColliderComponent (box, circle)
- Implement CollisionSystem for spatial queries
- Add collision detection between entities
- Create collision response (solid objects, triggers)

### 4.2 Health & Damage
- Create HealthComponent (current, max, regeneration)
- Implement DamageComponent for attacks
- Add death handling and respawning
- Create damage numbers/feedback

### 4.3 Basic Combat
- Create AttackComponent (damage, cooldown, range)
- Implement AttackSystem for melee attacks
- Add attack input handling and timing
- Create hit detection with collision
- Add basic enemy AI (chase player)

### 4.4 Interaction System
- Create InteractableComponent for objects
- Implement InteractionSystem for player interaction
- Add interaction prompts and UI
- Support doors, chests, NPCs

## Phase 5: UI Foundation

### 5.1 UI Framework
- Choose/create UI system (MonoGame.Extended.UI or custom)
- Create basic UI components (Button, Panel, Text)
- Implement UI scene layer
- Add UI input handling

### 5.2 HUD
- Create health bar display
- Add minimap placeholder
- Implement quick slot display
- Add status effects display

### 5.3 Menus
- Create main menu
- Implement pause menu
- Add settings menu (audio, graphics, controls)
- Create game over screen

## Implementation Notes

**Priority Order**: Complete each phase before moving to the next. Each phase builds on the previous.

**Testing Focus**: After each system, create a simple test scene to verify it works before continuing.

**File Organization**: Keep systems in their respective folders (Engine/Services, Game.World/Systems, Game.World/Components).

**Injector Pattern**: Continue using the existing injector pattern for integrating new systems into GameLifecycle.

**Small Wins**: Each subsection should be completable in 1-2 focused sessions to maintain momentum.
