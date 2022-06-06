# PEC4 - Zombie GTA
## Mel Aubets

En esta PEC, igual que en la anterior, se ha realizado un juego de zombis en tercera persona. Esta vez se ha utilizado el asset [Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526#publisher) para el controlador en tercera persona, de esta manera nuestro juego tendrá un movimiento más parecido al de ***GTA***. También se ha usado el asset [Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2018-4-32351#description) para el control de los vehículos.
Para implementar el juego se han creado algunos scripts nuevos y se han editado los existentes en los assets mencionados. Finalmente se ha modificado el _animator controller_ disponible en [Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526#publisher) para añadir las animaciones de muerte, reacción al golpe y disparo.

### Scripts:

Para esta PAC se han reutilizado scripts creados anteriormente con muy pocos cambios. Es el caso de los scripts de control de escena; **ExitGame**, **RestartGame** y **GameOver**, a los cuales se les ha añadido el script **ExitManager**, que carga la escena de Game Over al pulsar el boton ***Escape***. También se han conservado los scripts del enemigo; **EnemyAI**, **EnemyHealth** y **FieldOfView**. Estos últimos, además, se han reaprovechado para los scripts de los peatones; **WanderAI**, **WanderHealth** y **FieldOfView**.

En el script **WanderAI** encontramos una máquina de estados parecida a la de **EnemyAI**, la diferencia es que, en este caso, cuando el agente encuentre al objetivo saldrá corriendo en dirección contraria. Para que el agente priorice la acera a la carretera se han usado las capas de Navmesh y sus costes.

Al script **ThirdPersonController** disponible en [Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526#publisher) se le han añadido las funciones _Shoot()_ (Reutilizada de la PAC anterior, con un input _shoot_ añadido), _Steal()_; la función que cambia el controlador del personaje al juego, mediante un input llamado _steal_. Esta función convierte el jugador en hijo del coche y lo desactiva, de esta manera al cambiar el control de nuevo el jugador está en la posición adecuada. También cambia la cámara activa. Para controlar que esta función solo se ejecute cuando el jugador está cerca de un coche se han añadido las funciones _OnTriggerEnter(Collider other)_ y _OnTriggerExit(Collider other)_, estas modificarán el booleano correspondiente cuando el personaje colisione con el collider añadido a las puertas del coche.

Se han añadido las funciones correspondientes al script **StarterAssetsInputs** para poder llamar a las funciones explicadas anteriormente.

A **CarController**, dispoible en [Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2018-4-32351#description), se le han añadido las funciones _OnTriggerEnter(Collier other)_, para hacer desaparecer los coches al salir de la ciudad, y _OnCollisionEnter(Collision collision)_, para hacer desaparecer a los peatones y a los zombis a los que se atropelle. De esta misma familia también se ha editado el script **CarUserControl** para permitir el cambio de controles de coche a jugador.

Finalmente se ha creado el script **SpawningManager**, que recibe distintas _transforms_ para los coches, los peatones y los zombis. Utilizando las funciones _Start()_ y _Update()_ instancia los objetos correspondientes en el punto señalado. La condición para instanciar coches es que hayan pasado diez segundos, en cambio, la condición para instanciar zombis o peatones es que haya menos de una determinada cantidad de estos.

### Detalles finales:

Para que los peatones priorizen la acera frente al arcén se han utilizado las _Navmesh Layers_, asignando un coste de 2 a ir por la carretera. En cambio, los _Navmesh Agent_ enlazados a los zombis no tendrán en cuenta esta capa, ya que no deben priorizar ninguna zona caminable.

En esta PEC se han utilizado pocos tutoriales, en cambio, se ha usado mucho la documentación oficial de Unity y su foro.

### [Vídeo demostrativo](https://youtu.be/n5EQT_s7Yug)

### Assets Utilizados en esta PEC:
- [Toon Gas Station](https://assetstore.unity.com/packages/3d/environments/urban/toon-gas-station-155369)
- [Personajes y Animaciones](https://www.mixamo.com/)
- [Weapons Soldiers Sounds Pack](https://assetstore.unity.com/packages/audio/sound-fx/weapons/weapon-soldier-sounds-pack-29662)
- [Sci-Fi Weapons](https://devassets.com/assets/sci-fi-weapons/)
- [Standard Assets](https://assetstore.unity.com/packages/essentials/asset-packs/standard-assets-for-unity-2018-4-32351)
- [Unity Particle Pack 5.x](https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-5-x-73777)
- [Basic Metal 6 - Heavy Metal - Royalty Free Music](https://www.youtube.com/watch?v=azBtXTg4DQc&ab_channel=TeknoAXE%27sRoyaltyFreeMusic)
- [Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-third-person-character-controller-196526#publisher)
- [Vehicle Parking Lot Garage Gate PBR](https://assetstore.unity.com/packages/3d/environments/roadways/vehicle-parking-lot-garage-gate-pbr-111423#description)
- [CITY package](https://assetstore.unity.com/packages/3d/environments/urban/city-package-107224)

### Tutoriales utilizados en esta PEC:
- [Unity AI car - waypoints - Charlie Smith](https://www.youtube.com/watch?v=eAtEvUKKFEA&t=202s&ab_channel=CharlieSmith)
- [Nav Mesh Areas & Costs | Unity AI Pathfinding (Part 7) | Table Flip Games](https://www.youtube.com/watch?v=B3o_9JS6fOc&ab_channel=TableFlipGames)
- [Unity Starter Assets In-Depth Overview | 1st & 3rd Person Controller w/ Input System & Cinemachine - samyam](https://www.youtube.com/watch?v=CD0FlqllfIE&t=967s&ab_channel=samyam)