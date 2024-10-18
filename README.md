# Battleship Game 🎯

A console-based **Battleship Game** built from scratch with ASP.NET Core MVC. This project focuses on learning fundamental programming concepts while creating an interactive two-player game.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Note for Non-Windows Users](#note-for-non-windows-users)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgements](#acknowledgements)

---

## Features
- 🎮 Two-player turn-based gameplay.
- 📊 Interactive game grid with validation and user feedback.
- 🎵 Background sound effects with looping support.
- 🌈 Console interface with colored prompts and ASCII art.
- 💾 Easy-to-understand code with **builder patterns** and **modular components**.

---

## Installation

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine  
- [Git](https://git-scm.com) installed

### Steps to Run Locally

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/bs0991/BattleshipLiteApp.git
2. **Navigate to the Project Directory:**
   ```bash
   cd your-repo-name
3. **Restore Dependencies:**
   ```bash
   dotnet restore
4. **Run the Application:**
   ```bash
   dotnet run
   
---

## How to Play

1. Each player selects five grid positions to place their ships.
2. Players take turns guessing the opponent’s ship positions by entering grid coordinates (e.g., `A1`).
3. If the selected coordinate contains an opponent’s ship, it will be marked with **X** (hit).
4. If the guess is incorrect, the coordinate will be marked with **O** (miss).
5. The game continues until one player hits all five of the opponent’s ships.

---

## Project Structure

```plaintext
📦 BattleshipLiteApp
├── Models/              # Data models like PlayerModel, MenuModel, GridModel
├── Helpers/             # Utility classes like ConsoleHelper
├── Builders/            # Builder patterns for creating objects
├── Constants.cs         # Stores reusable constants like colors and ASCII art
├── Program.cs           # Main entry point of the game
└── README.md            # Documentation file
```
---

## Technologies Used

- **C#**: Main programming language used  
- **.NET Core**: Framework for building and running the application  
- **Console Application**: Simple text-based user interface  

---

## Known Issues

- **WAV File Compatibility**: The background and sound effects rely on `.wav` files, which may not work on non-Windows systems. If you're running on macOS or Linux, sound playback may not function as intended.

---

## Contributing

Contributions are welcome! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix:
   ```bash
   git checkout -b feature/YourFeatureName
3. Make your changes and commit them:
   ```bash
   git commit -m "Add some feature"
4. Push to the branch:
   ```bash
   git push origin feature-branch-name
5. Submit a pull request

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Acknowledgements

- ASCII text/art from https://patorjk.com and https://ascii.co.uk/art/battleship
- Music artist/song title: The Midnight - The Equaliser (Not Alone) // https://themidnightofficial.com/
- Explosion sound effects by Mike Koenig from https://soundbible.com/tags-explosion.html
