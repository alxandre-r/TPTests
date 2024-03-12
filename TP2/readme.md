
###    I. Les difficultés liées à la validation

#### Éléments du logiciel freinant la validation :

1.  **Structure de contrôle complexe** :
    
    -   La structure de contrôle utilisée dans le `Main` de `Program.cs` rend la lecture difficile et augmente la complexité cognitive pour suivre le flux d'exécution du programme.
2.  **Redondance du code** :
    
    -   La duplication de code dans la gestion des jeux (notamment la création d'instances de `Morpion` ou `PuissanceQuatre` et la boucle de jeu) dans le `Main` de `Program.cs` ainsi que dans les méthodes `BoucleJeu`, `tourJoueur`, et `tourJoueur2` des classes `Morpion` et `PuissanceQuatre`.
3.  **Manque de modularité** :
    
    -   Les méthodes `tourJoueur` et `tourJoueur2` dans les classes `Morpion` et `PuissanceQuatre` contiennent des blocs de code répétitifs qui pourraient être extraits dans des méthodes utilitaires pour réduire la duplication de code.
    
4.  **Méthodes sans retour** : Certaines méthodes ne retournent pas de valeur explicite, ce qui peut compliquer la validation du flux de contrôle et des résultats. Par exemple, les méthodes `tourJoueur` et `tourJoueur2` de la classe `Morpion` et `PuissanceQuatre` ne retournent rien (`void`).
    
5.   **Fonctions trop longues** : Les fonctions `BoucleJeu` dans les classes `Morpion` et `PuissanceQuatre` sont trop longues et contiennent beaucoup de logique.


### II. Les méthodes de résolution de ces problèmes

#### Actions à mettre en place pour valider l'existant et corriger les bugs éventuels :

1.  **Refactoring du code** :
    
    -   Identifier et extraire les blocs de code répétitifs dans des méthodes utilitaires pour améliorer la lisibilité et la maintenance du code.
    -   Simplifier la structure de contrôle pour rendre le code plus compréhensible.
2.  **Création de tests unitaires** :
    
    -   Mettre en place les tests unitaires pour couvrir toutes les fonctionnalités et les cas d'utilisation du jeu.
    
3.  **Utilisation de bonnes pratiques de développement** :
    
    -   Appliquer des principes de conception SOLID pour améliorer la modularité et la maintenabilité du code.
    -   Adopter des conventions de nommage claires et des commentaires appropriés pour faciliter la compréhension du code par les développeurs.

### III. Le développement des fonctionnalités manquantes

#### Procédure pour "brancher" un joueur contrôlé par l'ordinateur et historisation/persistance :

1.  **Intégration d'un joueur contrôlé par l'ordinateur** :
    
    -   Créer une nouvelle classe représentant le joueur contrôlé par l'ordinateur, en implémentant une logique de jeu automatisée basée sur de l'aléatoire
    -   Modifier les méthodes de jeu (`tourJoueur` et `tourJoueur2`) pour inclure la logique de jeu du joueur contrôlé par l'ordinateur en cas de besoin, tout en maintenant la possibilité de jouer contre un autre joueur.
2.  **Historisation et persistance** :
    
    -   Introduire un mécanisme de stockage des états de jeu à différents moments, tel des fichiers de journalisation, pour enregistrer l'historique des parties.
    -   Mettre en place des méthodes pour sauvegarder et charger les états de jeu, permettant aux utilisateurs de reprendre les parties interrompues.