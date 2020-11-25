# Micrófono Y Cámara
### Sergio Guerra Arencibia - ULL - Interfaces Inteligentes

#### Micrófono  
Para el uso del micrófono dentro de nuestro proyecto Unity, lo primero que debemos de hacer es asginarle un componente "Audio Source" a un objeto vacío o a la cámara principal (dado que no existe ningún gameObject destinado al micrófono). Yo he optado por esta segunda opción.  

Posteriormente creamos sobre este objeto un script desde el cual manipularemos el componente recién mencionado. 
En este script vamos a comprobar gracias al método update si una tecla (en mi caso en espacio) ha sido pulsada. Si es así, comprobamos si estamos en un estado de grabación o no. En el caso de que no estemos grabando, comenzamos a grabar con el micrófono. En cambio, si estábamos grabando terminamos la grabación y la reproducimos.   

La instrucción principal y la que más explicación necesita es la de inicio de grabación, que es la siguiente:  

```c#
   audioSource.clip = Microphone.Start("", false, 15, 48000);
```  
Este método recibe cuatro parámetros. El primero de ellos es el micrófono que se usará en la grabación, al poner la cadena vacía escoge el micrófono asignado por defecto. El segundo es si la grabación se hará ciclica, opción que hemos desactivado. El tercero es la duración de la grabación y el último es la frecuencia con la que se trabajará que en mi caso concreto es 48000.  

El script queda de la siguiente forma:  
```c# 
   void Start() {
      audioSource = GetComponent<AudioSource>();
   }
    
   void Update() {
      if (Input.GetKeyDown("space")) {
        if (!Microphone.IsRecording(""))
          audioSource.clip = Microphone.Start("", false, 15, 48000);
        else {
          Microphone.End("");
          audioSource.Play();
        }
      }
    }
```  


#### Cámara  
Para el uso de la cámara dentro de nuestro proyecto Unity todo lo que debemos hacer es modificar la textura de un GameObject y añadir una textura que mostrará lo que se capte por la cámara.  
En este caso yo he optado por construir un GameObject plano, similar a una pantalla, y proyectar en él lo que se capture por la cámara. Así que lo primero es añadir a este elemento un script que realizará esta tarea.  

Similar a lo que se hizo con el micrófono, estaremos comprobando en el método update si una tecla es pulsada (en este caso la tecla "v"). Si es pulsada, comprobamos si ya se está grabando con la cámara. En caso negativo, colocamos la textura de la cámara al componente Renderer del objeto y comenzamos a grabar.
En caso de que ya estemos grabando, restauramos la textura del objeto a la que tenía inicialmente (si no la restauráramos, se quedaría la última imagen congelada) y paramos de grabar.  
  
El script queda de la siguiente forma:   

```c#
   void Start() {
      renderer = GetComponent<Renderer>();
      defaultTexture = renderer.material.mainTexture;
      webcamTexture = new WebCamTexture("HD WebCam");
   }
   
   void Update() {
      if (Input.GetKey("v")) {
        if (!webcamTexture.isPlaying) {
          renderer.material.mainTexture = webcamTexture;
          webcamTexture.Play();
        } else {
          webcamTexture.Stop();
          renderer.material.mainTexture = defaultTexture;
      }
    }

```  

###### Ejemplo de uso de la cámara  
En el siguiente gif se ve la funcionalidad implementada de la cámara.  
Cuando se pulsa la tecla "v" sea activa la cámara. Y cuando se vuelve a pulsar se detiene la grabación y se restaura la textura inicial.  

![alt_text](https://github.com/ULL-GII-InterfacesII/MicrofonoYCamara-Alu0101133201/blob/main/camara.gif)
