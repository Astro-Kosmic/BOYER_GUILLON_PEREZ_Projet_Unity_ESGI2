# 🎮 DEVMON

## 👤 Auteur(s)

- **Adrien GUILLON - Clément BOYER - Lucas PEREZ**
- Rôle : Développeur / Level designer / etc.
- Liens : [Dépot GitHub](https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2)

---

## # Description du projet
Décris rapidement ton projet : type de jeu, objectif, contexte (projet perso, scolaire, game jam…).

---

## 1. Structure du Projet

```
/Assets
    /Scripts
    /Scenes
    /Prefabs
    /Materials
    /Animations
    /Audio
    /UI
/Packages
/ProjectSettings
```

---

## 2. Fonctionnalités Principales

- [ ] Système de mouvement joueur
- [ ] Caméra (Cinemachine ou custom)
- [ ] Menu principal
- [ ] Système audio
- [ ] UI / HUD
- [ ] IA basique
- [ ] Gestion des collisions
- [ ] Système de score / progression
- [ ] Sauvegarde / chargement
- [ ] Autres…

---

## 3. Scènes du Projet

| Scène        | Description |
|--------------|-------------|
| MainMenu     | Menu principal |
| Level_01     | Premier niveau |
| TestScene    | Scène de test |

---

## 4. Installation & Lancement

### a. Cloner le repository
```bash
git clone https://github.com/Astro-Kosmic/BOYER_GUILLON_PEREZ_Projet_Unity_ESGI2
```

### b. Version Unity requise
```
Unity 2022.3.x LTS (ou autre version exacte)
```

### c. Ouvrir le projet
1. Ouvrir Unity Hub  
2. Cliquer sur **Add project from disk**  
3. Sélectionner le dossier du projet  

---

## 5. Tests & Débogage

- Ouvrir la scène `TestScene`
- Appuyer sur **Play**
- Contrôles (à adapter selon ton jeu) :
  - `ZQSD` : déplacement
  - `Espace` : saut
  - `Échap` : pause / menu
- Consulter la console pour les logs

---

## 6. Organisation du Code

```
/Scripts
    /Player
    /Enemies
    /UI
    /Managers
    /Utilities
```

Principes :
- Architecture orientée composants
- Scripts séparés par responsabilités
- Managers centralisés (GameManager, AudioManager…)
- ScriptableObjects pour les données (optionnel)

---

## 7. Technologies & Packages utilisés

- Unity (version indiquée plus haut)
- TextMeshPro
- Cinemachine
- New Input System (si activé)
- URP / HDRP (selon ton projet)
- Autres packages éventuels…

---

## 8. Build

1. Aller dans **File → Build Settings**
2. Sélectionner la plateforme (Windows, Linux, WebGL…)
3. Ajouter toutes les scènes nécessaires dans *Scenes in Build*
4. Cliquer sur **Build**

---

## 9. Licence

```
Ce projet est sous licence MIT. Voir le fichier LICENSE pour détails.
```

---

## 10. Notes supplémentaires

- TODO :
  - [ ] Fonctionnalités à ajouter
  - [ ] Bugs connus
  - [ ] Améliorations futures

- Remarques techniques :
  - Notes internes ou contraintes spécifiques du projet.