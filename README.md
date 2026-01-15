# 🎮 DevMon — Documentation du Projet

##  Équipe
**Clément BOYER – Adrien GUILLON – Lucas PEREZ**  
Projet Unity — ESGI2 Campus Éductive  
Trimestre 1 – 2025/2026

---

#  1. Concept du jeu

> *“Dans un monde dominé par le NoCode, vous êtes l’un des derniers vrais développeurs. Capturez les DevMon, des créatures nées des langages de programmation, collectionnez les 8 Écussons du Code et affrontez C-lermo, maître du Bas Niveau.”*

La démo présente les premières mécaniques du jeu :  
- Exploration libre  
- Interactions avec l’environnement  
- Collecte d'objets  
- Navigation entre plusieurs scènes

---

#  2. Création de la carte

##  Terrain & Relief
Pour structurer la carte, l’équipe a utilisé l’outil **Terrain** natif de Unity :

- Sculpture du relief global  
- Création d’une chaîne de montagnes pour fermer la zone de jeu  
- Traçage manuel des chemins  
- Organisation progressive de la carte pour assurer lisibilité et cohérence  

L’objectif était d’obtenir un environnement naturel, jouable et cohérent.

##  Habillage visuel
Le terrain a été habillé avec :

- **Textures Fantasy Forest** pour le sol  
- **LowPoly Tree** pour les arbres  
- **Textures rocheuses Rock01** peintes manuellement  
- **Terrain Tools** pour dessiner le chemin  
- Sculptures fines des reliefs pour les contraintes de gameplay  

Les textures ont été configurées pour garantir un rendu propre (Filter Mode : *Point*, Wrap : *Repeat*).

##  Objets & Prefabs
Les assets extérieurs proviennent des packages suivants :

- *Fantasy Forest*  
- *Meadow Forest*  
- *LowPoly Tree*

Tous les éléments importants (arbres, maisons, lanternes…) ont été convertis en **prefabs** pour :  
✔ créer des motifs (patterns) cohérents  
✔ accélérer la mise en scène  
✔ garder un placement homogène

---

#  3. Joueur & Interactions

##  Sprite & déplacements
Le joueur utilise un sprite 2D animé provenant d’un package externe.  
Il permet une intégration simple de l’interaction avec le décor.

##  Système d’interaction
Le projet inclut notamment :

### 🔹 PNJ interactif
Lorsqu’un Player entre dans la zone du PNJ :  
- Le PNJ détecte le joueur via son trigger  
- Il stoppe sa patrouille  
- Il passe en **mode poursuite**  
- Il freeze le joueur via son script de mouvement  
- Un message debug signale l’événement

### 🔹 Collecte d’écussons
L’objet *écusson* utilise :
- Un mouvement de **rotation**  
- Une **lévitation sinusoïdale**  
- Un **Collider trigger**  
- Une interaction via la **touche E**  

Lorsque le joueur valide :
- Le compteur de l’UI s’incrémente  
- L’objet disparaît proprement

Scripts utilisés :  
- `CollectEcusson.cs`  
- `PlayerMovement.cs`  
- `NpcAI.cs`

---

#  4. Création des Interfaces

##  Menu Principal
Contient :
- Fond illustré  
- Bouton **Play** → MainWorld  
- Bouton **Exit** → Quitte le jeu  

Géré par `MainMenuManager.cs`.

##  HUD (Head‑Up Display)
Affiche :
- La **zone actuelle**  
- Le **compteur d’écussons**  
- Un menu latéral regroupant :  
  - DevMonDex  
  - Équipe  
  - Sac à Dos  
  - Retour Menu

Animations UI gérées avec **CanvasGroup** + **coroutines**.

---

#  5. Difficultés rencontrées

## ⚠️ Limites techniques
Manque d’expérience avec Unity et C#, rendant difficile la prise de recul et la structuration technique du projet.

## ⚠️ Travail collaboratif & Merge
Malgré une organisation réfléchie, le **merge final** des branches fut l’étape la plus anxiogène du projet :  
conflits Git, incohérences, fichiers d’éditeur corrompus.

## ⚠️ Calibrage & Placement
Le placement des éléments (maisons, arbres, colliders) a nécessité :  
- Beaucoup d’essais/erreurs  
- Consultation fréquente de la documentation  
- Recours à des tutoriels et à l’IA

## ⚠️ Complexité bicéphale
Difficulté à progresser simultanément sur :  
- La programmation orientée objet  
- La modélisation 3D  

---

#  6. Axes d’amélioration

### ✔️ Meilleure organisation
- Comprendre plus tôt l’architecture du projet  
- Mieux gérer les branches Git et les fusions  

### ✔️ Recul extérieur
- Tester plus tôt les mécaniques  
- Faire tester le jeu pour identifier ce qui n’est pas intuitif  

### ✔️ Apprentissage technique
- Approfondir C# orienté objet  
- Mieux maîtriser Unity (cycle de vie, scènes, prefabs…)  

### ✔️ Plus de pratique
- Réaliser des mini‑projets pour gagner en expérience  
- Prototyper avant de développer un système complet  

---

#  7. Architecture du projet

```
/Assets
    /Scripts
        /Items
            CollectEcusson.cs
        /Player
            PlayerMovement.cs
            CameraFollow.cs
        /PNJ
            NpcAI.cs
        /UI
            MainMenuManager.cs
            WorldUIManager.cs
    /Prefabs
    /Materials
    /Scenes
        MainMenu.unity
        MainWorld.unity
        Backpack.unity
```

---

#  8. Lancement

```
Unity 6.x — 6000.2 LTS
```

1. Ouvrir le projet dans **Unity Hub**  
2. Lancer la scène `MainMenu`  
3. Tester le menu, la collecte et les interactions

---

#  Licence
Projet scolaire • Usage interne ESGI