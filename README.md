# 🎮 DEVMON

## 👤 Auteur(s)

- **Adrien GUILLON - Clément BOYER - Lucas PEREZ**
- Rôle : Développeurs Unity / Level Designer / UI Designer
- Liens : [Dépot GitHub](https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2)

---

## # Description du projet

**DevMon** est un jeu scolaire réalisé à l’ESGI dans le cadre d’un projet Unity.  
Le but : créer un jeu intégrant un système de déplacement, une interface UI complète, une gestion de scènes, un PNJ interactif et des mécaniques inspirées de jeux d’aventure / RPG type Pokémon.

Ce dépôt contient la version collaborative du projet.

---

## 1. Structure du Projet

```
/Assets
    /Images              # Fonds, logos, sprites UI
    /Scripts
        /UI              # Gestion de l'interface (Main Menu, effets boutons)
        /Managers        # MainMenuManager, gestion scènes
    /Scenes
        /Menus           # Scène MainMenu
        /Game            # Scène principale du jeu
    /Prefabs             # Boutons stylisés & éléments réutilisables
    /Materials
    /Audio
    /Animations
/Packages
/ProjectSettings
```

---

## 2. Fonctionnalités Principales

- [x] **Menu principal complet**
  - Fond personnalisé
  - Logo DevMon
  - Boutons stylisés (Play / Exit)
  - Effets UI (hover, pressed, outline, shadow)
  - Script : `UIButtonScale` pour zoom dynamique
  - Navigation entre scènes via `MainMenuUIManager`
- [ ] Système de mouvement joueur
- [ ] Caméra (Cinemachine / custom)
- [ ] PNJ et interactions
- [ ] Gestion des collisions et objets
- [ ] UI / HUD ingame
- [ ] Inventaire (sac)
- [ ] Pokédex / Équipe
- [ ] Sauvegarde / chargement
- [ ] Audio (musique, SFX)

---

## 3. Scènes du Projet

| Scène        | Description |
|--------------|-------------|
| **MainMenu** | Menu principal (Play / Exit, fond DevMon) |
| **MainWorld** | Scène de jeu (déplacements, interactions) |

---

## 4. Installation & Lancement

### a. Cloner le repository
```bash
git clone https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2
```

### b. Version Unity requise
```
Unity 6.2.x (6000.2.x LTS)
```

### c. Ouvrir le projet
1. Ouvrir Unity Hub  
2. Cliquer sur **Add project from disk**  
3. Sélectionner le dossier du projet  

---

## 5. Tests & Débogage

- Ouvrir la scène `MainMenu`
- Appuyer sur **Play**
- Vérifier le fonctionnement :
  - Bouton **Play** → charge la scène MainWorld
  - Bouton **Exit** → quitte l'application / stop play mode
  - Hover / Click : effet zoom + changement de couleur

---

## 6. Organisation du Code

```
/Scripts
    /UI
        MainMenuUIManager.cs      # Navigation Play / Exit
        UIButtonScale.cs          # Hover / Click animations
    /Managers
    /Player
    /Enemies
    /Utilities
```

Principes :
- Architecture orientée composants
- UI séparée proprement
- Scripts organisés par catégories
- Menu principal modulaire et réutilisable

---

## 7. Technologies & Packages utilisés

- Unity 6.2.x
- TextMeshPro (UI avancée)
- New Input System (optionnel selon gameplay)
- Image full-screen responsive
- EventSystems (UI interactions)
- Sprite Editor (si besoin futurs spritesheets)

---

## 8. Build

1. Ouvrir **File → Build Profiles**
2. Vérifier les scènes :
   - 0 : `MainMenu`
   - 1 : `MainWorld`
3. Cliquer sur **Build**
4. Tester l’exécutable

---

## 9. Licence

```
Ce projet est sous licence MIT. Voir le fichier LICENSE pour détails.
```

---

## 10. Notes supplémentaires

- TODO (à venir) :
  - [ ] Intégrer le mouvement du joueur
  - [ ] Implémenter les collisions du décor et objets
  - [ ] PNJ avec comportement automatique
  - [ ] Menus supplémentaires (Pokedex / Équipe / Sac)
  - [ ] Système audio
  - [ ] Effets visuels supplémentaires sur le UI
  - [ ] Animations transitions de scènes

- Remarques techniques :
  - Menu principal entièrement stylisé selon la DA DevMon
  - Système UI responsive & scalable
  - Code propre, organisé, prêt pour extensions