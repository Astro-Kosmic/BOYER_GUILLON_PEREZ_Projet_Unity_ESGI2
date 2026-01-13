# 🎮 DEVMON

## 👤 Auteur(s)

- **Adrien GUILLON - Clément BOYER - Lucas PEREZ**
- Rôle : Développeurs Unity / Level Designer / UI Designer
- Liens : [Dépot GitHub](https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2)

---

## # Description du projet

**DevMon** est un jeu scolaire réalisé à l’ESGI dans le cadre d’un projet Unity.  
Le but : créer un jeu intégrant un système de déplacement, une interface UI complète, une gestion de scènes, un PNJ interactif et des mécaniques inspirées de jeux d’aventure / RPG type Pokémon.

Ce dépôt contient la version collaborative du projet, maintenant enrichi d’un **début de système d’inventaire fonctionnel**, encore **en cours de développement**.

---

## 1. Structure du Projet

```
/Assets
    /Images              # Fonds, logos, sprites UI
    /Scripts
        /UI              # Gestion de l'interface (Main Menu, World UI, Backpack)
        /Inventory       # Nouveaux scripts du système d'inventaire
        /Managers        # Gestion des scènes et transitions
    /Scenes
        /Menus           # Scène MainMenu
        /Game            # MainWorld + Backpack
    /Prefabs             # Boutons stylisés & éléments UI réutilisables
    /Materials
    /Audio
    /Animations
/Packages
/ProjectSettings
```

---

## 2. Fonctionnalités Principales

### ✔️ Fonctionnalités déjà terminées

- **Menu principal complet**
  - Fond personnalisé
  - Logo DevMon
  - Boutons stylisés (Play / Exit)
  - Hover / Click / Scale dynamique
  - Navigation scènes (`MainMenuUIManager`)

- **Système UI en jeu (MainWorld)**
  - HUD supérieur (zone actuelle)
  - Menu latéral animé (CanvasGroup + Scale)
  - Ouverture/fermeture via **Échap**
  - Navigation vers le Sac à Dos

- **Scène Sac à Dos (Backpack)**
  - UI complète
  - Système d’affichage des slots d’inventaire
  - Retour vers MainWorld

### 🧪 **NOUVEAU : Système d’inventaire (EN COURS DE DÉVELOPPEMENT)**
> ⚠️ Le système fonctionne partiellement — l'ajout d’items est opérationnel,  
> mais **le lien avec le gameplay (ramasser des objets au sol)** n’est pas implémenté.

Fonctionnalités actuelles :
- Slots d’inventaire générés automatiquement (UI)
- Items représentés via **Scriptable Objects**
- Système centralisé `InventorySystem` en **DontDestroyOnLoad**
- Test d’ajout d’objet via un bouton debug

Fonctionnalités à venir :
- Ajout d’un item en interagissant avec un objet au sol
- Stack d’items (quantité)
- Interaction avec les slots
- System de suppression / tri
- Persistence de l’inventaire entre sessions

---

## 3. Scènes du Projet

| Scène        | Description |
|--------------|-------------|
| **MainMenu** | Menu principal (Play / Exit) |
| **MainWorld** | Scène principale (HUD, menu latéral, navigation) |
| **Backpack** | Interface du sac à dos (inventaire WIP) |

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
2. **Add project from disk**  
3. Choisir le dossier du projet

---

## 5. Tests & Débogage

- Lancer la scène **MainMenu**
- Appuyer sur Play
- Tester :
  - **Play** → charge MainWorld  
  - **Échap** → ouvre le menu latéral  
  - **Sac à Dos** → ouvre la scène Backpack  
  - **Bouton Test** dans Backpack → ajoute un item au premier slot disponible  

---

## 6. Organisation du Code

```
/Scripts
    /UI
        MainMenuUIManager.cs
        WorldUIManager.cs
        BackpackUIManager.cs
    /Inventory
        InventorySystem.cs     # Source de vérité globale
        InventoryUI.cs         # Génération des slots UI
        ItemSlotUI.cs          # Affichage de chaque slot
        ItemData.cs            # ScriptableObject item
    /Managers
    /Player
    /Enemies
    /Utilities
```

---

## 7. Technologies & Packages utilisés

- Unity 6.2.x
- TextMeshPro
- New Input System (pour Escape)
- ScriptableObjects (système d’objets)
- CanvasGroup animations
- EventSystem UI  
- Sprites personnalisés

---

## 8. Build

1. Ouvrir **File → Build Profiles**
2. Vérifier les scènes :
   - `MainMenu`
   - `MainWorld`
   - `Backpack`
3. Cliquer sur **Build**

---

## 9. Licence

```
Projet scolaire — diffusion interne ESGI.
```

---

## 10. Notes supplémentaires

Travail restant :
- [ ] Déplacement du joueur  
- [ ] Objets ramassables (terrain → inventaire)  
- [ ] PNJ / Dialogues / IA simple  
- [ ] Pokédex / Équipe  
- [ ] Sauvegarde / chargement  
- [ ] Audio + SFX  
- [ ] Amélioration UI (animations, transitions)  

Le système d’inventaire est **en bonne voie**, mais encore incomplet.  
Il constitue désormais une **base solide** pour la suite du projet.