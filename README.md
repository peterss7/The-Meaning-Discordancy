![Build](https://img.shields.io/badge/build-pending-lightgrey)
![License](https://img.shields.io/badge/license-proprietary-red)

Copyright © 2025 Steven Peterson  
All rights reserved.

This software and all associated materials are the exclusive intellectual property of the author.  
No part of this code may be copied, modified, distributed, or used without explicit written permission from the author.

**Note:** This project is not licensed under an open-source license.  
Creative Commons references may be included for informational purposes only.

# The Meaning Discordancy

An experimental game of *emergent meaning*.

## Description

This game uses NLP libraries to perform vector similarity calculations on player input, primarily as players take turns tagging images. Over time, thematic structures emerge, and players find themselves in a battle of ideology — where winning means constructing meaning more efficiently than your opponent... or losing to theirs.

That's the idea, anyway. It's a ways off, but that's the vision.

## Getting Started

### Dependencies

* Program runs in docker.

### NLP Similarity Evaluator Service
* Python
  - flask, flask_smorest, flask-jwt-extended
  - flask-sqlalchemy, flask-migrate, sqlalchemy, pyodbc
  - python-dotenv, gunicorn, passlib
  - sentence-transformers, scikit-learn

### TheMeaningDiscordancy API (C# Backend)
* .NET / EF Core
  - Microsoft.AspNetCore.Http.Abstractions
  - Microsoft.EntityFrameworkCore.SqlServer + Tools + Abstractions
  - Microsoft.Extensions.Logging / DependencyInjection.Abstractions

### Angular Client
* Angular Material
* Storybook
* Rimraf

### Installing

* Installation scripts are still under development.
* Docker setup is not yet fully implemented.
* Frontend:
  ```bash
  cd ./src/client
  npm run install:all  
* Python backend  
  ```bash  
  cd ./src/nlp/powershell  
  ./install.ps1

### Executing 

* NLP Similarity Service(./src/nlp/powershell)
```
./run.ps1
```
Starts the Flask-based NLP backend.
* Angular Client(./src/client/)
```
npm run start:all
```
Starts both the client app and Storybook for component previews.

## File Structure

### The Discordancy Api
> Controllers and entry point
<details>
<summary>📁 (click to expand)</summary>

```plaintext
│       ├── TheMeaningDiscordancy.Api
│       │   ├── Classes
│       │   │   └── AppHostSettings.cs
│       │   ├── DiscordApi
│       │   │   ├── ConfigurationApiController.cs
│       │   │   ├── ItemApiController.cs
│       │   │   └── TagApiController.cs
│       │   ├── Extensions
│       │   │   └── StatupExtensions.cs
│       │   ├── Program.cs
│       │   ├── Properties
│       │   │   └── launchSettings.json
│       │   ├── TheMeaningDiscordancy.Api.csproj
│       │   ├── appsettings.Development.json
│       │   ├── appsettings.Local.json
│       │   └── appsettings.json
```
</details>

### The Discordancy Core Services
> Where the business logic of entities is executed.

<details>
<summary>📁 (click to expand)</summary>

```plaintext
│       ├── TheMeaningDiscordancy.Core
│       │   ├── CoreServices
│       │   │   ├── CoreStartupExtensions.cs
│       │   │   ├── Item
│       │   │   │   ├── Configuration
│       │   │   │   │   └── ItemConstants.cs
│       │   │   │   ├── Extensions
│       │   │   │   │   └── ItemStartupExtensions.cs
│       │   │   │   ├── Mapping
│       │   │   │   │   └── ItemProfile.cs
│       │   │   │   ├── Models
│       │   │   │   │   ├── Dtos
│       │   │   │   │   │   ├── Create
│       │   │   │   │   │   │   └── CreateItemDto.cs
│       │   │   │   │   │   ├── ItemDto.cs
│       │   │   │   │   │   └── Update
│       │   │   │   │   │       └── ItemUpdateDto.cs
│       │   │   │   │   ├── Entities
│       │   │   │   │   │   └── ItemEfc.cs
│       │   │   │   │   └── IItemMap.cs
│       │   │   │   ├── Repositories
│       │   │   │   │   ├── Interfaces
│       │   │   │   │   │   └── IItemRepository.cs
│       │   │   │   │   └── ItemRepository.cs
│       │   │   │   └── Services
│       │   │   │       ├── Interfaces
│       │   │   │       │   ├── IItemMappingService.cs
│       │   │   │       │   └── IItemService.cs
│       │   │   │       ├── ItemMappingService.cs
│       │   │   │       └── ItemService.cs
│       │   │   ├── Tag
│       │   │   │   ├── Configuration
│       │   │   │   │   └── TagConstants.cs
│       │   │   │   ├── Extensions
│       │   │   │   │   └── TagStartupExtensions.cs
│       │   │   │   ├── Mapping
│       │   │   │   │   └── TagProfile.cs
│       │   │   │   ├── Models
│       │   │   │   │   ├── Dtos
│       │   │   │   │   │   ├── Create
│       │   │   │   │   │   │   └── CreateTagDto.cs
│       │   │   │   │   │   └── TagDto.cs
│       │   │   │   │   ├── Entities
│       │   │   │   │   │   └── TagEfc.cs
│       │   │   │   │   └── ITagMap.cs
│       │   │   │   ├── Repositories
│       │   │   │   │   ├── Interfaces
│       │   │   │   │   │   └── ITagRepository.cs
│       │   │   │   │   └── TagRepository.cs
│       │   │   │   └── Services
│       │   │   │       ├── Interfaces
│       │   │   │       │   ├── ITagMappingService.cs
│       │   │   │       │   └── ITagService.cs
│       │   │   │       ├── TagMappingService.cs
│       │   │   │       └── TagService.cs
│       │   │   └── Utilities
│       │   │       ├── Classes
│       │   │       │   └── ImageData.cs
│       │   │       ├── Extensions
│       │   │       │   └── UtilityStartupExtensions.cs
│       │   │       └── Services
│       │   │           ├── ImageUtilityService.cs
│       │   │           └── Interfaces
│       │   │               └── IImageUtilityService.cs
│       │   ├── DiscordContext.cs
│       │   ├── Properties
│       │   │   └── launchSettings.json
│       │   ├── Results
│       │   │   ├── DiscordError.cs
│       │   │   ├── DiscordResult.cs
│       │   │   └── Error.cs
│       │   └── TheMeaningDiscordancy.Core.csproj
```
</details>

### Discordancy Infrastructure
> Persistence/WIP
<details>
<summary>📁 (click to expand)</summary>

```plaintext
│       ├── TheMeaningDiscordancy.Infrastructure
│       │   ├── Classes
│       │   │   └── Interfaces
│       │   │       └── IDiscordDataEntity.cs
│       │   ├── Extensions
│       │   │   └── PersistenceStartupExtensions.cs
│       │   ├── Repositories
│       │   │   ├── DiscordRepository.cs
│       │   │   └── Interfaces
│       │   │       └── IDiscordRepository.cs
│       │   └── TheMeaningDiscordancy.Infrastructure.csproj
```
</details>

### Angular Client
> Not displaying ts, scss, and html file for angular components to consolidate space. The are there.
<details>
<summary>📁 (click to expand)</summary>

```plaintext
│       ├── client
│       │   ├── README.md
│       │   ├── angular.json
│       │   ├── documentation.json
│       │   ├── package-lock.json
│       │   ├── package.json
│       │   ├── src
│       │   │   ├── app
│       │   │   │   ├── app-routing.module.ts
│       │   │   │   ├── app.module.ts
│       │   │   │   ├── constants
│       │   │   │   │   └── discord-constants.contants.ts
│       │   │   │   ├── core
│       │   │   │   │   ├── core.module.ts
│       │   │   │   │   ├── models
│       │   │   │   │   │   └── config-data.model.ts
│       │   │   │   │   └── services
│       │   │   │   │       ├── client.service.ts
│       │   │   │   │       └── config.service.ts
│       │   │   │   ├── items
│       │   │   │   │   ├── components
│       │   │   │   │   │   ├── components.module.ts
│       │   │   │   │   │   └── item-table
│       │   │   │   │   │       ├── item-table.module.ts
│       │   │   │   │   │       └── item-tile
│       │   │   │   │   ├── items.module.ts
│       │   │   │   │   ├── models
│       │   │   │   │   │   └── item.model.ts
│       │   │   │   │   └── services
│       │   │   │   │       ├── item-styles.service.ts
│       │   │   │   │       └── items.service.ts
│       │   │   │   └── shared
│       │   │   │       ├── components
│       │   │   │       │   ├── action-bar
│       │   │   │       │   ├── action-header
│       │   │   │       │   ├── components.module.ts
│       │   │   │       │   ├── file-upload
│       │   │   │       │   ├── icon-button
│       │   │   │       │   └── modal
│       │   │   │       ├── layout
│       │   │   │       │   ├── footer
│       │   │   │       │   ├── header
│       │   │   │       │   ├── home
│       │   │   │       │   ├── layout.module.ts
│       │   │   │       │   └── sidebar
│       │   │   │       ├── models
│       │   │   │       │   ├── config-data.model.ts
│       │   │   │       │   └── modal-data.model.ts
│       │   │   │       ├── pipes
│       │   │   │       │   └── normalize-url.pipe.ts
│       │   │   │       ├── services
│       │   │   │       │   ├── modal.service.ts
│       │   │   │       │   └── styles.service.ts
│       │   │   │       └── shared.module.ts
│       │   │   ├── assets
│       │   │   ├── index.html
│       │   │   ├── main.ts
│       │   │   ├── stories
│       │   │   ├── styles
│       │   │   │   ├── main.scss
│       │   │   │   └── mixins
│       │   │   │       ├── _components.scss
│       │   │   │       ├── _detail.scss
│       │   │   │       ├── _layout.scss
│       │   │   │       ├── components
│       │   │   │       │   ├── _display-components.scss
│       │   │   │       │   ├── _image-components.scss
│       │   │   │       │   └── components.scss
│       │   │   │       └── mixins.scss
│       │   │   └── styles.scss
│       │   ├── tsconfig.app.json
│       │   └── tsconfig.json
```
</details>

### NLP Similarity Evaluator Service
> Calculating scores by evaluating emergent similarities.
<details>
<summary>📁 (click to expand)</summary>
  
```plaintext
│       └── nlp
│           ├── Dockerfile
│           ├── __init__.py
│           ├── app.py
│           ├── powershell
│           │   ├── install.ps1
│           │   ├── reinstall.ps1
│           │   └── run.ps1
│           ├── requirements.txt
│           ├── resources
│           │   ├── __init__.py
│           │   └── tag_resource.py
│           └── schemas
│               ├── __init__.py
│               └── tag_schema.py
```
</details>

## Utilities

From project root:
```bash
.\AddHeaders.ps1               # Add copyright headers
.\AddHeaders.ps1 --restore     # Undo last header run
.\.treeignore\tree.py          # Get a visual on the indentation situation
```
These scripts automatically add or remove legal headers across code files, formatting the comment style based on file extension.
Planned: --update functionality to refresh existing headers.

## Help

If Python imports cannot be resolved, ensure that your interpreter points to:
`./venv/Scripts/python.exe`

## Version History

* 0.1
    * Initial Scaffold

## Acknowledgments

Inspiration, code snippets, etc.
TO-DO

## Authors & Contact
For licensing inquiries or collaboration opportunities:

**Steven Peterson**  [LinkedIn →](https://www.linkedin.com/in/steven-peterson7405926/)  
**TheMeaningDiscordancy** [Github →](https://github.com/peterss7/The-Meaning-Discordancy)  
