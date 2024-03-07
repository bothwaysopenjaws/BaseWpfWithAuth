# Remarque
Dans App.xaml, la StartupUri a été changée pour que ça soit la fenêtre login.


# Contexte de données
Le contexte de données est présent dans le projet .DBLib.

On a simplement des utilisateurs.
Les utilisateurs peuvent avoir des rôles.
On a des Garages.
Les garages peuvent avoir plusieurs voitures.

La clef Primaire est identifiée grace à l'annotation [Key] sur la propriété.

La clef étrangère est identifiée grace à l'annotation [ForeignKey(NomProprieteLiee)] sur la propriété.


# L'authentification
On a une fenêtre de login qui permet de se connecter à l'application (WindowLogin).
Cette fenêtre est liée à la classe LoginViewModel, qui est son contexte.

Elle a une méthode Login qui est appelée lorsqu'on clique sur le bouton "Se connecter".

Cette méthode vérifie si l'utilisateur existe dans la base de données, et si c'est le cas, on ouvre la fenêtre principale.

Un champ PasswordBox ne peut pas être bindé à une propriété, donc on la passe dans la méthode Login.

Si le mot de passe est valide, on garde l'utilisateur correspondant en mémoire dans la classe App, ce qui permet de l'avoir partout via App.LoggedUser (attention cast potentiellement nécessaire).