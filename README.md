# Unity-IR-Architecture
Using interactors and repositories in unity.

**Don't use it, old archive**

Accelerate development for small/middle size games!
Store data in repositories instead of static/singleton (if you use it), and access in interactors.
You can also get access to your data in Editor, using ScriptableObjectInteractor!

IR can save/load your data automatically (in Editor too) instead your own hardcode save-system (:

# Installation

Project supports Unity Package Manager. To install project as Git package do following:
1. Open PackageManager
2. Add package by git url `https://github.com/LinkerOK/Unity-IR-Architecture.git`

Or:
1. Open the `Packages/manifest.json` file.
2. Update `dependencies` to have `com.devlink.ir` package:
```json
{
  "dependencies": {
    "com.devlink.ir": "https://github.com/LinkerOK/Unity-IR-Architecture.git"
  }
}
```

# Have fun :)
