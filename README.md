# PR - Un Juego Propio

## Descripción

Este proyecto se basa en un videojuego de 2D de plataformas donde el heroe tiene que llegar al final de su camino mientras se defiende de gobins.

## Como Jugar

Para empezar la partida el jugador debe pulsar el botón empezar partida.
Tiene la opción de modificar las opciones, principalmente el volumen de juego.
El personaje se puede controlar con las las teclas A y D para el movimiento horizontal y el espacio para saltar. Con el click izquierdo podrá atacar a los goblins enemigos y con el derecho podra bloquear.
Si el jugador salta encima de un de los pinchos se acabará la partida.
Si los goblins logran golpear al jugador 3 veces se acabará la partida.
Los goblins tienen 2 vidas.

El jugador gana la partida al llegar al final del segundo nivel.

## Estructura del Proyecto
El proyecto consta de tres escenas, el menu, el nivel 1 y dos.
En la primera se ve un menu con iniciar la partida y salir del juego, con las opciones.
En las otras 2 se encuentra toda la funcionalidad del juego.
Cada clase controller gestiona sus animaciones

### PlayerController
En esta clase se controla el movimiento del personaje asi como su gestión de colisiones.
El movimiento se controla en el metodo update con una serie de comprovaciones segun la tecla pulsada.
En el caso de los movimientos laterales, se invierte el sprite en el eje x para girarlo.
En el caso del salto se comprueva que el jugador este encima de un solido.
Esta clase gestiona las acciones de ataque y bloqueo, que mandan una señal a los sensores.
Si el jugador es golpeado y no esta bloqueando pierde una vida.
Por ultimo si el personaje cae sobre pinchos o su vida llega a 0, se acaba la partida.

### EnemyController
En esta clase se controla el movimiento de los enemigos.
Al recibir una señal del sensor el enemigo se acercara al objetivo y girara su sprite segun la posicion..
Al colisionar con el objetivo lo atacara.
cada vez que lo atacan pierde una vida.
Si es atacado 2 veces muere.

### PlayerSensor
Esta clase permite golpear a los enemigos enfrente del jugador.
Atacara si hay un enemigo dentro del trigger y si el jugador ha enviado la accion atacar

### EnemySensor
Esta clase permite a los enemigos acercarse a su objetivo si este entra en el trigger

### Otras clases
Los otros scripts existentes en este proyecto son autoexplicativos

## How to Run

1. Open the project in Unity.
2. Open the main game scene located in `Assets/Scenes/`.
3. Press the Play button.

## Desarrolladores

Joan Lleonard Ruiz Albiñana

## Recursos de terceros
El diseño del personaje es propiedad de Sven Thole: https://assetstore.unity.com/packages/2d/characters/hero-knight-pixel-art-165188
Los Tiles y el background son propiedad de OOO Superposition Principle Inc.:https://assetstore.unity.com/packages/2d/environments/2d-pixel-art-platformer-biome-american-forest-255694
El goblin es propiedad de Luiz Melo: https://assetstore.unity.com/packages/2d/characters/monsters-creatures-fantasy-167949
La musica de fondo es propiedad de GuilhermeBernardes: https://pixabay.com/music/modern-classical-never-again-108445/
