# 🎮 DEVMON

## 👤 Auteur(s)

- **Adrien GUILLON – Clément BOYER – Lucas PEREZ**
- Rôles : Développeurs Unity / UI Designer / Level Designer
- Liens : [Dépôt GitHub](https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2)

---

## # Description du projet

**DevMon** est un mini-jeu Unity réalisé dans le cadre d’un projet scolaire (ESGI).  
Le jeu s’inspire des mécaniques de type RPG / Pokémon-lite et inclut :

- un **menu principal complet et stylisé**,  
- une **scène de jeu** avec **HUD**,  
- un **menu latéral animé** (ouverture via Échap),  
- une **navigation multi-scènes**,  
- un début de **système d’inventaire** (Scène Sac à Dos).

Projet réalisé en **3 jours** dans le cadre du module Unity.

---

## 1. Structure du Projet

```
/Assets
    /Scripts
        /UI
            MainMenuManager.cs
            WorldUIManager.cs
            BackpackUIManager.cs
        /Player
        /Managers
    /Scenes
        /Menus
            MainMenu.unity
        /Game
            MainWorld.unity
            Backpack.unity
    /Prefabs
    /Materials
    /Animations
    /Audio
    /UI
    /Images
/Packages
/ProjectSettings
```

---

## 2. Fonctionnalités Principales

### ✔️ Fonctionnalités terminées
- [x] **Menu principal stylisé** (fond, logo, boutons animés)
- [x] **Navigation Play / Quit**
- [x] **Scène MainWorld opérationnelle**
  - HUD supérieur (zone actuelle)
  - Menu latéral (DevMonDex / Équipe / Sac à Dos / Retour)
  - Animation d’apparition / disparition du menu (CanvasGroup + Scale)
  - Ouverture / fermeture via **Échap**
- [x] **Scène Sac à Dos (Backpack)**  
  - Scène dédiée  
  - Barre supérieure  
  - Bouton Retour → MainWorld  

### ⬜ Fonctionnalités à venir
- [ ] Déplacement du joueur
- [ ] Caméra follow (Cinemachine ou custom)
- [ ] Gestion des collisions
- [ ] DevMonDex (scène ou panel)
- [ ] Système d’inventaire complet (objets, quantités)
- [ ] IA basique (PNJ qui s’approche du joueur)
- [ ] Audio (musique + SFX)
- [ ] Sauvegarde / chargement
- [ ] Système de progression / stats

---

## 3. Scènes du Projet

| Scène        | Description |
|--------------|-------------|
| **MainMenu** | Menu principal (Play / Quit) |
| **MainWorld** | Scène de jeu principale (HUD + menu latéral) |
| **Backpack** | Scène du Sac à Dos (inventaire) |

---

## 4. Installation & Lancement

### a. Cloner le repository
```bash
git clone https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2
```

### b. Version Unity requise
```
Unity 6.x (6000.2 LTS)
```

### c. Ouvrir le projet
1. Ouvrir Unity Hub  
2. Cliquer sur **Add project from disk**  
3. Sélectionner le dossier du projet

---

## 5. Tests & Débogage

- Ouvrir la scène **MainMenu** ou **MainWorld**
- Appuyer sur **Play**
- Contrôles actuels :
  - `Échap` : ouvrir / fermer le menu latéral
- Navigation :
  - Play → MainWorld  
  - Menu latéral → Sac à Dos → Retour → MainWorld
  - Retour Menu → MainMenu
- Surveiller la **Console Unity** pour les logs

---

## 6. Organisation du Code

```
/Scripts
    /UI
        MainMenuManager.cs       # Gère Play / Quit
        WorldUIManager.cs        # Gestion du HUD et menu latéral
        BackpackUIManager.cs     # Gestion du retour depuis Backpack
    /Player
    /Enemies
    /Managers
    /Utilities
```

Principes :
- Organisation claire par rôle
- UI séparée dans des scripts dédiés
- Utilisation du CanvasGroup pour les animations UI
- Structure pensée pour étendre facilement (DevMonDex, Inventaire…)

---

## 7. Technologies & Packages utilisés

- Unity **6.x (6000.2 LTS)**  
- TextMeshPro  
- EventSystem UI  
- Image UI (sprites personnalisés)  
- New Input System (mode Both activé pour compatibilité Escape)  
- Futur : Cinemachine, ScriptableObjects, AudioMixer

---

## 8. Build

1. Ouvrir **File → Build Profiles**
2. Vérifier que les scènes suivantes sont listées :
   - `MainMenu`
   - `MainWorld`
   - `Backpack`
3. Cliquer sur **Build**

---

## 9. Licence

```
Projet scolaire – diffusion interne.
```

---

## 10. Notes supplémentaires

- TODO :
  - Ajouter le gameplay du joueur
  - Ajouter un PNJ avec comportement
  - Créer DevMonDex / Équipe
  - Ajouter des objets récupérables dans la nature
  - Styliser davantage les interfaces (icônes, animations)