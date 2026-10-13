# Unity Photo Example

A small Unity project that demonstrates a first-person controller and a simple in-game camera. Move around the sample scene, aim the camera at an object, and take a snapshot that is displayed through a render texture.

## Requirements

- Unity **6000.6.5f1**
- A desktop platform with keyboard and mouse input

The project uses the Universal Render Pipeline (URP) and Unity's Input System package.

## Getting started

1. Clone or download this repository.
2. Open the project with Unity `6000.6.5f1` using Unity Hub.
3. Open `Assets/Scenes/SampleScene.unity` if it is not opened automatically.
4. Press **Play** in the Unity Editor.

`SampleScene.unity` is already configured as the project's build scene.

## Controls

| Action | Keyboard and mouse |
| --- | --- |
| Move | `W` `A` `S` `D` or arrow keys |
| Look around | Move the mouse |
| Take a picture | Left mouse button |
| Aim the camera at the face/object | Hold the right mouse button |
| Reset the camera preview | `R` |

The cursor is locked and hidden while the scene is running. Stop Play mode to restore normal editor control.

## How it works

The scene uses two render textures:

- A live camera render is shown as the camera preview.
- Pressing the picture button renders the picture camera and switches the displayed material to the captured image.
- Pressing `R` switches the material back to the live camera render.

The camera moves between two configured transforms while the right mouse button is held, allowing the player to frame the target before taking a picture.

## Project structure

```text
Assets/
├── InputSystem_Actions.inputactions   Input bindings
├── Scenes/
│   └── SampleScene.unity              Main playable scene
├── Scripts/
│   ├── PlayerController.cs             Movement, gravity, and mouse look
│   └── CCameraControler.cs             Camera aiming and snapshot behavior
├── Settings/                           URP and volume settings
└── Textures/RenderTextures/            Live and captured image targets
Packages/                               Unity package manifest and lock file
ProjectSettings/                        Unity project and build configuration
```

## Extending the example

Input actions are defined in `Assets/InputSystem_Actions.inputactions`. The gameplay scripts currently use the `Move`, `Look`, `Attack`, `GetCamera`, and `RestartCamera` actions. Additional actions can be added in the Input System asset and then consumed by a component in the scene.

To change the scene's behavior, select the relevant objects in `SampleScene` and update the serialized references on `PlayerController` or `CCameraControler` in the Inspector.

## Notes

- The project currently contains one playable sample scene.
- Pictures are displayed in-game through render textures; the example does not save image files to disk.
- Generated Unity folders such as `Library`, `Temp`, and `UserSettings` are local editor data and are not required to open the project.