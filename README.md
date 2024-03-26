<h1 align="center">Verax API EF</h1>

<p align="center">
  <img src="https://img.shields.io/badge/C%23-239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#"/>
  <img src="https://img.shields.io/badge/Entity%20Framework-512BD4.svg?style=for-the-badge&logo=entity-framework&logoColor=white" alt="Entity Framework"/>
  <img src="https://img.shields.io/badge/.NET-512BD4.svg?style=for-the-badge&logo=.net&logoColor=white" alt=".NET"/>
  <img src="https://img.shields.io/badge/SQL%20Server-E34F26.svg?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt="SQL Server"/>


  <img src="https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=Verax_API_EF&metric=alert_status&token=09154b15417d84a94e809d60f1d5bb01654b5501" alt="Coverage"/>
</p>


## Introduction

Bienvenue sur le projet `Verax_API_EF`, une API RESTful développée spécifiquement pour faciliter la communication entre le site web et l'application Android du projet [Verax](https://codefirst.iut.uca.fr/git/Verax/Verax). Cette interface est conçue pour gérer efficacement les articles, les formulaires, et les utilisateurs.

## Technologies

- **.NET 8**: Le framework utilisé pour développer l'application.
- **Entity Framework Core**: ORM utilisé pour l'accès et la gestion de la base de données.
- **SQL Server**: Système de gestion de base de données recommandé (modifiable selon vos préférences).

## Configuration requise

- .NET 8.
- Un IDE tel que Visual Studio, VS Code avec l'extension C#, ou JetBrains Rider pour le développement.

## Installation

1. **Cloner le projet** : Exécutez `git clone https://codefirst.iut.uca.fr/git/Verax/Verax_API_EF.git` pour cloner le dépôt dans votre espace de travail local.
2. Ouvrez le fichier `Verax_API_EF.sln` avec votre IDE.
3. Restaurez les packages nécessaires.
4. Lancez le projet depuis IDE.

## Utilisation

Après avoir lancé l'API, elle sera accessible via `http://localhost:5000` par défaut. Voici quelques exemples de requêtes que vous pouvez effectuer :

- **Obtenir des articles** : `GET /articles`
- **Ajouter un utilisateur** : `POST /user` 
- **Mettre à jour un article** : `PUT /article/{id}` 
- **Supprimer un formulaire** : `DELETE /formulaire/{id}`

## Problèmes pouvant être rencontrés


### Migration


 - Lors de la création de la base de données, l'API s'appuie sur une migration incluse dans le projet `DbContextLib`. Si cette migration est absente, l'API ne fonctionnera pas correctement car la base de données sera vide, entraînant ainsi l'absence de données retournées. En cas de non présence de cette migration, vous devrez décommenter les lignes dans le fichier `LibraryContext.cs` du projet `DbContextLib` (aux alentours de la ligne 60), puis exécuter les commandes suivantes :

```bash
dotnet ef migrations add mrg1 --project DbContextLib --context LibraryContext
```

PS: N'oubliez pas de supprimer l'ancienne base de données dans le projet API et de recommenter les lignes dans le fichier `LibraryContext.cs`



### Tests Console API
 - Pour exécuter les tests console de l'API, assurez-vous au préalable que l'API est en cours d'exécution sur votre machine. Il est également crucial de vérifier que le port utilisé par l'application correspond à celui spécifié dans les configurations des tests. Cette vérification garantit que les tests peuvent interagir correctement avec l'API et fournir des résultats fiables.



## Equipe de développement
<p align="center" >

<a href="https://codefirst.iut.uca.fr/git/louis.laborie"  style="margin-right: 20px;">
  <img src="img/Louis.png" width="50" height="50" title="Louis Laborie" alt="Louis Laborie"/>
</a>
<a href="https://codefirst.iut.uca.fr/git/tony.fages" style="margin-right: 20px;">
  <img src="img/Tony.png" width="50" height="50" title="Tony Fages" alt="Tony Fages"/>
</a>
<p>

